namespace AdoNet
{
    partial class Form07ProcedimientoUpdatePlantilla
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbHospitales = new System.Windows.Forms.ComboBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lstPlantilla = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hospitales";
            // 
            // cmbHospitales
            // 
            this.cmbHospitales.FormattingEnabled = true;
            this.cmbHospitales.Location = new System.Drawing.Point(12, 43);
            this.cmbHospitales.Name = "cmbHospitales";
            this.cmbHospitales.Size = new System.Drawing.Size(234, 23);
            this.cmbHospitales.TabIndex = 1;
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnModificar.Location = new System.Drawing.Point(284, 43);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(201, 78);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar salario";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Plantilla";
            // 
            // lstPlantilla
            // 
            this.lstPlantilla.FormattingEnabled = true;
            this.lstPlantilla.ItemHeight = 15;
            this.lstPlantilla.Location = new System.Drawing.Point(12, 139);
            this.lstPlantilla.Name = "lstPlantilla";
            this.lstPlantilla.Size = new System.Drawing.Size(473, 259);
            this.lstPlantilla.TabIndex = 4;
            // 
            // Form07ProcedimientoUpdatePlantilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 407);
            this.Controls.Add(this.lstPlantilla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.cmbHospitales);
            this.Controls.Add(this.label1);
            this.Name = "Form07ProcedimientoUpdatePlantilla";
            this.Text = "Form07ProcedimientoUpdatePlantilla";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox cmbHospitales;
        private Button btnModificar;
        private Label label2;
        private ListBox lstPlantilla;
    }
}