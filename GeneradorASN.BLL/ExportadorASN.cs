using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorASN.BLL
{
    public class ExportadorASN
    {
        static public int ExportarRemisiones(string ruta, List<string> folios, GeneradorASN.Entities.RemisionesDataSet Remisiones, Registrador.IRegistroEjecucion registrador)
        {
            foreach (GeneradorASN.Entities.RemisionesDataSet.RemisionesDataTableRow remision in Remisiones.RemisionesDataTable.Rows)
            {
                if (folios.IndexOf(remision["FolioRemision"].ToString()) >= 0)
                {
                    Exportar(ruta, remision["FolioRemision"].ToString(), Remisiones, registrador);
                }
            }
            return 0;
        }

        static public int Exportar(string ruta, string folio, GeneradorASN.Entities.RemisionesDataSet Remisiones, Registrador.IRegistroEjecucion registrador)
        {
            return 0;
        }
    }
}
