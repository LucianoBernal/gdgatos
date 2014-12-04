namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class FrmReserva
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dataResultado = new System.Windows.Forms.DataGridView();
            this.cbRegimen = new System.Windows.Forms.CheckBox();
            this.cbCiudad = new System.Windows.Forms.CheckBox();
            this.cbNombre = new System.Windows.Forms.CheckBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtRegimenBusq = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.btnRunBaby = new System.Windows.Forms.Button();
            this.txtRegimenIns = new System.Windows.Forms.ComboBox();
            this.txtCantHuespedes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOcultoRegimenBusq = new System.Windows.Forms.TextBox();
            this.txtOcultoTipoHabBusq = new System.Windows.Forms.TextBox();
            this.txtOcultoRegimenIns = new System.Windows.Forms.TextBox();
            this.txtOcultoTipoHabIns = new System.Windows.Forms.TextBox();
            this.txtOcultoFechaDesde = new System.Windows.Forms.TextBox();
            this.txtOcultoCantNoches = new System.Windows.Forms.TextBox();
            this.txtOcultoHotel = new System.Windows.Forms.TextBox();
            this.txtOcultoCliente = new System.Windows.Forms.TextBox();
            this.txtDisponibilidad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataResultado)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.dataResultado);
            this.groupBox1.Controls.Add(this.cbRegimen);
            this.groupBox1.Controls.Add(this.cbCiudad);
            this.groupBox1.Controls.Add(this.cbNombre);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.txtCiudad);
            this.groupBox1.Controls.Add(this.txtRegimenBusq);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(22, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar Hotel";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(69, 136);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dataResultado
            // 
            this.dataResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataResultado.Location = new System.Drawing.Point(200, 25);
            this.dataResultado.Name = "dataResultado";
            this.dataResultado.Size = new System.Drawing.Size(230, 120);
            this.dataResultado.TabIndex = 12;
            // 
            // cbRegimen
            // 
            this.cbRegimen.AutoSize = true;
            this.cbRegimen.Location = new System.Drawing.Point(179, 112);
            this.cbRegimen.Name = "cbRegimen";
            this.cbRegimen.Size = new System.Drawing.Size(15, 14);
            this.cbRegimen.TabIndex = 10;
            this.cbRegimen.UseVisualStyleBackColor = true;
            // 
            // cbCiudad
            // 
            this.cbCiudad.AutoSize = true;
            this.cbCiudad.Location = new System.Drawing.Point(179, 76);
            this.cbCiudad.Name = "cbCiudad";
            this.cbCiudad.Size = new System.Drawing.Size(15, 14);
            this.cbCiudad.TabIndex = 9;
            this.cbCiudad.UseVisualStyleBackColor = true;
            // 
            // cbNombre
            // 
            this.cbNombre.AutoSize = true;
            this.cbNombre.Location = new System.Drawing.Point(179, 38);
            this.cbNombre.Name = "cbNombre";
            this.cbNombre.Size = new System.Drawing.Size(15, 14);
            this.cbNombre.TabIndex = 8;
            this.cbNombre.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(70, 35);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(102, 20);
            this.txtNombre.TabIndex = 7;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(69, 73);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(102, 20);
            this.txtCiudad.TabIndex = 6;
            // 
            // txtRegimenBusq
            // 
            this.txtRegimenBusq.FormattingEnabled = true;
            this.txtRegimenBusq.Location = new System.Drawing.Point(69, 109);
            this.txtRegimenBusq.Name = "txtRegimenBusq";
            this.txtRegimenBusq.Size = new System.Drawing.Size(103, 21);
            this.txtRegimenBusq.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Regimen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ciudad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtDisponibilidad);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtpFechaHasta);
            this.groupBox2.Controls.Add(this.dtpFechaDesde);
            this.groupBox2.Controls.Add(this.btnRunBaby);
            this.groupBox2.Controls.Add(this.txtRegimenIns);
            this.groupBox2.Controls.Add(this.txtCantHuespedes);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(22, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(447, 211);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Reserva";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Fecha de salida";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fecha de ingreso";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Location = new System.Drawing.Point(131, 112);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(195, 20);
            this.dtpFechaHasta.TabIndex = 8;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Location = new System.Drawing.Point(131, 86);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(195, 20);
            this.dtpFechaDesde.TabIndex = 7;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // btnRunBaby
            // 
            this.btnRunBaby.Enabled = false;
            this.btnRunBaby.Location = new System.Drawing.Point(219, 169);
            this.btnRunBaby.Name = "btnRunBaby";
            this.btnRunBaby.Size = new System.Drawing.Size(107, 25);
            this.btnRunBaby.TabIndex = 6;
            this.btnRunBaby.Text = "btnPiolin";
            this.btnRunBaby.UseVisualStyleBackColor = true;
            this.btnRunBaby.Click += new System.EventHandler(this.btnRunBaby_Click);
            // 
            // txtRegimenIns
            // 
            this.txtRegimenIns.FormattingEnabled = true;
            this.txtRegimenIns.Location = new System.Drawing.Point(185, 59);
            this.txtRegimenIns.Name = "txtRegimenIns";
            this.txtRegimenIns.Size = new System.Drawing.Size(125, 21);
            this.txtRegimenIns.TabIndex = 4;
            this.txtRegimenIns.SelectedIndexChanged += new System.EventHandler(this.txtRegimenIns_SelectedIndexChanged);
            // 
            // txtCantHuespedes
            // 
            this.txtCantHuespedes.Location = new System.Drawing.Point(185, 31);
            this.txtCantHuespedes.Name = "txtCantHuespedes";
            this.txtCantHuespedes.Size = new System.Drawing.Size(125, 20);
            this.txtCantHuespedes.TabIndex = 3;
            this.txtCantHuespedes.TextChanged += new System.EventHandler(this.txtCantHuespedes_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Regimen de reserva";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cantidad de huespedes";
            // 
            // txtOcultoRegimenBusq
            // 
            this.txtOcultoRegimenBusq.Location = new System.Drawing.Point(539, 48);
            this.txtOcultoRegimenBusq.Name = "txtOcultoRegimenBusq";
            this.txtOcultoRegimenBusq.Size = new System.Drawing.Size(42, 20);
            this.txtOcultoRegimenBusq.TabIndex = 2;
            this.txtOcultoRegimenBusq.Visible = false;
            // 
            // txtOcultoTipoHabBusq
            // 
            this.txtOcultoTipoHabBusq.Location = new System.Drawing.Point(546, 89);
            this.txtOcultoTipoHabBusq.Name = "txtOcultoTipoHabBusq";
            this.txtOcultoTipoHabBusq.Size = new System.Drawing.Size(34, 20);
            this.txtOcultoTipoHabBusq.TabIndex = 3;
            this.txtOcultoTipoHabBusq.Visible = false;
            // 
            // txtOcultoRegimenIns
            // 
            this.txtOcultoRegimenIns.Location = new System.Drawing.Point(540, 130);
            this.txtOcultoRegimenIns.Name = "txtOcultoRegimenIns";
            this.txtOcultoRegimenIns.Size = new System.Drawing.Size(53, 20);
            this.txtOcultoRegimenIns.TabIndex = 4;
            this.txtOcultoRegimenIns.Visible = false;
            // 
            // txtOcultoTipoHabIns
            // 
            this.txtOcultoTipoHabIns.Location = new System.Drawing.Point(541, 174);
            this.txtOcultoTipoHabIns.Name = "txtOcultoTipoHabIns";
            this.txtOcultoTipoHabIns.Size = new System.Drawing.Size(67, 20);
            this.txtOcultoTipoHabIns.TabIndex = 5;
            this.txtOcultoTipoHabIns.Visible = false;
            // 
            // txtOcultoFechaDesde
            // 
            this.txtOcultoFechaDesde.Location = new System.Drawing.Point(541, 201);
            this.txtOcultoFechaDesde.Name = "txtOcultoFechaDesde";
            this.txtOcultoFechaDesde.Size = new System.Drawing.Size(75, 20);
            this.txtOcultoFechaDesde.TabIndex = 6;
            this.txtOcultoFechaDesde.Visible = false;
            // 
            // txtOcultoCantNoches
            // 
            this.txtOcultoCantNoches.Location = new System.Drawing.Point(539, 229);
            this.txtOcultoCantNoches.Name = "txtOcultoCantNoches";
            this.txtOcultoCantNoches.Size = new System.Drawing.Size(76, 20);
            this.txtOcultoCantNoches.TabIndex = 7;
            this.txtOcultoCantNoches.Visible = false;
            // 
            // txtOcultoHotel
            // 
            this.txtOcultoHotel.Location = new System.Drawing.Point(553, 272);
            this.txtOcultoHotel.Name = "txtOcultoHotel";
            this.txtOcultoHotel.Size = new System.Drawing.Size(61, 20);
            this.txtOcultoHotel.TabIndex = 8;
            // 
            // txtOcultoCliente
            // 
            this.txtOcultoCliente.Location = new System.Drawing.Point(550, 302);
            this.txtOcultoCliente.Name = "txtOcultoCliente";
            this.txtOcultoCliente.Size = new System.Drawing.Size(65, 20);
            this.txtOcultoCliente.TabIndex = 9;
            this.txtOcultoCliente.Visible = false;
            // 
            // txtDisponibilidad
            // 
            this.txtDisponibilidad.Enabled = false;
            this.txtDisponibilidad.Location = new System.Drawing.Point(23, 169);
            this.txtDisponibilidad.Name = "txtDisponibilidad";
            this.txtDisponibilidad.Size = new System.Drawing.Size(148, 20);
            this.txtDisponibilidad.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Disponibilidad";
            // 
            // FrmReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 424);
            this.Controls.Add(this.txtOcultoCliente);
            this.Controls.Add(this.txtOcultoHotel);
            this.Controls.Add(this.txtOcultoCantNoches);
            this.Controls.Add(this.txtOcultoFechaDesde);
            this.Controls.Add(this.txtOcultoTipoHabIns);
            this.Controls.Add(this.txtOcultoRegimenIns);
            this.Controls.Add(this.txtOcultoTipoHabBusq);
            this.Controls.Add(this.txtOcultoRegimenBusq);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmReserva";
            this.Text = "frmReserva";
            this.Load += new System.EventHandler(this.FrmReserva_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataResultado)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataResultado;
        private System.Windows.Forms.CheckBox cbRegimen;
        private System.Windows.Forms.CheckBox cbCiudad;
        private System.Windows.Forms.CheckBox cbNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.ComboBox txtRegimenBusq;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRunBaby;
        private System.Windows.Forms.ComboBox txtRegimenIns;
        private System.Windows.Forms.TextBox txtCantHuespedes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOcultoRegimenBusq;
        private System.Windows.Forms.TextBox txtOcultoTipoHabBusq;
        private System.Windows.Forms.TextBox txtOcultoRegimenIns;
        private System.Windows.Forms.TextBox txtOcultoTipoHabIns;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.TextBox txtOcultoFechaDesde;
        private System.Windows.Forms.TextBox txtOcultoCantNoches;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtOcultoHotel;
        private System.Windows.Forms.TextBox txtOcultoCliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDisponibilidad;
    }
}