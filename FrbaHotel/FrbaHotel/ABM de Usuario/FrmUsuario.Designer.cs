namespace FrbaHotel.ABM_de_Usuario
{
    partial class FrmUsuario
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
            this.botonVolver.Location = new System.Drawing.Point(92, 137);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(100, 31);
            this.botonVolver.TabIndex = 9;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            // 
            // botonAlta
            // 
            this.botonAlta.Location = new System.Drawing.Point(92, 59);
            this.botonAlta.Name = "botonAlta";
            this.botonAlta.Size = new System.Drawing.Size(100, 31);
            this.botonAlta.TabIndex = 6;
            this.botonAlta.Text = "Alta";
            this.botonAlta.UseVisualStyleBackColor = true;
            // 
            // botonListado
            // 
            this.botonListado.Location = new System.Drawing.Point(92, 22);
            this.botonListado.Name = "botonListado";
            this.botonListado.Size = new System.Drawing.Size(100, 31);
            this.botonListado.TabIndex = 5;
            this.botonListado.Text = "Listado";
            this.botonListado.UseVisualStyleBackColor = true;
            // 
            // FrmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 191);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonAlta);
            this.Controls.Add(this.botonListado);
            this.Name = "FrmUsuario";
            this.Text = "ABM de Usuarios";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button botonAlta;
        private System.Windows.Forms.Button botonListado;
    }
}