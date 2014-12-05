namespace FrbaHotel.ABM_de_Habitacion
{
    partial class FrmHabitacion
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
            this.botonAlta = new System.Windows.Forms.Button();
            this.botonListado = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(92, 173);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(100, 31);
            this.botonVolver.TabIndex = 18;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // botonAlta
            // 
            this.botonAlta.Location = new System.Drawing.Point(92, 95);
            this.botonAlta.Name = "botonAlta";
            this.botonAlta.Size = new System.Drawing.Size(100, 31);
            this.botonAlta.TabIndex = 17;
            this.botonAlta.Text = "Alta";
            this.botonAlta.UseVisualStyleBackColor = true;
            this.botonAlta.Click += new System.EventHandler(this.botonAlta_Click);
            // 
            // botonListado
            // 
            this.botonListado.Location = new System.Drawing.Point(92, 58);
            this.botonListado.Name = "botonListado";
            this.botonListado.Size = new System.Drawing.Size(100, 31);
            this.botonListado.TabIndex = 16;
            this.botonListado.Text = "Listado";
            this.botonListado.UseVisualStyleBackColor = true;
            this.botonListado.Click += new System.EventHandler(this.botonListado_Click);
            // 
            // FrmHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonAlta);
            this.Controls.Add(this.botonListado);
            this.Name = "FrmHabitacion";
            this.Text = "ABM de Habitacion";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button botonAlta;
        private System.Windows.Forms.Button botonListado;
    }
}