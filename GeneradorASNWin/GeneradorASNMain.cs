using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneradorASN.BLL;

namespace GeneradorASNWin
{
    public partial class GeneradorASNMain : Form
    {
        bool flagComboPeriodos = false; //Para evitar primera ejecucion de calculo mientras se asigna el DataSource
        bool controlesFechaActivos = true;//Por default en true para que se deshabiliten al iniciar

        public GeneradorASNMain()
        {
            InitializeComponent();
        }

        private void InicializarComboPeriodos()
        {
            //Inicializacion periodo
            this.comboPeriodo.DataSource = /*Enum.GetValues(typeof(Periodos));*/GeneradorPeriodosdeFechas.Generar();
            this.comboPeriodo.ValueMember = "PeriodoID";
            this.comboPeriodo.DisplayMember = "PeriodoDesc";
            flagComboPeriodos = true;
            this.comboPeriodo.SelectedValue = (int) Periodos.Hoy;
        }

        private void ActivaControlesFecha()
        {
            if (controlesFechaActivos == false)
            {
                labelFechaInicio.Visible = true;
                labelFechaFinal.Visible = true;
                dateTimePickerFechaInicio.Visible = true;
                dateTimePickerFechaFinal.Visible = true;
                controlesFechaActivos = true;
            }
        }

        private void DesactivaControlesFecha()
        {
            if (controlesFechaActivos == true)
            {
                labelFechaInicio.Visible = false;
                labelFechaFinal.Visible = false;
                dateTimePickerFechaInicio.Visible = false;
                dateTimePickerFechaFinal.Visible = false;
                controlesFechaActivos = false;
            }
        }

        private void InicializarControles()
        {
            InicializarComboPeriodos();
            DesactivaControlesFecha();
        }

        private void GeneradorASN_Load(object sender, EventArgs e)
        {
            Text += " - V. " + typeof(GeneradorASNMain).Assembly.GetName().Version;   //Para mostrar la version
            InicializarControles();
            CargarDatos();
        }

        private void buttonCambiarRuta_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            Periodos periodo = (Periodos)Convert.ToInt32(comboPeriodo.SelectedValue);
            if (periodo == Periodos.Manual)
            {
                if (dateTimePickerFechaInicio.Value > dateTimePickerFechaFinal.Value)
                {
                    MessageBox.Show("Fechas incorrectas", "La fecha de inicio no puede ser mayor que la fecha final",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CargarDatos();
                }
            }
        }

        private void dateTimePickerFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            Periodos periodo = (Periodos)Convert.ToInt32(comboPeriodo.SelectedValue);
            if (periodo == Periodos.Manual)
            {
                if (dateTimePickerFechaInicio.Value > dateTimePickerFechaFinal.Value)
                {
                    MessageBox.Show("Fechas incorrectas", "La fecha de inicio no puede ser mayor que la fecha final", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CargarDatos();
                }
            }
        }

        private void linkCarpetaRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void CargarDatos()
        {
            DatosFiltro filtros = new DatosFiltro();
            Periodos periodo = (Periodos)Convert.ToInt32(comboPeriodo.SelectedValue);

            if (periodo == Periodos.Folios)
            {
                filtros.Filtro = TipoFiltro.Folios;
                //TBD
            }
            else
            {
                filtros.Filtro = TipoFiltro.Fecha;
                filtros.FechaInicio = dateTimePickerFechaInicio.Value;
                filtros.FechaFinal = dateTimePickerFechaFinal.Value;
            }

            remisionesDataTableBindingSource.DataSource = RemisionesManager.ObtenerRemisiones(filtros);
        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {

        }

        private void comboPeriodo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (flagComboPeriodos)
            {
                Periodos periodo = (Periodos)Convert.ToInt32(comboPeriodo.SelectedValue);

                if (periodo == Periodos.Folios)
                {
                    DesactivaControlesFecha();
                    //TBD
                }
                else if (periodo == Periodos.Manual)
                {
                    ActivaControlesFecha();
                }
                else
                {
                    DateTime inicio, final;
                    DesactivaControlesFecha();
                    GeneradorPeriodosdeFechas.CalcularFechas(periodo, DateTime.Now, out inicio, out final);
                    dateTimePickerFechaInicio.Value = inicio;
                    dateTimePickerFechaFinal.Value = final;
                }
            }
        }
    }
}
