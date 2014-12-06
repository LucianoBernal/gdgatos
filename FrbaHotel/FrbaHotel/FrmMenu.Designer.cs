namespace FrbaHotel
{
    partial class FrmMenu
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
            this.linkCambiarContraseña = new System.Windows.Forms.LinkLabel();
            this.lblUsuarioLogueado = new System.Windows.Forms.Label();
            this.btnCancelarEstadia = new System.Windows.Forms.Button();
            this.btnRegistrarEstadia = new System.Windows.Forms.Button();
            this.btnListadoEstadistico = new System.Windows.Forms.Button();
            this.btnHabitacion = new System.Windows.Forms.Button();
            this.btnRegimenEstadia = new System.Windows.Forms.Button();
            this.btnReserva = new System.Windows.Forms.Button();
            this.btnHotel = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.lblPerfil = new System.Windows.Forms.Label();
            this.btnRegistrarConsumible = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // linkCambiarContraseña
            // 
            this.linkCambiarContraseña.AutoSize = true;
            this.linkCambiarContraseña.Location = new System.Drawing.Point(12, 117);
            this.linkCambiarContraseña.Name = "linkCambiarContraseña";
            this.linkCambiarContraseña.Size = new System.Drawing.Size(101, 13);
            this.linkCambiarContraseña.TabIndex = 22;
            this.linkCambiarContraseña.TabStop = true;
            this.linkCambiarContraseña.Text = "Cambiar contraseña";
            // 
            // lblUsuarioLogueado
            // 
            this.lblUsuarioLogueado.AutoSize = true;
            this.lblUsuarioLogueado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUsuarioLogueado.Location = new System.Drawing.Point(12, 80);
            this.lblUsuarioLogueado.Name = "lblUsuarioLogueado";
            this.lblUsuarioLogueado.Size = new System.Drawing.Size(100, 13);
            this.lblUsuarioLogueado.TabIndex = 21;
            this.lblUsuarioLogueado.Text = "Usuario Logueado :";
            // 
            // btnCancelarEstadia
            // 
            this.btnCancelarEstadia.Location = new System.Drawing.Point(188, 252);
            this.btnCancelarEstadia.Name = "btnCancelarEstadia";
            this.btnCancelarEstadia.Size = new System.Drawing.Size(139, 45);
            this.btnCancelarEstadia.TabIndex = 35;
            this.btnCancelarEstadia.Text = "Cancelar Estadia";
            this.btnCancelarEstadia.UseVisualStyleBackColor = true;
            this.btnCancelarEstadia.Click += new System.EventHandler(this.btnCancelarEstadia_Click);
            // 
            // btnRegistrarEstadia
            // 
            this.btnRegistrarEstadia.Location = new System.Drawing.Point(372, 252);
            this.btnRegistrarEstadia.Name = "btnRegistrarEstadia";
            this.btnRegistrarEstadia.Size = new System.Drawing.Size(137, 45);
            this.btnRegistrarEstadia.TabIndex = 34;
            this.btnRegistrarEstadia.Text = "Registrar Estadia";
            this.btnRegistrarEstadia.UseVisualStyleBackColor = true;
            this.btnRegistrarEstadia.Click += new System.EventHandler(this.btnRegistrarEstadia_Click);
            // 
            // btnListadoEstadistico
            // 
            this.btnListadoEstadistico.Location = new System.Drawing.Point(372, 303);
            this.btnListadoEstadistico.Name = "btnListadoEstadistico";
            this.btnListadoEstadistico.Size = new System.Drawing.Size(137, 45);
            this.btnListadoEstadistico.TabIndex = 33;
            this.btnListadoEstadistico.Text = "Listado Estadístico";
            this.btnListadoEstadistico.UseVisualStyleBackColor = true;
            this.btnListadoEstadistico.Click += new System.EventHandler(this.btnListadoEstadistico_Click);
            // 
            // btnHabitacion
            // 
            this.btnHabitacion.Location = new System.Drawing.Point(188, 199);
            this.btnHabitacion.Name = "btnHabitacion";
            this.btnHabitacion.Size = new System.Drawing.Size(139, 47);
            this.btnHabitacion.TabIndex = 32;
            this.btnHabitacion.Text = "ABM Habitación";
            this.btnHabitacion.UseVisualStyleBackColor = true;
            this.btnHabitacion.Click += new System.EventHandler(this.btnHabitacion_Click);
            // 
            // btnRegimenEstadia
            // 
            this.btnRegimenEstadia.Location = new System.Drawing.Point(372, 199);
            this.btnRegimenEstadia.Name = "btnRegimenEstadia";
            this.btnRegimenEstadia.Size = new System.Drawing.Size(137, 47);
            this.btnRegimenEstadia.TabIndex = 31;
            this.btnRegimenEstadia.Text = "ABM Regimen/Estadia";
            this.btnRegimenEstadia.UseVisualStyleBackColor = true;
            this.btnRegimenEstadia.Click += new System.EventHandler(this.btnRegimenEstadia_Click);
            // 
            // btnReserva
            // 
            this.btnReserva.Location = new System.Drawing.Point(12, 252);
            this.btnReserva.Name = "btnReserva";
            this.btnReserva.Size = new System.Drawing.Size(139, 45);
            this.btnReserva.TabIndex = 27;
            this.btnReserva.Text = "Generar o Modificar Reserva";
            this.btnReserva.UseVisualStyleBackColor = true;
            this.btnReserva.Click += new System.EventHandler(this.btnReserva_Click);
            // 
            // btnHotel
            // 
            this.btnHotel.Location = new System.Drawing.Point(12, 198);
            this.btnHotel.Name = "btnHotel";
            this.btnHotel.Size = new System.Drawing.Size(139, 48);
            this.btnHotel.TabIndex = 26;
            this.btnHotel.Text = "ABM Hotel";
            this.btnHotel.UseVisualStyleBackColor = true;
            this.btnHotel.Click += new System.EventHandler(this.btnHotel_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(372, 144);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(137, 47);
            this.btnClientes.TabIndex = 25;
            this.btnClientes.Text = "ABM Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click_1);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(357, 358);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(152, 36);
            this.btnSalir.TabIndex = 24;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.Location = new System.Drawing.Point(12, 144);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(139, 47);
            this.btnRoles.TabIndex = 23;
            this.btnRoles.Text = "ABM Rol";
            this.btnRoles.UseVisualStyleBackColor = true;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.Location = new System.Drawing.Point(188, 144);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(139, 47);
            this.btnUsuario.TabIndex = 36;
            this.btnUsuario.Text = "ABM Usuario";
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(190, 303);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(137, 45);
            this.btnFacturar.TabIndex = 37;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Location = new System.Drawing.Point(12, 100);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(33, 13);
            this.lblPerfil.TabIndex = 38;
            this.lblPerfil.Text = "Perfil:";
            // 
            // btnRegistrarConsumible
            // 
            this.btnRegistrarConsumible.Location = new System.Drawing.Point(12, 303);
            this.btnRegistrarConsumible.Name = "btnRegistrarConsumible";
            this.btnRegistrarConsumible.Size = new System.Drawing.Size(139, 45);
            this.btnRegistrarConsumible.TabIndex = 39;
            this.btnRegistrarConsumible.Text = "Registrar Consumible";
            this.btnRegistrarConsumible.UseVisualStyleBackColor = true;
            this.btnRegistrarConsumible.Click += new System.EventHandler(this.btnRegistrarConsumible_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 406);
            this.Controls.Add(this.btnRegistrarConsumible);
            this.Controls.Add(this.lblPerfil);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.btnCancelarEstadia);
            this.Controls.Add(this.btnRegistrarEstadia);
            this.Controls.Add(this.btnListadoEstadistico);
            this.Controls.Add(this.btnHabitacion);
            this.Controls.Add(this.btnRegimenEstadia);
            this.Controls.Add(this.btnReserva);
            this.Controls.Add(this.btnHotel);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRoles);
            this.Controls.Add(this.linkCambiarContraseña);
            this.Controls.Add(this.lblUsuarioLogueado);
            this.Name = "FrmMenu";
            this.Text = "Sistema Hotel";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkCambiarContraseña;
        private System.Windows.Forms.Label lblUsuarioLogueado;
        private System.Windows.Forms.Button btnCancelarEstadia;
        private System.Windows.Forms.Button btnRegistrarEstadia;
        private System.Windows.Forms.Button btnListadoEstadistico;
        private System.Windows.Forms.Button btnHabitacion;
        private System.Windows.Forms.Button btnRegimenEstadia;
        private System.Windows.Forms.Button btnReserva;
        private System.Windows.Forms.Button btnHotel;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Label lblPerfil;
        private System.Windows.Forms.Button btnRegistrarConsumible;
    }
}