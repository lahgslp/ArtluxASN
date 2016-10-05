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
        static public List<List<RANDBData>> ObtenerRemisiones(DateTime fechaInicio, DateTime fechaFinal) {
            return DBManager.ObtenerRemisiones(true, fechaInicio, fechaFinal, ""); 
        }

        static public List<List<RANDBData>> ObtenerRemisiones(string Claves)
        {
            
            string []arrayClaves = Claves.Split(',');
            string ClavesNormalizadas = ""; 

            foreach (string clave in arrayClaves) {
                string tmpclave = clave.Trim();
                if (!string.IsNullOrEmpty(tmpclave)) {
                    Regex EsAlfanumerico = new Regex("[^a-zA-Z0-9]");
                    if (!EsAlfanumerico.IsMatch(tmpclave)) {
                        ClavesNormalizadas += ",'" + tmpclave+"'";
                    }
                }
            }

            if (ClavesNormalizadas.Length > 0)
            {
                ClavesNormalizadas = ClavesNormalizadas.Substring(1);  
                return DBManager.ObtenerRemisiones(false, DateTime.Now, DateTime.Now, ClavesNormalizadas);
            }
            else {
                throw new Exception("No existen folios de remision validos");
            }
           
        }

        static private List< List<RANDBData> > ObtenerRemisiones(bool PorFechas, DateTime fechaInicio, DateTime fechaFinal,string Claves)
        {
            string CadenaConexion = ConfigurationManager.ConnectionStrings["ArtluxSAE"].ToString();
            string Num_Empresa = ConfigurationManager.AppSettings["NumEmpresaSAE"];
            string Clientes = ConfigurationManager.AppSettings["ClaveCliente"];
            List<List<RANDBData>> data = new List<List<RANDBData>>();
            
            FbCommand fbComando = new FbCommand("", new FbConnection(CadenaConexion));
            FbDataAdapter fbDataAdaptador = new FbDataAdapter();
            DataTable dtRANS = new DataTable();
            string Texto_sql = "";
            
            Texto_sql += " SELECT rem.TIP_DOC,rem.CVE_DOC,rem.CVE_CLPV, rem.STATUS, rem.FECHA_DOC,Par.CVE_OBS RAN, Rans.STR_OBS STR_RAN";
            Texto_sql += "     ,rem.FECHA_VEN,rem.FECHA_ENT,Par.CVE_ART,Par.CANT,rem.DAT_ENVIO";
            Texto_sql += " FROM FACTR" + Num_Empresa + " Rem";
            Texto_sql += "     inner join Par_Factr" + Num_Empresa + " Par on rem.CVE_DOC = Par.CVE_DOC";
            Texto_sql += "     left join OBS_DOCF" + Num_Empresa + " Rans on Par.cve_obs = Rans.CVE_OBS";
            Texto_sql += "     inner join INFENVIO" + Num_Empresa + " envio on rem.DAT_ENVIO = envio.CVE_INFO";
            //Texto_sql += " WHERE status = 'E' and rem.CVE_CLPV in ('" + Clientes + "')";
            Texto_sql += " WHERE rem.CVE_CLPV in ('" + Clientes + "')";

            if (PorFechas)
            {
                Texto_sql += "     and fecha_doc between @FechaIni and @FechaFin ";
                fbComando.Parameters.AddWithValue("@FechaIni", fechaInicio);
                fbComando.Parameters.AddWithValue("@FechaFin", fechaFinal);
            }
            else {
                Texto_sql += "     and trim(rem.CVE_DOC) in (" + Claves + ")";
            }
            
            Texto_sql += "     and coalesce(dat_envio,0) <> 0";
            Texto_sql += "     and char_length(trim(coalesce(envio.CALLE,''))) <> 0";
            Texto_sql += " order by fecha_doc";

            fbComando.CommandText = Texto_sql;                      
            fbDataAdaptador.SelectCommand = fbComando;
            fbDataAdaptador.Fill(dtRANS);

            if (dtRANS != null && dtRANS.Rows.Count > 0) {
                //Se filtran los diferentes 'Claves de Documentos' <Pedidos>
                DataTable dtPedidos = dtRANS.DefaultView.ToTable(true,new string[] { "CVE_DOC" });
                foreach (DataRow drPedido in dtPedidos.Rows)
                {
                    int CantidadTotal = 0;
                    List<RANDBData> ListaDeRANS = new List<RANDBData>();
                    //Se filtran solo los RANs de un Pedido con 'Clave de Documento' <CVE_DOC>
                    DataRow[] RANsDePedido = dtRANS.Select("CVE_DOC = " + drPedido["CVE_DOC"].ToString ()) ; 
                    foreach (DataRow drRAN in RANsDePedido)
                    {
                        RANDBData Datos = new RANDBData();
                       
                        Datos.RAN = drRAN["RAN"].ToString();
                        Datos.Remision = drRAN["CVE_DOC"].ToString();
                        Datos.FechaCreacion = (DateTime)drRAN["FECHA_VEN"];
                        Datos.FechaEnvio = (DateTime)drRAN["FECHA_ENT"];
                        Datos.ClaveProducto = drRAN["CVE_ART"].ToString();
                        Datos.Cantidad = Convert.ToInt32(drRAN["CANT"]);

                        CantidadTotal += Datos.Cantidad;
                          
                        ListaDeRANS.Add(Datos);
                    }

                    foreach (RANDBData ran in ListaDeRANS) {
                        ran.CantidadTotal = CantidadTotal;
                    }

                    data.Add(ListaDeRANS);
                }
            }
                        
            return data;
        }
    }
}
