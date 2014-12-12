namespace FrbaHotel.Listado_Estadistico
{
    partial class FrmListadoEstadistico
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
            this.label1 = new System.Windows.Forms.Label();
            this.anioSelector = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.trimestreSelector = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxConsultas = new System.Windows.Forms.ComboBox();
            this.gridDatos = new System.Windows.Forms.DataGridView();
            this.botonConsultar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.anioSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trimestreSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccionar Año";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // anioSelector
            // 
            this.anioSelector.Location = new System.Drawing.Point(423, 6);
            this.anioSelector.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.anioSelector.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.anioSelector.Name = "anioSelector";
            this.anioSelector.Size = new System.Drawing.Size(120, 20);
            this.anioSelector.TabIndex = 1;
            this.anioSelector.Value = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.anioSelector.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccionar Trimestre";
            // 
            // trimestreSelector
            // 
            this.trimestreSelector.Location = new System.Drawing.Point(423, 48);
            this.trimestreSelector.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.trimestreSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trimestreSelector.Name = "trimestreSelector";
            this.trimestreSelector.Size = new System.Drawing.Size(120, 20);
            this.trimestreSelector.TabIndex = 3;
            this.trimestreSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Seleccionar Consulta";
            // 
            // comboBoxConsultas
            // 
            this.comboBoxConsultas.FormattingEnabled = true;
            this.comboBoxConsultas.Items.AddRange(new object[] {
            "Hoteles con mayor cantidad de reservas canceladas",
            "Hoteles con mayor cantidad de consumibles facturados",
            "Hoteles con mayor cantidad de dias fuera de servicio",
            "Habitaciones con mayor cantidad de dias ocupados",
            "Habitaciones con mayor cantidad de veces ocupadas",
            "Clientes con mayor cantidad de puntos"});
            this.comboBoxConsultas.Location = new System.Drawing.Point(19, 93);
            this.comboBoxConsultas.Name = "comboBoxConsultas";
            this.comboBoxConsultas.Size = new System.Drawing.Size(524, 21);
            this.comboBoxConsultas.TabIndex = 5;
            this.comboBoxConsultas.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // gridDatos
            // 
            this.gridDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDatos.Location = new System.Drawing.Point(16, 155);
            this.gridDatos.Name = "gridDatos";
            this.gridDatos.Size = new System.Drawing.Size(527, 183);
            this.gridDatos.TabIndex = 6;
            this.gridDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // botonConsultar
            // 
            this.botonConsultar.Location = new System.Drawing.Point(423, 120);
            this.botonConsultar.Name = "botonConsultar";
            this.botonConsultar.Size = new System.Drawing.Size(120, 29);
            this.botonConsultar.TabIndex = 7;
            this.botonConsultar.Text = "Consultar";
            this.botonConsultar.UseVisualStyleBackColor = true;
            this.botonConsultar.Click += new System.EventHandler(this.botonConsultar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(19, 120);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(120, 29);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FrmListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 350);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.botonConsultar);
            this.Controls.Add(this.gridDatos);
            this.Controls.Add(this.comboBoxConsultas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trimestreSelector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.anioSelector);
            this.Controls.Add(this.label1);
            this.Name = "FrmListadoEstadistico";
            this.Text = "Listados Estadisticos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.anioSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trimestreSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown anioSelector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown trimestreSelector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxConsultas;
        private System.Windows.Forms.DataGridView gridDatos;
        private System.Windows.Forms.Button botonConsultar;
        private System.Windows.Forms.Button btnVolver;


    }
}