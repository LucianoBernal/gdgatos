namespace FrbaHotel.ABM_de_Rol
{
    partial class FrmRol
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
            this.botonListado = new System.Windows.Forms.Button();
            this.botonAlta = new System.Windows.Forms.Button();
            this.botonModificacion = new System.Windows.Forms.Button();
            this.botonBaja = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonListado
            // 
            this.botonListado.Location = new System.Drawing.Point(99, 21);
            this.botonListado.Name = "botonListado";
            this.botonListado.Size = new System.Drawing.Size(100, 31);
            this.botonListado.TabIndex = 0;
            this.botonListado.Text = "Listado";
            this.botonListado.UseVisualStyleBackColor = true;
            this.botonListado.Click += new System.EventHandler(this.Listado_Click);
            // 
            // botonAlta
            // 
            this.botonAlta.Location = new System.Drawing.Point(99, 58);
            this.botonAlta.Name = "botonAlta";
            this.botonAlta.Size = new System.Drawing.Size(100, 31);
            this.botonAlta.TabIndex = 1;
            this.botonAlta.Text = "Alta";
            this.botonAlta.UseVisualStyleBackColor = true;
            this.botonAlta.Click += new System.EventHandler(this.botonAlta_Click);
            // 
            // botonModificacion
            // 
            this.botonModificacion.Location = new System.Drawing.Point(99, 95);
            this.botonModificacion.Name = "botonModificacion";
            this.botonModificacion.Size = new System.Drawing.Size(100, 31);
            this.botonModificacion.TabIndex = 2;
            this.botonModificacion.Text = "Modificación";
            this.botonModificacion.UseVisualStyleBackColor = true;
            this.botonModificacion.Click += new System.EventHandler(this.botonModificacion_Click);
            // 
            // botonBaja
            // 
            this.botonBaja.Location = new System.Drawing.Point(99, 132);
            this.botonBaja.Name = "botonBaja";
            this.botonBaja.Size = new System.Drawing.Size(100, 31);
            this.botonBaja.TabIndex = 3;
            this.botonBaja.Text = "Baja";
            this.botonBaja.UseVisualStyleBackColor = true;
            this.botonBaja.Click += new System.EventHandler(this.botonBaja_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(99, 209);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(100, 31);
            this.botonVolver.TabIndex = 4;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // FrmRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonBaja);
            this.Controls.Add(this.botonModificacion);
            this.Controls.Add(this.botonAlta);
            this.Controls.Add(this.botonListado);
            this.Name = "FrmRol";
            this.Text = "ABM Rol";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonListado;
        private System.Windows.Forms.Button botonAlta;
        private System.Windows.Forms.Button botonModificacion;
        private System.Windows.Forms.Button botonBaja;
        private System.Windows.Forms.Button botonVolver;
    }
}