﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorASN.BLL
{
    public class ExportadorASN
    {
        //static public int ExportarRemisiones(string ruta, List<string> folios, GeneradorASN.Entities.RemisionesDataSet Remisiones, Registrador.IRegistroEjecucion registrador)
        //{
        //    foreach (GeneradorASN.Entities.RemisionesDataSet.RemisionesDataTableRow remision in Remisiones.RemisionesDataTable.Rows)
        //    {
        //        if (folios.IndexOf(remision.FolioRemision) >= 0)
        //        {
        //            Exportar(ruta, remision, Remisiones, registrador);
        //        }
        //    }
        //    return 0;
        //}
        static public int ExportarRemisiones(string ruta, List<string> folios, GeneradorASN.Entities.RemisionesDataSet Remisiones, Registrador.IRegistroEjecucion registrador)
        {            
            Exportar(ruta, folios, Remisiones, registrador);            
            return 0;
        }

        static public int Exportar(string ruta, List<string> folios, GeneradorASN.Entities.RemisionesDataSet Remisiones, Registrador.IRegistroEjecucion registrador)
        {
            //char[] charsToTrim = { ':', '/', ' ' };            
            string month = DateTime.Now.Month >= 10 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month;
            string day = DateTime.Now.Day >= 10 ? DateTime.Now.Day.ToString() : "0" + DateTime.Now.Day;
            int fileNumber = 0;
            string fileEnd = "00.txt";

            double candidadTotalProducto = 0;
            string archivo = ruta + "\\" + "ASN" + DateTime.Now.Year + month + day;

            while (System.IO.File.Exists(archivo + fileEnd))
            {
                fileNumber++;
                if (fileNumber < 10)
                {
                    fileEnd = "0" + fileNumber + ".txt";
                }
                else
                {
                    fileEnd = fileNumber + ".txt";
                }
            }
            archivo = archivo + fileEnd;

            using (System.IO.StreamWriter archivoASN = System.IO.File.CreateText(archivo))
            {
                List<string> productosProcesados = new List<string>();
                int ContadorDT1 = 2;

                //Firma inicial
                //archivoASN.WriteLine(":N:");

                foreach (GeneradorASN.Entities.RemisionesDataSet.RemisionesDataTableRow remision in Remisiones.RemisionesDataTable.Rows)
                {
                    if (folios.IndexOf(remision.FolioRemision) >= 0)
                    {
                        archivoASN.WriteLine(":NISSANPRODGXS:");
                        archivoASN.WriteLine(GenerarHeader(remision));
                        foreach (GeneradorASN.Entities.RemisionesDataSet.PartidasDataTableRow partidaProductos in Remisiones.PartidasDataTable.Rows)
                        {
                            if (remision.FolioRemision == partidaProductos.FolioRemision)
                            {
                                if (productosProcesados.IndexOf(partidaProductos.ClaveProducto) < 0)
                                {
                                    List<GeneradorASN.Entities.RemisionesDataSet.PartidasDataTableRow> lineasDT2 = new List<GeneradorASN.Entities.RemisionesDataSet.PartidasDataTableRow>();
                                    candidadTotalProducto = 0;

                                    foreach (GeneradorASN.Entities.RemisionesDataSet.PartidasDataTableRow partidaDetalles in Remisiones.PartidasDataTable.Rows)
                                    {
                                        if (remision.FolioRemision == partidaDetalles.FolioRemision && partidaProductos.ClaveProducto == partidaDetalles.ClaveProducto)
                                        {
                                            candidadTotalProducto += partidaDetalles.CantidadPartida;
                                            lineasDT2.Add(partidaDetalles);
                                        }
                                    }
                                    productosProcesados.Add(partidaProductos.ClaveProducto);
                                    archivoASN.WriteLine(GenerarDT1(remision, partidaProductos, Remisiones, ContadorDT1, candidadTotalProducto));
                                    ContadorDT1++;
                                    foreach (GeneradorASN.Entities.RemisionesDataSet.PartidasDataTableRow lineaDT2 in lineasDT2)
                                    {
                                        archivoASN.WriteLine(GenerarDT2(remision, lineaDT2, Remisiones, ContadorDT1));
                                        ContadorDT1++;
                                    }
                                    lineasDT2.Clear();
                                }
                            }
                        }
                        productosProcesados.Clear();
                    }
                }

            }
            return 0;
        }

        //static public int Exportar(string ruta, GeneradorASN.Entities.RemisionesDataSet.RemisionesDataTableRow remision, GeneradorASN.Entities.RemisionesDataSet Remisiones, Registrador.IRegistroEjecucion registrador)
        //{
        //    double candidadTotalProducto = 0;
        //    string archivo = ruta + "\\" + "ASN" + remision.FolioRemision.Replace(" ", "") + ".txt";
        //    using (System.IO.StreamWriter archivoASN = System.IO.File.CreateText(archivo))
        //    {
        //        List<string> productosProcesados = new List<string>();
        //        int ContadorDT1 = 2;

        //        //Firma inicial
        //        archivoASN.WriteLine(":N:");
        //        //Header
        //        archivoASN.WriteLine(GenerarHeader(remision));
        //        foreach (GeneradorASN.Entities.RemisionesDataSet.PartidasDataTableRow partidaProductos in Remisiones.PartidasDataTable.Rows)
        //        {
        //            if (remision.FolioRemision == partidaProductos.FolioRemision)
        //            {
        //                if (productosProcesados.IndexOf(partidaProductos.ClaveProducto) < 0)
        //                {
        //                    List<GeneradorASN.Entities.RemisionesDataSet.PartidasDataTableRow> lineasDT2 = new List<GeneradorASN.Entities.RemisionesDataSet.PartidasDataTableRow>();
        //                    candidadTotalProducto = 0;

        //                    foreach (GeneradorASN.Entities.RemisionesDataSet.PartidasDataTableRow partidaDetalles in Remisiones.PartidasDataTable.Rows)
        //                    {
        //                        if (remision.FolioRemision == partidaDetalles.FolioRemision && partidaProductos.ClaveProducto == partidaDetalles.ClaveProducto)
        //                        {
        //                            candidadTotalProducto += partidaDetalles.CantidadPartida;
        //                            lineasDT2.Add(partidaDetalles);
        //                        }
        //                    }
        //                    productosProcesados.Add(partidaProductos.ClaveProducto);
        //                    archivoASN.WriteLine(GenerarDT1(remision, partidaProductos, Remisiones, ContadorDT1, candidadTotalProducto));
        //                    ContadorDT1++;
        //                    foreach (GeneradorASN.Entities.RemisionesDataSet.PartidasDataTableRow lineaDT2 in lineasDT2)
        //                    {
        //                        archivoASN.WriteLine(GenerarDT2(remision, lineaDT2, Remisiones, ContadorDT1));
        //                        ContadorDT1++;
        //                    }
        //                    lineasDT2.Clear();
        //                }
        //            }
        //        }

        //    }
        //    return 0;
        //}

        static public string GenerarHeader(GeneradorASN.Entities.RemisionesDataSet.RemisionesDataTableRow remision)
        {
            #region strings
            string Header = "HDR";
            string Purpose_Code = "00";
            string ASN_Number = "WCA" + remision.FolioRemision.Replace(" ", "").PadLeft(5, '0') + "       ";
            //string ASN_Number = remision.FolioRemision.Replace(" ", "") + "           ";
            string Ship_Date = "";
            string Ship_Time = "";
            string Create_Date = "";
            string Create_Time = "";
            string EstimatedArrival_Date = "";
            string EstimatedArrival_Time = "";
            string TrnsTimeZone = "  ";
            string Gross_Weight_Value = "";
            string Net_Weight_Value = "";
            string Gross_Weight_UM = "KG ";
            string Pack_Code = "PLT90     ";
            string Lading_qty = "";
            string TrnsScacCode = "XTUM             ";
            string TransportStage = "  ";
            string TrnsCarrierMode = "M  ";
            string TrnsRouting = "                                   ";
            string TrnsCarrierLocId = "                         ";
            string TrnsEquipCode = "TL ";
            string Equipment_Initial = "ST";
            string Equipment_Number = "02896";
            string TrnsInvoiceNum = "";
            string TrnsAirBillNumber = "                              ";
            string TrnsFreightBillNumber = "                                   ";
            string TrnsCarrierBillNumber = "                                   ";
            string Reference_Number = "";
            string TrnsMasterBillofLading = "                                   ";
            string TrnsSealNumber = "          ";
            string Supplier_Number = "032309                             ";
            string TrnsShipFromId = Supplier_Number;
            string Ship_To = "R                                  ";
            string TrnsUltimateDest = Ship_To;
            string TrnsUltimateDest2 = "                                   ";
            string TrnsConsigneeId = "                                   ";
            string OrderedBy = "                                   ";
            //poner total del documento
            string Invoice_Total_Amount = "";
            string Number_of_Line_Items = "";
            string TrnsDockCode = "0                        ";
            string ExcessReasonCode = "   ";
            string TrnsExcessTrans = "   ";
            string TrnsAETC = "                 ";
            string MetodoDePago = "  ";
            string TerminosDeTransporte = "   ";
            string TrnsCurrCode = "   ";
            string TrnsInvoiceTotal = "               ";
            string NombreCliente = "                                   ";
            string TotalLines = "";
            string TotalUnitsShipped = "          ";
            string TrnsSealNum2 = "          ";
            string TrnsSealNum3 = "        ";
            string TrnsSealNum4 = "        ";
            string ContainerType2 = "          ";
            string ContainerQuantity2 = "   ";
            string ContainerType3 = ContainerType2;
            string ContainerQuantity3 = ContainerQuantity2;
            string ContainerType4 = ContainerType2;
            string ContainerQuantity4 = ContainerQuantity2;
            string CantidadAEmbarcar = "                  ";
            #endregion

            DateTime fechaDocumento = DateTime.Now; //remision.FechaDocumento;

            //ASN_Number = "WCA" + remision.FolioRemision.Replace(" ", "").PadLeft(6, '0');
            ASN_Number = remision.FolioRemision.Replace(" ", "");
            while (ASN_Number.Length < 16)
            {
                ASN_Number += " ";
            }

            //Fechas
            Ship_Date = fechaDocumento.ToString("yyyyMMdd");
            Ship_Time = fechaDocumento.ToString("hhmm");
            Create_Date = fechaDocumento.ToString("yyyyMMdd");
            Create_Time = fechaDocumento.ToString("hhmm");
            EstimatedArrival_Date = remision.FechaEntrega.ToString("yyyyMMdd");
            EstimatedArrival_Time = fechaDocumento.ToString("hhmm");

            //Pesos
            Net_Weight_Value = Gross_Weight_Value = remision.PesoTotal.ToString();
            while (Gross_Weight_Value.Length < 18)
            {
                Gross_Weight_Value += " ";
            }
            while (Net_Weight_Value.Length < 18)
            {
                Net_Weight_Value += " ";
            }

            //Cantidades
            TrnsInvoiceTotal = remision.CantidadTotal.ToString();
            while (TrnsInvoiceTotal.Length < 15)
            {
                TrnsInvoiceTotal += " ";
            }

            Lading_qty = remision.PartidasTotales.ToString();
            while (Lading_qty.Length < 7)
            {
                Lading_qty += " ";
            }

            //Placas
            while (Equipment_Initial.Length < 4)
            {
                Equipment_Initial += " ";
            }
            while (Equipment_Number.Length < 17)
            {
                Equipment_Number += " ";
            }

            //Factura
            TrnsInvoiceNum = ASN_Number;
            while (TrnsInvoiceNum.Length < 30)
            {
                TrnsInvoiceNum += " ";
            }
            Reference_Number = ASN_Number;

            //Cantidades
            TotalLines = (remision.PartidasTotales + 1).ToString(); //Checar el '+1'
            while (TotalLines.Length < 10)
            {
                TotalLines += " ";
            }

            return Header + Purpose_Code + ASN_Number +
                Ship_Date + Ship_Time + Create_Date + Create_Time + EstimatedArrival_Date + EstimatedArrival_Time + TrnsTimeZone +
                Gross_Weight_Value + Net_Weight_Value + Gross_Weight_UM +
                Pack_Code + Lading_qty +
                TrnsScacCode + TransportStage + TrnsCarrierMode + TrnsRouting + TrnsCarrierLocId +
                TrnsEquipCode + Equipment_Initial + Equipment_Number +
                TrnsInvoiceNum + TrnsAirBillNumber + TrnsFreightBillNumber + TrnsCarrierBillNumber +
                Reference_Number +
                TrnsMasterBillofLading + TrnsSealNumber +
                Supplier_Number + TrnsShipFromId +
                Ship_To + TrnsUltimateDest +
                TrnsUltimateDest2 + TrnsConsigneeId + OrderedBy +
                Invoice_Total_Amount + Number_of_Line_Items +
                TrnsDockCode + ExcessReasonCode + TrnsExcessTrans + TrnsAETC + MetodoDePago + TerminosDeTransporte + TrnsCurrCode +
                TrnsInvoiceTotal + NombreCliente +
                TotalLines +
                TotalUnitsShipped + TrnsSealNum2 + TrnsSealNum3 + TrnsSealNum4 +
                ContainerType2 + ContainerQuantity2 + ContainerType3 + ContainerQuantity3 + ContainerType4 + ContainerQuantity4 + CantidadAEmbarcar;
        }

        static public string GenerarDT1(GeneradorASN.Entities.RemisionesDataSet.RemisionesDataTableRow remision, GeneradorASN.Entities.RemisionesDataSet.PartidasDataTableRow partida, GeneradorASN.Entities.RemisionesDataSet Remisiones, int ContadorDT1, double TotalProducto)
        {
            #region strings
            string DT = "DT1";
            string ContadorDeParte = ContadorDT1.ToString();
            string ConsecutivoDetallesDoc = "     ";
            string NivelDeEmpaque = "   ";
            string TrnsClientPartNumber = partida.ClaveProductoAlterna;
            string TrnsECLevel = "                              ";
            string TrnsDtlCustField4 = "                                   ";
            string ContainerPartNumber = "                              ";
            string TrnsUnitsShipped = TotalProducto.ToString();
            string TrnsUMUnitsShipped = "EA ";
            string TrnsCumulativeQuantity = "0           ";
            string TrnsPONumber = remision.FolioRemision.Replace(" ", "");
            string ReleaseNumber = "                              ";
            string ContractNumber = "          ";
            string TrnsDtlBillofLading = "                ";
            string TrnsDtlPackSlipNumber = "                ";
            string TrnsReleaseNum = "                ";
            string TrnsDtlShipTo = "                 ";
            string UltimateDestination = "                 ";
            string TrnsDtlDock = "        ";
            string TrnsDtlDockClauseNumber = "    ";
            string TrnsDtlDockChargeTotalAmount = "         ";
            string TrnsDtlDockDescription = "                                                                           ";
            string TrnsUnitPrice = "               ";   //TBD - Precio
            string TrnsContainerQuantity = "0    "; //TBD - Number of Loads
            string TrnsUnitsPerContainer = "       ";
            string TrnsContainerCode = "PLT90            ";
            string SerialNumber = "                                   ";
            string VolumeOfPackage = "               ";
            string FechaDeProduccion = "        ";
            string FechaDeFacturacion = "        ";
            string CantidadDeContenedores = "         ";
            string UnidadDeMedidaEnVolumen = "   ";
            string NumeroDeReferenciaDelEmpaque = "                                   ";
            string NumeroDeSerieDelContenedor = "                                   ";
            string NumeroDeEtiquetaKanban = "                                   ";
            string TrnsGrossPieceWeight = "                  ";
            string TrnsUMGrossPieceWeight = "   ";
            string TrnsNetPieceWeight = "                  ";
            string TrnsUMNetPieceWeight = "   ";
            
            #endregion

            while (ContadorDeParte.Length < 5)
            {
                ContadorDeParte += " ";
            }

            while (TrnsClientPartNumber.Length < 30)
            {
                TrnsClientPartNumber += " ";
            }

            while (TrnsUnitsShipped.Length < 12)
            {
                TrnsUnitsShipped += " ";
            }

            //PO Number
            while (TrnsPONumber.Length < 35)
            {
                TrnsPONumber += " ";
            }
            return DT + ContadorDeParte + ConsecutivoDetallesDoc + NivelDeEmpaque + TrnsClientPartNumber + TrnsECLevel + TrnsDtlCustField4 + ContainerPartNumber + TrnsUnitsShipped + TrnsUMUnitsShipped +
                TrnsCumulativeQuantity + TrnsPONumber + ReleaseNumber + ContractNumber +
                TrnsDtlBillofLading + TrnsDtlPackSlipNumber + TrnsReleaseNum + TrnsDtlShipTo + UltimateDestination + TrnsDtlDock + TrnsDtlDockClauseNumber + TrnsDtlDockChargeTotalAmount + TrnsDtlDockDescription +
                TrnsUnitPrice + TrnsContainerQuantity + TrnsUnitsPerContainer + TrnsContainerCode + SerialNumber + VolumeOfPackage + FechaDeProduccion + FechaDeFacturacion + CantidadDeContenedores + UnidadDeMedidaEnVolumen +
                NumeroDeReferenciaDelEmpaque + NumeroDeEtiquetaKanban + NumeroDeSerieDelContenedor + TrnsGrossPieceWeight + TrnsUMGrossPieceWeight + TrnsNetPieceWeight + TrnsUMNetPieceWeight;
        }

        static public string GenerarDT2(GeneradorASN.Entities.RemisionesDataSet.RemisionesDataTableRow remision, GeneradorASN.Entities.RemisionesDataSet.PartidasDataTableRow partida, GeneradorASN.Entities.RemisionesDataSet Remisiones, int ContadorDT2)
        {
            #region strings
            string DT = "DT2";
            string Trnspallet = partida.RAN.Trim();
            string TrnsNoCases = partida.CantidadPartida.ToString();
            string TrnsLabelSerial = "          ";
            #endregion

            while (Trnspallet.Length < 8)
            {
                Trnspallet += " ";
            }

            while (TrnsNoCases.Length < 7)
            {
                TrnsNoCases += " ";
            }


            return DT + Trnspallet + TrnsNoCases + TrnsLabelSerial;
        }
    }
}
