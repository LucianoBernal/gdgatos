﻿namespace FrbaHotel.Registrar_Estadia
{
    partial class FormRsrvEstd
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
            this.botonCheckIn = new System.Windows.Forms.Button();
            this.botonCheckOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(58, 176);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(100, 31);
            this.botonVolver.TabIndex = 8;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // botonCheckIn
            // 
            this.botonCheckIn.Location = new System.Drawing.Point(58, 30);
            this.botonCheckIn.Name = "botonCheckIn";
            this.botonCheckIn.Size = new System.Drawing.Size(100, 31);
            this.botonCheckIn.TabIndex = 7;
            this.botonCheckIn.Text = "Check-in";
            this.botonCheckIn.UseVisualStyleBackColor = true;
            this.botonCheckIn.Click += new System.EventHandler(this.botonCheckIn_Click);
            // 
            // botonCheckOut
            // 
            this.botonCheckOut.Location = new System.Drawing.Point(58, 67);
            this.botonCheckOut.Name = "botonCheckOut";
            this.botonCheckOut.Size = new System.Drawing.Size(100, 31);
            this.botonCheckOut.TabIndex = 9;
            this.botonCheckOut.Text = "Check-out";
            this.botonCheckOut.UseVisualStyleBackColor = true;
            // 
            // FormRsrvEstd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 267);
            this.Controls.Add(this.botonCheckOut);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonCheckIn);
            this.Name = "FormRsrvEstd";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Button botonCheckIn;
        private System.Windows.Forms.Button botonCheckOut;
    }
}