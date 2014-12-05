namespace FrbaHotel.ABM_de_Habitacion
{
    partial class FrmHabitacion_Alta
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
            this.botonGuardar = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOcultoHotel = new System.Windows.Forms.TextBox();
            this.txtOcultoTipo = new System.Windows.Forms.TextBox();
            this.txtBaja = new System.Windows.Forms.CheckBox();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHotel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPiso = new System.Windows.Forms.NumericUpDown();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPiso)).BeginInit();
            this.SuspendLayout();
            // 
            // botonGuardar
            // 
            this.botonGuardar.Location = new System.Drawing.Point(449, 170);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(98, 30);
            this.botonGuardar.TabIndex = 77;
            this.botonGuardar.Text = "Guardar";
            this.botonGuardar.UseVisualStyleBackColor = true;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(32, 170);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(98, 30);
            this.botonVolver.TabIndex = 76;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPiso);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.txtTipo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtHotel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtOcultoHotel);
            this.groupBox1.Controls.Add(this.txtOcultoTipo);
            this.groupBox1.Controls.Add(this.txtBaja);
            this.groupBox1.Controls.Add(this.txtUbicacion);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 143);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Habitacion";
            // 
            // txtOcultoHotel
            // 
            this.txtOcultoHotel.Location = new System.Drawing.Point(389, 112);
            this.txtOcultoHotel.Name = "txtOcultoHotel";
            this.txtOcultoHotel.Size = new System.Drawing.Size(47, 20);
            this.txtOcultoHotel.TabIndex = 73;
            this.txtOcultoHotel.Visible = false;
            // 
            // txtOcultoTipo
            // 
            this.txtOcultoTipo.Location = new System.Drawing.Point(442, 112);
            this.txtOcultoTipo.Name = "txtOcultoTipo";
            this.txtOcultoTipo.Size = new System.Drawing.Size(47, 20);
            this.txtOcultoTipo.TabIndex = 72;
            this.txtOcultoTipo.Visible = false;
            // 
            // txtBaja
            // 
            this.txtBaja.AutoSize = true;
            this.txtBaja.Location = new System.Drawing.Point(204, 115);
            this.txtBaja.Name = "txtBaja";
            this.txtBaja.Size = new System.Drawing.Size(91, 17);
            this.txtBaja.TabIndex = 68;
            this.txtBaja.Text = "Dado de Baja";
            this.txtBaja.UseVisualStyleBackColor = true;
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(357, 19);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(178, 20);
            this.txtUbicacion.TabIndex = 44;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(73, 19);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(178, 20);
            this.txtNumero.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Ubicacion:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Numero:";
            // 
            // txtTipo
            // 
            this.txtTipo.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtTipo.FormattingEnabled = true;
            this.txtTipo.Location = new System.Drawing.Point(357, 53);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(178, 21);
            this.txtTipo.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "Tipo de Habitación: ";
            // 
            // txtHotel
            // 
            this.txtHotel.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtHotel.FormattingEnabled = true;
            this.txtHotel.Location = new System.Drawing.Point(73, 53);
            this.txtHotel.Name = "txtHotel";
            this.txtHotel.Size = new System.Drawing.Size(178, 21);
            this.txtHotel.TabIndex = 74;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "Hotel:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(357, 86);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(178, 20);
            this.txtDescripcion.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 79;
            this.label2.Text = "Descripcion:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 80;
            this.label5.Text = "Piso:";
            // 
            // txtPiso
            // 
            this.txtPiso.Location = new System.Drawing.Point(73, 86);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(120, 20);
            this.txtPiso.TabIndex = 81;
            this.txtPiso.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(240, 170);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(98, 30);
            this.btnLimpiar.TabIndex = 78;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmHabitacion_Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 217);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.botonGuardar);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmHabitacion_Alta";
            this.Text = "Alta de Habitacion";
            this.Load += new System.EventHandler(this.FrmHabitacion_Alta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPiso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonGuardar;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtOcultoHotel;
        private System.Windows.Forms.TextBox txtOcultoTipo;
        private System.Windows.Forms.CheckBox txtBaja;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtPiso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox txtTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtHotel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLimpiar;
    }
}