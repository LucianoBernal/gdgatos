namespace FrbaHotel.Registrar_Estadia
{
    partial class FormCheckInPosta
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
            this.btnRegHuesped = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRegHuesped
            // 
            this.btnRegHuesped.Location = new System.Drawing.Point(80, 45);
            this.btnRegHuesped.Name = "btnRegHuesped";
            this.btnRegHuesped.Size = new System.Drawing.Size(120, 23);
            this.btnRegHuesped.TabIndex = 0;
            this.btnRegHuesped.Text = "Agregar Huesped";
            this.btnRegHuesped.UseVisualStyleBackColor = true;
            this.btnRegHuesped.Click += new System.EventHandler(this.btnRegHuesped_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(91, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Realizar check in";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(101, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Volver";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 65);
            this.label1.TabIndex = 3;
            this.label1.Text = "Actualmente no ha ingresado usuarios";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormCheckInPosta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRegHuesped);
            this.Name = "FormCheckInPosta";
            this.Text = "Check-In";
            this.Load += new System.EventHandler(this.FormCheckInPosta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRegHuesped;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
    }
}