using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
                " FROM SKYNET.Hoteles h WHERE 1=1  ";
            if (txtCiudad.Text != "")
            {
                strQuery = strQuery + " AND h.ciudad = '" + txtCiudad + "' ";
            }
            if (txtNombre.Text != "")
            {
                strQuery = strQuery + " AND h.nombre = '" + txtNombre + "' ";
            }
            if (txtEstrellas.Text != "")
            {
                strQuery = strQuery + " AND h.cantidadEstrellas = '" + txtEstrellas + "' ";
            }
            if (txtPais.Text != "")
            {
                strQuery = strQuery + " AND h.pais = '" + txtPais + "' ";
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

        }
    }
}
