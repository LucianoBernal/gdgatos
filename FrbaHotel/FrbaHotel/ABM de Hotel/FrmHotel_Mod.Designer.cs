namespace FrbaHotel.ABM_de_Hotel
{
    partial class FrmHotel_Mod
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
            this.txtCadena = new System.Windows.Forms.ComboBox();
            this.cadena = new System.Windows.Forms.Label();
            this.txtNumCalle = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPais = new System.Windows.Forms.ComboBox();
            this.botonGuardar = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.Regimen = new System.Windows.Forms.CheckedListBox();
            this.txtFecha = new System.Windows.Forms.DateTimePicker();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtEstrellas = new System.Windows.Forms.NumericUpDown();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstrellas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCadena
            // 
            this.txtCadena.FormattingEnabled = true;
            this.txtCadena.Location = new System.Drawing.Point(412, 184);
            this.txtCadena.Name = "txtCadena";
            this.txtCadena.Size = new System.Drawing.Size(180, 21);
            this.txtCadena.TabIndex = 10;
            // 
            // cadena
            // 
            this.cadena.AutoSize = true;
            this.cadena.Location = new System.Drawing.Point(340, 187);
            this.cadena.Name = "cadena";
            this.cadena.Size = new System.Drawing.Size(47, 13);
            this.cadena.TabIndex = 49;
            this.cadena.Text = "Cadena:";
            // 
            // txtNumCalle
            // 
            this.txtNumCalle.Location = new System.Drawing.Point(412, 102);
            this.txtNumCalle.Name = "txtNumCalle";
            this.txtNumCalle.Size = new System.Drawing.Size(180, 20);
            this.txtNumCalle.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(340, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Numero:";
            // 
            // txtPais
            // 
            this.txtPais.FormattingEnabled = true;
            this.txtPais.Location = new System.Drawing.Point(412, 142);
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(180, 21);
            this.txtPais.TabIndex = 9;
            // 
            // botonGuardar
            // 
            this.botonGuardar.Location = new System.Drawing.Point(491, 368);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(98, 30);
            this.botonGuardar.TabIndex = 12;
            this.botonGuardar.Text = "Guardar";
            this.botonGuardar.UseVisualStyleBackColor = true;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(23, 368);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(98, 30);
            this.botonVolver.TabIndex = 14;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Tipo de Regimen:";
            // 
            // Regimen
            // 
            this.Regimen.CheckOnClick = true;
            this.Regimen.FormattingEnabled = true;
            this.Regimen.Location = new System.Drawing.Point(124, 232);
            this.Regimen.Name = "Regimen";
            this.Regimen.Size = new System.Drawing.Size(219, 94);
            this.Regimen.TabIndex = 11;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(124, 184);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(200, 20);
            this.txtFecha.TabIndex = 5;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(124, 142);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(180, 20);
            this.txtCiudad.TabIndex = 4;
            // 
            // txtEstrellas
            // 
            this.txtEstrellas.Location = new System.Drawing.Point(412, 62);
            this.txtEstrellas.Name = "txtEstrellas";
            this.txtEstrellas.Size = new System.Drawing.Size(120, 20);
            this.txtEstrellas.TabIndex = 7;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(124, 102);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(180, 20);
            this.txtDireccion.TabIndex = 3;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(124, 62);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(180, 20);
            this.txtTelefono.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(412, 23);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(180, 20);
            this.txtEmail.TabIndex = 6;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(124, 23);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(180, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(340, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "País:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Fecha de Creación:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Ciudad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Estrellas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Dirección:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Teléfono:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Nombre:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCadena);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.Regimen);
            this.groupBox1.Controls.Add(this.cadena);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNumCalle);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPais);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtFecha);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.txtCiudad);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.txtEstrellas);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 336);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Hotel";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(257, 368);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(98, 30);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FrmHotel_Mod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 415);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.botonGuardar);
            this.Controls.Add(this.botonVolver);
            this.Name = "FrmHotel_Mod";
            this.Text = "Modificacion de Hotel";
            this.Load += new System.EventHandler(this.FrmHotel_Mod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtEstrellas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox txtCadena;
        private System.Windows.Forms.Label cadena;
        private System.Windows.Forms.TextBox txtNumCalle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox txtPais;
        private System.Windows.Forms.Button botonGuardar;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckedListBox Regimen;
        private System.Windows.Forms.DateTimePicker txtFecha;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.NumericUpDown txtEstrellas;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLimpiar;
    }
}