using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorASN.DAL
{
    public class RANDBData
    {
        public string RAN { get; set; }
        public string Remision { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string ClaveProducto { get; set; }
        public int Cantidad { get; set; }
        public int CantidadTotal { get; set; }
        public string ClaveCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ClaveProductoAlterna { get; set; }
   }
}
