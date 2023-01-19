namespace Fundamentos
{
    partial class Form19TemperaturaClases
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
            this.lstMeses = new System.Windows.Forms.ListBox();
            this.txtTempMin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTempMax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTempMedia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstMeses
            // 
            this.lstMeses.FormattingEnabled = true;
            this.lstMeses.ItemHeight = 15;
            this.lstMeses.Location = new System.Drawing.Point(12, 50);
            this.lstMeses.Name = "lstMeses";
            this.lstMeses.Size = new System.Drawing.Size(219, 379);
            this.lstMeses.TabIndex = 16;
            // 
            // txtTempMin
            // 
            this.txtTempMin.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTempMin.Location = new System.Drawing.Point(304, 277);
            this.txtTempMin.Name = "txtTempMin";
            this.txtTempMin.Size = new System.Drawing.Size(100, 31);
            this.txtTempMin.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(264, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Temperatura mínima";
            // 
            // txtTempMax
            // 
            this.txtTempMax.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTempMax.Location = new System.Drawing.Point(304, 184);
            this.txtTempMax.Name = "txtTempMax";
            this.txtTempMax.Size = new System.Drawing.Size(100, 31);
            this.txtTempMax.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(264, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Temperatura máxima";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(296, 39);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(111, 43);
            this.btnGenerar.TabIndex = 10;
            this.btnGenerar.Text = "Generar meses";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 36);
            this.label1.TabIndex = 9;
            this.label1.Text = "Meses";
            // 
            // txtTempMedia
            // 
            this.txtTempMedia.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTempMedia.Location = new System.Drawing.Point(307, 364);
            this.txtTempMedia.Name = "txtTempMedia";
            this.txtTempMedia.Size = new System.Drawing.Size(100, 31);
            this.txtTempMedia.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(267, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 25);
            this.label4.TabIndex = 17;
            this.label4.Text = "Temperatura media";
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(296, 97);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(111, 31);
            this.btnMostrar.TabIndex = 19;
            this.btnMostrar.Text = "Mostar datos";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click_1);
            // 
            // Form19TemperaturaClases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 450);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.txtTempMedia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstMeses);
            this.Controls.Add(this.txtTempMin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTempMax);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.label1);
            this.Name = "Form19TemperaturaClases";
            this.Text = "Form19TemperaturaClases";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lstMeses;
        private TextBox txtTempMin;
        private Label label3;
        private TextBox txtTempMax;
        private Label label2;
        private Button btnGenerar;
        private Label label1;
        private TextBox txtTempMedia;
        private Label label4;
        private Button btnMostrar;
    }
}