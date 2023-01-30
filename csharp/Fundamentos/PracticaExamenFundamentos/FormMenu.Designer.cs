namespace PracticaExamenFundamentos
{
    partial class FormMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.formulariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formFormularioHospitalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formulariosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // formulariosToolStripMenuItem
            // 
            this.formulariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formFormularioHospitalToolStripMenuItem});
            this.formulariosToolStripMenuItem.Name = "formulariosToolStripMenuItem";
            this.formulariosToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.formulariosToolStripMenuItem.Text = "Formularios";
            // 
            // formFormularioHospitalToolStripMenuItem
            // 
            this.formFormularioHospitalToolStripMenuItem.Name = "formFormularioHospitalToolStripMenuItem";
            this.formFormularioHospitalToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.formFormularioHospitalToolStripMenuItem.Text = "Form01FormularioHospital";
            this.formFormularioHospitalToolStripMenuItem.Click += new System.EventHandler(this.form01ControlarInputsToolStripMenuItem_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem formulariosToolStripMenuItem;
        private ToolStripMenuItem formFormularioHospitalToolStripMenuItem;
    }
}