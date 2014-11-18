using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Login;
using FrbaHotel.FuncionesGenerales;

namespace FrbaHotel
{
    public partial class FrmPrincipal : Form
    {
        private int idUsuario;
        private string nombreUsuario;
        private int idRol;
        private Button botonSistema;
        private Button botonHuesped;
        Funciones fn = new Funciones();

        public FrmPrincipal()
        {
            InitializeComponent();

            //idUsuario = Globales.idUsuarioLogueado;
        }

        private void InitializeComponent()
        {
            this.botonSistema = new System.Windows.Forms.Button();
            this.botonHuesped = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonSistema
            // 
            this.botonSistema.Location = new System.Drawing.Point(76, 104);
            this.botonSistema.Name = "botonSistema";
            this.botonSistema.Size = new System.Drawing.Size(133, 39);
            this.botonSistema.TabIndex = 0;
            this.botonSistema.Text = "Ingreso al Sistema";
            this.botonSistema.UseVisualStyleBackColor = true;
            this.botonSistema.Click += new System.EventHandler(this.botonSistema_Click);
            // 
            // botonHuesped
            // 
            this.botonHuesped.Location = new System.Drawing.Point(76, 175);
            this.botonHuesped.Name = "botonHuesped";
            this.botonHuesped.Size = new System.Drawing.Size(133, 39);
            this.botonHuesped.TabIndex = 1;
            this.botonHuesped.Text = "Ingreso Huesped";
            this.botonHuesped.UseVisualStyleBackColor = true;
            this.botonHuesped.Click += new System.EventHandler(this.botonHuesped_Click);
            // 
            // FrmPrincipal
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.botonHuesped);
            this.Controls.Add(this.botonSistema);
            this.Name = "FrmPrincipal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.ResumeLayout(false);

        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
       /*     nombreUsuario = fn.getUsername(idUsuario);


            int IdRol = (int)new Query("SELECT count(*) FROM TABLA_ROL  " +
                                            " WHERE idUsuario = " + idUsuario).ObtenerUnicoCampo();

            if (IdRol == 1)
            {
                idRol = (int)new Query("SELECT ID_ROL FROM TABLA_USUARIO WHERE idUsuario = " + idUsuario).ObtenerUnicoCampo();
            }
            else
            {
                idRol = Globales.idRolElegido;
            }

            cargarFrmPrincipal();*/

        }

        public void cargarFrmPrincipal()
        {
            //ACA ADENTRO CARGAR TODO PARA EL FRMPRINCIPAL
        }

        private void botonSistema_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
        }

        private void botonHuesped_Click(object sender, EventArgs e)
        {
            fn.recibirHuesped();
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.ShowDialog();
        }


    }
}
