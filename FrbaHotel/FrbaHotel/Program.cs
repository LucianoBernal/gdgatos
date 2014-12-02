using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;

namespace FrbaHotel
{
    public class DetalleConId
    {
        public string Detalle { get; set; }
        public int Id { get; set; }
    }
    public class ListaConId
    {
        public List<DetalleConId> Lista { get; set; }
        public ComboBox Combo { get; set; }
        public string Text { get{
            return this.ObtenerId(this.Combo.Text).ToString();}}
        public void CargarDatos(ComboBox combo, string sql)
        {
            Query query = new Query(sql);
            foreach (DataRow dataRow in query.ObtenerDataTable().AsEnumerable())
            {
                this.Agregar((int)Convert.ToInt32(dataRow[0]), (string)dataRow[1]);
                combo.Items.Add(dataRow[1]);
            }
            combo.DisplayMember = "Key";
            combo.ValueMember = "Value";
            combo.Text = null;
            this.Combo = combo;
        }
        public int ObtenerId(string detalle)
        {
        //    this.Lista.Find( NO TENGO INTERNET POR DIOS
            foreach(DetalleConId elem in this.Lista)
            {
                if (elem.Detalle==detalle)
                    return elem.Id;
            }
            return -1;
        }
        public string ObtenerDetalle(int id)
        {
        //    this.Lista.Find(
            foreach(DetalleConId elem in this.Lista)
            {
                if (elem.Id == id)
                    return elem.Detalle;
            }
            return "";
        }
        public void Agregar(int id, string detalle)
        {
            DetalleConId nuevo = new DetalleConId();
            nuevo.Id = id;
            nuevo.Detalle = detalle;
            this.Lista.Add(nuevo);
        }
    }/*
    public class TextosIngresoList : List<ControlConCampo>
    {
        public void agregarControl(Control ctrl, string campo, bool apostrofe, bool combo)
        {
            ControlConCampo nuevo = new ControlConCampo();
            nuevo.control = ctrl;
            nuevo.campoAsociado = campo;
            nuevo.conApostrofe = apostrofe;
            nuevo.esCombo = combo;
            this.Add(nuevo);
        }
        public bool EstanTodosLlenos()
        {
            foreach(ControlConCampo elem in this)
            {
                if (((Control)elem.control).Text.Trim() == ""){
                    MessageBox.Show("El TextBox '" + ((Control)elem.control).Name + "' esta vacio");
                    ((Control)elem.control).Focus();
                    return false;
                }
            }
            return true;
        }
        public string GenerarUpdate()
        {
            string retorno = "";
            foreach (ControlConCampo elem in this)
            {
                string apostrofe = (elem.conApostrofe)?"'":"";
  //              string parenton = (elem.esCombo) ? "(" : "";
                string parentoff = (elem.esCombo) ? ")": "";
                retorno += elem.campoAsociado + " = " + apostrofe + elem.control.Text + apostrofe+ parentoff +", ";
            }
            return retorno.Substring(0, retorno.Length-2);
        }//Para sacar el ultimo ", "
    }
    public class ControlConCampo
    {
        public Control control { get; set; }
        public string campoAsociado { get; set; }
        public bool conApostrofe { get; set; }
        public bool esCombo { get; set; }
    }*/
    public class ControlConCheckBox
    {
        public CheckBox CheckBox;
        public Control Control { get; set; }
        public bool ConApostrofe{ get; set;} //Apostrofe significa si el dato que vamos a 
                                             //ingresar es un texto, en la consulta sql
                                             //deberiamos ingresar "'", cachais?
        public string CampoAsociado { get; set; } //Campo asociado es el que vamos a poner en la query
    }
    /*
    public class TextosBusqueda : List<ControlConCheckBox>
    {
        public string GenerarWhere(bool agregarComodin)
        {//Agregar asteriscos seria Hacer busquedas del estilo nombre like '%juan%'
         //Todavia no esta implementado
            string resultado = "";
            foreach (ControlConCheckBox elem in this)
            {
                if (elem.checkBox.Checked)
                {
                    string patitaonopatita = (elem.conApostrofe) ? "'" : "";
                    string asterisco = (agregarComodin) ? "%" : ""; //Para el combo no tiene 
                                                                                        //sentido porque siempre 
                                                                                        //vas a tener valores exactos
                    resultado += "AND " + elem.campoAsociado + ((agregarComodin) ? " LIKE " : " = ") +patitaonopatita + asterisco + elem.control.Text + asterisco + patitaonopatita; 
                }
            }
            return /*(resultado != "") ? resultado.Substring(4, resultado.Length - 4) : ""*//*resultado;
        }
        public void AgregarControl(CheckBox cb, bool apostrofe, string campo, Control ctrl)
        {
            ControlConCheckBox nuevo = new ControlConCheckBox();
            nuevo.checkBox = cb;
            nuevo.conApostrofe = apostrofe;
            nuevo.campoAsociado = campo;
            nuevo.control = ctrl;
            this.Add(nuevo);
        }
    }
    */
    public class ListaTextos : List<ControlConCheckBox>
    {
        public string GenerarBusqueda(bool usarComodin)
        {
            string retorno = "";
            foreach (ControlConCheckBox elem in this)
            {
                if (elem.CheckBox.Checked)
                {
                    string apostrofe = (elem.ConApostrofe) ? "'" : "";
                    string comodin = (usarComodin && elem.ConApostrofe) ? "%" : "";
                    retorno += " AND " + elem.CampoAsociado + ((usarComodin) ? " LIKE " : " = ") + apostrofe + comodin + elem.Control.Text + comodin + apostrofe;
                }
            }
            return retorno;
        }//Si es la primera condicion deberias sacarle los primeros 4 caracteres hijo
        public string GenerarUpdate()
        {
            string retorno = "";
            foreach (ControlConCheckBox elem in this)
            {
                string apostrofe = (elem.ConApostrofe) ? "'" : "";
                retorno += elem.CampoAsociado + "=" + apostrofe + elem.Control.Text + apostrofe + ", ";
            }
            return retorno.Substring(0, retorno.Length - 2);
        }
        public string GenerarInsert()
        {
            string retorno = "(";
            foreach (ControlConCheckBox elem in this)
            {
                retorno += elem.CampoAsociado + ", ";
            }
            retorno = retorno.Substring(0, retorno.Length - 2);
            retorno += ") VALUES (";
            foreach(ControlConCheckBox elem in this)
            {
                string apostrofe = (elem.ConApostrofe)?"'":"";
                retorno += apostrofe + elem.Control.Text + apostrofe + ", ";
            }
            retorno = retorno.Substring(0, retorno.Length -2);
            return retorno + ")";
        }
        public ControlConCheckBox Agregar(Control control, bool conApostrofe, string campo)
        {
            ControlConCheckBox nuevo = new ControlConCheckBox();
            nuevo.Control = control;
            nuevo.ConApostrofe = conApostrofe;
            nuevo.CampoAsociado = campo;
            this.Add(nuevo);
            return nuevo;
        }
        public void AgregarConCheck(Control control, bool conApostrofe, string campo, CheckBox checkBox)
        {
            this.Agregar(control, conApostrofe, campo).CheckBox = checkBox;
        }
        public bool EstanTodosLlenos()
        {
            foreach (ControlConCheckBox elem in this)
            {
                if (((Control)elem.Control).Text.Trim() == "")
                {
                    MessageBox.Show("El TextBox asociado al campo '" + elem.CampoAsociado + "' esta vacio");
 //                   ((Control)elem.Control).Focus();
                    return false;
                }
            }
            return true;
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmPrincipal());
        }
    }
}
