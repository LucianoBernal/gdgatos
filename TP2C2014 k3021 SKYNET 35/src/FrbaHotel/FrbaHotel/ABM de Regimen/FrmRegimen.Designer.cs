namespace FrbaHotel.ABM_de_Regimen
{
    partial class FrmRegimenes
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
            this.botonVolver = new System.Windows.Forms.Button();
            this.botonBaja = new System.Windows.Forms.Button();
            this.botonModificacion = new System.Windows.Forms.Button();
            this.botonAlta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(92, 190);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(100, 31);
            this.botonVolver.TabIndex = 8;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // botonBaja
            // 
            this.botonBaja.Location = new System.Drawing.Point(92, 113);
            this.botonBaja.Name = "botonBaja";
            this.botonBaja.Size = new System.Drawing.Size(100, 31);
            this.botonBaja.TabIndex = 7;
            this.botonBaja.Text = "Baja";
            this.botonBaja.UseVisualStyleBackColor = true;
            this.botonBaja.Click += new System.EventHandler(this.botonBaja_Click);
            // 
            // botonModificacion
            // 
            this.botonModificacion.Location = new System.Drawing.Point(92, 76);
            this.botonModificacion.Name = "botonModificacion";
            this.botonModificacion.Size = new System.Drawing.Size(100, 31);
            this.botonModificacion.TabIndex = 6;
            this.botonModificacion.Text = "Modificación";
            this.botonModificacion.UseVisualStyleBackColor = true;
            this.botonModificacion.Click += new System.EventHandler(this.botonModificacion_Click);
            // 
            // botonAlta
            // 
            this.botonAlta.Location = new System.Drawing.Point(92, 39);
            this.botonAlta.Name = "botonAlta";
            this.botonAlta.Size = new System.Drawing.Size(100, 31);
            this.botonAlta.TabIndex = 5;
            this.botonAlta.Text = "Alta";
            this.botonAlta.UseVisualStyleBackColor = true;
            this.botonAlta.Click += new System.EventHandler(this.botonAlta_Click);
            // 
            // FrmRegimenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonBaja);
            this.Controls.Add(this.botonModificacion);
            this.Controls.Add(this.botonAlta);
            this.Name = "FrmRegimenes";
            this.Text = "ABM de Regimenes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button botonBaja;
        private System.Windows.Forms.Button botonModificacion;
        private System.Windows.Forms.Button botonAlta;
    }
}