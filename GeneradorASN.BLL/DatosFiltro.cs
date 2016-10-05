using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorASN.BLL
{
    public enum TipoFiltro
    {
        Fecha,
        Folios
    }

    public class DatosFiltro
    {
        public TipoFiltro Filtro { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Folios { get; set; }
    }
}
