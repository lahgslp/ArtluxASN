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
        public GeneradorASNMain()
        {
            InitializeComponent();
        }

        private void GeneradorASN_Load(object sender, EventArgs e)
        {
            Text += " - V. " + typeof(GeneradorASNMain).Assembly.GetName().Version;   //Para mostrar la version
            this.comboPeriodo.DataSource = GeneradorPeriodosdeFechas.Generar();
            this.comboPeriodo.ValueMember = "PeriodoID";
            this.comboPeriodo.DisplayMember = "PeriodoDesc";
            CargarDatos();
        }

        private void buttonCambiarRuta_Click(object sender, EventArgs e)
        {

        }

        private void comboPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerFechaInicio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerFechaFinal_ValueChanged(object sender, EventArgs e)
        {

        }

        private void linkCarpetaRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void CargarDatos()
        {
            rANDataTableBindingSource.DataSource = RANManager.ObtenerRANs(dateTimePickerFechaInicio.Value, dateTimePickerFechaFinal.Value);
        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {

        }
    }
}
