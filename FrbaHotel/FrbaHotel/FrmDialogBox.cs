using System;
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
        public int Razon;
    
        public FrmDialogBox(Form sender, string textoPregunta, int proposito)
        {
            InitializeComponent();
            labelTexto.Text = textoPregunta;
            this.Razon = proposito;
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
            this.txtRespuesta.Location = new System.Drawing.Point(388, 17);
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(99, 20);
            this.txtRespuesta.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(78, 46);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 21);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(302, 46);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 21);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmDialogBox
            // 
            this.ClientSize = new System.Drawing.Size(518, 79);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtRespuesta);
            this.Controls.Add(this.labelTexto);
            this.Name = "FrmDialogBox";
            this.Load += new System.EventHandler(this.FrmDialogBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtRespuesta.Text != "")
            {
                //this.FormPadre.Show();
                ((FrmMenu)this.FormPadre).RespuestaDialog(txtRespuesta.Text, this.Razon);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Complete el campo.");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ((FrmMenu)this.FormPadre).RespuestaDialog(null, this.Razon);
            this.Hide();
            this.FormPadre.Show();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e){
                    ((FrmMenu)this.FormPadre).RespuestaDialog(null, this.Razon);
            this.Hide();
            this.FormPadre.Show();
        }

        private void FrmDialogBox_Load(object sender, EventArgs e)
        {

        }
    }
}
