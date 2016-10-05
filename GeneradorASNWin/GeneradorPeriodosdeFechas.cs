using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GeneradorASNWin
{
    enum Periodos
    {
        Hoy,
        Ayer,
        SemanaActual,
        SemanaPasada,
        DosSemanas,
        MesActual,
        MesPasado,
        Manual,
        Folios
    }

    class GeneradorPeriodosdeFechas
    {
        public static DataTable Generar()
        {
            DataTable periodos = new DataTable("PeriodosFechas");
            periodos.Columns.Add("PeriodoID");
            periodos.Columns.Add("PeriodoDesc");

            DataRow r1 = periodos.Rows.Add();
            r1["PeriodoID"] = (int) Periodos.Hoy;
            r1["PeriodoDesc"] = "Hoy";

            DataRow r2 = periodos.Rows.Add();
            r2["PeriodoID"] = (int) Periodos.Ayer;
            r2["PeriodoDesc"] = "Ayer";

            DataRow r3 = periodos.Rows.Add();
            r3["PeriodoID"] = (int) Periodos.SemanaActual;
            r3["PeriodoDesc"] = "Semana Actual";

            DataRow r4 = periodos.Rows.Add();
            r4["PeriodoID"] = (int) Periodos.SemanaPasada;
            r4["PeriodoDesc"] = "Semana Pasada";

            DataRow r5 = periodos.Rows.Add();
            r5["PeriodoID"] = (int) Periodos.DosSemanas;
            r5["PeriodoDesc"] = "Dos Semanas";

            DataRow r6 = periodos.Rows.Add();
            r6["PeriodoID"] = (int) Periodos.MesActual;
            r6["PeriodoDesc"] = "Mes Actual";

            DataRow r7 = periodos.Rows.Add();
            r7["PeriodoID"] = (int) Periodos.MesPasado;
            r7["PeriodoDesc"] = "Mes Pasado";

            DataRow r8 = periodos.Rows.Add();
            r8["PeriodoID"] = (int) Periodos.Manual;
            r8["PeriodoDesc"] = "Manual";

            DataRow r9 = periodos.Rows.Add();
            r9["PeriodoID"] = (int)Periodos.Folios;
            r9["PeriodoDesc"] = "Folios";

            return periodos;
        }

        public static void CalcularFechas(Periodos Periodo, DateTime FechaActual, out DateTime FechaInicial, out DateTime FechaFinal)
        {
            //default a Hoy
            FechaInicial = FechaActual.Date;
            FechaFinal = FechaActual.Date;
            switch (Periodo)
            {
                case Periodos.Hoy:
                    //default a Hoy
                    break;
                case Periodos.Ayer:
                    if (FechaActual.DayOfWeek == DayOfWeek.Monday)
                    {
                        //Si es lunes, regresar viernes
                        FechaInicial = FechaActual.AddDays(-3).Date;
                        FechaFinal = FechaActual.AddDays(-3).Date;
                    }
                    else
                    {
                        FechaInicial = FechaActual.AddDays(-1).Date;
                        FechaFinal = FechaActual.AddDays(-1).Date;
                    }
                    break;
                case Periodos.SemanaActual:
                    FechaInicial = FechaActual.Date;
                    FechaFinal = FechaActual.Date;
                    break;
                case Periodos.SemanaPasada:
                    FechaInicial = FechaActual.Date;
                    FechaFinal = FechaActual.Date;
                    break;
                case Periodos.DosSemanas:
                    FechaInicial = FechaActual.Date;
                    FechaFinal = FechaActual.Date;
                    break;
                case Periodos.MesActual:
                    FechaInicial = FechaActual.Date;
                    FechaFinal = FechaActual.Date;
                    break;
                case Periodos.MesPasado:
                    FechaInicial = FechaActual.Date;
                    FechaFinal = FechaActual.Date;
                    break;
                case Periodos.Manual:
                    //default a Hoy
                    break;
            }
        }
    }
}
