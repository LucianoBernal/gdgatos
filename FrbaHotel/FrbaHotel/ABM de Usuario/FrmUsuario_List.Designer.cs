namespace FrbaHotel.ABM_de_Usuario
{
    partial class FrmUsuario_List
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDinamica = new System.Windows.Forms.CheckBox();
            this.cbExacta = new System.Windows.Forms.CheckBox();
            this.cbMail = new System.Windows.Forms.CheckBox();
            this.cbApellido = new System.Windows.Forms.CheckBox();
            this.cbNombre = new System.Windows.Forms.CheckBox();
            this.cbHotel = new System.Windows.Forms.CheckBox();
            this.cbRol = new System.Windows.Forms.CheckBox();
            this.cbUsername = new System.Windows.Forms.CheckBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtHotel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRol = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataResultado = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnDeshabilitar = new System.Windows.Forms.Button();
            this.btnHabilitar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtOcultoRoles = new System.Windows.Forms.TextBox();
            this.txtOcultoHoteles = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDinamica);
            this.groupBox1.Controls.Add(this.cbExacta);
            this.groupBox1.Controls.Add(this.cbMail);
            this.groupBox1.Controls.Add(this.cbApellido);
            this.groupBox1.Controls.Add(this.cbNombre);
            this.groupBox1.Controls.Add(this.cbHotel);
            this.groupBox1.Controls.Add(this.cbRol);
            this.groupBox1.Controls.Add(this.cbUsername);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtMail);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.txtHotel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtRol);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(565, 131);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscador";
            // 
            // cbDinamica
            // 
            this.cbDinamica.AutoSize = true;
            this.cbDinamica.Checked = true;
            this.cbDinamica.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDinamica.Location = new System.Drawing.Point(392, 104);
            this.cbDinamica.Name = "cbDinamica";
            this.cbDinamica.Size = new System.Drawing.Size(121, 17);
            this.cbDinamica.TabIndex = 29;
            this.cbDinamica.Text = "Búsqueda Dinámica";
            this.cbDinamica.UseVisualStyleBackColor = true;
            this.cbDinamica.CheckedChanged += new System.EventHandler(this.cbDinamica_CheckedChanged);
            // 
            // cbExacta
            // 
            this.cbExacta.AutoSize = true;
            this.cbExacta.Location = new System.Drawing.Point(245, 104);
            this.cbExacta.Name = "cbExacta";
            this.cbExacta.Size = new System.Drawing.Size(110, 17);
            this.cbExacta.TabIndex = 28;
            this.cbExacta.Text = "Búsqueda Exacta";
            this.cbExacta.UseVisualStyleBackColor = true;
            this.cbExacta.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cbMail
            // 
            this.cbMail.AutoSize = true;
            this.cbMail.Location = new System.Drawing.Point(536, 77);
            this.cbMail.Name = "cbMail";
            this.cbMail.Size = new System.Drawing.Size(15, 14);
            this.cbMail.TabIndex = 27;
            this.cbMail.UseVisualStyleBackColor = true;
            this.cbMail.CheckedChanged += new System.EventHandler(this.cbMail_CheckedChanged_1);
            // 
            // cbApellido
            // 
            this.cbApellido.AutoSize = true;
            this.cbApellido.Location = new System.Drawing.Point(536, 47);
            this.cbApellido.Name = "cbApellido";
            this.cbApellido.Size = new System.Drawing.Size(15, 14);
            this.cbApellido.TabIndex = 26;
            this.cbApellido.UseVisualStyleBackColor = true;
            this.cbApellido.CheckedChanged += new System.EventHandler(this.cbApellido_CheckedChanged_1);
            // 
            // cbNombre
            // 
            this.cbNombre.AutoSize = true;
            this.cbNombre.Location = new System.Drawing.Point(536, 22);
            this.cbNombre.Name = "cbNombre";
            this.cbNombre.Size = new System.Drawing.Size(15, 14);
            this.cbNombre.TabIndex = 25;
            this.cbNombre.UseVisualStyleBackColor = true;
            this.cbNombre.CheckedChanged += new System.EventHandler(this.cbNombre_CheckedChanged_1);
            // 
            // cbHotel
            // 
            this.cbHotel.AutoSize = true;
            this.cbHotel.Location = new System.Drawing.Point(282, 75);
            this.cbHotel.Name = "cbHotel";
            this.cbHotel.Size = new System.Drawing.Size(15, 14);
            this.cbHotel.TabIndex = 24;
            this.cbHotel.UseVisualStyleBackColor = true;
            this.cbHotel.CheckedChanged += new System.EventHandler(this.cbHotel_CheckedChanged);
            // 
            // cbRol
            // 
            this.cbRol.AutoSize = true;
            this.cbRol.Location = new System.Drawing.Point(282, 48);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(15, 14);
            this.cbRol.TabIndex = 23;
            this.cbRol.UseVisualStyleBackColor = true;
            this.cbRol.CheckedChanged += new System.EventHandler(this.cbRol_CheckedChanged);
            // 
            // cbUsername
            // 
            this.cbUsername.AutoSize = true;
            this.cbUsername.Location = new System.Drawing.Point(282, 21);
            this.cbUsername.Name = "cbUsername";
            this.cbUsername.Size = new System.Drawing.Size(15, 14);
            this.cbUsername.TabIndex = 22;
            this.cbUsername.UseVisualStyleBackColor = true;
            this.cbUsername.CheckedChanged += new System.EventHandler(this.cbUsername_CheckedChanged_1);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(9, 100);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 21;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Location = new System.Drawing.Point(113, 100);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtMail
            // 
            this.txtMail.Enabled = false;
            this.txtMail.Location = new System.Drawing.Point(371, 72);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(160, 20);
            this.txtMail.TabIndex = 6;
            this.txtMail.TextChanged += new System.EventHandler(this.txtMail_TextChanged_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(308, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Email:";
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(371, 45);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(160, 20);
            this.txtApellido.TabIndex = 5;
            this.txtApellido.TextChanged += new System.EventHandler(this.txtApellido_TextChanged);
            // 
            // txtHotel
            // 
            this.txtHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtHotel.Enabled = false;
            this.txtHotel.FormattingEnabled = true;
            this.txtHotel.Location = new System.Drawing.Point(113, 73);
            this.txtHotel.Name = "txtHotel";
            this.txtHotel.Size = new System.Drawing.Size(161, 21);
            this.txtHotel.TabIndex = 3;
            this.txtHotel.SelectedIndexChanged += new System.EventHandler(this.txtHotel_SelectedIndexChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Apellido:";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(371, 19);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(160, 20);
            this.txtNombre.TabIndex = 4;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Hotel:";
            // 
            // txtRol
            // 
            this.txtRol.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRol.Enabled = false;
            this.txtRol.FormattingEnabled = true;
            this.txtRol.Location = new System.Drawing.Point(113, 45);
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(161, 21);
            this.txtRol.TabIndex = 2;
            this.txtRol.SelectedIndexChanged += new System.EventHandler(this.txtRol_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nombre:";
            // 
            // txtUsername
            // 
            this.txtUsername.Enabled = false;
            this.txtUsername.Location = new System.Drawing.Point(113, 18);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(161, 20);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rol de Usuario:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de Usuario:";
            // 
            // dataResultado
            // 
            this.dataResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataResultado.Location = new System.Drawing.Point(21, 149);
            this.dataResultado.Name = "dataResultado";
            this.dataResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataResultado.Size = new System.Drawing.Size(543, 150);
            this.dataResultado.TabIndex = 20;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 305);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(98, 30);
            this.btnVolver.TabIndex = 21;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnDeshabilitar
            // 
            this.btnDeshabilitar.Location = new System.Drawing.Point(125, 305);
            this.btnDeshabilitar.Name = "btnDeshabilitar";
            this.btnDeshabilitar.Size = new System.Drawing.Size(98, 30);
            this.btnDeshabilitar.TabIndex = 22;
            this.btnDeshabilitar.Text = "Deshabilitar";
            this.btnDeshabilitar.UseVisualStyleBackColor = true;
            this.btnDeshabilitar.Click += new System.EventHandler(this.btnDeshabilitar_Click);
            // 
            // btnHabilitar
            // 
            this.btnHabilitar.Location = new System.Drawing.Point(347, 305);
            this.btnHabilitar.Name = "btnHabilitar";
            this.btnHabilitar.Size = new System.Drawing.Size(98, 30);
            this.btnHabilitar.TabIndex = 23;
            this.btnHabilitar.Text = "Habilitar";
            this.btnHabilitar.UseVisualStyleBackColor = true;
            this.btnHabilitar.Click += new System.EventHandler(this.btnHabilitar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(463, 305);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(98, 30);
            this.btnModificar.TabIndex = 24;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // txtOcultoRoles
            // 
            this.txtOcultoRoles.Location = new System.Drawing.Point(636, 23);
            this.txtOcultoRoles.Name = "txtOcultoRoles";
            this.txtOcultoRoles.Size = new System.Drawing.Size(94, 20);
            this.txtOcultoRoles.TabIndex = 25;
            this.txtOcultoRoles.Visible = false;
            // 
            // txtOcultoHoteles
            // 
            this.txtOcultoHoteles.Location = new System.Drawing.Point(638, 53);
            this.txtOcultoHoteles.Name = "txtOcultoHoteles";
            this.txtOcultoHoteles.Size = new System.Drawing.Size(91, 20);
            this.txtOcultoHoteles.TabIndex = 26;
            this.txtOcultoHoteles.Visible = false;
            // 
            // FrmUsuario_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 340);
            this.Controls.Add(this.txtOcultoHoteles);
            this.Controls.Add(this.txtOcultoRoles);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnHabilitar);
            this.Controls.Add(this.btnDeshabilitar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dataResultado);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmUsuario_List";
            this.Text = "Listado de Usuarios";
            this.Load += new System.EventHandler(this.FrmUsuario_List_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox txtHotel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox txtRol;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataResultado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnDeshabilitar;
        private System.Windows.Forms.Button btnHabilitar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.CheckBox cbMail;
        private System.Windows.Forms.CheckBox cbApellido;
        private System.Windows.Forms.CheckBox cbNombre;
        private System.Windows.Forms.CheckBox cbHotel;
        private System.Windows.Forms.CheckBox cbRol;
        private System.Windows.Forms.CheckBox cbUsername;
        private System.Windows.Forms.CheckBox cbExacta;
        private System.Windows.Forms.CheckBox cbDinamica;
        private System.Windows.Forms.TextBox txtOcultoRoles;
        private System.Windows.Forms.TextBox txtOcultoHoteles;

    }
}