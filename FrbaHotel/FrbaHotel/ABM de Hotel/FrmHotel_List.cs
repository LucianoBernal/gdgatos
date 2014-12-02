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
    public partial class FrmHotel_List : Form
    {
        public FrmHotel_List()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCiudad.Text = null;
            txtEstrellas.Text = null;
            txtNombre.Text = null;
            txtPais.Text = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string strQuery = "SELECT DISTINCT(idHotel), nombre, ciudad, pais, mail, cantidadEstrellas, fechaCreacion " +
                " FROM SKYNET.Hoteles h, SKYNET.UsuarioRolHotel uh WHERE h.idHotel = uh.hotel AND uh.usuario = "+Globales.idUsuarioLogueado+" AND   " +
                " uh.rol = (SELECT idRol FROM SKYNET.Roles WHERE nombre = 'ADMINISTRADOR' ) ";
            if (txtCiudad.Text != "")
            {
                strQuery = strQuery + " AND h.ciudad LIKE '%" + txtCiudad.Text + "%' ";
            }
            if (txtNombre.Text != "")
            {
                strQuery = strQuery + " AND h.nombre LIKE '%" + txtNombre.Text + "%' ";
            }
            if (txtEstrellas.Text != "")
            {
                strQuery = strQuery + " AND h.cantidadEstrellas = " + txtEstrellas.Value + " ";
            }
            if (txtPais.Text != "")
            {
                strQuery = strQuery + " AND h.pais = (SELECT idPais FROM SKYNET.Paises WHERE pais = '" + txtPais.Text + "') ";
            }
            mostrarResultado(strQuery);
        }
        private void mostrarResultado(string strQuery)
        {
            Query resultado = new Query(strQuery);
            dataResultado.DataSource = resultado.ObtenerDataTable();
            dataResultado.Columns["idHotel"].Visible = false;  //oculto esta columna
            dataResultado.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            btnDeshabilitar.Visible = true;
            btnHabilitar.Visible = true;
            btnModificar.Visible = true;
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {

        }

        private void FrmHotel_List_Load(object sender, EventArgs e)
        {
            CargarPaisesEnLista();
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
        private void dataResultado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmHotel hotel = new FrmHotel();
            this.Hide();
            hotel.ShowDialog();
            hotel = (FrmHotel)this.ActiveMdiChild;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idHotel = idHotelSeleccionado();

            FrmHotel_Mod modificar = new FrmHotel_Mod(idHotel);
            this.Hide();
            modificar.ShowDialog();
            modificar = (FrmHotel_Mod)this.ActiveMdiChild;
        }
        private int idHotelSeleccionado()
        {
            DataGridViewRow fila = dataResultado.SelectedRows[0];


            return Convert.ToInt32(fila.Cells["idHotel"].Value.ToString());

        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            txtCiudad.Text = null;
            txtEstrellas.Value = 0;
            txtNombre.Text = null;
            txtPais.SelectedItem = null;
        }
    }
}
