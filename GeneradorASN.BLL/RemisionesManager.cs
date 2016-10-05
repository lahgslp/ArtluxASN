using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneradorASN.Entities;
using GeneradorASN.DAL;
using System.Collections;


namespace GeneradorASN.BLL
{
    public class RemisionesManager
    {
        //Comentando temporalmente para que no truene durante los cambios al RANDataset
        static public RemisionesDataSet ObtenerRemisiones(DatosFiltro filtros)
        {
            RemisionesDataSet ds = new RemisionesDataSet();
            RemisionesDataSet.RemisionesDataTableRow row = ds.RemisionesDataTable.NewRemisionesDataTableRow();
            row.FolioRemision = "0001";
            row.CantidadTotal = 100.2;
            row.PartidasTotales = 56;
            row.PesoTotal = 4565.56;
            row.FechaDocumento = DateTime.Now;
            row.FechaEntrega = DateTime.Now.AddDays(2);
            row.ListaRANs = "P4565D,P4566D,P4567D";
            ds.RemisionesDataTable.Rows.Add(row);
            /*          

                        RANDataSet ds = new RANDataSet();
                        Hashtable PesosArticulo = CargadorXMLPesosNissan.ObtenerPesos();  

                        List<List<RANDBData>> ransFromDB = DBManager.ObtenerRANs(fechaInicio, fechaFinal);
                        foreach (List<RANDBData> ListOfRans in ransFromDB)
                        {
                            foreach (RANDBData ran in ListOfRans)
                            {
                                RANDataSet.RANDataTableRow row = ds.RANDataTable.NewRANDataTableRow();
                                MedidasArticulo MedidaArticulo = (MedidasArticulo)PesosArticulo[ran.ClaveProducto]; 
                                row.RAN = ran.RAN;
                                row.Remision = ran.Remision;
                                row.FechaCreacion = ran.FechaCreacion;
                                row.Cantidad = ran.Cantidad;
                                row.ClaveProducto = ran.ClaveProducto;
                                row.FechaEnvio = ran.FechaEnvio;
                                row.PesoBruto = (ran.Cantidad / MedidaArticulo.PiezasXcaja) * MedidaArticulo.Peso; //Es la cantidad individual por ran o por la cantidad total?
                                row.NumeroDePartidas = ListOfRans.Count();
                                row.CantidadTotalRemision = ran.CantidadTotal;
                                ds.RANDataTable.Rows.Add(row);
                            }
                        }
*/
            return ds;
        }
    }
}
