namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class FrmElegirHabitaciones
    {
        public System.Windows.Forms.ComboBox[] txtHabitacion = new System.Windows.Forms.ComboBox[5];
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.labelAviso = new System.Windows.Forms.Label();
            this.txtHabitacion1 = new System.Windows.Forms.ComboBox();
            this.txtHabitacion2 = new System.Windows.Forms.ComboBox();
            this.txtHabitacion3 = new System.Windows.Forms.ComboBox();
            this.txtHabitacion4 = new System.Windows.Forms.ComboBox();
            this.txtHabitacion5 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Habitaciones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Base simple (1 persona)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Base doble (2 personas)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Base triple (3 personas)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Base cuadruple (4 personas)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "King (5 personas)";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(149, 234);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(131, 27);
            this.btnConfirmar.TabIndex = 11;
            this.btnConfirmar.Text = "Confirmar Eleccion";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(18, 234);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(114, 27);
            this.btnVolver.TabIndex = 12;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // labelAviso
            // 
            this.labelAviso.Location = new System.Drawing.Point(43, 188);
            this.labelAviso.Name = "labelAviso";
            this.labelAviso.Size = new System.Drawing.Size(211, 32);
            this.labelAviso.TabIndex = 13;
            this.labelAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHabitacion1
            // 
            this.txtHabitacion1.FormattingEnabled = true;
            this.txtHabitacion1.Location = new System.Drawing.Point(181, 45);
            this.txtHabitacion1.Name = "txtHabitacion1";
            this.txtHabitacion1.Size = new System.Drawing.Size(99, 21);
            this.txtHabitacion1.TabIndex = 14;
            this.txtHabitacion1.SelectedIndexChanged += new System.EventHandler(this.txtHabitacion1_SelectedIndexChanged);
            // 
            // txtHabitacion2
            // 
            this.txtHabitacion2.FormattingEnabled = true;
            this.txtHabitacion2.Location = new System.Drawing.Point(181, 73);
            this.txtHabitacion2.Name = "txtHabitacion2";
            this.txtHabitacion2.Size = new System.Drawing.Size(99, 21);
            this.txtHabitacion2.TabIndex = 15;
            this.txtHabitacion2.SelectedIndexChanged += new System.EventHandler(this.txtHabitacion2_SelectedIndexChanged);
            // 
            // txtHabitacion3
            // 
            this.txtHabitacion3.FormattingEnabled = true;
            this.txtHabitacion3.Location = new System.Drawing.Point(181, 99);
            this.txtHabitacion3.Name = "txtHabitacion3";
            this.txtHabitacion3.Size = new System.Drawing.Size(99, 21);
            this.txtHabitacion3.TabIndex = 16;
            this.txtHabitacion3.SelectedIndexChanged += new System.EventHandler(this.txtHabitacion3_SelectedIndexChanged);
            // 
            // txtHabitacion4
            // 
            this.txtHabitacion4.FormattingEnabled = true;
            this.txtHabitacion4.Location = new System.Drawing.Point(181, 126);
            this.txtHabitacion4.Name = "txtHabitacion4";
            this.txtHabitacion4.Size = new System.Drawing.Size(99, 21);
            this.txtHabitacion4.TabIndex = 17;
            this.txtHabitacion4.SelectedIndexChanged += new System.EventHandler(this.txtHabitacion4_SelectedIndexChanged);
            // 
            // txtHabitacion5
            // 
            this.txtHabitacion5.FormattingEnabled = true;
            this.txtHabitacion5.Location = new System.Drawing.Point(181, 153);
            this.txtHabitacion5.Name = "txtHabitacion5";
            this.txtHabitacion5.Size = new System.Drawing.Size(99, 21);
            this.txtHabitacion5.TabIndex = 18;
            this.txtHabitacion5.SelectedIndexChanged += new System.EventHandler(this.txtHabitacion5_SelectedIndexChanged);
            // 
            // FrmElegirHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.txtHabitacion5);
            this.Controls.Add(this.txtHabitacion4);
            this.Controls.Add(this.txtHabitacion3);
            this.Controls.Add(this.txtHabitacion2);
            this.Controls.Add(this.txtHabitacion1);
            this.Controls.Add(this.labelAviso);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmElegirHabitaciones";
            this.Text = "Elegir Tipo de Habitaciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label labelAviso;
        private System.Windows.Forms.ComboBox txtHabitacion1;
        private System.Windows.Forms.ComboBox txtHabitacion2;
        private System.Windows.Forms.ComboBox txtHabitacion3;
        private System.Windows.Forms.ComboBox txtHabitacion4;
        private System.Windows.Forms.ComboBox txtHabitacion5;
    }
}