namespace Fundamentos
{
    partial class Form17MesesTemp
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
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTempMax = new System.Windows.Forms.TextBox();
            this.txtTempMin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstMeses = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Meses";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(307, 83);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(111, 43);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar meses";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(307, 132);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(111, 43);
            this.btnMostrar.TabIndex = 3;
            this.btnMostrar.Text = "Mostrar datos";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(274, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Temperatura máxima";
            // 
            // txtTempMax
            // 
            this.txtTempMax.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTempMax.Location = new System.Drawing.Point(314, 247);
            this.txtTempMax.Name = "txtTempMax";
            this.txtTempMax.Size = new System.Drawing.Size(100, 31);
            this.txtTempMax.TabIndex = 5;
            // 
            // txtTempMin
            // 
            this.txtTempMin.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTempMin.Location = new System.Drawing.Point(314, 340);
            this.txtTempMin.Name = "txtTempMin";
            this.txtTempMin.Size = new System.Drawing.Size(100, 31);
            this.txtTempMin.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(274, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Temperatura mínima";
            // 
            // lstMeses
            // 
            this.lstMeses.FormattingEnabled = true;
            this.lstMeses.ItemHeight = 15;
            this.lstMeses.Location = new System.Drawing.Point(12, 50);
            this.lstMeses.Name = "lstMeses";
            this.lstMeses.Size = new System.Drawing.Size(219, 379);
            this.lstMeses.TabIndex = 8;
            // 
            // Form17MesesTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 450);
            this.Controls.Add(this.lstMeses);
            this.Controls.Add(this.txtTempMin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTempMax);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.label1);
            this.Name = "Form17MesesTemp";
            this.Text = "Form17MesesTemp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btnGenerar;
        private Button btnMostrar;
        private Label label2;
        private TextBox txtTempMax;
        private TextBox txtTempMin;
        private Label label3;
        private ListBox lstMeses;
    }
}