using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FrbaHotel
{/*
    public class TextBoxConControl : TextBox
    {
        public void ChequearVacio()
        {
            if (this.Text.Trim()=="")
            {
                MessageBox.Show("El textbox '" + this.Name + "' se encuentra vacio");
            }
        }
    }*/
    
    public class TextList : List<TextBox>
    {
        public bool estanTodosLlenos()
        {
            foreach(TextBox elem in this)
            {
                if (elem.Text.Trim() == ""){
                    MessageBox.Show("El TextBox '" + elem.Name + "' esta vacio");
                    elem.Focus();
                    return false;
                }
            }
            return true;
        }
    }
    public class ComboList : List<ComboBox>
    {
        public bool estaTodosLlenos()
        {
            foreach (ComboBox elem in this)
            {
                if (elem.Text == "")
                {
                    MessageBox.Show("No ha seleccionado datos en el ComboBox '" + elem.Name + "'");
                    elem.Focus();
                    return false;
                }
            }
            return true;
        }
    }
    //No se si tiene sentido consultar las fechas dado que desconozco si pueden tomar un valor en blanco
    //De ultima que quede la fecha de hoy

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
