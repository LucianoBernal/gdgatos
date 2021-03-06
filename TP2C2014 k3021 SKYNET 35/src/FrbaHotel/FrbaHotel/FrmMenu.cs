﻿using System;
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
using FrbaHotel.Cancelar_Reserva;
using FrbaHotel.Registrar_Consumible;
using FrbaHotel.Listado_Estadistico;
using FrbaHotel.ABM_de_Habitacion;
using FrbaHotel.Registrar_Estadia;
using FrbaHotel.ABM_de_Regimen;
using FrbaHotel.Facturar;


namespace FrbaHotel
{
    public partial class FrmMenu : Form
    {
        private int idUsuario;
        private string nombreUsuario;
        private int idRol;
        Funciones fn = new Funciones();
        public void RespuestaDialog(string respuesta, int tipoResp)
        {//A esta hora me importa poco repetir codigo
            if (tipoResp == 1 && respuesta != null)
            {
                object query = new Query("SELECT estado FROM SKYNET.Reservas WHERE codigoReserva =" + respuesta + " AND hotel= " + Globales.idHotelElegido + " ").ObtenerUnicoCampo();
               
                if (query == null)
                {
                    if (Convert.ToInt32(respuesta) > 0)
                    {
                        MessageBox.Show("Ha ingresado un numero de reserva no valido");
                        this.Show();
                    }
                    else {
                        FrmReserva nuevo = new FrmReserva(Convert.ToUInt32(respuesta), this);
                        nuevo.ShowDialog();
                    }
                    //TerminarMetodo
                }
                else
                {
                    if (Convert.ToInt32(query) == 1 || Convert.ToInt32(query) == 5 || Convert.ToInt32(query) == 6)
                    {
                        MessageBox.Show("La reserva ingresada se encuentra cancelada");
                        this.Show();
                        //TerminarMetodo
                    }
                    if (Convert.ToInt32(query) == 2)
                    {
                        MessageBox.Show("La reserva ya tiene una estadia asociada, por lo cual no puede modificarse");
                        this.Show();
                        //TerminarMetodo
                    }
                    if (Convert.ToInt32(query) == 3 || Convert.ToInt32(query) == 4)
                    {
                        FrmReserva nuevo = new FrmReserva(Convert.ToUInt32(respuesta), this);
                        nuevo.ShowDialog();
                    }
                }
            }
            if (tipoResp == 2 && respuesta != null)
            {
                object query = new Query("SELECT estado FROM SKYNET.Reservas WHERE codigoReserva =" + respuesta + " AND hotel= " + Globales.idHotelElegido + " ").ObtenerUnicoCampo();
                if (query == null)
                {
                    MessageBox.Show("Ha ingresado un numero de reserva no valido");
                    this.Show();
                    //TerminarMetodo
                }
                else
                {
                    if (Convert.ToInt32(query) == 1 || Convert.ToInt32(query) == 5 || Convert.ToInt32(query) == 6)
                    {
                        MessageBox.Show("La reserva ingresada ya se encuentra cancelada");
                        this.Show();
                        //TerminarMetodo
                    }
                    if (Convert.ToInt32(query) == 2)
                    {
                        MessageBox.Show("La reserva ya tiene una estadia asociada, por lo cual no puede ser cancelada");
                        this.Show();
                        //TerminarMetodo
                    }
                    if (Convert.ToInt32(query) == 3 || Convert.ToInt32(query) == 4)
                    {
                        FrmCancelarReserva nuevo = new FrmCancelarReserva(Convert.ToInt32(respuesta), this);
                        nuevo.ShowDialog();
                    }
                }
            }
            if (tipoResp == 3 && respuesta != null)
            {
                object query = new Query("SELECT estado FROM SKYNET.Reservas WHERE codigoReserva =" + respuesta + " AND hotel= " + Globales.idHotelElegido + " ").ObtenerUnicoCampo();
                object query2 = new Query("SELECT TOP 1 * FROM SKYNET.Facturas WHERE estadia =" + respuesta).ObtenerUnicoCampo();
                    if (query == null)
                    {
                        MessageBox.Show("Ha ingresado un numero de reserva no valido");
                        this.Show();
                        //TerminarMetodo
                    }
                    else {               if (query2 != null)
                {
                    MessageBox.Show("La reserva ingresada ya ha sido facturada");
                    this.Show();
                }else 
                    {
                        if (Convert.ToInt32(query) == 1 || Convert.ToInt32(query) == 5 || Convert.ToInt32(query) == 6)
                        {
                            MessageBox.Show("La reserva ingresada se encuentra cancelada");
                            this.Show();
                            //TerminarMetodo
                        }
                        if (Convert.ToInt32(query) == 2)
                        {//Deberia ademas preguntar que la estadia no tiene fecha de egreso
                            FrmRegistrarConsumibles nuevo = new FrmRegistrarConsumibles(Convert.ToInt32(respuesta), this);
                            nuevo.ShowDialog();
                        }
                        if (Convert.ToInt32(query) == 3 || Convert.ToInt32(query) == 4)
                        {
                            MessageBox.Show("La reserva no se encuentra efectivizada, y por lo tanto no es posible registrar consumos");
                            this.Show();
                        }
                    }
                }
            }
            if (tipoResp == 4 && respuesta != null)
            {
                object query = new Query("SELECT estado FROM SKYNET.Reservas WHERE codigoReserva =" + respuesta).ObtenerUnicoCampo();
                if (query == null)
                {
                        MessageBox.Show("Ha ingresado un numero de reserva no valido");
                        this.Show();
                }
                else
                {
                    if (Convert.ToInt32(query) == 1 || Convert.ToInt32(query) == 5 || Convert.ToInt32(query) == 6)
                    {
                        MessageBox.Show("La reserva ingresada se encuentra cancelada");
                        this.Show();
                        //TerminarMetodo
                    }
                    if (Convert.ToInt32(query) == 2)
                    {
                        if ((new Query("SELECT cantNoches FROM SKYNET.Estadias WHERE reserva =" + respuesta).ObtenerUnicoCampo()) != null)
                        {

                            int hotel = Convert.ToInt32(new Query("SELECT hotel FROM SKYNET.Reservas WHERE codigoReserva =" + respuesta).ObtenerUnicoCampo());
                            if (hotel == Globales.idHotelElegido)
                            {
                                FrmFacturar nuevo = new FrmFacturar(this, Convert.ToInt32(respuesta));
                                nuevo.Show();
                            }
                            else{
                                MessageBox.Show("La reserva ingresada no se corresponde con el hotel logueado");
                                this.Show();
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("No se encuentra registrado el checkout de la estadia");
                            this.Show();
                        }//TerminarMetodo
                    }
                    if (Convert.ToInt32(query) == 3 || Convert.ToInt32(query) == 4)
                    {
                        MessageBox.Show("La reserva no tiene una estadia asociada, por lo cual no puede facturarse");
                        this.Show();
                    }
                }
            } if (tipoResp == 5 && respuesta != null)
            {
                //MessageBox.Show("SELECT estado FROM SKYNET.Reservas WHERE codigoReserva =" + respuesta+" AND hotel= "+ Globales.idHotelElegido +" ");
                object query = new Query("SELECT estado FROM SKYNET.Reservas WHERE codigoReserva =" + respuesta+" AND hotel= "+ Globales.idHotelElegido +" ").ObtenerUnicoCampo();
                if (query == null)
                {
                    MessageBox.Show("Ha ingresado un numero de reserva no valido");
                    this.Show();
                }
                else
                {
                    if (Convert.ToInt32(query) == 1 || Convert.ToInt32(query) == 5 || Convert.ToInt32(query) == 6)
                    {
                        MessageBox.Show("La reserva ingresada se encuentra cancelada");
                        this.Show();
                        //TerminarMetodo
                    }
                    else {
                        object query2=null;
                        if(Convert.ToInt32(query)==2)
                                 query2 = new Query("SELECT cantNoches FROM SKYNET.Estadias WHERE reserva =" + respuesta).ObtenerUnicoCampo();
                        if (((query2 is DBNull)&&(Convert.ToInt32(query)==2))||(Convert.ToInt32(query)!=2))
                        {
                            FormRsrvEstd form = new FormRsrvEstd(this, Convert.ToInt32(respuesta), Convert.ToInt32(query));
                            this.Visible = false;
                            form.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Ya se ha registrado un checkout para la estadia ingresada");
                            this.Show();
                        }
                    }
                }
            }
        }
        public FrmMenu()
        {
            InitializeComponent();

            idUsuario = Globales.idUsuarioLogueado;
//            Globales.fechaSistema = Settings.Default.FechaSistema.ToShortDateString();

            this.btnCancelarEstadia.Enabled = false;
            this.btnClientes.Enabled = false;
            this.btnFacturar.Enabled = false;
            this.btnHabitacion.Enabled = false;
            this.btnHotel.Enabled = false;
            this.btnListadoEstadistico.Enabled = false;
            this.btnReserva.Enabled = false;
            this.btnRegimenEstadia.Enabled = false;
            this.btnRegistrarConsumible.Enabled = false;
            this.btnRegistrarEstadia.Enabled = false;
            this.btnRoles.Enabled = false;
            this.btnUsuario.Enabled = false;
            this.btnListadoEstadistico.Enabled = false;
            linkCambiarContraseña.Visible = false;
            lblUsuarioLogueado.Visible = false;
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            nombreUsuario = fn.getUsername(idUsuario);
            idRol = Globales.idRolElegido;
            cargarMenu();
            cargarConfig();
        }
        public void cargarConfig() {
            Funciones fn = new Funciones();
            string text = System.IO.File.ReadAllText( Application.StartupPath.Substring(0, Application.StartupPath.Length-9) + "App.ini");
            Globales.fechaSistema = fn.TransformarABD(text.Substring(6,text.Length-6));
  //          new Query("UPDATE SKYNET.Config SET fecha='" + Globales.fechaSistema+"'").Ejecutar();
            new Query("UPDATE SKYNET.Config SET fecha=(SELECT convert(datetime, '"+Globales.fechaSistema+"', 121))").Ejecutar();
            
            label1.Text = Globales.fechaSistema;
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
                    case 1: this.btnRoles.Enabled = true;
                        break;

                    //ABM USUARIO
                    case 2: this.btnUsuario.Enabled = true;
                        break;

                    //ABM CLIENTES
                    case 3: this.btnClientes.Enabled = true;
                        break;

                    //ABM HOTEL
                    case 4: this.btnHotel.Enabled = true;
                        break;

                    //ABM HABITACION
                    case 5: this.btnHabitacion.Enabled = true;
                        break;

                    //ABM REGIMEN DE ESTADIA
                    case 6: this.btnRegimenEstadia.Enabled = true;
                        break;

                    //GENERAR O MODIFICAR RESERVA
                    case 7: this.btnReserva.Enabled = true;
                        break;

                    //CANCELAR RESERVA
                    case 8: this.btnCancelarEstadia.Enabled = true;
                        break;

                    //REGISTRAR ESTADIA
                    case 9: this.btnRegistrarEstadia.Enabled = true;
                        break;

                    //REGISTRAR CONSUMIBLES
                    case 10: this.btnRegistrarConsumible.Enabled = true;
                        break;

                    //FACTURAR
                    case 11: this.btnFacturar.Enabled = true;
                        break;

                    //LISTADO ESTADISTICO
                    case 12: this.btnListadoEstadistico.Enabled = true;
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
            this.Visible=false;
            FrmRol rol = new FrmRol();
            rol.ShowDialog();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            this.Visible=false;
            FrmUsuario usuario = new FrmUsuario();
            usuario.ShowDialog();
        }

        private void btnHotel_Click(object sender, EventArgs e)
        {
            this.Visible=false;
            FrmHotel hotel = new FrmHotel();
            hotel.ShowDialog();
        }

        private void btnRegimenEstadia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esto no se encuentra en el dominio del trabajo practico.");
            /*this.Visible=false;
            FrmRegimenes reg = new FrmRegimenes();
            reg.ShowDialog();*/
        }

        private void btnReserva_Click(object sender, EventArgs e)
        {
            FrmDialogBox dialog = new FrmDialogBox(this, "Si tiene su numero de reserva, ingresela. Si quiere crear una, ingrese 0", 1);
            this.Visible=false;
            dialog.ShowDialog();

        }

	private void btnClientes_Click(object sender, EventArgs e)
        {
            this.Visible=false;
            FrmCliente cliente = new FrmCliente();
            cliente.ShowDialog();
        }

    private void btnClientes_Click_1(object sender, EventArgs e)
    {
        this.Visible=false;
        FrmCliente cliente = new FrmCliente();
        cliente.ShowDialog();
    }

    private void btnCancelarEstadia_Click(object sender, EventArgs e)
    {
        this.Visible=false;
        FrmDialogBox dialog = new FrmDialogBox(this, "Ingrese el numero de reserva", 2);
        dialog.ShowDialog();
    }

    private void btnRegistrarConsumible_Click(object sender, EventArgs e)
    {
        this.Visible=false;
        FrmDialogBox dialog = new FrmDialogBox(this, "Ingrese el numero de reserva asociado a la estadia", 3);
        dialog.ShowDialog();
    }

    private void btnListadoEstadistico_Click(object sender, EventArgs e)
    {
        this.Visible=false;
        FrmListadoEstadistico nuevo = new FrmListadoEstadistico();
        nuevo.ShowDialog();
    }

    private void btnHabitacion_Click(object sender, EventArgs e)
    {
        this.Visible=false;
        FrmHabitacion habitacion = new FrmHabitacion();
        habitacion.ShowDialog();
    }

    private void btnRegistrarEstadia_Click(object sender, EventArgs e)
    {/*
        FormRsrvEstd form = new FormRsrvEstd();
        this.Visible = false;
        form.ShowDialog();*/
        /*this.Visible=false;*/
        FrmDialogBox dialog = new FrmDialogBox(this, "Ingrese el numero de reserva asociado a la estadia", 5);
        this.Visible = false;
        dialog.ShowDialog();
    }

    private void btnFacturar_Click(object sender, EventArgs e)
    {
        this.Visible=false;
        FrmDialogBox dialog = new FrmDialogBox(this, "Ingrese el numero de reserva asociado a la estadia a facturar", 4);
        dialog.ShowDialog();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void linkCambiarContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        FrmChangePass frm = new FrmChangePass();
        this.Visible=false;
        frm.ShowDialog();
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        Globales.idHotelElegido = 0;
        Globales.idRol = 0;
        Globales.idRolElegido = 0;
        Globales.idUsuarioLogueado = 0;
        FrmPrincipal frm = new FrmPrincipal();
        this.Visible=false;
        frm.ShowDialog();
    }

    }
}
