﻿using System;
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
            try
            {
                bool PorFechas = filtros.Filtro == TipoFiltro.Fecha; //Determina si es por fechas el filtro  
                Hashtable PesosArticulo = CargadorXMLPesosNissan.ObtenerPesos();
                List<List<RANDBData>> ListaRemisiones = null;

                if (PorFechas)
                {
                    ListaRemisiones = DBManager.ObtenerRemisiones(filtros.FechaInicio, filtros.FechaFinal);
                    //ListaRemisiones = DBManager.ObtenerRemisiones(new DateTime(2016,06,01) , new DateTime(2016, 10, 30));
                }
                else
                {
                    ListaRemisiones = DBManager.ObtenerRemisiones(filtros.Folios);
                    //ListaRemisiones = DBManager.ObtenerRemisiones("2888,123abc,2942,#^--12,3003,ab123");
                }
                               
                foreach (List<RANDBData> ListaDeRANs in ListaRemisiones)
                {
                    RemisionesDataSet.RemisionesDataTableRow rowRemision = ds.RemisionesDataTable.NewRemisionesDataTableRow();
                    string strListaRANs = "";
                    double PesoTotal = 0;
                    rowRemision.FolioRemision = ListaDeRANs[0].Remision;
                    rowRemision.CantidadTotal = ListaDeRANs[0].CantidadTotal;
                    rowRemision.PartidasTotales = ListaDeRANs.Count;
                    rowRemision.FechaDocumento = ListaDeRANs[0].FechaCreacion;
                    rowRemision.FechaEntrega = ListaDeRANs[0].FechaEnvio;
                    ds.RemisionesDataTable.Rows.Add(rowRemision);

                    foreach (RANDBData ran in ListaDeRANs)
                    {
                        RemisionesDataSet.PartidasDataTableRow rowPartida = ds.PartidasDataTable.NewPartidasDataTableRow();
                        MedidasArticulo MedidaArticulo = (MedidasArticulo)PesosArticulo[ran.ClaveProducto];
                        rowPartida.FolioRemision = ran.Remision;
                        rowPartida.ClaveProducto = ran.ClaveProducto;
                        rowPartida.CantidadPartida = ran.Cantidad;
                        rowPartida.PesoPartida = (Double)((ran.Cantidad / MedidaArticulo.PiezasXcaja) * MedidaArticulo.Peso);
                        rowPartida.RAN = ran.RAN;

                        PesoTotal += rowPartida.PesoPartida;
                        ds.PartidasDataTable.Rows.Add(rowPartida);

                        strListaRANs += "," + ran.RAN;

                        if (string.IsNullOrEmpty(ran.RAN.Trim())) {
                            //send a warning
                        }
                    }
                    rowRemision.ListaRANs = strListaRANs.Trim().Length > 1 ? strListaRANs.Substring(1) : "";
                    rowRemision.PesoTotal = PesoTotal;
                }

                return ds;
            }
            catch (Exception ex) {
                //send a error
            }

            return ds;
        }
    }
}