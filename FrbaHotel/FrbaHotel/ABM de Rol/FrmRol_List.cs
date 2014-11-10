using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class FrmRol_List : Form
    {
        public FrmRol_List()
        {
            InitializeComponent();
        }

        private void FrmRol_List_Load(object sender, EventArgs e)
        {
            botonBuscar.Enabled = false;
            LlenarComboBox();
            comboRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            comboRol.SelectedItem = null;
            gridDatos.DataSource = null;
            botonBuscar.Enabled = false;
        }

        private void comboRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboRol.Text.Trim() != "" || comboRol.SelectedItem != null)
            {
                botonBuscar.Enabled = true;
            }
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            string rol = comboRol.Text;
            string qry = " SELECT f.descripcion Funcionalidad " +
                            " FROM SKYNET.RolFunciones rf, SKYNET.Roles r, SKYNET.Funciones f " +
                            " WHERE rf.funcion = f.idFuncion " +
                            " AND rf.rol= r.idRol" +
                            " AND r.nombre = '" + rol + "' " +
                            " ORDER BY f.DESCRIPCION";

            gridDatos.DataSource = new Query(qry).ObtenerDataTable();
        }

        public void LlenarComboBox()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT nombre FROM SKYNET.Roles WHERE baja = 0", conexion);
            da.Fill(ds, "SKYNET.Roles");

            comboRol.DataSource = ds.Tables[0].DefaultView;
            comboRol.ValueMember = "nombre";
            comboRol.SelectedItem = null;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmRol rol = new FrmRol();
            this.Hide();
            rol.ShowDialog();
            rol = (FrmRol)this.ActiveMdiChild;
        }
    }
}
