using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.FuncionesGenerales;
using FrbaHotel.Login;
using FrbaHotel.ABM_de_Rol;
using FrbaHotel.ABM_de_Usuario;
using FrbaHotel.ABM_de_Hotel;
using FrbaHotel.Generar_Modificar_Reserva;
using FrbaHotel.ABM_de_Cliente;

namespace FrbaHotel
{
    public partial class FrmMenu : Form
    {
        private int idUsuario;
        private string nombreUsuario;
        private int idRol;
        Funciones fn = new Funciones();
        public void RespuestaDialog(string respuesta, int tipoResp)
        {
            if (tipoResp == 1 && respuesta != null)
            {
                FrmReserva nuevo = new FrmReserva(Convert.ToUInt32(respuesta), this);
                this.Hide();
                nuevo.Show();
            }

        }
        public FrmMenu()
        {
            InitializeComponent();

            idUsuario = Globales.idUsuarioLogueado;
            Globales.fechaSistema = Settings.Default.FechaSistema.ToShortDateString();

            this.btnCancelarEstadia.Visible = false;
            this.btnClientes.Visible = false;
            this.btnFacturar.Visible = false;
            this.btnHabitacion.Visible = false;
            this.btnHotel.Visible = false;
            this.btnListadoEstadistico.Visible = false;
            this.btnRegimenEstadia.Visible = false;
            this.btnRegistrarConsumible.Visible = false;
            this.btnRegistrarEstadia.Visible = false;
            this.btnReserva.Visible = true;
            this.btnRoles.Visible = false;
            this.btnUsuario.Visible = false;
            linkCambiarContraseña.Visible = false;
            lblUsuarioLogueado.Visible = false;
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            nombreUsuario = fn.getUsername(idUsuario);
            idRol = Globales.idRolElegido;
            cargarMenu();
        }
        public void cargarMenu()
        {
            Query qr = new Query(" SELECT nombre FROM SKYNET.Roles WHERE idRol = " + idRol);
            qr.pTipoComando = CommandType.Text;
            string nombreRol = qr.ObtenerUnicoCampo().ToString();

            //MUESTRA EL NOMBRE Y PERFIL DEL USUARIO LOGUEADO
            lblPerfil.Visible = true;
            if (idRol != 3)
            {
                lblUsuarioLogueado.Text = " Usuario Conectado : " + nombreUsuario.ToUpper();
                lblUsuarioLogueado.Visible = true;
                linkCambiarContraseña.Visible = true;
            }
            lblPerfil.Text = " Perfil : " + nombreRol.ToUpper();

            //MUESTRA SOLO LAS FUNCIONALIDADES PERMITIDAS PARA EL ROL LOGUEADO
            Query qrFunciones = new Query("SELECT funcion FROM SKYNET.RolFunciones WHERE rol = " + idRol);

            foreach (DataRow dataRow in qrFunciones.ObtenerDataTable().AsEnumerable())
            {
                switch (Convert.ToInt32(dataRow[0]))
                {
                    //ABM ROL
                    case 1: this.btnRoles.Visible = true;
                        break;

                    //ABM USUARIO
                    case 2: this.btnUsuario.Visible = true;
                        break;

                    //ABM CLIENTES
                    case 3: this.btnClientes.Visible = true;
                        break;

                    //ABM HOTEL
                    case 4: this.btnHotel.Visible = true;
                        break;

                    //ABM HABITACION
                    case 5: this.btnHabitacion.Visible = true;
                        break;

                    //ABM REGIMEN DE ESTADIA
                    case 6: this.btnRegimenEstadia.Visible = true;
                        break;

                    //GENERAR O MODIFICAR RESERVA
                    case 7: this.btnReserva.Visible = true;
                        break;

                    //CANCELAR RESERVA
                    case 8: this.btnCancelarEstadia.Visible = true;
                        break;

                    //REGISTRAR ESTADIA
                    case 9: this.btnRegistrarEstadia.Visible = true;
                        break;

                    //REGISTRAR CONSUMIBLES
                    case 10: this.btnRegistrarConsumible.Visible = true;
                        break;

                    //FACTURAR
                    case 11: this.btnFacturar.Visible = true;
                        break;

                    //LISTADO ESTADISTICO
                    case 12: this.btnListadoEstadistico.Visible = true;
                        break;


                }
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmRol rol = new FrmRol();
            rol.ShowDialog();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmUsuario usuario = new FrmUsuario();
            usuario.ShowDialog();
        }

        private void btnHotel_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmHotel hotel = new FrmHotel();
            hotel.ShowDialog();
        }

        private void btnRegimenEstadia_Click(object sender, EventArgs e)
        {
            
//            MessageBox.Show("Ingrese el numero de reserva, si desea crear una nueva, ingrese 0", 
            this.Hide();
            FrmHotel hotel = new FrmHotel();
            hotel.ShowDialog();
        }

        private void btnReserva_Click(object sender, EventArgs e)
        {
            FrmDialogBox dialog = new FrmDialogBox(this, "Ingrese el numero de reserva, de lo contrario ingrese 0");
            this.Hide();
            dialog.Show();

        }

	private void btnClientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmCliente cliente = new FrmCliente();
            cliente.Show();
        }

    private void btnClientes_Click_1(object sender, EventArgs e)
    {
        this.Hide();
        FrmCliente cliente = new FrmCliente();
        cliente.Show();
    }

    }
}
