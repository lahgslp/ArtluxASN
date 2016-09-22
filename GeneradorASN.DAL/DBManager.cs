using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorASN.DAL
{
    public class DBManager
    {
        static public List<RANDBData> ObtenerRANs(DateTime fechaInicio, DateTime fechaFinal)
        {
            List<RANDBData> data = new List<RANDBData>();

            RANDBData datosFalsos = new RANDBData();
            datosFalsos.RAN = "AquiNomasProbando";

            data.Add(datosFalsos);
            return data;
        }
    }
}
