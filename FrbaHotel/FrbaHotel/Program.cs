using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FrbaHotel
{   
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
        public string GenerarWhere(bool agregarComodin)
        {//Agregar asteriscos seria Hacer busquedas del estilo nombre like '%juan%'
         //Todavia no esta implementado
            string resultado = "";
            foreach (ControlConCheckBox elem in this)
            {
                if (elem.checkBox.Checked)
                {
                    string patitaonopatita = (elem.conApostrofe) ? "'" : "";
                    string asterisco = (agregarComodin && !elem.esCombo) ? "%" : ""; //Para el combo no tiene 
                                                                                        //sentido porque siempre 
                                                                                        //vas a tener valores exactos
                    resultado += "AND " + elem.campoAsociado + ((agregarComodin && !elem.esCombo) ? " LIKE " : " = ") +patitaonopatita + asterisco + elem.control.Text + asterisco + patitaonopatita + ((elem.esCombo) ? ")" : ""); 
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
