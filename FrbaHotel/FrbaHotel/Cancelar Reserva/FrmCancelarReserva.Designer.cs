namespace FrbaHotel.Cancelar_Reserva
{
    partial class FrmCancelarReserva
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
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtOcultoReserva = new System.Windows.Forms.TextBox();
            this.txtOcultoFecha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(38, 45);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(218, 20);
            this.txtMotivo.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(165, 88);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(104, 23);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(26, 82);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 28);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Volver";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtOcultoReserva
            // 
            this.txtOcultoReserva.Location = new System.Drawing.Point(44, 185);
            this.txtOcultoReserva.Name = "txtOcultoReserva";
            this.txtOcultoReserva.Size = new System.Drawing.Size(31, 20);
            this.txtOcultoReserva.TabIndex = 3;
            this.txtOcultoReserva.Visible = false;
            // 
            // txtOcultoFecha
            // 
            this.txtOcultoFecha.Location = new System.Drawing.Point(161, 186);
            this.txtOcultoFecha.Name = "txtOcultoFecha";
            this.txtOcultoFecha.Size = new System.Drawing.Size(95, 20);
            this.txtOcultoFecha.TabIndex = 4;
            this.txtOcultoFecha.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Motivo de la Cancelacion:";
            // 
            // FrmCancelarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 135);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOcultoFecha);
            this.Controls.Add(this.txtOcultoReserva);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtMotivo);
            this.Name = "FrmCancelarReserva";
            this.Text = "Cancelar Reserva";
            this.Load += new System.EventHandler(this.FrmCancelarReserva_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtOcultoReserva;
        private System.Windows.Forms.TextBox txtOcultoFecha;
        private System.Windows.Forms.Label label1;
    }
}