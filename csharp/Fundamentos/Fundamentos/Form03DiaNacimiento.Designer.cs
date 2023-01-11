namespace Fundamentos
{
    partial class Form03DiaNacimiento
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
            this.labelDia = new System.Windows.Forms.Label();
            this.Mes = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textDay = new System.Windows.Forms.TextBox();
            this.textMonth = new System.Windows.Forms.TextBox();
            this.textYear = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDia
            // 
            this.labelDia.AutoSize = true;
            this.labelDia.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDia.Location = new System.Drawing.Point(73, 49);
            this.labelDia.Name = "labelDia";
            this.labelDia.Size = new System.Drawing.Size(52, 36);
            this.labelDia.TabIndex = 0;
            this.labelDia.Text = "Día";
            // 
            // Mes
            // 
            this.Mes.AutoSize = true;
            this.Mes.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Mes.Location = new System.Drawing.Point(73, 98);
            this.Mes.Name = "Mes";
            this.Mes.Size = new System.Drawing.Size(63, 36);
            this.Mes.TabIndex = 1;
            this.Mes.Text = "Mes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(73, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 36);
            this.label3.TabIndex = 2;
            this.label3.Text = "Año";
            // 
            // textDay
            // 
            this.textDay.Location = new System.Drawing.Point(196, 62);
            this.textDay.Name = "textDay";
            this.textDay.Size = new System.Drawing.Size(100, 23);
            this.textDay.TabIndex = 3;
            // 
            // textMonth
            // 
            this.textMonth.Location = new System.Drawing.Point(196, 111);
            this.textMonth.Name = "textMonth";
            this.textMonth.Size = new System.Drawing.Size(100, 23);
            this.textMonth.TabIndex = 4;
            // 
            // textYear
            // 
            this.textYear.Location = new System.Drawing.Point(196, 156);
            this.textYear.Name = "textYear";
            this.textYear.Size = new System.Drawing.Size(100, 23);
            this.textYear.TabIndex = 5;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(449, 89);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(107, 64);
            this.btnCalculate.TabIndex = 6;
            this.btnCalculate.Text = "Calcular dia nacimiento";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResult.Location = new System.Drawing.Point(303, 262);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 36);
            this.lblResult.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(292, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 36);
            this.label1.TabIndex = 8;
            this.label1.Text = "Resultado";
            // 
            // Form03DiaNacimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.textYear);
            this.Controls.Add(this.textMonth);
            this.Controls.Add(this.textDay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Mes);
            this.Controls.Add(this.labelDia);
            this.Name = "Form03DiaNacimiento";
            this.Text = "Form03DiaNacimiento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelDia;
        private Label Mes;
        private Label label3;
        private TextBox textDay;
        private TextBox textMonth;
        private TextBox textYear;
        private Button btnCalculate;
        private Label lblResult;
        private Label label1;
    }
}