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
       

        static public List<RANDBData> ObtenerRANs(DateTime fechaInicio, DateTime fechaFinal)
        {
            string CadenaConexion = ConfigurationManager.ConnectionStrings["ArtluxSAE"].ToString();
            string Num_Empresa = ConfigurationManager.AppSettings["NumEmpresaSAE"];
            List<RANDBData> data = new List<RANDBData>();
            
            FbCommand fbComando = new FbCommand("", new FbConnection(CadenaConexion));
            FbDataAdapter fbDataAdaptador = new FbDataAdapter();
            DataTable dtRANS = new DataTable();
            string Texto_sql = "";

            Texto_sql += " SELECT  Ped.TIP_DOC, Ped.CVE_DOC,Ped.CVE_CLPV, Ped.STATUS, Ped.FECHA_DOC,Par.CVE_OBS RAN, Rans.STR_OBS strRAN";
            Texto_sql += "     ,Ped.FECHA_VEN,Ped.FECHA_ENT,Par.CVE_ART,Par.CANT";
            Texto_sql += " FROM FACTP" + Num_Empresa + " Ped";
            Texto_sql += "     inner join PAR_FACTP" + Num_Empresa + " Par on Ped.CVE_DOC = Par.CVE_DOC";
            Texto_sql += "     left join OBS_DOCF" + Num_Empresa + " Rans on Par.cve_obs = Rans.CVE_OBS";
            Texto_sql += " WHERE status = 'E'";
            //Texto_sql += "     and fecha_ven between CAST('"+fechaInicio.ToString("dd.MM.yyyy")  +"' AS DATE) and CAST('"+fechaFinal.ToString("dd.MM.yyyy")  +"' AS DATE)";
            Texto_sql += "     and fecha_ven between @FechaIni and @FechaFin ";
            Texto_sql += " order by fecha_ven";
            
            fbComando.CommandText = Texto_sql;
            fbComando.Parameters.AddWithValue("@FechaIni", fechaInicio);
            fbComando.Parameters.AddWithValue("@FechaFin", fechaFinal);
           
            fbDataAdaptador.SelectCommand = fbComando;
            fbDataAdaptador.Fill(dtRANS);

            if (dtRANS != null && dtRANS.Rows.Count > 0) {
                foreach( DataRow dRow in dtRANS.Rows ) {
                    RANDBData Datos = new RANDBData();
                    Datos.RAN = dRow["RAN"].ToString();
                    Datos.Remision  = dRow["CVE_DOC"].ToString();
                    Datos.FechaCreacion = (DateTime)dRow["FECHA_VEN"];
                    Datos.FechaEnvio = (DateTime)dRow["FECHA_ENT"];
                    Datos.ClaveProducto = dRow["CVE_ART"].ToString();
                    Datos.Cantidad = (int)dRow["CANT"];
                    Datos.CantidadTotal = (int)dRow["CANT"];

                    data.Add(Datos);
                }
            }
                        
            return data;
        }
    }
}
