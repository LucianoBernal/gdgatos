using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Regimen
{
    public partial class FrmRegimen_Alta : Form
    {
        public ListaTextos listaTextos = new ListaTextos();

        public FrmRegimen_Alta()
        {
            InitializeComponent();
            listaTextos.Agregar(txtDescripcion, true, "descripcion");
            listaTextos.Agregar(txtOcultoPrecio, false, "precioBase");
            listaTextos.Agregar(txtHabilitado, false, "habilitado");
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmRegimenes rol = new FrmRegimenes();
            this.Visible=false;
            rol.ShowDialog();
            rol = (FrmRegimenes)this.ActiveMdiChild;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = null;
            numPrecio.Text = null;
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            txtOcultoPrecio.Text = numPrecio.Value.ToString();
            if (listaTextos.EstanTodosLlenos())
            {
                string Habilitado = "SELECT COUNT(1) FROM SKYNET.Regimenes where descripcion = '" + txtDescripcion.Text + "'";
                Query qry = new Query(Habilitado);
                qry.pComando = Habilitado;
                int existeReg = (int)qry.ObtenerUnicoCampo();

                if (existeReg == 1)
                {
                    txtDescripcion.Text = null;
                    MessageBox.Show("Descripcion de regimen ya existente - Ingresar una nueva descripcion"
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string sql = "INSERT INTO SKYNET.Regimenes ";
                    sql += listaTextos.GenerarInsert();
                    new Query(sql).Ejecutar();
                    MessageBox.Show("El regimen "+txtDescripcion.Text+" se dio de alta satisfactoriamente");

                    FrmRegimenes rol = new FrmRegimenes();
                    this.Visible=false;
                    rol.ShowDialog();
                    rol = (FrmRegimenes)this.ActiveMdiChild;
                }   
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            botonGuardar.Visible = true;
        }

        private void FrmRegimen_Alta_Load(object sender, EventArgs e)
        {

        }
    }
}
