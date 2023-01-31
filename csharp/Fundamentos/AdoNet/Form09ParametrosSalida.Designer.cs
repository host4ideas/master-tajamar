namespace AdoNet
{
    partial class Form09ParametrosSalida
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
            this.lblMensajes = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstEmpleados = new System.Windows.Forms.ListBox();
            this.txtPersonas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMedia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSuma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDepartamentos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMensajes
            // 
            this.lblMensajes.AutoSize = true;
            this.lblMensajes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMensajes.ForeColor = System.Drawing.Color.IndianRed;
            this.lblMensajes.Location = new System.Drawing.Point(12, 362);
            this.lblMensajes.Name = "lblMensajes";
            this.lblMensajes.Size = new System.Drawing.Size(0, 21);
            this.lblMensajes.TabIndex = 20;
            this.lblMensajes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(193, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 21);
            this.label4.TabIndex = 19;
            this.label4.Text = "Empleados";
            // 
            // lstEmpleados
            // 
            this.lstEmpleados.FormattingEnabled = true;
            this.lstEmpleados.ItemHeight = 15;
            this.lstEmpleados.Location = new System.Drawing.Point(193, 43);
            this.lstEmpleados.Name = "lstEmpleados";
            this.lstEmpleados.Size = new System.Drawing.Size(382, 214);
            this.lstEmpleados.TabIndex = 18;
            // 
            // txtPersonas
            // 
            this.txtPersonas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPersonas.Location = new System.Drawing.Point(12, 287);
            this.txtPersonas.Name = "txtPersonas";
            this.txtPersonas.Size = new System.Drawing.Size(100, 29);
            this.txtPersonas.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "Personas";
            // 
            // txtMedia
            // 
            this.txtMedia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMedia.Location = new System.Drawing.Point(12, 223);
            this.txtMedia.Name = "txtMedia";
            this.txtMedia.Size = new System.Drawing.Size(100, 29);
            this.txtMedia.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "Media";
            // 
            // txtSuma
            // 
            this.txtSuma.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSuma.Location = new System.Drawing.Point(12, 161);
            this.txtSuma.Name = "txtSuma";
            this.txtSuma.Size = new System.Drawing.Size(100, 29);
            this.txtSuma.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "Suma";
            // 
            // cmbDepartamentos
            // 
            this.cmbDepartamentos.FormattingEnabled = true;
            this.cmbDepartamentos.Location = new System.Drawing.Point(12, 42);
            this.cmbDepartamentos.Name = "cmbDepartamentos";
            this.cmbDepartamentos.Size = new System.Drawing.Size(121, 23);
            this.cmbDepartamentos.TabIndex = 21;
            this.cmbDepartamentos.SelectedIndexChanged += new System.EventHandler(this.cmbDepartamentos_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 21);
            this.label5.TabIndex = 22;
            this.label5.Text = "Departamentos";
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(12, 80);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(121, 42);
            this.btnMostrar.TabIndex = 23;
            this.btnMostrar.Text = "Mostrar datos";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // Form09ParametrosSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 390);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDepartamentos);
            this.Controls.Add(this.lblMensajes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstEmpleados);
            this.Controls.Add(this.txtPersonas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMedia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSuma);
            this.Controls.Add(this.label1);
            this.Name = "Form09ParametrosSalida";
            this.Text = "Form09ParametrosSalida";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblMensajes;
        private Label label4;
        private ListBox lstEmpleados;
        private TextBox txtPersonas;
        private Label label3;
        private TextBox txtMedia;
        private Label label2;
        private TextBox txtSuma;
        private Label label1;
        private ComboBox cmbDepartamentos;
        private Label label5;
        private Button btnMostrar;
    }
}