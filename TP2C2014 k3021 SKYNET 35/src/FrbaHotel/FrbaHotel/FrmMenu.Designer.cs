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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // linkCambiarContraseña
            // 
            this.linkCambiarContraseña.AutoSize = true;
            this.linkCambiarContraseña.Location = new System.Drawing.Point(12, 66);
            this.linkCambiarContraseña.Name = "linkCambiarContraseña";
            this.linkCambiarContraseña.Size = new System.Drawing.Size(101, 13);
            this.linkCambiarContraseña.TabIndex = 15;
            this.linkCambiarContraseña.TabStop = true;
            this.linkCambiarContraseña.Text = "Cambiar contraseña";
            this.linkCambiarContraseña.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCambiarContraseña_LinkClicked);
            // 
            // lblUsuarioLogueado
            // 
            this.lblUsuarioLogueado.AutoSize = true;
            this.lblUsuarioLogueado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUsuarioLogueado.Location = new System.Drawing.Point(12, 29);
            this.lblUsuarioLogueado.Name = "lblUsuarioLogueado";
            this.lblUsuarioLogueado.Size = new System.Drawing.Size(100, 13);
            this.lblUsuarioLogueado.TabIndex = 21;
            this.lblUsuarioLogueado.Text = "Usuario Logueado :";
            // 
            // btnCancelarEstadia
            // 
            this.btnCancelarEstadia.Location = new System.Drawing.Point(188, 201);
            this.btnCancelarEstadia.Name = "btnCancelarEstadia";
            this.btnCancelarEstadia.Size = new System.Drawing.Size(139, 45);
            this.btnCancelarEstadia.TabIndex = 8;
            this.btnCancelarEstadia.Text = "Cancelar Reserva";
            this.btnCancelarEstadia.UseVisualStyleBackColor = true;
            this.btnCancelarEstadia.Click += new System.EventHandler(this.btnCancelarEstadia_Click);
            // 
            // btnRegistrarEstadia
            // 
            this.btnRegistrarEstadia.Location = new System.Drawing.Point(372, 201);
            this.btnRegistrarEstadia.Name = "btnRegistrarEstadia";
            this.btnRegistrarEstadia.Size = new System.Drawing.Size(137, 45);
            this.btnRegistrarEstadia.TabIndex = 9;
            this.btnRegistrarEstadia.Text = "Registrar Estadia";
            this.btnRegistrarEstadia.UseVisualStyleBackColor = true;
            this.btnRegistrarEstadia.Click += new System.EventHandler(this.btnRegistrarEstadia_Click);
            // 
            // btnListadoEstadistico
            // 
            this.btnListadoEstadistico.Location = new System.Drawing.Point(372, 252);
            this.btnListadoEstadistico.Name = "btnListadoEstadistico";
            this.btnListadoEstadistico.Size = new System.Drawing.Size(137, 45);
            this.btnListadoEstadistico.TabIndex = 12;
            this.btnListadoEstadistico.Text = "Listado Estadístico";
            this.btnListadoEstadistico.UseVisualStyleBackColor = true;
            this.btnListadoEstadistico.Click += new System.EventHandler(this.btnListadoEstadistico_Click);
            // 
            // btnHabitacion
            // 
            this.btnHabitacion.Location = new System.Drawing.Point(188, 148);
            this.btnHabitacion.Name = "btnHabitacion";
            this.btnHabitacion.Size = new System.Drawing.Size(139, 47);
            this.btnHabitacion.TabIndex = 5;
            this.btnHabitacion.Text = "ABM Habitación";
            this.btnHabitacion.UseVisualStyleBackColor = true;
            this.btnHabitacion.Click += new System.EventHandler(this.btnHabitacion_Click);
            // 
            // btnRegimenEstadia
            // 
            this.btnRegimenEstadia.Location = new System.Drawing.Point(372, 148);
            this.btnRegimenEstadia.Name = "btnRegimenEstadia";
            this.btnRegimenEstadia.Size = new System.Drawing.Size(137, 47);
            this.btnRegimenEstadia.TabIndex = 6;
            this.btnRegimenEstadia.Text = "ABM Regimen";
            this.btnRegimenEstadia.UseVisualStyleBackColor = true;
            this.btnRegimenEstadia.Click += new System.EventHandler(this.btnRegimenEstadia_Click);
            // 
            // btnReserva
            // 
            this.btnReserva.Location = new System.Drawing.Point(12, 201);
            this.btnReserva.Name = "btnReserva";
            this.btnReserva.Size = new System.Drawing.Size(139, 45);
            this.btnReserva.TabIndex = 7;
            this.btnReserva.Text = "Generar o Modificar Reserva";
            this.btnReserva.UseVisualStyleBackColor = true;
            this.btnReserva.Click += new System.EventHandler(this.btnReserva_Click);
            // 
            // btnHotel
            // 
            this.btnHotel.Location = new System.Drawing.Point(12, 147);
            this.btnHotel.Name = "btnHotel";
            this.btnHotel.Size = new System.Drawing.Size(139, 48);
            this.btnHotel.TabIndex = 4;
            this.btnHotel.Text = "ABM Hotel";
            this.btnHotel.UseVisualStyleBackColor = true;
            this.btnHotel.Click += new System.EventHandler(this.btnHotel_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(372, 93);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(137, 47);
            this.btnClientes.TabIndex = 3;
            this.btnClientes.Text = "ABM Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click_1);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(317, 331);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(152, 36);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.Location = new System.Drawing.Point(12, 93);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(139, 47);
            this.btnRoles.TabIndex = 1;
            this.btnRoles.Text = "ABM Rol";
            this.btnRoles.UseVisualStyleBackColor = true;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.Location = new System.Drawing.Point(188, 93);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(139, 47);
            this.btnUsuario.TabIndex = 2;
            this.btnUsuario.Text = "ABM Usuario";
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(190, 252);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(137, 45);
            this.btnFacturar.TabIndex = 11;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Location = new System.Drawing.Point(12, 49);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(33, 13);
            this.lblPerfil.TabIndex = 38;
            this.lblPerfil.Text = "Perfil:";
            // 
            // btnRegistrarConsumible
            // 
            this.btnRegistrarConsumible.Location = new System.Drawing.Point(12, 252);
            this.btnRegistrarConsumible.Name = "btnRegistrarConsumible";
            this.btnRegistrarConsumible.Size = new System.Drawing.Size(139, 45);
            this.btnRegistrarConsumible.TabIndex = 10;
            this.btnRegistrarConsumible.Text = "Registrar Consumible";
            this.btnRegistrarConsumible.UseVisualStyleBackColor = true;
            this.btnRegistrarConsumible.Click += new System.EventHandler(this.btnRegistrarConsumible_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(394, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "label1";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(54, 331);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(152, 36);
            this.btnCerrar.TabIndex = 40;
            this.btnCerrar.Text = "Cerrar Sesion";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Fecha:";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 376);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label2;
    }
}