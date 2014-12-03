﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class FrmDialogBox : Form
    {
        private Label labelTexto;
        private TextBox txtRespuesta;
        private Button btnGuardar;
        private Button btnCancelar;
        public Form FormPadre;
    
        public FrmDialogBox(Form sender, string textoPregunta)
        {
            InitializeComponent();
            labelTexto.Text = textoPregunta;
            this.FormPadre = sender;
        }

        private void InitializeComponent()
        {
            this.labelTexto = new System.Windows.Forms.Label();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTexto
            // 
            this.labelTexto.AutoSize = true;
            this.labelTexto.Location = new System.Drawing.Point(29, 20);
            this.labelTexto.Name = "labelTexto";
            this.labelTexto.Size = new System.Drawing.Size(35, 13);
            this.labelTexto.TabIndex = 0;
            this.labelTexto.Text = "label1";
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Location = new System.Drawing.Point(220, 17);
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(99, 20);
            this.txtRespuesta.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(32, 46);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 21);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(189, 46);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 21);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmDialogBox
            // 
            this.ClientSize = new System.Drawing.Size(340, 79);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtRespuesta);
            this.Controls.Add(this.labelTexto);
            this.Name = "FrmDialogBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //this.FormPadre.Show();
            ((FrmMenu)this.FormPadre).RespuestaDialog(txtRespuesta.Text, 1);
            this.Hide();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ((FrmMenu)this.FormPadre).RespuestaDialog(null, 1);
            this.Hide();
            this.FormPadre.Show();
        }
    }
}
