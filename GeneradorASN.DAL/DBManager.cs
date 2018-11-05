using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Configuration;
using FirebirdSql.Data.FirebirdClient;
using System.Text.RegularExpressions;

namespace GeneradorASN.DAL
{
    public class DBManager
    {
        static public List<List<RANDBData>> ObtenerRemisiones(DateTime fechaInicio, DateTime fechaFinal, Registrador.IRegistroEjecucion registrador) {
            return DBManager.ObtenerRemisiones(true, fechaInicio, fechaFinal, "", registrador); 
        }

        static public List<List<RANDBData>> ObtenerRemisiones(string Claves, Registrador.IRegistroEjecucion registrador)
        {
            string ClavesNormalizadas = DBManager.ProcesaClavesAlfaNumericas(Claves); 
            if (ClavesNormalizadas.Length > 0)
            {
                return DBManager.ObtenerRemisiones(false, DateTime.Now, DateTime.Now, ClavesNormalizadas, registrador);
            }
            else {
                throw new Exception("No existen folios de remision validos");
            }
           
        }

       static private string ProcesaClavesAlfaNumericas(string Claves) {
            string[] arrayClaves = Claves.Split(',');
            string ClavesNormalizadas = "";

            foreach (string clave in arrayClaves)
            {
                string tmpclave = clave.Trim();
                if (!string.IsNullOrEmpty(tmpclave))
                {
                    Regex EsAlfanumerico = new Regex("[^a-zA-Z0-9]");
                    if (!EsAlfanumerico.IsMatch(tmpclave))
                    {
                        ClavesNormalizadas += ",'" + tmpclave + "'";
                    }
                }
            }

            if (ClavesNormalizadas.Length > 0)
            {
                ClavesNormalizadas = ClavesNormalizadas.Substring(1);
            }
         

            return ClavesNormalizadas;
        }

        static private List< List<RANDBData> > ObtenerRemisiones(bool PorFechas, DateTime fechaInicio, DateTime fechaFinal,string Claves, Registrador.IRegistroEjecucion registrador)
        {
            string CadenaConexion = ConfigurationManager.ConnectionStrings["ArtluxSAE"].ToString();
            string Num_Empresa = ConfigurationManager.AppSettings["NumEmpresaSAE"];
            string Clientes = DBManager.ProcesaClavesAlfaNumericas(ConfigurationManager.AppSettings["ClaveCliente"]);
            List<List<RANDBData>> data = new List<List<RANDBData>>();
                      
            FbCommand fbComando = new FbCommand("", new FbConnection(CadenaConexion));
            FbDataAdapter fbDataAdaptador = new FbDataAdapter();
            DataTable dtRANS = new DataTable();
            string Texto_sql = "";

            if (Clientes.Length <= 0)
            {
                throw new Exception("La clave o claves de cliente dadas, no son validas.");
            }

            Texto_sql += " SELECT rem.TIP_DOC,rem.CVE_DOC,rem.CVE_CLPV,cliente.NOMBRE, rem.STATUS, rem.FECHA_DOC,Par.CVE_OBS RAN, Rans.STR_OBS STR_RAN";
            Texto_sql += "     ,rem.FECHA_VEN,rem.FECHA_ENT,Par.CVE_ART,Par.CANT,rem.DAT_ENVIO,coalesce(alternas.CVE_ALTER,'') CVE_ALTER ";
            Texto_sql += " FROM FACTR" + Num_Empresa + " Rem";
            Texto_sql += "     inner join Par_Factr" + Num_Empresa + " Par on rem.CVE_DOC = Par.CVE_DOC";
            Texto_sql += "     left join OBS_DOCF" + Num_Empresa + " Rans on Par.cve_obs = Rans.CVE_OBS";
            Texto_sql += "     inner join INFENVIO" + Num_Empresa + " envio on rem.DAT_ENVIO = envio.CVE_INFO";
            Texto_sql += "     left join CLIE" + Num_Empresa + " cliente on rem.CVE_CLPV = cliente.CLAVE";
            Texto_sql += "     left join CVES_ALTER" + Num_Empresa + " alternas on Par.CVE_ART = alternas.CVE_ART";
            //Texto_sql += " WHERE status = 'E' and rem.CVE_CLPV in ('" + Clientes + "')";
            Texto_sql += " WHERE rem.STATUS NOT IN ('C') AND rem.CVE_CLPV in (" + Clientes + ")";

            if (PorFechas)
            {
                Texto_sql += "     and fecha_doc between @FechaIni and @FechaFin ";
                fbComando.Parameters.AddWithValue("@FechaIni", fechaInicio);
                fbComando.Parameters.AddWithValue("@FechaFin", fechaFinal);
            }
            else
            {
                Texto_sql += "     and trim(rem.CVE_DOC) in (" + Claves + ")";
            }

            Texto_sql += "     and coalesce(dat_envio,0) <> 0";
            Texto_sql += "     and char_length(trim(coalesce(envio.CALLE,''))) <> 0";
            Texto_sql += " order by fecha_doc";
            try
            {
                fbComando.CommandText = Texto_sql;
                fbDataAdaptador.SelectCommand = fbComando;
                fbDataAdaptador.Fill(dtRANS);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            

            if (dtRANS != null && dtRANS.Rows.Count > 0) {
                //Se filtran los diferentes 'Claves de Documentos' <Pedidos>
                //registrador.Registrar("TEMP: Antes de dtRANS.DefaultView.ToTable");
                DataTable dtPedidos = dtRANS.DefaultView.ToTable(true,new string[] { "CVE_DOC" });
                //registrador.Registrar("TEMP: Desp de dtRANS.DefaultView.ToTable: " + dtPedidos.Rows.Count);
                foreach (DataRow drPedido in dtPedidos.Rows)
                {
                    if (drPedido["CVE_DOC"].ToString().Trim().All(char.IsDigit))   //Si todos son numeros 0-9
                    {
                        int CantidadTotal = 0;
                        List<RANDBData> ListaDeRANS = new List<RANDBData>();
                        //Se filtran solo los RANs de un Pedido con 'Clave de Documento' <CVE_DOC>
                        //registrador.Registrar("TEMP: Empezando a procesar '" + drPedido["CVE_DOC"].ToString() + "'");
                        DataRow[] RANsDePedido = dtRANS.Select("CVE_DOC = '" + drPedido["CVE_DOC"].ToString() + "'");
                        foreach (DataRow drRAN in RANsDePedido)
                        {
                            RANDBData Datos = new RANDBData();

                            Datos.RAN = drRAN["STR_RAN"].ToString();
                            Datos.Remision = drRAN["CVE_DOC"].ToString().Trim();
                            Datos.FechaCreacion = (DateTime)drRAN["FECHA_VEN"];
                            Datos.FechaEnvio = (DateTime)drRAN["FECHA_ENT"];
                            Datos.ClaveProducto = drRAN["CVE_ART"].ToString();
                            Datos.Cantidad = Convert.ToInt32(drRAN["CANT"]);
                            Datos.ClaveCliente = drRAN["CVE_CLPV"].ToString();
                            Datos.NombreCliente = drRAN["NOMBRE"].ToString();
                            Datos.ClaveProductoAlterna = drRAN["CVE_ALTER"].ToString();

                            CantidadTotal += Datos.Cantidad;

                            ListaDeRANS.Add(Datos);
                        }

                        foreach (RANDBData ran in ListaDeRANS)
                        {
                            ran.CantidadTotal = CantidadTotal;
                        }
                        //registrador.Registrar("TEMP: Encontrado con numeros" + drPedido["CVE_DOC"].ToString());
                        data.Add(ListaDeRANS);
                    }
                    else
                    {
                        //registrador.Registrar("TEMP: Encontrado con letra " + drPedido["CVE_DOC"].ToString());
                    }
                }
            }
            //registrador.Registrar("TEMP: Para mostrar " + data.Count);

            return data;
        }
    }
}
