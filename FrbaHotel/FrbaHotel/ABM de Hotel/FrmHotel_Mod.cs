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
    public partial class FrmHotel_Mod : Form
    {
        public ListaTextos listaTextos = new ListaTextos();
        private int idHotel;
        string nombreHotel;

        public FrmHotel_Mod(int id)
        {
            InitializeComponent();
            idHotel = id;
            this.AgregarTextos();
        }
        public void AgregarTextos()
        {
            listaTextos.Agregar(txtCadena, true, "cadena");
            listaTextos.Agregar(txtCiudad, true, "ciudad");
            listaTextos.Agregar(txtEmail, true, "mail");
            listaTextos.Agregar(txtEstrellas, true, "cantidadEstrellas");
            listaTextos.Agregar(txtFecha, false, "fechaCreacion");
            listaTextos.Agregar(txtNombre, false, "nombre");
            listaTextos.Agregar(txtNumCalle, false, "numCalle");
            listaTextos.Agregar(txtDireccion, false, "calle");
            listaTextos.Agregar(txtPais, false, "pais");
            listaTextos.Agregar(txtTelefono, false, "telefono");
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            if (listaTextos.EstanTodosLlenos())
            {
                int numero;
                bool okNumero = int.TryParse(txtNumCalle.Text, out numero);
                if (okNumero)
                {
                    if (nombreDesocupado(txtNombre.Text, nombreHotel) == true)
                    {
                        //            MessageBox.Show("UPDATE SKYNET.Usuarios SET " + listaTextos.GenerarUpdate() + " WHERE idUser = " + idUsuario.ToString());
                        new Query("UPDATE SKYNET.Hoteles SET mail = '" + txtEmail.Text + "', telefono = '" + txtTelefono.Text + "', cantidadEstrellas = '" + txtEstrellas.Value + "', " +
                            " calle = '" + txtDireccion.Text + "', numCalle = " + txtNumCalle.Text + ", ciudad = '" + txtCiudad.Text + "', fechaCreacion = '" + txtFecha.Value + "', " +
                            " pais = (SELECT idPais FROM SKYNET.Paises WHERE pais ='" + txtPais.Text.ToString() + "'), cadena = (SELECT idCadena FROM SKYNET.Cadenas WHERE cadena = '" + txtCadena.Text.ToString() + "') " +
                            " WHERE idHotel = " + idHotel.ToString()).Ejecutar();
                        ActualizarRegimen();
                        MessageBox.Show("Ya esta");
                    }
                    else
                    {
                        MessageBox.Show("El nombre del hotel ya esta usado, eliga otro");
                    }
                }
                else
                {
                    MessageBox.Show("El numero de la calle tiene letras. Verifiquelo.");
                }
            }
        }
        private bool nombreDesocupado(string nombreNuevo, string nombreViejo)
        {
            if (nombreNuevo == nombreViejo)
            {
                return true;
            }
            else
            {
                int res = (int)new Query("SELECT COUNT(1) FROM SKYNET.Hoteles WHERE nombre ='" + nombreNuevo + "'  ").ObtenerUnicoCampo();
                if (res == 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        private void ActualizarRegimen()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            for (int i = 0; i < Regimen.Items.Count; i++)
            {
                string sql;
                string RegimenesItem = Regimen.Items[i].ToString().Replace(']', ' ').Substring(Regimen.Items[i].ToString().IndexOf(',') + 1).TrimEnd();
                if (Regimen.GetItemChecked(i))
                {
                    // insertar si no existe
                    sql = " INSERT INTO SKYNET.HotelesRegimenes (regimen, hotel)" +
                            " SELECT DISTINCT " + RegimenesItem + ", " + idHotel +
                            " from SKYNET.Regimenes " +
                            " WHERE " + RegimenesItem + " NOT IN ( SELECT regimen FROM SKYNET.HotelesRegimenes WHERE hotel = " + idHotel + ")";
                }
                else
                {
                    // borrar el registro en caso que este desmarcado (no es necesario chequear si existe)
                    sql = " DELETE FROM SKYNET.HotelesRegimenes" +
                            " WHERE hotel = " + idHotel +
                            " AND regimen = " + RegimenesItem;
                }
                Query qry = new Query();
                qry.pComando = sql;
                qry.Ejecutar();
            }
        }

        private void FrmHotel_Mod_Load(object sender, EventArgs e)
        {
            CargarRegimenesEnLista();
            CargarPaisesEnLista();
            CargarCadenasEnLista();
            cargarDatos();
        }
        private void cargarDatos()
        {
            Query qry = new Query("SELECT c.cadena, h.ciudad, h.mail, h.cantidadEstrellas, h.fechaCreacion, h.nombre, h.numCalle, h.calle, " +
                " p.pais, h.telefono FROM SKYNET.Hoteles h, SKYNET.Cadenas c, SKYNET.Paises p " +
                " WHERE c.idCadena = h.cadena AND p.idPais = h.pais AND h.idHotel = " + idHotel);
            foreach (DataRow datos in qry.ObtenerDataTable().AsEnumerable())
            {
                txtCadena.SelectedItem = datos[0].ToString();
                txtCiudad.Text = datos[1].ToString();
                txtEmail.Text = datos[2].ToString();
                txtEstrellas.Text = datos[3].ToString();
                txtFecha.Text = datos[4].ToString();
                txtNombre.Text = datos[5].ToString();
                nombreHotel = datos[5].ToString(); ;
                txtNumCalle.Text = (datos[6].ToString().Length > 3) ? datos[6].ToString().Substring(0, datos[6].ToString().Length - 3) : datos[6].ToString();
                txtDireccion.Text = datos[7].ToString();
                txtPais.SelectedItem = datos[8].ToString();
                txtTelefono.Text = datos[9].ToString();
            }

            string ConsultarRegimenesHotel = " SELECT r.descripcion Regimen  FROM SKYNET.Regimenes r, SKYNET.HotelesRegimenes hr" +
                                                "  WHERE hr.hotel = " + idHotel + " AND r.idRegimen = hr.regimen";

            qry = new Query(ConsultarRegimenesHotel);
            DataTable regimenesSeleccionados = qry.ObtenerDataTable();
            foreach (DataRow regimenSeleccionado in regimenesSeleccionados.Rows)
            {
                string descripcionRegimen = regimenSeleccionado["Regimen"].ToString();
                int index = Regimen.FindString(descripcionRegimen, 0);
                Regimen.SetItemChecked(index, true);
            }
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
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmHotel_List hotel = new FrmHotel_List();
            this.Hide();
            hotel.ShowDialog();
            hotel = (FrmHotel_List)this.ActiveMdiChild;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }

    }
}
