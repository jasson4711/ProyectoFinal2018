namespace VentaPresentacion
{
    partial class ManejoClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManejoClientes));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripCancelar = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.MaskedTextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CEDULA = new System.Windows.Forms.Label();
            this.dataGridViewClientes = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LavenderBlush;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripEditar,
            this.toolStripNuevo,
            this.toolStripActualizar,
            this.toolStripEliminar,
            this.toolStripGuardar,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.toolStripCancelar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(505, 39);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripEditar
            // 
            this.toolStripEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripEditar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripEditar.Image")));
            this.toolStripEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripEditar.Name = "toolStripEditar";
            this.toolStripEditar.Size = new System.Drawing.Size(28, 36);
            this.toolStripEditar.Text = "toolStripButtonEditar";
            this.toolStripEditar.ToolTipText = "Al dar click en esta opcion se habilitaran los controles de edicion";
            this.toolStripEditar.Click += new System.EventHandler(this.toolStripEditar_Click);
            // 
            // toolStripNuevo
            // 
            this.toolStripNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripNuevo.Enabled = false;
            this.toolStripNuevo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripNuevo.Image")));
            this.toolStripNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNuevo.Name = "toolStripNuevo";
            this.toolStripNuevo.Size = new System.Drawing.Size(36, 36);
            this.toolStripNuevo.Text = "toolStripButtonNuevo";
            this.toolStripNuevo.ToolTipText = " Añadir nuevo producto";
            // 
            // toolStripActualizar
            // 
            this.toolStripActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripActualizar.Enabled = false;
            this.toolStripActualizar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripActualizar.Image")));
            this.toolStripActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripActualizar.Name = "toolStripActualizar";
            this.toolStripActualizar.Size = new System.Drawing.Size(28, 36);
            this.toolStripActualizar.Text = "toolStripButtonActualizar";
            this.toolStripActualizar.ToolTipText = "Actualizar un producto";
            // 
            // toolStripEliminar
            // 
            this.toolStripEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripEliminar.Enabled = false;
            this.toolStripEliminar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripEliminar.Image")));
            this.toolStripEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripEliminar.Name = "toolStripEliminar";
            this.toolStripEliminar.Size = new System.Drawing.Size(28, 36);
            this.toolStripEliminar.Text = "toolStripButtonBorrar";
            this.toolStripEliminar.ToolTipText = "Borrar un producto";
            // 
            // toolStripGuardar
            // 
            this.toolStripGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripGuardar.Enabled = false;
            this.toolStripGuardar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripGuardar.Image")));
            this.toolStripGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripGuardar.Name = "toolStripGuardar";
            this.toolStripGuardar.Size = new System.Drawing.Size(36, 36);
            this.toolStripGuardar.Text = "toolStripButtonGuardar";
            this.toolStripGuardar.ToolTipText = "Guardar Cambios";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripCancelar
            // 
            this.toolStripCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCancelar.Enabled = false;
            this.toolStripCancelar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCancelar.Image")));
            this.toolStripCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCancelar.Name = "toolStripCancelar";
            this.toolStripCancelar.Size = new System.Drawing.Size(36, 36);
            this.toolStripCancelar.Text = "toolStripButton1";
            this.toolStripCancelar.ToolTipText = "Cancelar cambios";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCedula);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CEDULA);
            this.groupBox1.Location = new System.Drawing.Point(1, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 221);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATOS VENTA";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(116, 35);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "ID:";
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(116, 61);
            this.txtCedula.Mask = "0000000000";
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(100, 20);
            this.txtCedula.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(116, 192);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(362, 20);
            this.txtEmail.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "E-MAIL:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(116, 166);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(362, 20);
            this.txtTelefono.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "TELÉFONO:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(116, 140);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(362, 20);
            this.txtDireccion.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "DIRECCION:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(116, 113);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(362, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "NOMBRE:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(116, 87);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(362, 20);
            this.txtApellido.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "APELLIDO:";
            // 
            // CEDULA
            // 
            this.CEDULA.AutoSize = true;
            this.CEDULA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CEDULA.Location = new System.Drawing.Point(12, 64);
            this.CEDULA.Name = "CEDULA";
            this.CEDULA.Size = new System.Drawing.Size(92, 13);
            this.CEDULA.TabIndex = 0;
            this.CEDULA.Text = "CEDULA/RUC:";
            // 
            // dataGridViewClientes
            // 
            this.dataGridViewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientes.Location = new System.Drawing.Point(16, 273);
            this.dataGridViewClientes.Name = "dataGridViewClientes";
            this.dataGridViewClientes.Size = new System.Drawing.Size(475, 175);
            this.dataGridViewClientes.TabIndex = 15;
            // 
            // ManejoClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 457);
            this.Controls.Add(this.dataGridViewClientes);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ManejoClientes";
            this.Text = "ManejoClientes";
            this.Load += new System.EventHandler(this.ManejoClientes_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripEditar;
        private System.Windows.Forms.ToolStripButton toolStripNuevo;
        private System.Windows.Forms.ToolStripButton toolStripActualizar;
        private System.Windows.Forms.ToolStripButton toolStripEliminar;
        private System.Windows.Forms.ToolStripButton toolStripGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtCedula;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label CEDULA;
        private System.Windows.Forms.DataGridView dataGridViewClientes;
    }
}