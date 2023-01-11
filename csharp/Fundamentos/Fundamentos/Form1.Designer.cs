namespace Fundamentos
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPulsar = new System.Windows.Forms.Button();
            this.labelNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.formulariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formSumarNumerosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formColoresPosicionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formDiaNacimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formDateTimesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPulsar
            // 
            this.btnPulsar.BackColor = System.Drawing.Color.Coral;
            this.btnPulsar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPulsar.Location = new System.Drawing.Point(245, 187);
            this.btnPulsar.Name = "btnPulsar";
            this.btnPulsar.Size = new System.Drawing.Size(197, 73);
            this.btnPulsar.TabIndex = 0;
            this.btnPulsar.Text = "Pulsar";
            this.btnPulsar.UseVisualStyleBackColor = false;
            this.btnPulsar.Click += new System.EventHandler(this.btnPulsar_Click);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNombre.Location = new System.Drawing.Point(172, 100);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(115, 36);
            this.labelNombre.TabIndex = 1;
            this.labelNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombre.Location = new System.Drawing.Point(358, 100);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 41);
            this.txtNombre.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formulariosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // formulariosToolStripMenuItem
            // 
            this.formulariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formSumarNumerosToolStripMenuItem,
            this.formColoresPosicionToolStripMenuItem,
            this.formDiaNacimientoToolStripMenuItem,
            this.formDateTimesToolStripMenuItem});
            this.formulariosToolStripMenuItem.Name = "formulariosToolStripMenuItem";
            this.formulariosToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.formulariosToolStripMenuItem.Text = "Formularios";
            // 
            // formSumarNumerosToolStripMenuItem
            // 
            this.formSumarNumerosToolStripMenuItem.Name = "formSumarNumerosToolStripMenuItem";
            this.formSumarNumerosToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.formSumarNumerosToolStripMenuItem.Text = "Form sumar números";
            this.formSumarNumerosToolStripMenuItem.Click += new System.EventHandler(this.formSumarNumerosToolStripMenuItem_Click);
            // 
            // formColoresPosicionToolStripMenuItem
            // 
            this.formColoresPosicionToolStripMenuItem.Name = "formColoresPosicionToolStripMenuItem";
            this.formColoresPosicionToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.formColoresPosicionToolStripMenuItem.Text = "Form colores posición";
            this.formColoresPosicionToolStripMenuItem.Click += new System.EventHandler(this.formColoresPosicionToolStripMenuItem_Click);
            // 
            // formDiaNacimientoToolStripMenuItem
            // 
            this.formDiaNacimientoToolStripMenuItem.Name = "formDiaNacimientoToolStripMenuItem";
            this.formDiaNacimientoToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.formDiaNacimientoToolStripMenuItem.Text = "Form dia nacimiento";
            this.formDiaNacimientoToolStripMenuItem.Click += new System.EventHandler(this.formDiaNacimientoToolStripMenuItem_Click);
            // 
            // formDateTimesToolStripMenuItem
            // 
            this.formDateTimesToolStripMenuItem.Name = "formDateTimesToolStripMenuItem";
            this.formDateTimesToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.formDateTimesToolStripMenuItem.Text = "Form DateTimes";
            this.formDateTimesToolStripMenuItem.Click += new System.EventHandler(this.formDateTimesToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.btnPulsar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Formulario";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnPulsar;
        private Label labelNombre;
        private TextBox txtNombre;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem formulariosToolStripMenuItem;
        private ToolStripMenuItem formSumarNumerosToolStripMenuItem;
        private ToolStripMenuItem formColoresPosicionToolStripMenuItem;
        private ToolStripMenuItem formDiaNacimientoToolStripMenuItem;
        private ToolStripMenuItem formDateTimesToolStripMenuItem;
    }
}