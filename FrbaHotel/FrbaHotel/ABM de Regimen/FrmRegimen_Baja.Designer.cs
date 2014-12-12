namespace FrbaHotel.ABM_de_Regimen
{
    partial class FrmRegimen_Baja
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
            this.botonBorrar = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboRegimen = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // botonBorrar
            // 
            this.botonBorrar.Location = new System.Drawing.Point(251, 84);
            this.botonBorrar.Name = "botonBorrar";
            this.botonBorrar.Size = new System.Drawing.Size(81, 31);
            this.botonBorrar.TabIndex = 13;
            this.botonBorrar.Text = "Borrar";
            this.botonBorrar.UseVisualStyleBackColor = true;
            this.botonBorrar.Click += new System.EventHandler(this.botonBorrar_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(67, 84);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(81, 31);
            this.botonVolver.TabIndex = 12;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Seleccione el Regimen";
            // 
            // comboRegimen
            // 
            this.comboRegimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRegimen.FormattingEnabled = true;
            this.comboRegimen.Location = new System.Drawing.Point(142, 25);
            this.comboRegimen.Name = "comboRegimen";
            this.comboRegimen.Size = new System.Drawing.Size(204, 21);
            this.comboRegimen.TabIndex = 10;
            // 
            // FrmRegimen_Baja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 140);
            this.Controls.Add(this.botonBorrar);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboRegimen);
            this.Name = "FrmRegimen_Baja";
            this.Text = "Baja de Regimenes";
            this.Load += new System.EventHandler(this.FrmRegimen_Baja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonBorrar;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboRegimen;

    }
}