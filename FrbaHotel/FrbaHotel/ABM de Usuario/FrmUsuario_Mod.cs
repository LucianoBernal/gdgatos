using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class FrmUsuario_Mod : Form
    {
        public ListaTextos listaTextos = new ListaTextos();
        public ListaConId listaTipoDoc = new ListaConId();
        private int idUsuario;
        public FrmUsuario_Mod(int id)
        {
            InitializeComponent();
            idUsuario = id;
            this.AgregarTextos();
        }

        public void AgregarTextos() {
            listaTextos.Agregar(txtApellido, true, "apellido");
            listaTextos.Agregar(txtCalle, true, "calle");
            listaTextos.Agregar(txtMail, true, "mail");
            listaTextos.Agregar(txtNombre, true, "nombre");
            listaTextos.Agregar(txtNumCalle, false, "numCalle");
            listaTextos.Agregar(txtNumDoc, false, "numDoc");
            listaTextos.Agregar(txtTelefono, false, "telefono");
            listaTextos.Agregar(txtOcultoTipoDoc, false, "tipoDoc");
        }
        private void FrmUsuario_Mod_Load(object sender, EventArgs e)
        {
            listaTipoDoc.Lista = new List<DetalleConId>();
            listaTipoDoc.CargarDatos(txtTipoDoc, "SELECT idTipoDoc, nombre FROM SKYNET.TiposDoc");
            Query qry = new Query("SELECT apellido, calle, fechaNac, mail, nombre, numCalle, numDoc, telefono, tipoDoc FROM SKYNET.Usuarios WHERE idUser = " + idUsuario.ToString());
            foreach (DataRow datos in qry.ObtenerDataTable().AsEnumerable())
            {
                txtApellido.Text = datos[0].ToString();
                txtCalle.Text = datos[1].ToString();
                txtFecha.Text = datos[2].ToString();
                txtMail.Text = datos[3].ToString();
                txtNombre.Text = datos[4].ToString();
                txtNumCalle.Text = (datos[5].ToString().Length>3)?datos[5].ToString().Substring(0, datos[5].ToString().Length-3):datos[5].ToString();
                txtNumDoc.Text = (datos[6].ToString().Length > 3) ? datos[6].ToString().Substring(0, datos[6].ToString().Length - 3) : datos[6].ToString();
                txtTelefono.Text = (datos[7].ToString().Length > 3) ? datos[7].ToString().Substring(0, datos[7].ToString().Length - 3) : datos[7].ToString();
                txtTipoDoc.Text =  (datos[8].ToString()!="")? (listaTipoDoc.ObtenerDetalle(Convert.ToInt32(datos[8]))):(listaTipoDoc.ObtenerDetalle(1));
            }//Me tomo la molestia de los substrings porque esos numeros son (18, 2)
            //Se que me va a dar un solo registro pero no se hacerlo de otra forma sori
//           label10.Text = "UPDATE SKYNET.Usuarios SET " + listaTextos.GenerarUpdate() + " WHERE idUser = " + idUsuario.ToString();
//           new Query("UPDATE SKYNET.Usuarios SET " + listaTextos.GenerarUpdate() + " WHERE idUser = " + idUsuario.ToString()).Ejecutar();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            txtOcultoTipoDoc.Text = listaTipoDoc.ObtenerId(txtTipoDoc.Text).ToString();
            if (listaTextos.EstanTodosLlenos()){
//            MessageBox.Show("UPDATE SKYNET.Usuarios SET " + listaTextos.GenerarUpdate() + " WHERE idUser = " + idUsuario.ToString());
            new Query("UPDATE SKYNET.Usuarios SET " + listaTextos.GenerarUpdate() + " WHERE idUser = " + idUsuario.ToString()).Ejecutar();
            MessageBox.Show("Ya esta");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
