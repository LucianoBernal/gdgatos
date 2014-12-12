namespace FrbaHotel.Login
{
    partial class FrmRolesLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.botonIngresar = new System.Windows.Forms.Button();
            this.comboBoxHotel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione el perfil con el que desea ingresar:";
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(28, 187);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(221, 21);
            this.comboBox.TabIndex = 2;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // botonIngresar
            // 
            this.botonIngresar.Location = new System.Drawing.Point(174, 233);
            this.botonIngresar.Name = "botonIngresar";
            this.botonIngresar.Size = new System.Drawing.Size(92, 29);
            this.botonIngresar.TabIndex = 3;
            this.botonIngresar.Text = "Ingresar";
            this.botonIngresar.UseVisualStyleBackColor = true;
            this.botonIngresar.Click += new System.EventHandler(this.botonIngresar_Click);
            // 
            // comboBoxHotel
            // 
            this.comboBoxHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHotel.FormattingEnabled = true;
            this.comboBoxHotel.Location = new System.Drawing.Point(28, 74);
            this.comboBoxHotel.Name = "comboBoxHotel";
            this.comboBoxHotel.Size = new System.Drawing.Size(221, 21);
            this.comboBoxHotel.TabIndex = 1;
            this.comboBoxHotel.SelectedIndexChanged += new System.EventHandler(this.comboBoxHotel_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Seleccione el hotel al que desea ingresar";
            // 
            // FrmRolesLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 276);
            this.Controls.Add(this.comboBoxHotel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.botonIngresar);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.label1);
            this.Name = "FrmRolesLogin";
            this.Text = "Eliga el Rol y Hotel";
            this.Load += new System.EventHandler(this.FrmRolesLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button botonIngresar;
        private System.Windows.Forms.ComboBox comboBoxHotel;
        private System.Windows.Forms.Label label2;
    }
}