namespace FrbaHotel.Registrar_Consumible
{
    partial class FrmRegistrarConsumibles
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
            this.txtConsumibles = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOcultoConsumible = new System.Windows.Forms.TextBox();
            this.txtPrecios = new System.Windows.Forms.ComboBox();
            this.txtOcultoPrecio = new System.Windows.Forms.TextBox();
            this.txtOcultoEstadia = new System.Windows.Forms.TextBox();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // txtConsumibles
            // 
            this.txtConsumibles.FormattingEnabled = true;
            this.txtConsumibles.Location = new System.Drawing.Point(107, 46);
            this.txtConsumibles.Name = "txtConsumibles";
            this.txtConsumibles.Size = new System.Drawing.Size(173, 21);
            this.txtConsumibles.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(161, 132);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(118, 28);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(9, 132);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(123, 28);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Consumible";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cantidad";
            // 
            // txtOcultoConsumible
            // 
            this.txtOcultoConsumible.Location = new System.Drawing.Point(149, 197);
            this.txtOcultoConsumible.Name = "txtOcultoConsumible";
            this.txtOcultoConsumible.Size = new System.Drawing.Size(141, 20);
            this.txtOcultoConsumible.TabIndex = 6;
            this.txtOcultoConsumible.Visible = false;
            // 
            // txtPrecios
            // 
            this.txtPrecios.FormattingEnabled = true;
            this.txtPrecios.Location = new System.Drawing.Point(19, 197);
            this.txtPrecios.Name = "txtPrecios";
            this.txtPrecios.Size = new System.Drawing.Size(77, 21);
            this.txtPrecios.TabIndex = 7;
            this.txtPrecios.Visible = false;
            // 
            // txtOcultoPrecio
            // 
            this.txtOcultoPrecio.Location = new System.Drawing.Point(126, 229);
            this.txtOcultoPrecio.Name = "txtOcultoPrecio";
            this.txtOcultoPrecio.Size = new System.Drawing.Size(79, 20);
            this.txtOcultoPrecio.TabIndex = 8;
            this.txtOcultoPrecio.Visible = false;
            // 
            // txtOcultoEstadia
            // 
            this.txtOcultoEstadia.Location = new System.Drawing.Point(24, 229);
            this.txtOcultoEstadia.Name = "txtOcultoEstadia";
            this.txtOcultoEstadia.Size = new System.Drawing.Size(36, 20);
            this.txtOcultoEstadia.TabIndex = 9;
            this.txtOcultoEstadia.Visible = false;
            // 
            // numCantidad
            // 
            this.numCantidad.Location = new System.Drawing.Point(107, 78);
            this.numCantidad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(173, 20);
            this.numCantidad.TabIndex = 10;
            this.numCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(161, 109);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(72, 20);
            this.txtCantidad.TabIndex = 11;
            this.txtCantidad.Visible = false;
            // 
            // FrmRegistrarConsumibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 186);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.txtOcultoEstadia);
            this.Controls.Add(this.txtOcultoPrecio);
            this.Controls.Add(this.txtPrecios);
            this.Controls.Add(this.txtOcultoConsumible);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtConsumibles);
            this.Name = "FrmRegistrarConsumibles";
            this.Text = "Agregar Consumibles";
            this.Load += new System.EventHandler(this.FrmRegistrarConsumibles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox txtConsumibles;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOcultoConsumible;
        private System.Windows.Forms.ComboBox txtPrecios;
        private System.Windows.Forms.TextBox txtOcultoPrecio;
        private System.Windows.Forms.TextBox txtOcultoEstadia;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
    }
}