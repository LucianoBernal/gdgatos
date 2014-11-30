using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Hotel
{
    public partial class FrmHotel_Alta : Form
    {
        SqlConnection conexion = new SqlConnection();
        int idHotel;
        public FrmHotel_Alta()
        {
            InitializeComponent();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            txtCiudad.Text = null;
            txtDireccion.Text = null;
            txtEmail.Text = null;
            txtEstrellas.Value = 0;
            txtFecha.Text = null;
            txtNombre.Text = null;
            txtPais.Text = null;
            txtTelefono.Text = null;
            foreach (int i in Regimen.CheckedIndices)
            {
                Regimen.SetItemCheckState(i, CheckState.Unchecked);
            }
            botonGuardar.Enabled = false;

        }
        private void CargarRegimenesEnLista()
        {
            string sql = "SELECT descripcion, idRegimen FROM SKYNET.Regimenes WHERE habilitado = 1";
            Query qry = new Query(sql);
            List<KeyValuePair<string, int>> datos = (from x in qry.ObtenerDataTable().AsEnumerable()
                                                     select new
                                                     KeyValuePair<string, int>(x["descripcion"].ToString(), Convert.ToInt32(x["idRegimen"]))).ToList();

            Regimen.DataSource = datos;
            Regimen.DisplayMember = "Key";
            Regimen.ValueMember = "Value";
        }
        public void CargarPaisesEnLista()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT pais FROM SKYNET.Paises", conexion);
            da.Fill(ds, "SKYNET.Paises");

            txtPais.DataSource = ds.Tables[0].DefaultView;
            txtPais.ValueMember = "pais";
            txtPais.SelectedItem = null;
        }

        public void CargarCadenasEnLista()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT cadena FROM SKYNET.Cadenas", conexion);
            da.Fill(ds, "SKYNET.Cadenas");

            txtCadena.DataSource = ds.Tables[0].DefaultView;
            txtCadena.ValueMember = "cadena";
            txtCadena.SelectedItem = null;
        }

        private void FrmHotel_Alta_Load(object sender, EventArgs e)
        {
            CargarRegimenesEnLista();
            CargarPaisesEnLista();
            CargarCadenasEnLista();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmHotel hotel = new FrmHotel();
            this.Hide();
            hotel.ShowDialog();
            hotel = (FrmHotel)this.ActiveMdiChild;
        }

        private bool faltaDatos()
        {
            if (txtCadena.Text != "" && txtCiudad.Text != "" && txtDireccion.Text != "" && txtEmail.Text != "" && txtNombre.Text != "" &&
                txtNumCalle.Text != "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            if (!faltaDatos())
            {
                conexion.ConnectionString = Settings.Default.CadenaDeConexion;

                if (txtNombre.Text.Trim() != "")
                {
                    string Habilitado = "SELECT COUNT(1) FROM SKYNET.Hoteles where nombre = '" + txtNombre.Text + "'";
                    Query qry = new Query(Habilitado);
                    qry.pComando = Habilitado;
                    int existeHotel = (int)qry.ObtenerUnicoCampo();

                    if (existeHotel == 1)
                    {
                        txtNombre.Text = null;
                        MessageBox.Show("Nombre de hotel ya existente - Eliga un nuevo nombre"
                            , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string sql = "INSERT INTO SKYNET.Hoteles (nombre, ciudad, pais, mail, cantidadEstrellas, fechaCreacion, calle, numCalle, cadena) "
                        + " VALUES ('" + txtNombre.Text + "', '" + txtCiudad.Text + "', (SELECT idPais FROM SKYNET.Paises WHERE pais ='" + txtPais.Text.ToString() + "'), '" + txtEmail.Text + "', "
                        + " '" + txtEstrellas.Value + "', '" + txtFecha.Value + "', '" + txtDireccion.Text + "', '" + txtNumCalle.Text + "', (SELECT idCadena FROM SKYNET.Cadenas WHERE cadena = '" + txtCadena.Text.ToString() + "') )";

                        qry.pComando = sql;
                        qry.Ejecutar();


                        string consulta = "SELECT convert(int, idHotel) FROM SKYNET.Hoteles WHERE nombre= '" + txtNombre.Text + "'";
                        Query qr = new Query(consulta);
                        qr.pComando = consulta;
                        idHotel = (int)qr.ObtenerUnicoCampo();

                        sql = "INSERT INTO SKYNET.UsuarioRolHotel (usuario, hotel, rol ) SELECT " + Globales.idUsuarioLogueado + ", " + idHotel + ", r.idRol FROM  SKYNET.Roles r where r.nombre='ADMINISTRADOR' ";

                        qry.pComando = sql;
                        qry.Ejecutar();

                        foreach (var checkedItem in Regimen.CheckedItems)
                        {
                            string sql2 = "insert into SKYNET.HotelesRegimenes (regimen, hotel)  " +
                                         "SELECT r.idRegimen, " + idHotel +
                                         "from SKYNET.Regimenes r where r.descripcion = '" + checkedItem.ToString().Replace('[', ' ').Substring(1, checkedItem.ToString().IndexOf(',') - 1).TrimStart() + "'";

                            Query qry2 = new Query();
                            qry2.pComando = sql2;
                            qry2.Ejecutar();
                        }

                        MessageBox.Show("El hotel ha sido dado de alta con exito!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Visible = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Verifique los datos ingresados!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
