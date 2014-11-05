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
        Funciones fn = new Funciones();

        public FrmPrincipal()
        {
            InitializeComponent();

            idUsuario = Globales.idUsuarioLogueado;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmPrincipal
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "FrmPrincipal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.ResumeLayout(false);

        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            nombreUsuario = fn.getUsername(idUsuario);


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

            cargarFrmPrincipal();

        }

        public void cargarFrmPrincipal()
        {
            //ACA ADENTRO CARGAR TODO PARA EL FRMPRINCIPAL
        }

    }
}
