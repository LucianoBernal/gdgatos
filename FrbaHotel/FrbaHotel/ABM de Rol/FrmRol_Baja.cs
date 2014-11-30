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
    public partial class FrmRol_Baja : Form
    {
        public FrmRol_Baja()
        {
            InitializeComponent();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmRol rol = new FrmRol();
            this.Hide();
            rol.ShowDialog();
            rol = (FrmRol)this.ActiveMdiChild;
        }

        /*Valido si eligio un rol, y elimino(cambio estado) en caso de ser afirmativo*/
        private void botonBorrar_Click(object sender, EventArgs e)
        {
            if (comboRol.Text != "")
            { 
                string nombreRol = comboRol.Text.ToString();
                string qry = " UPDATE SKYNET.Roles " +
                                " SET baja= 1 " +
                                " WHERE nombre = '" + nombreRol + "'";
                new Query(qry).Ejecutar();

                MessageBox.Show("Rol inhabilitado con exito!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                /*this.Visible = false;*//*LINEA QUE CIERRA EL PROG, CHAU*/
            }
            else
            {
                MessageBox.Show("Seleccione el Rol a dar de baja", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /*Seteo de formulario */
        private void FrmRol_Baja_Load(object sender, EventArgs e)
        {
            LlenarComboBox();
            comboRol.Text = null;
            comboRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void LlenarComboBox()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT nombre from SKYNET.Roles where baja = 0", conexion);
            da.Fill(ds, "SKYNET.ROLES");

            comboRol.DataSource = ds.Tables[0].DefaultView;
            comboRol.ValueMember = "nombre";
            comboRol.SelectedItem = null;
        }


    }
}
