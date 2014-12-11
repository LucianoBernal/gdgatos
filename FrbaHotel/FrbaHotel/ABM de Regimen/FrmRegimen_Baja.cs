using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Regimen
{
    public partial class FrmRegimen_Baja : Form
    {
        public FrmRegimen_Baja()
        {
            InitializeComponent();
        }

        private void botonBorrar_Click(object sender, EventArgs e)
        {
            if (comboRegimen.Text != "")
            {
                string nombreRol = comboRegimen.Text.ToString();
                string qry = " UPDATE SKYNET.Regimenes " +
                                " SET habilitado= 0 " +
                                " WHERE descripcion = '" + nombreRol + "'";
                new Query(qry).Ejecutar();

                MessageBox.Show("Regimen inhabilitado con exito!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmRegimenes rol = new FrmRegimenes();
                this.Hide();
                rol.ShowDialog();
                rol = (FrmRegimenes)this.ActiveMdiChild;
                /*this.Visible = false;*/
                /*LINEA QUE CIERRA EL PROG, CHAU*/
            }
            else
            {
                MessageBox.Show("Seleccione el Regimen a dar de baja", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmRegimenes frm = new FrmRegimenes();
            this.Hide();
            frm.ShowDialog();
            frm = (FrmRegimenes)this.ActiveMdiChild;
        }

        private void FrmRegimen_Baja_Load(object sender, EventArgs e)
        {
            LlenarComboBox();
            comboRegimen.Text = null;
            comboRegimen.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void LlenarComboBox()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT descripcion from SKYNET.Regimenes where habilitado = 1", conexion);
            da.Fill(ds, "SKYNET.Regimenes");

            comboRegimen.DataSource = ds.Tables[0].DefaultView;
            comboRegimen.ValueMember = "descripcion";
            comboRegimen.SelectedItem = null;
        }
    }
}
