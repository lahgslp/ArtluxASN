﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneradorASN.BLL;
using GeneradorASN.Entities;
using System.Configuration;

namespace GeneradorASNWin
{
    public partial class GeneradorASNMain : Form
    {
        bool flagComboPeriodos = false; //Para evitar primera ejecucion de calculo mientras se asigna el DataSource
        bool controlesFechaActivos = true;//Por default en true para que se deshabiliten al iniciar
        bool controlesFoliosActivos = true;//Por default en true para que se deshabiliten al iniciar

        RemisionesDataSet Remisiones;

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
            DateTime inicio, final;
            GeneradorPeriodosdeFechas.CalcularFechas(Periodos.Hoy, DateTime.Now, out inicio, out final);
            dateTimePickerFechaInicio.Value = inicio;
            dateTimePickerFechaFinal.Value = final;
        }

        private void ActivaControlesFolios()
        {
            if (controlesFoliosActivos == false)
            {
                labelFolios.Visible = true;
                textBoxFolios.Visible = true;
                textBoxFolios.Text = "";
                buttonRefrescar.Visible = true;
                controlesFoliosActivos = true;
            }
        }

        private void DesactivaControlesFolios()
        {
            if (controlesFoliosActivos == true)
            {
                labelFolios.Visible = false;
                textBoxFolios.Visible = false;
                textBoxFolios.Text = "";
                buttonRefrescar.Visible = false;
                controlesFoliosActivos = false;
            }
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
            DesactivaControlesFolios();
            this.textBoxRutaDestino.Text = ConfigurationManager.AppSettings["RutaDestino"];
        }

        private void GeneradorASN_Load(object sender, EventArgs e)
        {
            Text += " - V. " + typeof(GeneradorASNMain).Assembly.GetName().Version;   //Para mostrar la version
            InicializarControles();
            CargarDatos();
        }

        private void buttonCambiarRuta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog selRuta = new FolderBrowserDialog();
            selRuta.SelectedPath = this.textBoxRutaDestino.Text;
            if (selRuta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBoxRutaDestino.Text = selRuta.SelectedPath;
            }
        }

        private void dateTimePickerFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            Periodos periodo = (Periodos)Convert.ToInt32(comboPeriodo.SelectedValue);
            if (periodo == Periodos.Manual)
            {
                if (dateTimePickerFechaInicio.Value > dateTimePickerFechaFinal.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final", "Fechas incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickerFechaInicio.Value = dateTimePickerFechaFinal.Value;
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
                    MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final", "Fechas incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickerFechaFinal.Value = dateTimePickerFechaInicio.Value;
                }
                else
                {
                    CargarDatos();
                }
            }
        }

        private void linkCarpetaRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + "\\" + "GeneradorASNWin");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void comboPeriodo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (flagComboPeriodos)
            {
                Periodos periodo = (Periodos)Convert.ToInt32(comboPeriodo.SelectedValue);

                if (periodo == Periodos.Folios)
                {
                    DesactivaControlesFecha();
                    ActivaControlesFolios();
                }
                else if (periodo == Periodos.Manual)
                {
                    ActivaControlesFecha();
                    DesactivaControlesFolios();
                }
                else
                {
                    DateTime inicio, final;
                    DesactivaControlesFecha();
                    DesactivaControlesFolios();
                    GeneradorPeriodosdeFechas.CalcularFechas(periodo, DateTime.Now, out inicio, out final);
                    dateTimePickerFechaInicio.Value = inicio;
                    dateTimePickerFechaFinal.Value = final;
                    CargarDatos();
                }
            }
            this.buttonCargar.Enabled = true;
        }

        private bool FoliosValidos(string folios)
        {
            bool resultado = true;
            //TBD, como validar los folios
            return resultado;
        }

        private void buttonRefrescar_Click(object sender, EventArgs e)
        {
            if (textBoxFolios.Text != String.Empty && textBoxFolios.Text.Replace(" ", "") != string.Empty)
            {
                if (FoliosValidos(textBoxFolios.Text))
                {
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show("Por favor introduzca folios separados por comas", "Folios vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxFolios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonRefrescar_Click(null, null);
            }
        }

        private void CargarDatos()
        {
            DatosFiltro filtros = new DatosFiltro();
            Periodos periodo = (Periodos)Convert.ToInt32(comboPeriodo.SelectedValue);

            if (periodo == Periodos.Folios)
            {
                filtros.Filtro = TipoFiltro.Folios;
                filtros.Folios = textBoxFolios.Text;
            }
            else
            {
                filtros.Filtro = TipoFiltro.Fecha;
                filtros.FechaInicio = dateTimePickerFechaInicio.Value;
                filtros.FechaFinal = dateTimePickerFechaFinal.Value;
            }

            Registrador.IRegistroEjecucion registrador = new Registrador.RegistroEjecucionArchivo("GeneradorASNWinLogCarga" + DateTime.Now.ToString("yyyyMMddHHmmss"));            

            Cursor.Current = Cursors.WaitCursor;
            Remisiones = RemisionesManager.ObtenerRemisiones(filtros, registrador);
            remisionesDataTableBindingSource.DataSource = Remisiones;

            foreach (DataGridViewRow row in dataGridViewRANs.Rows)
            {
                if(((DateTime)row.Cells["fechaDocumentoDataGridViewTextBoxColumn"].Value) >= DateTime.Today)
                    row.Cells["Selected"].Value = true;
            }

            Cursor.Current = Cursors.Default;
        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {
            this.buttonCargar.Enabled = false;
            List<string> foliosElegidos = new List<string>();
            if (dataGridViewRANs.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewRANs.Rows)
                {
                    if (row.Cells["Selected"].Value != null)
                    {
                        if (Convert.ToBoolean(row.Cells["Selected"].Value) == true)
                        {
                            foliosElegidos.Add(Convert.ToString(row.Cells["folioRemisionDataGridViewTextBoxColumn"].Value));
                        }
                    }
                }
                if (foliosElegidos.Count > 0)
                {
                    Registrador.IRegistroEjecucion registrador = new Registrador.RegistroEjecucionArchivo("GeneradorASNWinLogGeneracion" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                    
                    ExportadorASN.ExportarRemisiones(this.textBoxRutaDestino.Text, foliosElegidos, Remisiones, registrador);
                }
                else
                {
                    MessageBox.Show("No hay remisiones seleccionadas. Favor de seleccionar remisiones a cargar ASN", "Seleccionar Remisiones");
                }
            }
            else
            {
                MessageBox.Show("No hay remisiones disponibles para cargar","No hay Remisiones");
            }
            //http://www.codeproject.com/Articles/42437/Toggling-the-States-of-all-CheckBoxes-Inside-a-Dat
        }

        private void checkBoxSeleccionaTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSeleccionaTodo.Checked)
            {
                foreach (DataGridViewRow row in dataGridViewRANs.Rows)
                {
                    row.Cells["Selected"].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridViewRANs.Rows)
                {
                    row.Cells["Selected"].Value = false;
                }
            }
        }
    }
}
