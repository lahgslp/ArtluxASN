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
        static public RemisionesDataSet ObtenerRemisiones(DatosFiltro filtros, Registrador.IRegistroEjecucion registrador)
        {
            RemisionesDataSet ds = new RemisionesDataSet();
            string CveDoc = "";
            string RAN = "";

            //string claves = "";
            //string clavesAlternas = "";
            try
            {
                bool PorFechas = filtros.Filtro == TipoFiltro.Fecha; //Determina si es por fechas el filtro  
                Hashtable PesosArticulo = CargadorXMLPesosNissan.ObtenerPesos();
                List<List<RANDBData>> ListaRemisiones = null;

                if (PorFechas)
                {
                    ListaRemisiones = DBManager.ObtenerRemisiones(filtros.FechaInicio, filtros.FechaFinal, registrador);
                    //ListaRemisiones = DBManager.ObtenerRemisiones(new DateTime(2017,08,01) , new DateTime(2018, 10, 30));
                }
                else
                {
                    ListaRemisiones = DBManager.ObtenerRemisiones(filtros.Folios, registrador);
                    //ListaRemisiones = DBManager.ObtenerRemisiones("2888,123abc,2942,2b#^--12,3003,ab123");
                }

                foreach (List<RANDBData> ListaDeRANs in ListaRemisiones)
                {
                    RemisionesDataSet.RemisionesDataTableRow rowRemision = ds.RemisionesDataTable.NewRemisionesDataTableRow();
                    string strListaRANs = "";
                    float PesoTotal = 0;

                    CveDoc = ListaDeRANs[0].Remision;
                    rowRemision.FolioRemision = ListaDeRANs[0].Remision;
                    rowRemision.CantidadTotal = ListaDeRANs[0].CantidadTotal;
                    rowRemision.PartidasTotales = ListaDeRANs.Count;
                    rowRemision.FechaDocumento = ListaDeRANs[0].FechaCreacion;
                    rowRemision.FechaEntrega = ListaDeRANs[0].FechaEnvio;
                    rowRemision.ClaveCliente = ListaDeRANs[0].ClaveCliente;
                    rowRemision.NombreCliente = ListaDeRANs[0].NombreCliente;

                    ds.RemisionesDataTable.Rows.Add(rowRemision);

                    foreach (RANDBData ran in ListaDeRANs)
                    {
                        float PesoPartida = 0;
                        RemisionesDataSet.PartidasDataTableRow rowPartida = ds.PartidasDataTable.NewPartidasDataTableRow();
                        MedidasArticulo MedidaArticulo = new MedidasArticulo();

                        //if (ran.ClaveProducto.Substring(0, 5) != "NIMEX" && ran.ClaveProductoAlterna.Substring(0, 5) != "NIMEX")
                        //{
                        //    claves = claves + ran.ClaveProducto + ",";
                        //    clavesAlternas = clavesAlternas + ran.ClaveProductoAlterna + ",";
                        //}

                        if (ran.ClaveProducto.Substring(0, 5) == "NIMEX")
                        {
                            MedidaArticulo = (MedidasArticulo)PesosArticulo[ran.ClaveProducto];
                        }
                        else
                        {
                            MedidaArticulo = (MedidasArticulo)PesosArticulo[ran.ClaveProductoAlterna];
                        }

                        RAN = ran.RAN;
                        if (MedidaArticulo == null)
                        {
                            registrador.RegistrarAdvertencia("No se encontro el articulo '" + ran.ClaveProducto + "' dentro del archivo de pesos.");
                        }
                        else
                        {
                            PesoPartida = (float)(ran.Cantidad / MedidaArticulo.PiezasXcaja * MedidaArticulo.Peso);
                        }

                        rowPartida.FolioRemision = ran.Remision;
                        rowPartida.ClaveProducto = ran.ClaveProducto;
                        rowPartida.CantidadPartida = ran.Cantidad;
                        rowPartida.PesoPartida = PesoPartida;
                        rowPartida.RAN = ran.RAN;
                        rowPartida.ClaveProductoAlterna = ran.ClaveProductoAlterna;

                        PesoTotal += PesoPartida;
                        ds.PartidasDataTable.Rows.Add(rowPartida);

                        strListaRANs += "," + ran.RAN;

                        if (string.IsNullOrEmpty(ran.RAN.Trim()))
                        {
                            registrador.RegistrarAdvertencia("No se encontro RAN para la clave de remisión '" + ran.Remision + "' con clave de articulo '" + ran.ClaveProducto + "'.");
                        }
                        if (string.IsNullOrEmpty(ran.ClaveProductoAlterna.Trim()))
                        {
                            registrador.RegistrarAdvertencia("No se encontro 'Clave Alterna' para la clave de producto '" + ran.ClaveProducto + "'.");
                        }
                    }
                    rowRemision.ListaRANs = strListaRANs.Trim().Length > 1 ? strListaRANs.Substring(1) : "";
                    rowRemision.PesoTotal = Convert.ToInt32(Math.Round(PesoTotal));
                }

            }
            catch (Exception ex)
            {
                registrador.RegistrarError("Ocurrio un error desconocido al procesar la remisión '" + CveDoc + "' con RAN '" + RAN + "'. Detalles '" + ex.Message + "'");
            }

            return ds;
        }
    }
}
