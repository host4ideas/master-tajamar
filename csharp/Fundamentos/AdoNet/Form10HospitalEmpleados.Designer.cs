namespace AdoNet
{
    partial class Form10HospitalEmpleados
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
            this.label5 = new System.Windows.Forms.Label();
            this.cmbHospital = new System.Windows.Forms.ComboBox();
            this.lblMensajes = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstEmpleados = new System.Windows.Forms.ListBox();
            this.txtPersonas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMedia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSuma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 21);
            this.label5.TabIndex = 34;
            this.label5.Text = "Hospital";
            // 
            // cmbHospital
            // 
            this.cmbHospital.FormattingEnabled = true;
            this.cmbHospital.Location = new System.Drawing.Point(12, 42);
            this.cmbHospital.Name = "cmbHospital";
            this.cmbHospital.Size = new System.Drawing.Size(121, 23);
            this.cmbHospital.TabIndex = 33;
            this.cmbHospital.SelectedIndexChanged += new System.EventHandler(this.cmbHospital_SelectedIndexChanged);
            // 
            // lblMensajes
            // 
            this.lblMensajes.AutoSize = true;
            this.lblMensajes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMensajes.ForeColor = System.Drawing.Color.IndianRed;
            this.lblMensajes.Location = new System.Drawing.Point(12, 313);
            this.lblMensajes.Name = "lblMensajes";
            this.lblMensajes.Size = new System.Drawing.Size(0, 21);
            this.lblMensajes.TabIndex = 32;
            this.lblMensajes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(193, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 21);
            this.label4.TabIndex = 31;
            this.label4.Text = "Empleados";
            // 
            // lstEmpleados
            // 
            this.lstEmpleados.FormattingEnabled = true;
            this.lstEmpleados.ItemHeight = 15;
            this.lstEmpleados.Location = new System.Drawing.Point(193, 43);
            this.lstEmpleados.Name = "lstEmpleados";
            this.lstEmpleados.Size = new System.Drawing.Size(382, 229);
            this.lstEmpleados.TabIndex = 30;
            // 
            // txtPersonas
            // 
            this.txtPersonas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPersonas.Location = new System.Drawing.Point(12, 231);
            this.txtPersonas.Name = "txtPersonas";
            this.txtPersonas.Size = new System.Drawing.Size(100, 29);
            this.txtPersonas.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 21);
            this.label3.TabIndex = 28;
            this.label3.Text = "Personas";
            // 
            // txtMedia
            // 
            this.txtMedia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMedia.Location = new System.Drawing.Point(12, 167);
            this.txtMedia.Name = "txtMedia";
            this.txtMedia.Size = new System.Drawing.Size(100, 29);
            this.txtMedia.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 21);
            this.label2.TabIndex = 26;
            this.label2.Text = "Media";
            // 
            // txtSuma
            // 
            this.txtSuma.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSuma.Location = new System.Drawing.Point(12, 105);
            this.txtSuma.Name = "txtSuma";
            this.txtSuma.Size = new System.Drawing.Size(100, 29);
            this.txtSuma.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 21);
            this.label1.TabIndex = 24;
            this.label1.Text = "Suma";
            // 
            // Form10HospitalEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 357);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbHospital);
            this.Controls.Add(this.lblMensajes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstEmpleados);
            this.Controls.Add(this.txtPersonas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMedia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSuma);
            this.Controls.Add(this.label1);
            this.Name = "Form10HospitalEmpleados";
            this.Text = "Form10HospitalEmpleados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label5;
        private ComboBox cmbHospital;
        private Label lblMensajes;
        private Label label4;
        private ListBox lstEmpleados;
        private TextBox txtPersonas;
        private Label label3;
        private TextBox txtMedia;
        private Label label2;
        private TextBox txtSuma;
        private Label label1;
    }
}