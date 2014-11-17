using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class FrmRol_Mod : Form
    {
        string rol;

        public FrmRol_Mod()
        {
            InitializeComponent();
        }

        private void FrmRol_Mod_Load(object sender, EventArgs e)
        {
            LlenarComboBox();
            botonBuscar.Enabled = false;
            chkHabilitado.Enabled = false;
            txtNombreRol.Enabled = false;
            botonGuardar.Enabled = false;
            comboRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void LlenarComboBox()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT nombre FROM SKYNET.Roles", conexion);
            da.Fill(ds, "SKYNET.Roles");

            comboRol.DataSource = ds.Tables[0].DefaultView;
            comboRol.ValueMember = "nombre";
            comboRol.SelectedItem = null;
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            rol = comboRol.Text.ToString();
            comboRol.Enabled = false;
            txtNombreRol.Enabled = true;
            chkHabilitado.Enabled = true;
            CargarDatosRol();
        }

        private void CargarDatosRol()
        {
            /* Setear el mismo nombre por defecto */
            txtNombreRol.Text = rol;

            CargarFuncionalidadesEnLista();
            /*VER*/string ConsultarFuncionalidades = " SELECT f.descripcion Funcionalidad " +
                                                " FROM SKYNET.RolFunciones rf" +
                                                " JOIN SKYNET.Roles r ON r.idRol = rf.rol" +
                                                " RIGHT JOIN SKYNET.Funciones f on f.idFuncion = rf.funcion" +
                                                " WHERE rf.rol= r.idRol " +
                                                " AND r.nombre = '" + rol + "' ";

            Query qry = new Query(ConsultarFuncionalidades);

            /* Para tildar las funcionalidades habilitadas */
            DataTable funcionalidades = qry.ObtenerDataTable();
            foreach (DataRow funcionalidad in funcionalidades.Rows)
            {
                string descripcionFuncionalidad = funcionalidad["Funcionalidad"].ToString();
                int index = Funcionalidades.FindString(descripcionFuncionalidad, 0);
                Funcionalidades.SetItemChecked(index, true);
            }

            /* Para tildar la casilla de Rol habilitado*/
            string Habilitado = "SELECT baja FROM SKYNET.Roles where nombre = '" + rol + "'";
            qry.pComando = Habilitado;
            chkHabilitado.Checked = (bool)qry.ObtenerUnicoCampo();

            /* Para deshabilitar el chequeo del box si el rol está habilitado 
             * para dar de baja el rol está el form de baja */
            if (chkHabilitado.Checked == true)
            {
                chkHabilitado.Enabled = false;
            }
        }

        /* Se cargan las funcionalidades de la tabla en check list*/
        private void CargarFuncionalidadesEnLista()
        {
            string sql = "SELECT descripcion, idFuncion FROM SKYNET.Funciones";
            Query qry = new Query(sql);
            List<KeyValuePair<string, int>> datos = (from x in qry.ObtenerDataTable().AsEnumerable()
                                                     select new
                                                     KeyValuePair<string, int>(x["descripcion"].ToString(), Convert.ToInt32(x["idFuncion"]))).ToList();

            Funcionalidades.DataSource = datos;
            Funcionalidades.DisplayMember = "Key";
            Funcionalidades.ValueMember = "Value";
        }

        private void txtNombreRol_TextChanged(object sender, EventArgs e)
        {
            if (txtNombreRol.Text != comboRol.Text)
            {
                botonGuardar.Enabled = true;
            }
            else
            {
                botonBuscar.Enabled = false;
            }
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            ActualizarFuncionalidades();
            GuardarModificaciones();

            MessageBox.Show("Modificación realizada con éxito!");

            this.Visible = false;
        }

        private void ActualizarFuncionalidades()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            string consulta = "SELECT idRol FROM SKYNET.Roles WHERE nombre = '" + rol + "'";
            Query qr = new Query(consulta);
            qr.pComando = consulta;
            int idRol = Convert.ToInt32(qr.ObtenerUnicoCampo());

            for (int i = 0; i < Funcionalidades.Items.Count; i++)
            {
                string sql;
                string Funcionalidad = Funcionalidades.Items[i].ToString().Replace(']', ' ').Substring(Funcionalidades.Items[i].ToString().IndexOf(',') + 1).TrimEnd();
                if (Funcionalidades.GetItemChecked(i))
                {
                    // insertar si no existe
                    sql = " INSERT INTO SKYNET.RolFunciones (funcion, rol)" +
                            " SELECT DISTINCT " + Funcionalidad + ", " + idRol + 
                            " from SKYNET.Funciones" +
                            " WHERE " + Funcionalidad + " NOT IN ( SELECT funcion FROM SKYNET.RolFunciones WJERE rol = " + idRol + ")";
                }
                else
                {
                    // borrar el registro en caso que este desmarcado (no es necesario chequear si existe)
                    sql = " DELETE FROM SKYNET.RolFunciones" +
                            " WHERE rol = " + idRol +
                            " AND funcion = " + Funcionalidad;
                }

                Query qry = new Query();
                qry.pComando = sql;
                qry.Ejecutar();
            }
        }

        private void GuardarModificaciones()
        {
            //FALTA
        }

        private void Funcionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Funcionalidades.CheckedItems.Count > 0)
            {
                botonGuardar.Enabled = true;
            }
            else
            {
                botonGuardar.Enabled = false;
            }
        }

        private void chkHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            botonGuardar.Enabled = true;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            if (comboRol.Enabled == true)
            {
                comboRol.SelectedItem = null;
            }

            txtNombreRol.Text = null;

            if (chkHabilitado.Checked != true)
            {
                chkHabilitado.Checked = false;
            }

            foreach (int i in Funcionalidades.CheckedIndices)
            {
                Funcionalidades.SetItemCheckState(i, CheckState.Unchecked);
            }

            botonGuardar.Enabled = false;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FrmRol rol = new FrmRol();
            this.Hide();
            rol.ShowDialog();
            rol = (FrmRol)this.ActiveMdiChild;
        }

        private void comboRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboRol.Text.Trim() != "")
            {
                botonBuscar.Enabled = true;
            }
        }
    }
}
