namespace FrbaHotel.Registrar_Estadia
{
    partial class FormCheckIn
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
            this.dataResultado = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOcultoTipo = new System.Windows.Forms.TextBox();
            this.cbExacta = new System.Windows.Forms.CheckBox();
            this.cbMail = new System.Windows.Forms.CheckBox();
            this.cbNumDoc = new System.Windows.Forms.CheckBox();
            this.cbTipo = new System.Windows.Forms.CheckBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnHuesped = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnRegistrarHuesped = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataResultado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataResultado
            // 
            this.dataResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataResultado.Location = new System.Drawing.Point(12, 119);
            this.dataResultado.Name = "dataResultado";
            this.dataResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataResultado.Size = new System.Drawing.Size(341, 195);
            this.dataResultado.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRegistrarHuesped);
            this.groupBox1.Controls.Add(this.txtOcultoTipo);
            this.groupBox1.Controls.Add(this.cbExacta);
            this.groupBox1.Controls.Add(this.cbMail);
            this.groupBox1.Controls.Add(this.cbNumDoc);
            this.groupBox1.Controls.Add(this.cbTipo);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtMail);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtNumDoc);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTipo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 101);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscador";
            // 
            // txtOcultoTipo
            // 
            this.txtOcultoTipo.Location = new System.Drawing.Point(197, 65);
            this.txtOcultoTipo.Name = "txtOcultoTipo";
            this.txtOcultoTipo.Size = new System.Drawing.Size(100, 20);
            this.txtOcultoTipo.TabIndex = 31;
            this.txtOcultoTipo.Visible = false;
            // 
            // cbExacta
            // 
            this.cbExacta.AutoSize = true;
            this.cbExacta.Checked = true;
            this.cbExacta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbExacta.Location = new System.Drawing.Point(320, 43);
            this.cbExacta.Name = "cbExacta";
            this.cbExacta.Size = new System.Drawing.Size(110, 17);
            this.cbExacta.TabIndex = 28;
            this.cbExacta.Text = "Búsqueda Exacta";
            this.cbExacta.UseVisualStyleBackColor = true;
            // 
            // cbMail
            // 
            this.cbMail.AutoSize = true;
            this.cbMail.Location = new System.Drawing.Point(282, 45);
            this.cbMail.Name = "cbMail";
            this.cbMail.Size = new System.Drawing.Size(15, 14);
            this.cbMail.TabIndex = 27;
            this.cbMail.UseVisualStyleBackColor = true;
            this.cbMail.CheckedChanged += new System.EventHandler(this.cbMail_CheckedChanged);
            // 
            // cbNumDoc
            // 
            this.cbNumDoc.AutoSize = true;
            this.cbNumDoc.Location = new System.Drawing.Point(536, 15);
            this.cbNumDoc.Name = "cbNumDoc";
            this.cbNumDoc.Size = new System.Drawing.Size(15, 14);
            this.cbNumDoc.TabIndex = 26;
            this.cbNumDoc.UseVisualStyleBackColor = true;
            this.cbNumDoc.CheckedChanged += new System.EventHandler(this.cbNumDoc_CheckedChanged);
            // 
            // cbTipo
            // 
            this.cbTipo.AutoSize = true;
            this.cbTipo.Location = new System.Drawing.Point(282, 16);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(15, 14);
            this.cbTipo.TabIndex = 23;
            this.cbTipo.UseVisualStyleBackColor = true;
            this.cbTipo.CheckedChanged += new System.EventHandler(this.cbTipo_CheckedChanged);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(9, 68);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 21;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(113, 68);
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
            this.txtMail.Location = new System.Drawing.Point(113, 40);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(161, 20);
            this.txtMail.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Email:";
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Enabled = false;
            this.txtNumDoc.Location = new System.Drawing.Point(371, 13);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.Size = new System.Drawing.Size(160, 20);
            this.txtNumDoc.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Numero:";
            // 
            // txtTipo
            // 
            this.txtTipo.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtTipo.Enabled = false;
            this.txtTipo.FormattingEnabled = true;
            this.txtTipo.Location = new System.Drawing.Point(113, 13);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(161, 21);
            this.txtTipo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo Identificación:";
            // 
            // btnUsuario
            // 
            this.btnUsuario.Location = new System.Drawing.Point(383, 132);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(110, 33);
            this.btnUsuario.TabIndex = 24;
            this.btnUsuario.Text = "Agregar Usuario";
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnHuesped
            // 
            this.btnHuesped.Location = new System.Drawing.Point(383, 171);
            this.btnHuesped.Name = "btnHuesped";
            this.btnHuesped.Size = new System.Drawing.Size(110, 33);
            this.btnHuesped.TabIndex = 25;
            this.btnHuesped.Text = "Agregar Huesped";
            this.btnHuesped.UseVisualStyleBackColor = true;
            this.btnHuesped.Click += new System.EventHandler(this.btnHuesped_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(383, 210);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 33);
            this.btnGuardar.TabIndex = 26;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(383, 281);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(110, 33);
            this.btnVolver.TabIndex = 27;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnRegistrarHuesped
            // 
            this.btnRegistrarHuesped.Location = new System.Drawing.Point(431, 58);
            this.btnRegistrarHuesped.Name = "btnRegistrarHuesped";
            this.btnRegistrarHuesped.Size = new System.Drawing.Size(110, 33);
            this.btnRegistrarHuesped.TabIndex = 28;
            this.btnRegistrarHuesped.Text = "Registrar Huesped";
            this.btnRegistrarHuesped.UseVisualStyleBackColor = true;
            this.btnRegistrarHuesped.Click += new System.EventHandler(this.btnRegistrarHuesped_Click);
            // 
            // FormCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 326);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnHuesped);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.dataResultado);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormCheckIn";
            this.Text = "FormCheckIn";
            this.Load += new System.EventHandler(this.FormCheckIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataResultado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataResultado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtOcultoTipo;
        private System.Windows.Forms.CheckBox cbExacta;
        private System.Windows.Forms.CheckBox cbMail;
        private System.Windows.Forms.CheckBox cbNumDoc;
        private System.Windows.Forms.CheckBox cbTipo;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNumDoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox txtTipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnHuesped;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnRegistrarHuesped;
    }
}