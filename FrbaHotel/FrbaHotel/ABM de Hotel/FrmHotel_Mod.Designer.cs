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
            ((System.ComponentModel.ISupportInitialize)(this.txtEstrellas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCadena
            // 
            this.txtCadena.FormattingEnabled = true;
            this.txtCadena.Location = new System.Drawing.Point(416, 181);
            this.txtCadena.Name = "txtCadena";
            this.txtCadena.Size = new System.Drawing.Size(180, 21);
            this.txtCadena.TabIndex = 50;
            // 
            // cadena
            // 
            this.cadena.AutoSize = true;
            this.cadena.Location = new System.Drawing.Point(344, 184);
            this.cadena.Name = "cadena";
            this.cadena.Size = new System.Drawing.Size(47, 13);
            this.cadena.TabIndex = 49;
            this.cadena.Text = "Cadena:";
            // 
            // txtNumCalle
            // 
            this.txtNumCalle.Location = new System.Drawing.Point(416, 99);
            this.txtNumCalle.Name = "txtNumCalle";
            this.txtNumCalle.Size = new System.Drawing.Size(180, 20);
            this.txtNumCalle.TabIndex = 48;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(344, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Numero:";
            // 
            // txtPais
            // 
            this.txtPais.FormattingEnabled = true;
            this.txtPais.Location = new System.Drawing.Point(416, 139);
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(180, 21);
            this.txtPais.TabIndex = 46;
            // 
            // botonGuardar
            // 
            this.botonGuardar.Location = new System.Drawing.Point(488, 334);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(98, 30);
            this.botonGuardar.TabIndex = 44;
            this.botonGuardar.Text = "Guardar";
            this.botonGuardar.UseVisualStyleBackColor = true;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(20, 334);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(98, 30);
            this.botonVolver.TabIndex = 43;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Tipo de Regimen:";
            // 
            // Regimen
            // 
            this.Regimen.CheckOnClick = true;
            this.Regimen.FormattingEnabled = true;
            this.Regimen.Location = new System.Drawing.Point(128, 224);
            this.Regimen.Name = "Regimen";
            this.Regimen.Size = new System.Drawing.Size(219, 79);
            this.Regimen.TabIndex = 41;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(128, 181);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(200, 20);
            this.txtFecha.TabIndex = 40;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(128, 139);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(180, 20);
            this.txtCiudad.TabIndex = 39;
            // 
            // txtEstrellas
            // 
            this.txtEstrellas.Location = new System.Drawing.Point(416, 59);
            this.txtEstrellas.Name = "txtEstrellas";
            this.txtEstrellas.Size = new System.Drawing.Size(120, 20);
            this.txtEstrellas.TabIndex = 38;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(128, 99);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(180, 20);
            this.txtDireccion.TabIndex = 37;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(128, 59);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(180, 20);
            this.txtTelefono.TabIndex = 36;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(416, 20);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(180, 20);
            this.txtEmail.TabIndex = 35;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(128, 20);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(180, 20);
            this.txtNombre.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(344, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "País:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Fecha de Creación:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Ciudad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(344, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Estrellas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Dirección:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Teléfono:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Nombre:";
            // 
            // FrmHotel_Mod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 384);
            this.Controls.Add(this.txtCadena);
            this.Controls.Add(this.cadena);
            this.Controls.Add(this.txtNumCalle);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPais);
            this.Controls.Add(this.botonGuardar);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Regimen);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtCiudad);
            this.Controls.Add(this.txtEstrellas);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmHotel_Mod";
            this.Text = "FrmHotel_Mod";
            this.Load += new System.EventHandler(this.FrmHotel_Mod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtEstrellas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}