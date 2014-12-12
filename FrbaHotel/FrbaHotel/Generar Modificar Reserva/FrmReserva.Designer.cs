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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.numCantHuesp = new System.Windows.Forms.NumericUpDown();
            this.txtHotel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnComprobarDisponibilidad = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDisponibilidad = new System.Windows.Forms.TextBox();
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
            this.txtValorEstado = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantHuesp)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnVolver);
            this.groupBox2.Controls.Add(this.numCantHuesp);
            this.groupBox2.Controls.Add(this.txtHotel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnComprobarDisponibilidad);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(447, 260);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Reserva";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(14, 211);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(112, 23);
            this.btnVolver.TabIndex = 17;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // numCantHuesp
            // 
            this.numCantHuesp.Location = new System.Drawing.Point(241, 69);
            this.numCantHuesp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCantHuesp.Name = "numCantHuesp";
            this.numCantHuesp.Size = new System.Drawing.Size(127, 20);
            this.numCantHuesp.TabIndex = 16;
            this.numCantHuesp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCantHuesp.ValueChanged += new System.EventHandler(this.numCantHuesp_ValueChanged);
            // 
            // txtHotel
            // 
            this.txtHotel.Enabled = false;
            this.txtHotel.Location = new System.Drawing.Point(241, 38);
            this.txtHotel.Name = "txtHotel";
            this.txtHotel.Size = new System.Drawing.Size(125, 20);
            this.txtHotel.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Hotel";
            // 
            // btnComprobarDisponibilidad
            // 
            this.btnComprobarDisponibilidad.Location = new System.Drawing.Point(145, 211);
            this.btnComprobarDisponibilidad.Name = "btnComprobarDisponibilidad";
            this.btnComprobarDisponibilidad.Size = new System.Drawing.Size(135, 24);
            this.btnComprobarDisponibilidad.TabIndex = 13;
            this.btnComprobarDisponibilidad.Text = "Comprobar Disponibilidad";
            this.btnComprobarDisponibilidad.UseVisualStyleBackColor = true;
            this.btnComprobarDisponibilidad.Click += new System.EventHandler(this.btnComprobarDisponibilidad_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(70, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Disponibilidad";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtDisponibilidad
            // 
            this.txtDisponibilidad.Enabled = false;
            this.txtDisponibilidad.Location = new System.Drawing.Point(241, 181);
            this.txtDisponibilidad.Name = "txtDisponibilidad";
            this.txtDisponibilidad.Size = new System.Drawing.Size(125, 20);
            this.txtDisponibilidad.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(70, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Fecha de salida";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fecha de ingreso";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Location = new System.Drawing.Point(187, 149);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(195, 20);
            this.dtpFechaHasta.TabIndex = 8;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Location = new System.Drawing.Point(187, 123);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(195, 20);
            this.dtpFechaDesde.TabIndex = 7;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // btnRunBaby
            // 
            this.btnRunBaby.Enabled = false;
            this.btnRunBaby.Location = new System.Drawing.Point(299, 210);
            this.btnRunBaby.Name = "btnRunBaby";
            this.btnRunBaby.Size = new System.Drawing.Size(125, 25);
            this.btnRunBaby.TabIndex = 6;
            this.btnRunBaby.Text = "btnPiolin";
            this.btnRunBaby.UseVisualStyleBackColor = true;
            this.btnRunBaby.Click += new System.EventHandler(this.btnRunBaby_Click);
            // 
            // txtRegimenIns
            // 
            this.txtRegimenIns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRegimenIns.FormattingEnabled = true;
            this.txtRegimenIns.Location = new System.Drawing.Point(241, 96);
            this.txtRegimenIns.Name = "txtRegimenIns";
            this.txtRegimenIns.Size = new System.Drawing.Size(125, 21);
            this.txtRegimenIns.TabIndex = 4;
            this.txtRegimenIns.SelectedIndexChanged += new System.EventHandler(this.txtRegimenIns_SelectedIndexChanged);
            // 
            // txtCantHuespedes
            // 
            this.txtCantHuespedes.Location = new System.Drawing.Point(383, 68);
            this.txtCantHuespedes.Name = "txtCantHuespedes";
            this.txtCantHuespedes.Size = new System.Drawing.Size(41, 20);
            this.txtCantHuespedes.TabIndex = 3;
            this.txtCantHuespedes.Visible = false;
            this.txtCantHuespedes.TextChanged += new System.EventHandler(this.txtCantHuespedes_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Regimen de reserva";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 71);
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
            // txtValorEstado
            // 
            this.txtValorEstado.Location = new System.Drawing.Point(541, 252);
            this.txtValorEstado.Name = "txtValorEstado";
            this.txtValorEstado.Size = new System.Drawing.Size(83, 20);
            this.txtValorEstado.TabIndex = 10;
            this.txtValorEstado.Text = "3";
            this.txtValorEstado.Visible = false;
            // 
            // FrmReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 284);
            this.Controls.Add(this.txtValorEstado);
            this.Controls.Add(this.txtOcultoCliente);
            this.Controls.Add(this.txtOcultoHotel);
            this.Controls.Add(this.txtOcultoCantNoches);
            this.Controls.Add(this.txtOcultoFechaDesde);
            this.Controls.Add(this.txtOcultoTipoHabIns);
            this.Controls.Add(this.txtOcultoRegimenIns);
            this.Controls.Add(this.txtOcultoTipoHabBusq);
            this.Controls.Add(this.txtOcultoRegimenBusq);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmReserva";
            this.Text = "frmReserva";
            this.Load += new System.EventHandler(this.FrmReserva_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantHuesp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDisponibilidad;
        private System.Windows.Forms.TextBox txtOcultoFechaDesde;
        private System.Windows.Forms.TextBox txtOcultoCantNoches;
        private System.Windows.Forms.TextBox txtOcultoHotel;
        private System.Windows.Forms.TextBox txtOcultoCliente;
        private System.Windows.Forms.TextBox txtValorEstado;
        private System.Windows.Forms.Button btnComprobarDisponibilidad;
        private System.Windows.Forms.TextBox txtHotel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numCantHuesp;
        private System.Windows.Forms.Button btnVolver;
    }
}