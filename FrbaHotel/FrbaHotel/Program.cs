using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FrbaHotel
{   
    public class TextosIngresoList : List<Control>
    {
        public bool EstanTodosLlenos()
        {
            foreach(Control elem in this)
            {
                if (((Control)elem).Text.Trim() == ""){
                    MessageBox.Show("El TextBox '" + ((Control)elem).Name + "' esta vacio");
                    ((Control)elem).Focus();
                    return false;
                }
            }
            return true;
        }
    }
    public class ControlConCheckBox
    {
        public CheckBox checkBox;
        public bool conApostrofe{ get; set;} //Apostrofe significa si el dato que vamos a 
                                             //ingresar es un texto, en la consulta sql
                                             //deberiamos ingresar "'", cachais?
        public string campoAsociado { get; set; } //Campo asociado es el que vamos a poner en la query
        public Control control{ get; set; }
        public bool esCombo { get; set; }
    }

    public class TextosBusqueda : List<ControlConCheckBox>
    {
        public string GenerarWhere(bool agregarAsteriscos)
        {//Agregar asteriscos seria Hacer busquedas del estilo nombre=*+'juan'+*
         //Todavia no esta implementado
            string resultado = "";
            foreach (ControlConCheckBox elem in this)
            {
                if (elem.checkBox.Checked)
                {
                    string patitaonopatita = (elem.conApostrofe) ? "'" : "";
                    resultado += "AND " + elem.campoAsociado + "=" + patitaonopatita + elem.control.Text + patitaonopatita + ((elem.esCombo)?")":""); 
                }
            }
            return /*(resultado != "") ? resultado.Substring(4, resultado.Length - 4) : ""*/resultado;
        }
        public void AgregarControl(CheckBox cb, bool apostrofe, string campo, Control ctrl, bool combo)
        {
            ControlConCheckBox nuevo = new ControlConCheckBox();
            nuevo.checkBox = cb;
            nuevo.conApostrofe = apostrofe;
            nuevo.campoAsociado = campo;
            nuevo.control = ctrl;
            nuevo.esCombo = combo;
            this.Add(nuevo);
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
