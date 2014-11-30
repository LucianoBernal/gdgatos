using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.FuncionesGenerales;


namespace FrbaHotel.Login
{
    public partial class FrmRolesLogin : Form
    {


        public int idUsuario;


        public FrmRolesLogin(int idUsr)
        {
            InitializeComponent();

            idUsuario = idUsr;

            botonIngresar.Enabled = false;
        }

        private void FrmRolesLogin_Load(object sender, EventArgs e)
        {
            cargarHoteles();
           // cargarRoles();
        }


        public void cargarRoles(string hotel)
        {
            Globales.idHotelElegido = (int)new Query("SELECT convert(int,idHotel) FROM SKYNET.Hoteles  " +
                                   " WHERE calle = '" + hotel + "'").ObtenerUnicoCampo();

            string sql = "SELECT DISTINCT(r.nombre) FROM SKYNET.Roles r,SKYNET.UsuarioRolHotel ur WHERE ur.hotel = "+Globales.idHotelElegido+" AND ur.rol = r.idRol AND r.baja=0 AND ur.usuario = " + idUsuario;


            Query qry = new Query(sql);

            foreach (DataRow dataRow in qry.ObtenerDataTable().AsEnumerable())
            {
                comboBox.Items.Add(dataRow[0]);
            }

            comboBox.DisplayMember = "Key";
            comboBox.ValueMember = "Value";
            comboBox.Text = null;
        }


        public void cargarHoteles()
        {
            string sql = "SELECT DISTINCT(h.calle) FROM SKYNET.Hoteles h,SKYNET.UsuarioRolHotel ur, SKYNET.Roles r WHERE r.idRol = ur.Rol AND r.baja = 0 AND ur.hotel = h.idHotel AND ur.usuario = " + idUsuario;/*agregar baja del hotel*/


            Query qry = new Query(sql);

            foreach (DataRow dataRow in qry.ObtenerDataTable().AsEnumerable())
            {
                comboBoxHotel.Items.Add(dataRow[0]);
            }

            comboBoxHotel.DisplayMember = "Key";
            comboBoxHotel.ValueMember = "Value";
            comboBoxHotel.Text = null;
        }


        private void botonIngresar_Click(object sender, EventArgs e)
        {
            int idRol = (int)new Query("SELECT convert(int,idRol) FROM SKYNET.Roles  " +
                                   " WHERE nombre = '" + comboBox.SelectedItem.ToString() + "'").ObtenerUnicoCampo();

            Globales.idRolElegido = idRol;
            
            Query qr = new Query("SELECT distinct(username) from SKYNET.Usuarios WHERE idUser = " + idUsuario);

            qr.pTipoComando = CommandType.Text;
            string nombreUsuario = qr.ObtenerUnicoCampo().ToString();

            this.Visible = false;
            Funciones fn = new Funciones();
            fn.recibirUsuario(idUsuario);

        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.Text != null)
            {
                botonIngresar.Enabled = true;
            }
        }

        private void comboBoxHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hotelSeleccionado = comboBoxHotel.SelectedItem.ToString();
            cargarRoles(hotelSeleccionado);
        }




    }
}
