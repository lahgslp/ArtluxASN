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
            this.labelDestino = new System.Windows.Forms.Label();
            this.textBoxRutaDestino = new System.Windows.Forms.TextBox();
            this.buttonCargar = new System.Windows.Forms.Button();
            this.buttonCambiarRuta = new System.Windows.Forms.Button();
            this.linkCarpetaRegistro = new System.Windows.Forms.LinkLabel();
            this.rANDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCreacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.claveProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaEnvioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pesoBrutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDePartidasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadTotalRemisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxRANs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRANs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rANDataTableBindingSource)).BeginInit();
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
            this.dataGridViewRANs.AllowUserToOrderColumns = true;
            this.dataGridViewRANs.AutoGenerateColumns = false;
            this.dataGridViewRANs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRANs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rANDataGridViewTextBoxColumn,
            this.remisionDataGridViewTextBoxColumn,
            this.fechaCreacionDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.claveProductoDataGridViewTextBoxColumn,
            this.fechaEnvioDataGridViewTextBoxColumn,
            this.pesoBrutoDataGridViewTextBoxColumn,
            this.numeroDePartidasDataGridViewTextBoxColumn,
            this.cantidadTotalRemisionDataGridViewTextBoxColumn});
            this.dataGridViewRANs.DataSource = this.rANDataTableBindingSource;
            this.dataGridViewRANs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRANs.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewRANs.Name = "dataGridViewRANs";
            this.dataGridViewRANs.Size = new System.Drawing.Size(730, 205);
            this.dataGridViewRANs.TabIndex = 0;
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
            // rANDataTableBindingSource
            // 
            this.rANDataTableBindingSource.DataMember = "RANDataTable";
            this.rANDataTableBindingSource.DataSource = typeof(GeneradorASN.Entities.RANDataSet);
            // 
            // rANDataGridViewTextBoxColumn
            // 
            this.rANDataGridViewTextBoxColumn.DataPropertyName = "RAN";
            this.rANDataGridViewTextBoxColumn.HeaderText = "RAN";
            this.rANDataGridViewTextBoxColumn.Name = "rANDataGridViewTextBoxColumn";
            // 
            // remisionDataGridViewTextBoxColumn
            // 
            this.remisionDataGridViewTextBoxColumn.DataPropertyName = "Remision";
            this.remisionDataGridViewTextBoxColumn.HeaderText = "Remision";
            this.remisionDataGridViewTextBoxColumn.Name = "remisionDataGridViewTextBoxColumn";
            // 
            // fechaCreacionDataGridViewTextBoxColumn
            // 
            this.fechaCreacionDataGridViewTextBoxColumn.DataPropertyName = "FechaCreacion";
            this.fechaCreacionDataGridViewTextBoxColumn.HeaderText = "FechaCreacion";
            this.fechaCreacionDataGridViewTextBoxColumn.Name = "fechaCreacionDataGridViewTextBoxColumn";
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            // 
            // claveProductoDataGridViewTextBoxColumn
            // 
            this.claveProductoDataGridViewTextBoxColumn.DataPropertyName = "ClaveProducto";
            this.claveProductoDataGridViewTextBoxColumn.HeaderText = "ClaveProducto";
            this.claveProductoDataGridViewTextBoxColumn.Name = "claveProductoDataGridViewTextBoxColumn";
            // 
            // fechaEnvioDataGridViewTextBoxColumn
            // 
            this.fechaEnvioDataGridViewTextBoxColumn.DataPropertyName = "FechaEnvio";
            this.fechaEnvioDataGridViewTextBoxColumn.HeaderText = "FechaEnvio";
            this.fechaEnvioDataGridViewTextBoxColumn.Name = "fechaEnvioDataGridViewTextBoxColumn";
            // 
            // pesoBrutoDataGridViewTextBoxColumn
            // 
            this.pesoBrutoDataGridViewTextBoxColumn.DataPropertyName = "PesoBruto";
            this.pesoBrutoDataGridViewTextBoxColumn.HeaderText = "PesoBruto";
            this.pesoBrutoDataGridViewTextBoxColumn.Name = "pesoBrutoDataGridViewTextBoxColumn";
            // 
            // numeroDePartidasDataGridViewTextBoxColumn
            // 
            this.numeroDePartidasDataGridViewTextBoxColumn.DataPropertyName = "NumeroDePartidas";
            this.numeroDePartidasDataGridViewTextBoxColumn.HeaderText = "NumeroDePartidas";
            this.numeroDePartidasDataGridViewTextBoxColumn.Name = "numeroDePartidasDataGridViewTextBoxColumn";
            // 
            // cantidadTotalRemisionDataGridViewTextBoxColumn
            // 
            this.cantidadTotalRemisionDataGridViewTextBoxColumn.DataPropertyName = "CantidadTotalRemision";
            this.cantidadTotalRemisionDataGridViewTextBoxColumn.HeaderText = "CantidadTotalRemision";
            this.cantidadTotalRemisionDataGridViewTextBoxColumn.Name = "cantidadTotalRemisionDataGridViewTextBoxColumn";
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
            ((System.ComponentModel.ISupportInitialize)(this.rANDataTableBindingSource)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn rANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCreacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn claveProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEnvioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pesoBrutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDePartidasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadTotalRemisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource rANDataTableBindingSource;
    }
}

