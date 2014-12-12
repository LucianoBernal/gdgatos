namespace FrbaHotel.Facturar
{
    partial class FrmFacturar
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
            this.txtReserva = new System.Windows.Forms.TextBox();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.dataResultado = new System.Windows.Forms.DataGridView();
            this.txtTipoPago = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.txtDatosTarjeta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // txtReserva
            // 
            this.txtReserva.Enabled = false;
            this.txtReserva.Location = new System.Drawing.Point(347, 26);
            this.txtReserva.Name = "txtReserva";
            this.txtReserva.Size = new System.Drawing.Size(167, 20);
            this.txtReserva.TabIndex = 0;
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(382, 313);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(108, 20);
            this.btnFacturar.TabIndex = 1;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // dataResultado
            // 
            this.dataResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataResultado.Location = new System.Drawing.Point(37, 146);
            this.dataResultado.Name = "dataResultado";
            this.dataResultado.Size = new System.Drawing.Size(644, 156);
            this.dataResultado.TabIndex = 2;
            // 
            // txtTipoPago
            // 
            this.txtTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtTipoPago.FormattingEnabled = true;
            this.txtTipoPago.Location = new System.Drawing.Point(347, 52);
            this.txtTipoPago.Name = "txtTipoPago";
            this.txtTipoPago.Size = new System.Drawing.Size(167, 21);
            this.txtTipoPago.TabIndex = 3;
            this.txtTipoPago.SelectedIndexChanged += new System.EventHandler(this.txtTipoPago_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Numero de Reserva";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tipo de pago";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Numero de tarjeta";
            // 
            // txtNumeroTarjeta
            // 
            this.txtNumeroTarjeta.Enabled = false;
            this.txtNumeroTarjeta.Location = new System.Drawing.Point(347, 78);
            this.txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            this.txtNumeroTarjeta.Size = new System.Drawing.Size(167, 20);
            this.txtNumeroTarjeta.TabIndex = 7;
            // 
            // txtDatosTarjeta
            // 
            this.txtDatosTarjeta.Enabled = false;
            this.txtDatosTarjeta.Location = new System.Drawing.Point(347, 104);
            this.txtDatosTarjeta.Name = "txtDatosTarjeta";
            this.txtDatosTarjeta.Size = new System.Drawing.Size(167, 20);
            this.txtDatosTarjeta.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Datos de tarjeta";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(207, 313);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 20);
            this.btnVolver.TabIndex = 10;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FrmFacturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 345);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDatosTarjeta);
            this.Controls.Add(this.txtNumeroTarjeta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTipoPago);
            this.Controls.Add(this.dataResultado);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.txtReserva);
            this.Name = "FrmFacturar";
            this.Text = "Facturar";
            this.Load += new System.EventHandler(this.FrmFacturar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReserva;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.DataGridView dataResultado;
        private System.Windows.Forms.ComboBox txtTipoPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumeroTarjeta;
        private System.Windows.Forms.TextBox txtDatosTarjeta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnVolver;
    }
}