using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Facturar
{
    public partial class FrmFacturar : Form
    {
        public Form Padre;
        public int Reserva;
        public ListaConId listaPagos = new ListaConId();
        public FrmFacturar()
        {
            InitializeComponent();
        }
        public FrmFacturar(Form padre, int reserva) {
            this.Padre = padre;
            this.Reserva = reserva;
            InitializeComponent();
            this.txtReserva.Text = reserva.ToString();
            listaPagos.Lista = new List<DetalleConId>();
            listaPagos.CargarDatos(txtTipoPago, "SELECT idTipoPago, nombre FROM SKYNET.TiposPago");
            txtTipoPago.Text = txtTipoPago.Items[0].ToString();
        }
        private void FrmFacturar_Load(object sender, EventArgs e)
        {

        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            new Query("exec SKYNET.facturarUnaEstadia @estadia=" + this.Reserva.ToString() + ", @fecha='" + System.DateTime.Today.ToString() + "', @nombreTipoPago='" + txtTipoPago.Text + "', @numTarjeta=" + (txtNumeroTarjeta.Text==""?"0":txtNumeroTarjeta.Text) + ", @datosTarjeta='" + txtDatosTarjeta.Text+"'").Ejecutar();
            //Ponele que ya deberia haber facturado
            string strquery = "SELECT * FROM SKYNET.emitirFactura(" + this.Reserva.ToString() + ")";
            mostrarResultado(strquery);
        }
        private void mostrarResultado(string strQuery)
        {
            Query resultado = new Query(strQuery);
            dataResultado.DataSource = resultado.ObtenerDataTable();
//            dataResultado.Columns["idUser"].Visible = false;  //oculto esta columna
            dataResultado.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
//            btnDeshabilitar.Visible = true;
//            btnHabilitar.Visible = true;
//            btnModificar.Visible = true;
        }
        private void txtTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNumeroTarjeta.Enabled = txtTipoPago.Text == "Tarjeta Debito" || txtTipoPago.Text == "Tarjeta Credito";
            txtDatosTarjeta.Enabled = txtTipoPago.Text == "Tarjeta Debito" || txtTipoPago.Text == "Tarjeta Credito";
            txtDatosTarjeta.Text = (!(txtTipoPago.Text == "Tarjeta Debito" || txtTipoPago.Text == "Tarjeta Credito"))?"":txtDatosTarjeta.Text;
            txtNumeroTarjeta.Text = (!(txtTipoPago.Text == "Tarjeta Debito" || txtTipoPago.Text == "Tarjeta Credito")) ?"0" : txtNumeroTarjeta.Text;
        }
    }
}
