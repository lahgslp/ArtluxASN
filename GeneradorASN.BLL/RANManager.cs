using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneradorASN.Entities;
using GeneradorASN.DAL;

namespace GeneradorASN.BLL
{
    public class RANManager
    {
        static public RANDataSet ObtenerRANs(DateTime fechaInicio, DateTime fechaFinal)
        {
            RANDataSet ds = new RANDataSet();

            List<RANDBData> ransFromDB = DBManager.ObtenerRANs(fechaInicio, fechaFinal);

            foreach (RANDBData ran in ransFromDB)
            {
                RANDataSet.RANDataTableRow row = ds.RANDataTable.NewRANDataTableRow();
                row.RAN = ran.RAN;
                ds.RANDataTable.Rows.Add(row);
            }

            return ds;
        }
    }
}
