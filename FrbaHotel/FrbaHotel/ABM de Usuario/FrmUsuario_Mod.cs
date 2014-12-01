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
        public TextosIngresoList listaTextos = new TextosIngresoList();
        private int idUsuario;
        public FrmUsuario_Mod(int id)
        {
            InitializeComponent();
            idUsuario = id;
            this.AgregarTextos();
        }

        public void AgregarTextos() {
/*            listaTextos.Add(txtApellido);
            listaTextos.Add(txtCalle);
            listaTextos.Add(txtFecha);
            listaTextos.Add(txtMail);
            listaTextos.Add(txtNombre);
            listaTextos.Add(txtNumCalle);
            listaTextos.Add(txtNumDoc);
            listaTextos.Add(txtTelefono);
            listaTextos.Add(txtTipoDoc);
 */
            listaTextos.agregarControl(txtApellido, "apellido", true, false);
            listaTextos.agregarControl(txtCalle, "calle", true, false);
 //           listaTextos.agregarControl(txtFecha, "fechaNac", true);
            listaTextos.agregarControl(txtMail, "mail", true, false);
            listaTextos.agregarControl(txtNombre, "nombre", true, false);
            listaTextos.agregarControl(txtNumCalle, "numCalle", false, false);
            listaTextos.agregarControl(txtNumDoc, "numDoc", false, false);
            listaTextos.agregarControl(txtTelefono, "telefono", false, false);
            listaTextos.agregarControl(txtTipoDoc, "tipoDoc = (SELECT u.tipoDoc FROM SKYNET.Usuarios u, SKYNET.tiposDoc t WHERE u.idUser = "+ idUsuario.ToString() + " AND t.idTipoDoc = u.tipoDoc AND t.nombre ", true, true);
        }
        private void FrmUsuario_Mod_Load(object sender, EventArgs e)
        {
            CargarTipoDoc();
            ObtenerTipoDocActual();
            Query qry = new Query("SELECT apellido, calle, fechaNac, mail, nombre, numCalle, numDoc, telefono FROM SKYNET.Usuarios WHERE idUser = " + idUsuario.ToString());
            foreach (DataRow datos in qry.ObtenerDataTable().AsEnumerable())
            {
                txtApellido.Text = datos[0].ToString();
                txtCalle.Text = datos[1].ToString();
                txtFecha.Text = datos[2].ToString();
                txtMail.Text = datos[3].ToString();
                txtNombre.Text = datos[4].ToString();
                txtNumCalle.Text = datos[5].ToString().Substring(0, datos[5].ToString().Length-3);
                txtNumDoc.Text = datos[6].ToString().Substring(0, datos[6].ToString().Length-3);
                txtTelefono.Text = datos[7].ToString().Substring(0, datos[7].ToString().Length-3);
            }//Me tomo la molestia de los substrings porque esos numeros son (18, 2)
            //Se que me va a dar un solo registro pero no se hacerlo de otra forma sori
//           label10.Text = "UPDATE SKYNET.Usuarios SET " + listaTextos.GenerarUpdate() + " WHERE idUser = " + idUsuario.ToString();
//           new Query("UPDATE SKYNET.Usuarios SET " + listaTextos.GenerarUpdate() + " WHERE idUser = " + idUsuario.ToString()).Ejecutar();
        }
        public void CargarTipoDoc()
        {
            string sql = "SELECT t.nombre FROM SKYNET.TiposDoc t ";


            Query qry = new Query(sql);


            foreach (DataRow dataRow in qry.ObtenerDataTable().AsEnumerable())
            {
                txtTipoDoc.Items.Add(dataRow[0]);
            }
            txtTipoDoc.DisplayMember = "Key";
            txtTipoDoc.ValueMember = "Value";
            txtTipoDoc.Text = null;
        }
        public void ObtenerTipoDocActual()
        {
            string sql = "SELECT t.nombre FROM SKYNET.TiposDoc t, SKYNET.Usuarios u WHERE t.idTipoDoc=u.tipoDoc AND u.idUser = " + idUsuario.ToString();
            Query qry = new Query(sql);
            txtTipoDoc.Text = Convert.ToString(qry.ObtenerUnicoCampo());
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
//            MessageBox.Show("UPDATE SKYNET.Usuarios SET " + listaTextos.GenerarUpdate() + " WHERE idUser = " + idUsuario.ToString());
            new Query("UPDATE SKYNET.Usuarios SET " + listaTextos.GenerarUpdate() + " WHERE idUser = " + idUsuario.ToString()).Ejecutar();
            MessageBox.Show("Ya esta");
        }
    }
}
