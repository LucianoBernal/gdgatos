namespace FrbaHotel
{
    partial class FrmElegirHotel
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
            this.comboBoxHotel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.botonIngresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxHotel
            // 
            this.comboBoxHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHotel.FormattingEnabled = true;
            this.comboBoxHotel.Location = new System.Drawing.Point(33, 54);
            this.comboBoxHotel.Name = "comboBoxHotel";
            this.comboBoxHotel.Size = new System.Drawing.Size(221, 21);
            this.comboBoxHotel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Seleccione el hotel al que desea ingresar";
            // 
            // botonIngresar
            // 
            this.botonIngresar.Location = new System.Drawing.Point(179, 103);
            this.botonIngresar.Name = "botonIngresar";
            this.botonIngresar.Size = new System.Drawing.Size(75, 23);
            this.botonIngresar.TabIndex = 6;
            this.botonIngresar.Text = "Ingresar";
            this.botonIngresar.UseVisualStyleBackColor = true;
            this.botonIngresar.Click += new System.EventHandler(this.botonIngresar_Click);
            // 
            // FrmElegirHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 143);
            this.Controls.Add(this.comboBoxHotel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.botonIngresar);
            this.Name = "FrmElegirHotel";
            this.Text = "Elija el Hotel";
            this.Load += new System.EventHandler(this.FrmElegirHotel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxHotel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button botonIngresar;
    }
}