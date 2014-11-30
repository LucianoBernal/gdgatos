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
    public partial class FrmRol_Alta : Form
    {
        int idRol;
        SqlConnection conexion = new SqlConnection();

        public FrmRol_Alta()
        {
            InitializeComponent();
        }


        /* Cargamos todas las funcionalidades en la lista*/
        private void CargarFuncionalidadesEnLista()
        {
            string sql = "SELECT descripcion, idFuncion FROM SKYNET.Funciones";
            Query qry = new Query(sql);
            List<KeyValuePair<string, int>> datos = (from x in qry.ObtenerDataTable().AsEnumerable()
                                                     select new
                                                     KeyValuePair<string, int>(x["descripcion"].ToString(), Convert.ToInt32(x["idFuncion"]))).ToList();

            Funcionalidades.DataSource = datos;
            Funcionalidades.DisplayMember = "Key";
            Funcionalidades.ValueMember = "Value";
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() != "")
            {
                CargarFuncionalidadesEnLista();
                botonGuardar.Enabled = true;
            }
        }

        /* Cuando se haya chequeado algun objeto se habilita el boton de guardar */
        private void Funcionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Funcionalidades.CheckedItems.Count > 0)
            {
                botonGuardar.Enabled = true;
            }
            else
            {
                botonGuardar.Enabled = false;
            }
        }

        /* Al Clickear Guardar se Inserta todas las funcionalidades chequeadas */
        private void botonGuardar_Click(object sender, EventArgs e)
        {
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            if (txtNombre.Text.Trim() != "")
            {
                string Habilitado = "SELECT COUNT(1) FROM SKYNET.Roles where nombre = '" + txtNombre.Text + "'";
                Query qry = new Query(Habilitado);
                qry.pComando = Habilitado;
                int existeRol = (int)qry.ObtenerUnicoCampo();

                if (existeRol == 1)
                {
                    txtNombre.Text = null;
                    MessageBox.Show("Nombre de rol ya existente - Ingresar nuevo nombre"
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string sql = "INSERT INTO SKYNET.Roles (nombre) VALUES ('" + txtNombre.Text + "')";
                    qry.pComando = sql;
                    qry.Ejecutar();

                    string consulta = "SELECT idRol FROM SKYNET.Roles WHERE nombre= '" + txtNombre.Text + "'";
                    Query qr = new Query(consulta);
                    qr.pComando = consulta;
                    idRol = (int)qr.ObtenerUnicoCampo();

                    foreach (var checkedItem in Funcionalidades.CheckedItems)
                    {
                        string sql2 = "insert into SKYNET.RolFunciones (funcion, rol) VALUES " +
                                     "SELECT idFuncion, " + idRol + 
                                     "from SKYNET.Funciones where descripcion = '" + checkedItem.ToString().Replace('[', ' ').Substring(1, checkedItem.ToString().IndexOf(',') - 1).TrimStart() + "'";

                        Query qry2 = new Query();
                        qry2.pComando = sql2;
                        qry2.Ejecutar();
                    }

                    MessageBox.Show("Rol dado de alta con exito!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Visible = false;
                }
            }
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmRol rol = new FrmRol();
            this.Hide();
            rol.ShowDialog();
            rol = (FrmRol)this.ActiveMdiChild;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            foreach (int i in Funcionalidades.CheckedIndices)
            {
                Funcionalidades.SetItemCheckState(i, CheckState.Unchecked);
            }
            botonGuardar.Enabled = false;
        }

        private void FrmRol_Alta_Load(object sender, EventArgs e)
        {
            botonGuardar.Enabled = false;
            botonLimpiar.Enabled = true;
        }


    }
}
