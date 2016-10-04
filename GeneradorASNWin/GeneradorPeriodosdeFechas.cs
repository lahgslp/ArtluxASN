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
        UltimoMes,
        Manual
    }

    class GeneradorPeriodosdeFechas
    {
        public static DataTable Generar()
        {
            DataTable periodos = new DataTable("PeriodosFechas");
            periodos.Columns.Add("PeriodoID");
            periodos.Columns.Add("PeriodoDesc");

            DataRow r1 = periodos.Rows.Add();
            r1["PeriodoID"] = Periodos.Hoy;
            r1["PeriodoDesc"] = "Hoy";

            DataRow r2 = periodos.Rows.Add();
            r2["PeriodoID"] = Periodos.Ayer;
            r2["PeriodoDesc"] = "Ayer";

            DataRow r3 = periodos.Rows.Add();
            r3["PeriodoID"] = Periodos.SemanaActual;
            r3["PeriodoDesc"] = "Semana Actual";

            DataRow r4 = periodos.Rows.Add();
            r4["PeriodoID"] = Periodos.SemanaPasada;
            r4["PeriodoDesc"] = "Semana Pasada";

            DataRow r5 = periodos.Rows.Add();
            r5["PeriodoID"] = Periodos.DosSemanas;
            r5["PeriodoDesc"] = "Dos Semanas";

            DataRow r6 = periodos.Rows.Add();
            r6["PeriodoID"] = Periodos.MesActual;
            r6["PeriodoDesc"] = "Mes Actual";

            DataRow r7 = periodos.Rows.Add();
            r7["PeriodoID"] = Periodos.UltimoMes;
            r7["PeriodoDesc"] = "Último Mes";

            DataRow r8 = periodos.Rows.Add();
            r8["PeriodoID"] = Periodos.Manual;
            r8["PeriodoDesc"] = "Manual";

            return periodos;
        }
    }
}
