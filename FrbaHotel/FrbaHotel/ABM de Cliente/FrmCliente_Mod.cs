﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class FrmCliente_Mod : Form
    {
        public ListaTextos listaTextos = new ListaTextos();
        public ListaConId listaTipoDoc = new ListaConId();
        public ListaConId listaNacionalidad = new ListaConId();
        public ListaConId listaPaisDeOrigen = new ListaConId();
        int idCliente;
        string mailAnterior, tipoDocAnterior, numDocAnterior;
        public FrmCliente_Mod(int id)
        {
            InitializeComponent();
            idCliente = id;
            AgregarTextos();
        }
        public void AgregarTextos()
        {
            listaTextos.Agregar(txtApellido, true, "apellido");
            listaTextos.Agregar(txtCalle, true, "calle");
            listaTextos.Agregar(txtMail, true, "mail");
            listaTextos.Agregar(txtNombre, true, "nombre");
            listaTextos.Agregar(txtNumCalle, false, "numCalle");
            listaTextos.Agregar(txtNumDoc, false, "numDoc");
            listaTextos.Agregar(txtTelefono, false, "telefono");
            listaTextos.Agregar(txtOcultoTipoDoc, false, "tipoDoc");
            listaTextos.Agregar(txtOcultoNacionalidad, false, "nacionalidad");
            listaTextos.Agregar(txtOcultoPaisDeOrigen, false, "paisDeOrigen");
        }

        private void FrmCliente_Mod_Load(object sender, EventArgs e)
        {
            listaTipoDoc.Lista = new List<DetalleConId>();
            listaTipoDoc.CargarDatos(txtTipoDoc, "SELECT idTipoDoc, nombre FROM SKYNET.TiposDoc");
            listaNacionalidad.Lista = new List<DetalleConId>();
            listaNacionalidad.CargarDatos(txtNacionalidad, "SELECT idNacionalidad, nacionalidad FROM SKYNET.Nacionalidades");
            listaPaisDeOrigen.Lista = new List<DetalleConId>();
            listaPaisDeOrigen.CargarDatos(txtPaisDeOrigen, "SELECT idPais, pais FROM SKYNET.Paises");
            Query qry = new Query("SELECT apellido, calle, fechaNac, mail, nombre, numCalle, numDoc, telefono, tipoDoc, piso, depto, nacionalidad, "+
                        " baja, rol, paisDeOrigen, inconsistencia FROM SKYNET.Clientes WHERE idCliente = " + idCliente.ToString());
            foreach (DataRow datos in qry.ObtenerDataTable().AsEnumerable())
            {
                txtApellido.Text = datos[0].ToString();
                txtCalle.Text = datos[1].ToString();
                txtFecha.Text = datos[2].ToString();
                txtMail.Text = datos[3].ToString();
                mailAnterior = datos[3].ToString();
                txtNombre.Text = datos[4].ToString();
                txtNumCalle.Text = (datos[5].ToString().Length > 3) ? datos[5].ToString().Substring(0, datos[5].ToString().Length - 3) : datos[5].ToString();
                txtNumDoc.Text = (datos[6].ToString().Length > 3) ? datos[6].ToString().Substring(0, datos[6].ToString().Length - 3) : datos[6].ToString();
                numDocAnterior = (datos[6].ToString().Length > 3) ? datos[6].ToString().Substring(0, datos[6].ToString().Length - 3) : datos[6].ToString();
                txtTelefono.Text = (datos[7].ToString().Length > 3) ? datos[7].ToString().Substring(0, datos[7].ToString().Length - 3) : datos[7].ToString();
                txtTipoDoc.Text = (datos[8].ToString() != "") ? (listaTipoDoc.ObtenerDetalle(Convert.ToInt32(datos[8]))) : (listaTipoDoc.ObtenerDetalle(1));
                tipoDocAnterior = (datos[8].ToString() != "") ? (listaTipoDoc.ObtenerDetalle(Convert.ToInt32(datos[8]))) : (listaTipoDoc.ObtenerDetalle(1));
                txtPiso.Text = datos[9].ToString();
                txtDepto.Text = datos[10].ToString();
                txtNacionalidad.Text = (datos[11].ToString() != "") ? (listaNacionalidad.ObtenerDetalle(Convert.ToInt32(datos[11]))) : (listaNacionalidad.ObtenerDetalle(1));

                if (datos[12].ToString() == "True")
                {
                    txtBaja.Checked = true;
                }
                txtRol.Text = datos[13].ToString();
                txtPaisDeOrigen.Text = (datos[14].ToString() != "") ? (listaPaisDeOrigen.ObtenerDetalle(Convert.ToInt32(datos[14]))) : (listaPaisDeOrigen.ObtenerDetalle(1));
                if (datos[15].ToString() == "True")
                {
                    txtInconsistencia.Checked = true;
                }
            }
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmCliente_List cliente = new FrmCliente_List();
            this.Hide();
            cliente.ShowDialog();
            cliente = (FrmCliente_List)this.ActiveMdiChild;
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            txtOcultoTipoDoc.Text = listaTipoDoc.ObtenerId(txtTipoDoc.Text).ToString();
            txtOcultoNacionalidad.Text = listaNacionalidad.ObtenerId(txtNacionalidad.Text).ToString();
            txtOcultoPaisDeOrigen.Text = listaPaisDeOrigen.ObtenerId(txtPaisDeOrigen.Text).ToString();
            if (listaTextos.EstanTodosLlenos())
            {
                int numDoc, numCalle, telefono;
                bool okNumDoc = int.TryParse(txtNumDoc.Text, out numDoc);
                if (okNumDoc == false)
                {
                    MessageBox.Show("El numero de Documento no es un Numero.");
                }
                bool okNumCalle = int.TryParse(txtNumCalle.Text, out numCalle);
                if (okNumCalle == false)
                {
                    MessageBox.Show("El numero de Calle no es un Numero.");
                }
                bool okTelefono = int.TryParse(txtTelefono.Text, out telefono);
                if (okTelefono == false)
                {
                    MessageBox.Show("El telefono debe ser solo numeros.");
                }
                if (okTelefono == true && okNumCalle == true && okNumDoc == true)
                {
                    if ((!existeMail(txtMail.Text)) && (!existeCliente(txtOcultoTipoDoc.Text, txtNumDoc.Text)))
                    {
                        int incons;
                        int baja;
                        if (txtBaja.Checked == true)
                        {
                            baja = 1;
                        }
                        else
                        {
                            baja = 0;
                        }
                        if (txtInconsistencia.Checked == true)
                        {
                            incons = 1;
                        }
                        else
                        {
                            incons = 0;
                        }
                        string strquery = "UPDATE SKYNET.Clientes SET nombre = '" + txtNombre.Text + "', apellido = '" + txtApellido.Text + "', tipoDoc = " + txtOcultoTipoDoc.Text + ", numDoc = " + txtNumDoc.Text + ", " +
                            " mail = '" + txtMail.Text + "', telefono = " + txtTelefono.Text + ", calle ='" + txtCalle.Text + "', nacionalidad = " + txtOcultoNacionalidad.Text + ", " +
                            " numCalle = " + txtNumCalle.Text + ", fechaNac = '" + txtFecha.Value + "', baja = " + baja + ", rol = " + txtRol.Text + ", paisDeOrigen = " + txtOcultoPaisDeOrigen.Text + ", inconsistencia = " + incons + " ";
                        if (txtPiso.Text != "")
                        {
                            strquery = strquery + ", piso = " + txtPiso.Text + "";
                        }
                        if (txtDepto.Text != "")
                        {
                            strquery = strquery + ", depto = '" + txtDepto.Text + "' ";
                        }
                        strquery = strquery + "WHERE idCliente = " + idCliente.ToString();
                        new Query().Ejecutar();
                        MessageBox.Show("Ya esta");
                    }
                }
            }
        }
        private bool existeCliente(string tipoDoc, string numero)
        {
            if (tipoDocAnterior == tipoDoc && numero == numDocAnterior)
            {
                return (false);
            }else{
                int retornar = (int)new Query("SELECT COUNT(1) FROM SKYNET.Clientes WHERE tipoDoc = " + tipoDoc + " AND numDoc = " + numero + " ").ObtenerUnicoCampo();
                if (retornar == 1)
                {
                    MessageBox.Show("Ya existe el cliente. Por favor verifique el tipo y numero de documento ingresado.");
                }
                return (retornar == 1);
            }
        }
        private bool existeMail(string mail)
        {
            if (mailAnterior == mail)
            {
                return (false);
            }
            else
            {
                int retornar = (int)new Query("SELECT COUNT(1) FROM SKYNET.Clientes WHERE mail ='" + mail + "' ").ObtenerUnicoCampo();
                if (retornar == 1)
                {
                    MessageBox.Show("Ya existe el mail ingresado. Por favor verifiquelo.");
                }
                return (retornar == 1);
            }
        }
    }
}
