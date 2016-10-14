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
                if (folios.IndexOf(remision.FolioRemision) >= 0)
                {
                    Exportar(ruta, remision.FolioRemision, Remisiones, registrador);
                }
            }
            return 0;
        }

        static public int Exportar(string ruta, string folio, GeneradorASN.Entities.RemisionesDataSet Remisiones, Registrador.IRegistroEjecucion registrador)
        {
            string archivo = ruta + "\\" + "ASN" + folio.Replace(" ", "") + ".txt";
            using (System.IO.StreamWriter archivoASN = System.IO.File.CreateText(archivo))
            {
                //Firma inicial
                archivoASN.WriteLine(":N:");
                //Header
                archivoASN.WriteLine(GenerarHeader(folio, Remisiones));

            }
            return 0;
        }

        static public string GenerarHeader(string folio, GeneradorASN.Entities.RemisionesDataSet Remisiones)
        {
            string Header = "HDR";
            string Purpose_Code = "00";
            string ASN_Number = "WCA" + folio.Replace(" ", "").PadLeft(5, '0') + "       ";
            string Ship_Date = "";
            string Ship_Time = "";
            string Create_Date = "";
            string Create_Time = "";
            string EstimatedArrival_Date = "";
            string EstimatedArrival_Time = "";
            string TrnsTimeZone = "  ";
            string Gross_Weight_Value = "";
            string Net_Weight_Value = "";
            string Gross_Weight_UM = "kg ";
            string Pack_Code = "PLT90     ";
            string Lading_qty = "";
            string TrnsScacCode = "PSKL             ";
            string TransportStage = "  ";
            string TrnsCarrierMode = "P  ";
            string TrnsRouting = "                                   ";
            string TrnsCarrierLocId = "                         ";
            string TrnsEquipCode = "TL ";
            string Equipment_Initial = "ST";
            string Equipment_Number = "2896";
            string TrnsInvoiceNum = "";
            string TrnsAirBillNumber = "                              ";
            string TrnsFreightBillNumber = "                                   ";
            string TrnsCarrierBillNumber = "                                   ";
            string Reference_Number = "";
            string TrnsMasterBillofLading = "                                   ";
            string TrnsSealNumber = "          ";
            string Supplier_Number = "032309                             ";
            string TrnsShipFromId = Supplier_Number;
            string Ship_To = "N                                  ";
            string TrnsUltimateDest = Ship_To;
            string TrnsUltimateDest2 = "                                   ";
            string TrnsConsigneeId = "                                   ";
            string OrderedBy = "                                   ";
            string Invoice_Total_Amount = "";
            string Number_of_Line_Items = "";

            foreach (GeneradorASN.Entities.RemisionesDataSet.RemisionesDataTableRow remision in Remisiones.RemisionesDataTable.Rows)
            {
                if(remision.FolioRemision ==  folio)
                {
                    DateTime fechaDocumento = DateTime.Now; //remision.FechaDocumento;

                    ASN_Number = "WCA" + folio.Replace(" ", "").PadLeft(6, '0');
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
                    Net_Weight_Value = Gross_Weight_Value = remision.PesoTotal.ToString("N0");
                    while (Gross_Weight_Value.Length < 18)
                    {
                        Gross_Weight_Value += " ";
                    }
                    while (Net_Weight_Value.Length < 18)
                    {
                        Net_Weight_Value += " ";
                    }

                    //Cantidades
                    Lading_qty = remision.PartidasTotales.ToString("N0");
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
                }
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
                Invoice_Total_Amount + Number_of_Line_Items;
        }
    }
}
