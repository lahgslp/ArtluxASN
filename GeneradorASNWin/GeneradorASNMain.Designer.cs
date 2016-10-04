namespace GeneradorASNWin
{
    partial class GeneradorASNMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelPeriodo = new System.Windows.Forms.Label();
            this.comboPeriodo = new System.Windows.Forms.ComboBox();
            this.dateTimePickerFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.labelFechaInicio = new System.Windows.Forms.Label();
            this.labelFechaFinal = new System.Windows.Forms.Label();
            this.groupBoxRANs = new System.Windows.Forms.GroupBox();
            this.dataGridViewRANs = new System.Windows.Forms.DataGridView();
            this.remisionesDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelDestino = new System.Windows.Forms.Label();
            this.textBoxRutaDestino = new System.Windows.Forms.TextBox();
            this.buttonCargar = new System.Windows.Forms.Button();
            this.buttonCambiarRuta = new System.Windows.Forms.Button();
            this.linkCarpetaRegistro = new System.Windows.Forms.LinkLabel();
            this.remisionesDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.folioRemisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partidasTotalesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pesoTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listaRANsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxRANs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRANs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remisionesDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remisionesDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPeriodo
            // 
            this.labelPeriodo.AutoSize = true;
            this.labelPeriodo.Location = new System.Drawing.Point(12, 15);
            this.labelPeriodo.Name = "labelPeriodo";
            this.labelPeriodo.Size = new System.Drawing.Size(46, 13);
            this.labelPeriodo.TabIndex = 0;
            this.labelPeriodo.Text = "Periodo:";
            // 
            // comboPeriodo
            // 
            this.comboPeriodo.Location = new System.Drawing.Point(64, 12);
            this.comboPeriodo.Name = "comboPeriodo";
            this.comboPeriodo.Size = new System.Drawing.Size(121, 21);
            this.comboPeriodo.TabIndex = 1;
            this.comboPeriodo.SelectedIndexChanged += new System.EventHandler(this.comboPeriodo_SelectedIndexChanged);
            // 
            // dateTimePickerFechaInicio
            // 
            this.dateTimePickerFechaInicio.Location = new System.Drawing.Point(265, 15);
            this.dateTimePickerFechaInicio.Name = "dateTimePickerFechaInicio";
            this.dateTimePickerFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFechaInicio.TabIndex = 2;
            this.dateTimePickerFechaInicio.ValueChanged += new System.EventHandler(this.dateTimePickerFechaInicio_ValueChanged);
            // 
            // dateTimePickerFechaFinal
            // 
            this.dateTimePickerFechaFinal.Location = new System.Drawing.Point(548, 15);
            this.dateTimePickerFechaFinal.Name = "dateTimePickerFechaFinal";
            this.dateTimePickerFechaFinal.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFechaFinal.TabIndex = 3;
            this.dateTimePickerFechaFinal.ValueChanged += new System.EventHandler(this.dateTimePickerFechaFinal_ValueChanged);
            // 
            // labelFechaInicio
            // 
            this.labelFechaInicio.AutoSize = true;
            this.labelFechaInicio.Location = new System.Drawing.Point(191, 15);
            this.labelFechaInicio.Name = "labelFechaInicio";
            this.labelFechaInicio.Size = new System.Drawing.Size(68, 13);
            this.labelFechaInicio.TabIndex = 4;
            this.labelFechaInicio.Text = "Fecha Inicio:";
            // 
            // labelFechaFinal
            // 
            this.labelFechaFinal.AutoSize = true;
            this.labelFechaFinal.Location = new System.Drawing.Point(477, 15);
            this.labelFechaFinal.Name = "labelFechaFinal";
            this.labelFechaFinal.Size = new System.Drawing.Size(65, 13);
            this.labelFechaFinal.TabIndex = 6;
            this.labelFechaFinal.Text = "Fecha Final:";
            // 
            // groupBoxRANs
            // 
            this.groupBoxRANs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRANs.Controls.Add(this.dataGridViewRANs);
            this.groupBoxRANs.Location = new System.Drawing.Point(12, 41);
            this.groupBoxRANs.Name = "groupBoxRANs";
            this.groupBoxRANs.Size = new System.Drawing.Size(736, 224);
            this.groupBoxRANs.TabIndex = 7;
            this.groupBoxRANs.TabStop = false;
            this.groupBoxRANs.Text = "Listado de RANs";
            // 
            // dataGridViewRANs
            // 
            this.dataGridViewRANs.AllowUserToAddRows = false;
            this.dataGridViewRANs.AllowUserToDeleteRows = false;
            this.dataGridViewRANs.AutoGenerateColumns = false;
            this.dataGridViewRANs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRANs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.folioRemisionDataGridViewTextBoxColumn,
            this.cantidadTotalDataGridViewTextBoxColumn,
            this.partidasTotalesDataGridViewTextBoxColumn,
            this.pesoTotalDataGridViewTextBoxColumn,
            this.fechaDocumentoDataGridViewTextBoxColumn,
            this.fechaEntregaDataGridViewTextBoxColumn,
            this.listaRANsDataGridViewTextBoxColumn});
            this.dataGridViewRANs.DataSource = this.remisionesDataTableBindingSource;
            this.dataGridViewRANs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRANs.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewRANs.Name = "dataGridViewRANs";
            this.dataGridViewRANs.ReadOnly = true;
            this.dataGridViewRANs.Size = new System.Drawing.Size(730, 205);
            this.dataGridViewRANs.TabIndex = 0;
            // 
            // remisionesDataTableBindingSource
            // 
            this.remisionesDataTableBindingSource.DataMember = "RemisionesDataTable";
            this.remisionesDataTableBindingSource.DataSource = this.remisionesDataSetBindingSource;
            // 
            // labelDestino
            // 
            this.labelDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDestino.AutoSize = true;
            this.labelDestino.Location = new System.Drawing.Point(12, 274);
            this.labelDestino.Name = "labelDestino";
            this.labelDestino.Size = new System.Drawing.Size(46, 13);
            this.labelDestino.TabIndex = 8;
            this.labelDestino.Text = "Destino:";
            // 
            // textBoxRutaDestino
            // 
            this.textBoxRutaDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxRutaDestino.Location = new System.Drawing.Point(64, 271);
            this.textBoxRutaDestino.Name = "textBoxRutaDestino";
            this.textBoxRutaDestino.ReadOnly = true;
            this.textBoxRutaDestino.Size = new System.Drawing.Size(369, 20);
            this.textBoxRutaDestino.TabIndex = 9;
            // 
            // buttonCargar
            // 
            this.buttonCargar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCargar.Location = new System.Drawing.Point(670, 271);
            this.buttonCargar.Name = "buttonCargar";
            this.buttonCargar.Size = new System.Drawing.Size(75, 23);
            this.buttonCargar.TabIndex = 10;
            this.buttonCargar.Text = "&Cargar";
            this.buttonCargar.UseVisualStyleBackColor = true;
            this.buttonCargar.Click += new System.EventHandler(this.buttonCargar_Click);
            // 
            // buttonCambiarRuta
            // 
            this.buttonCambiarRuta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCambiarRuta.Location = new System.Drawing.Point(439, 271);
            this.buttonCambiarRuta.Name = "buttonCambiarRuta";
            this.buttonCambiarRuta.Size = new System.Drawing.Size(75, 23);
            this.buttonCambiarRuta.TabIndex = 11;
            this.buttonCambiarRuta.Text = "Ca&mbiar";
            this.buttonCambiarRuta.UseVisualStyleBackColor = true;
            this.buttonCambiarRuta.Click += new System.EventHandler(this.buttonCambiarRuta_Click);
            // 
            // linkCarpetaRegistro
            // 
            this.linkCarpetaRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkCarpetaRegistro.AutoSize = true;
            this.linkCarpetaRegistro.Location = new System.Drawing.Point(15, 294);
            this.linkCarpetaRegistro.Name = "linkCarpetaRegistro";
            this.linkCarpetaRegistro.Size = new System.Drawing.Size(170, 13);
            this.linkCarpetaRegistro.TabIndex = 12;
            this.linkCarpetaRegistro.TabStop = true;
            this.linkCarpetaRegistro.Text = "Ver carpeta de registro de eventos";
            this.linkCarpetaRegistro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCarpetaRegistro_LinkClicked);
            // 
            // remisionesDataSetBindingSource
            // 
            this.remisionesDataSetBindingSource.DataSource = typeof(GeneradorASN.Entities.RemisionesDataSet);
            this.remisionesDataSetBindingSource.Position = 0;
            // 
            // Selected
            // 
            this.Selected.HeaderText = "Incluir";
            this.Selected.Name = "Selected";
            this.Selected.ReadOnly = true;
            // 
            // folioRemisionDataGridViewTextBoxColumn
            // 
            this.folioRemisionDataGridViewTextBoxColumn.DataPropertyName = "FolioRemision";
            this.folioRemisionDataGridViewTextBoxColumn.HeaderText = "FolioRemision";
            this.folioRemisionDataGridViewTextBoxColumn.Name = "folioRemisionDataGridViewTextBoxColumn";
            this.folioRemisionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadTotalDataGridViewTextBoxColumn
            // 
            this.cantidadTotalDataGridViewTextBoxColumn.DataPropertyName = "CantidadTotal";
            this.cantidadTotalDataGridViewTextBoxColumn.HeaderText = "CantidadTotal";
            this.cantidadTotalDataGridViewTextBoxColumn.Name = "cantidadTotalDataGridViewTextBoxColumn";
            this.cantidadTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // partidasTotalesDataGridViewTextBoxColumn
            // 
            this.partidasTotalesDataGridViewTextBoxColumn.DataPropertyName = "PartidasTotales";
            this.partidasTotalesDataGridViewTextBoxColumn.HeaderText = "PartidasTotales";
            this.partidasTotalesDataGridViewTextBoxColumn.Name = "partidasTotalesDataGridViewTextBoxColumn";
            this.partidasTotalesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pesoTotalDataGridViewTextBoxColumn
            // 
            this.pesoTotalDataGridViewTextBoxColumn.DataPropertyName = "PesoTotal";
            this.pesoTotalDataGridViewTextBoxColumn.HeaderText = "PesoTotal";
            this.pesoTotalDataGridViewTextBoxColumn.Name = "pesoTotalDataGridViewTextBoxColumn";
            this.pesoTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaDocumentoDataGridViewTextBoxColumn
            // 
            this.fechaDocumentoDataGridViewTextBoxColumn.DataPropertyName = "FechaDocumento";
            this.fechaDocumentoDataGridViewTextBoxColumn.HeaderText = "FechaDocumento";
            this.fechaDocumentoDataGridViewTextBoxColumn.Name = "fechaDocumentoDataGridViewTextBoxColumn";
            this.fechaDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaEntregaDataGridViewTextBoxColumn
            // 
            this.fechaEntregaDataGridViewTextBoxColumn.DataPropertyName = "FechaEntrega";
            this.fechaEntregaDataGridViewTextBoxColumn.HeaderText = "FechaEntrega";
            this.fechaEntregaDataGridViewTextBoxColumn.Name = "fechaEntregaDataGridViewTextBoxColumn";
            this.fechaEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // listaRANsDataGridViewTextBoxColumn
            // 
            this.listaRANsDataGridViewTextBoxColumn.DataPropertyName = "ListaRANs";
            this.listaRANsDataGridViewTextBoxColumn.HeaderText = "ListaRANs";
            this.listaRANsDataGridViewTextBoxColumn.Name = "listaRANsDataGridViewTextBoxColumn";
            this.listaRANsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // GeneradorASNMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 325);
            this.Controls.Add(this.linkCarpetaRegistro);
            this.Controls.Add(this.buttonCambiarRuta);
            this.Controls.Add(this.buttonCargar);
            this.Controls.Add(this.textBoxRutaDestino);
            this.Controls.Add(this.labelDestino);
            this.Controls.Add(this.groupBoxRANs);
            this.Controls.Add(this.labelFechaFinal);
            this.Controls.Add(this.labelFechaInicio);
            this.Controls.Add(this.dateTimePickerFechaFinal);
            this.Controls.Add(this.dateTimePickerFechaInicio);
            this.Controls.Add(this.comboPeriodo);
            this.Controls.Add(this.labelPeriodo);
            this.Name = "GeneradorASNMain";
            this.Text = "Generador de ASN Nissan de SAE - Artlux S.A. de C.V.";
            this.Load += new System.EventHandler(this.GeneradorASN_Load);
            this.groupBoxRANs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRANs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remisionesDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remisionesDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPeriodo;
        private System.Windows.Forms.ComboBox comboPeriodo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaFinal;
        private System.Windows.Forms.Label labelFechaInicio;
        private System.Windows.Forms.Label labelFechaFinal;
        private System.Windows.Forms.GroupBox groupBoxRANs;
        private System.Windows.Forms.DataGridView dataGridViewRANs;
        private System.Windows.Forms.Label labelDestino;
        private System.Windows.Forms.TextBox textBoxRutaDestino;
        private System.Windows.Forms.Button buttonCargar;
        private System.Windows.Forms.Button buttonCambiarRuta;
        private System.Windows.Forms.LinkLabel linkCarpetaRegistro;
        private System.Windows.Forms.BindingSource remisionesDataTableBindingSource;
        private System.Windows.Forms.BindingSource remisionesDataSetBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn folioRemisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partidasTotalesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pesoTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEntregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn listaRANsDataGridViewTextBoxColumn;
    }
}

