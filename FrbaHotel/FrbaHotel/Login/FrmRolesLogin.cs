using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public partial class FrmRolesLogin : Form
    {


        public int idUsuario;
        // private int IdRolElegido;


        public FrmRolesLogin(int idUsr)
        {
            InitializeComponent();

            idUsuario = idUsr;

            btnIngresar.Enabled = false;
        }

        private void FrmRolesLogin_Load(object sender, EventArgs e)
        {
            cargarRoles();
        }


        public void cargarRoles()
        {
            string sql = "SELECT r.ROL_NOMBRE rol FROM TABLA_ROLES r, TABLA_ROLES_USUARIO ur where ur.idRol = r.idRol and ur.idUsuario = " + idUsuario;


            Query qry = new Query(sql);


            foreach (DataRow dataRow in qry.ObtenerDataTable().AsEnumerable())
            {
                comboBox.Items.Add(dataRow[0]);
            }


            comboBox.DisplayMember = "Key";
            comboBox.ValueMember = "Value";
            comboBox.Text = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

        }


    }
}
