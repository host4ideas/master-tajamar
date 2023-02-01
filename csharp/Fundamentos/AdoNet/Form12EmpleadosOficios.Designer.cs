namespace AdoNet
{
    partial class Form12EmpleadosOficios
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
            this.lstEmpleados = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOficios = new System.Windows.Forms.ComboBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.columnApellido = new System.Windows.Forms.ColumnHeader();
            this.columnOficio = new System.Windows.Forms.ColumnHeader();
            this.columnSalario = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIncremento = new System.Windows.Forms.TextBox();
            this.btnIncrementar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstEmpleados
            // 
            this.lstEmpleados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnApellido,
            this.columnOficio,
            this.columnSalario});
            this.lstEmpleados.Location = new System.Drawing.Point(12, 87);
            this.lstEmpleados.Name = "lstEmpleados";
            this.lstEmpleados.Size = new System.Drawing.Size(387, 177);
            this.lstEmpleados.TabIndex = 0;
            this.lstEmpleados.UseCompatibleStateImageBehavior = false;
            this.lstEmpleados.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Oficios";
            // 
            // cmbOficios
            // 
            this.cmbOficios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbOficios.FormattingEnabled = true;
            this.cmbOficios.Location = new System.Drawing.Point(12, 33);
            this.cmbOficios.Name = "cmbOficios";
            this.cmbOficios.Size = new System.Drawing.Size(121, 29);
            this.cmbOficios.TabIndex = 2;
            this.cmbOficios.SelectedIndexChanged += new System.EventHandler(this.cmbOficios_SelectedIndexChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.Location = new System.Drawing.Point(216, 33);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(137, 29);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // columnApellido
            // 
            this.columnApellido.Text = "Apellido";
            // 
            // columnOficio
            // 
            this.columnOficio.Text = "Oficio";
            // 
            // columnSalario
            // 
            this.columnSalario.Text = "Salario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(441, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Incremento";
            // 
            // txtIncremento
            // 
            this.txtIncremento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtIncremento.Location = new System.Drawing.Point(441, 34);
            this.txtIncremento.Name = "txtIncremento";
            this.txtIncremento.Size = new System.Drawing.Size(130, 29);
            this.txtIncremento.TabIndex = 5;
            // 
            // btnIncrementar
            // 
            this.btnIncrementar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIncrementar.Location = new System.Drawing.Point(441, 69);
            this.btnIncrementar.Name = "btnIncrementar";
            this.btnIncrementar.Size = new System.Drawing.Size(130, 29);
            this.btnIncrementar.TabIndex = 6;
            this.btnIncrementar.Text = "Incremento";
            this.btnIncrementar.UseVisualStyleBackColor = true;
            this.btnIncrementar.Click += new System.EventHandler(this.btnIncrementar_Click);
            // 
            // Form12EmpleadosOficios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 287);
            this.Controls.Add(this.btnIncrementar);
            this.Controls.Add(this.txtIncremento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.cmbOficios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstEmpleados);
            this.Name = "Form12EmpleadosOficios";
            this.Text = "Form12EmpleadosOficios";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView lstEmpleados;
        private ColumnHeader columnApellido;
        private ColumnHeader columnOficio;
        private ColumnHeader columnSalario;
        private Label label1;
        private ComboBox cmbOficios;
        private Button btnEliminar;
        private Label label2;
        private TextBox txtIncremento;
        private Button btnIncrementar;
    }
}