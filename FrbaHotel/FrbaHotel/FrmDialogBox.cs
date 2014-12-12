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
        private NumericUpDown numRespuesta;
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
            this.numRespuesta = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numRespuesta)).BeginInit();
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
            this.txtRespuesta.Location = new System.Drawing.Point(438, 47);
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(99, 20);
            this.txtRespuesta.TabIndex = 1;
            this.txtRespuesta.Visible = false;
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
            // numRespuesta
            // 
            this.numRespuesta.Location = new System.Drawing.Point(453, 13);
            this.numRespuesta.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numRespuesta.Name = "numRespuesta";
            this.numRespuesta.Size = new System.Drawing.Size(170, 20);
            this.numRespuesta.TabIndex = 4;
            this.numRespuesta.ValueChanged += new System.EventHandler(this.numRespuesta_ValueChanged);
            // 
            // FrmDialogBox
            // 
            this.ClientSize = new System.Drawing.Size(635, 79);
            this.Controls.Add(this.numRespuesta);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtRespuesta);
            this.Controls.Add(this.labelTexto);
            this.Name = "FrmDialogBox";
            this.Load += new System.EventHandler(this.FrmDialogBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRespuesta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            txtRespuesta.Text = numRespuesta.Value.ToString();
            if (txtRespuesta.Text != "")
            {
                //this.FormPadre.Show();
                ((FrmMenu)this.FormPadre).RespuestaDialog(txtRespuesta.Text, this.Razon);
                this.Visible=false;
            }
            else
            {
                MessageBox.Show("Complete el campo.");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ((FrmMenu)this.FormPadre).RespuestaDialog(null, this.Razon);
            this.Visible=false;
            this.FormPadre.Show();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e){
                    ((FrmMenu)this.FormPadre).RespuestaDialog(null, this.Razon);
            this.Visible=false;
            this.FormPadre.Show();
        }

        private void FrmDialogBox_Load(object sender, EventArgs e)
        {

        }

        private void numRespuesta_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
