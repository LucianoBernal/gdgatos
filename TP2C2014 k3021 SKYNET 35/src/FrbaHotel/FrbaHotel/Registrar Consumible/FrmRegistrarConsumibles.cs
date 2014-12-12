using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class FrmRegistrarConsumibles : Form
    {
        public int IdReserva;
        public Form Padre;
        public ListaTextos listaTextos=new ListaTextos();
        public ListaTextos listaPosta = new ListaTextos(); //Solo me sirve para chequear vacios
        public ListaConId listaConsumibles=new ListaConId();
        public ListaConId listaPrecios= new ListaConId();
        public FrmRegistrarConsumibles(int idReserva, Form padre)
        {
            this.IdReserva = idReserva;
            this.Padre = padre;
            listaConsumibles.Lista = new List<DetalleConId>();
            listaPrecios.Lista = new List<DetalleConId>();
            InitializeComponent();
            txtOcultoEstadia.Text = idReserva.ToString();
            listaTextos.Agregar(txtCantidad, false, "cantidad");
            listaTextos.Agregar(txtOcultoConsumible, false, "consumible");
            listaTextos.Agregar(txtOcultoPrecio, false, "precioTotal");
            listaTextos.Agregar(txtOcultoEstadia, false, "estadia");
            listaPosta.Agregar(txtCantidad, false, "Cantidad");
            listaPosta.Agregar(txtConsumibles, false, "Consumibles");
            listaConsumibles.CargarDatos(txtConsumibles, "SELECT codigo, nombre FROM SKYNET.Consumibles");
            listaPrecios.CargarDatos(txtPrecios, "SELECT codigo, precio FROM SKYNET.Consumibles");
        }

        private void FrmRegistrarConsumibles_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            txtCantidad.Text = numCantidad.Value.ToString();
            if (listaPosta.EstanTodosLlenos())
            {
                txtOcultoConsumible.Text = listaConsumibles.ObtenerId(txtConsumibles.Text).ToString();
                txtOcultoPrecio.Text = (Convert.ToDecimal(listaPrecios.ObtenerDetalle(listaConsumibles.ObtenerId(txtConsumibles.Text))) * Convert.ToInt32(txtCantidad.Text)).ToString(".");
                new Query("INSERT INTO SKYNET.ConsumiblesEstadias " + listaTextos.GenerarInsert()).Ejecutar();
                //            MessageBox.Show("INSERT INTO SKYNET.ConsumiblesEstadias " + listaTextos.GenerarInsert());
                MessageBox.Show("Se ha registrado el consumo de " + txtCantidad.Text + " " + txtConsumibles.Text);
                this.btnVolver_Click(this, e);
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Visible=false;
            this.Padre.Show();
        }
    }
}
