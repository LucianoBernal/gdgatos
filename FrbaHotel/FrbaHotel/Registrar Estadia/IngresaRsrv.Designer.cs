namespace FrbaHotel.Registrar_Estadia
{
    partial class IngresaRsrv
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
            this.botonIngresar = new System.Windows.Forms.Button();
            this.labelRsrv = new System.Windows.Forms.Label();
            this.txtReserva = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // botonIngresar
            // 
            this.botonIngresar.Location = new System.Drawing.Point(121, 125);
            this.botonIngresar.Name = "botonIngresar";
            this.botonIngresar.Size = new System.Drawing.Size(75, 23);
            this.botonIngresar.TabIndex = 0;
            this.botonIngresar.Text = "Ingresar";
            this.botonIngresar.UseVisualStyleBackColor = true;
            this.botonIngresar.Click += new System.EventHandler(this.botonIngresar_Click);
            // 
            // labelRsrv
            // 
            this.labelRsrv.AutoSize = true;
            this.labelRsrv.Location = new System.Drawing.Point(60, 48);
            this.labelRsrv.Name = "labelRsrv";
            this.labelRsrv.Size = new System.Drawing.Size(136, 13);
            this.labelRsrv.TabIndex = 1;
            this.labelRsrv.Text = "Ingrese número de reserva:";
            // 
            // txtReserva
            // 
            this.txtReserva.Location = new System.Drawing.Point(63, 74);
            this.txtReserva.Name = "txtReserva";
            this.txtReserva.Size = new System.Drawing.Size(133, 20);
            this.txtReserva.TabIndex = 2;
            // 
            // IngresaRsrv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 266);
            this.Controls.Add(this.txtReserva);
            this.Controls.Add(this.labelRsrv);
            this.Controls.Add(this.botonIngresar);
            this.Name = "IngresaRsrv";
            this.Text = "IngresaRsrv";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonIngresar;
        private System.Windows.Forms.Label labelRsrv;
        private System.Windows.Forms.TextBox txtReserva;
    }
}