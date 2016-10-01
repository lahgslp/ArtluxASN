using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Configuration;
using FirebirdSql.Data.FirebirdClient;


namespace GeneradorASN.DAL
{
    public class DBManager
    {
       

        static public List< List<RANDBData> > ObtenerRANs(DateTime fechaInicio, DateTime fechaFinal)
        {
            string CadenaConexion = ConfigurationManager.ConnectionStrings["ArtluxSAE"].ToString();
            string Num_Empresa = ConfigurationManager.AppSettings["NumEmpresaSAE"];
            string Clientes = ConfigurationManager.AppSettings["ClaveCliente"];
            List<List<RANDBData>> data = new List<List<RANDBData>>();
            
            FbCommand fbComando = new FbCommand("", new FbConnection(CadenaConexion));
            FbDataAdapter fbDataAdaptador = new FbDataAdapter();
            DataTable dtRANS = new DataTable();
            string Texto_sql = "";

            Texto_sql += " SELECT  Ped.TIP_DOC, Ped.CVE_DOC,Ped.CVE_CLPV, Ped.STATUS, Ped.FECHA_DOC,Par.CVE_OBS RAN, Rans.STR_OBS strRAN";
            Texto_sql += "     ,Ped.FECHA_VEN,Ped.FECHA_ENT,Par.CVE_ART,Par.CANT";
            Texto_sql += " FROM FACTP" + Num_Empresa + " Ped";
            Texto_sql += "     inner join PAR_FACTP" + Num_Empresa + " Par on Ped.CVE_DOC = Par.CVE_DOC";
            Texto_sql += "     left join OBS_DOCF" + Num_Empresa + " Rans on Par.cve_obs = Rans.CVE_OBS";
            Texto_sql += " WHERE status = 'E' and Ped.CVE_CLPV in ('"+Clientes +"')";
            //Texto_sql += "     and fecha_ven between CAST('"+fechaInicio.ToString("dd.MM.yyyy")  +"' AS DATE) and CAST('"+fechaFinal.ToString("dd.MM.yyyy")  +"' AS DATE)";
            Texto_sql += "     and fecha_doc between @FechaIni and @FechaFin ";
            Texto_sql += "     and coalesce(dat_envio,0) <> 0";
            Texto_sql += " order by fecha_doc";
            
            fbComando.CommandText = Texto_sql;
            fbComando.Parameters.AddWithValue("@FechaIni", fechaInicio);
            fbComando.Parameters.AddWithValue("@FechaFin", fechaFinal);
           
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
                        Datos.Cantidad = (int)drRAN["CANT"];

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
