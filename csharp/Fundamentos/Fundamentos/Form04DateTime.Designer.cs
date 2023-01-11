namespace Fundamentos
{
    partial class Form04DateTime
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
            this.checkBoxFormat = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textDate = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIncr = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIncr = new System.Windows.Forms.TextBox();
            this.rdbYears = new System.Windows.Forms.RadioButton();
            this.rdbMonths = new System.Windows.Forms.RadioButton();
            this.rdbDays = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxFormat
            // 
            this.checkBoxFormat.AutoSize = true;
            this.checkBoxFormat.Location = new System.Drawing.Point(12, 145);
            this.checkBoxFormat.Name = "checkBoxFormat";
            this.checkBoxFormat.Size = new System.Drawing.Size(149, 19);
            this.checkBoxFormat.TabIndex = 0;
            this.checkBoxFormat.Text = "Cambiar formato fecha";
            this.checkBoxFormat.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Viner Hand ITC", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha actual";
            // 
            // textDate
            // 
            this.textDate.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textDate.Location = new System.Drawing.Point(12, 69);
            this.textDate.Name = "textDate";
            this.textDate.Size = new System.Drawing.Size(567, 41);
            this.textDate.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIncr);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIncr);
            this.groupBox1.Controls.Add(this.rdbYears);
            this.groupBox1.Controls.Add(this.rdbMonths);
            this.groupBox1.Controls.Add(this.rdbDays);
            this.groupBox1.Location = new System.Drawing.Point(12, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 151);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Incrementar fecha";
            // 
            // btnIncr
            // 
            this.btnIncr.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIncr.Location = new System.Drawing.Point(301, 83);
            this.btnIncr.Name = "btnIncr";
            this.btnIncr.Size = new System.Drawing.Size(177, 41);
            this.btnIncr.TabIndex = 5;
            this.btnIncr.Text = "Incrementar";
            this.btnIncr.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(301, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Incremento:";
            // 
            // txtIncr
            // 
            this.txtIncr.Location = new System.Drawing.Point(378, 36);
            this.txtIncr.Name = "txtIncr";
            this.txtIncr.Size = new System.Drawing.Size(100, 23);
            this.txtIncr.TabIndex = 3;
            // 
            // rdbYears
            // 
            this.rdbYears.AutoSize = true;
            this.rdbYears.Location = new System.Drawing.Point(40, 105);
            this.rdbYears.Name = "rdbYears";
            this.rdbYears.Size = new System.Drawing.Size(52, 19);
            this.rdbYears.TabIndex = 2;
            this.rdbYears.TabStop = true;
            this.rdbYears.Text = "Años";
            this.rdbYears.UseVisualStyleBackColor = true;
            // 
            // rdbMonths
            // 
            this.rdbMonths.AutoSize = true;
            this.rdbMonths.Location = new System.Drawing.Point(40, 70);
            this.rdbMonths.Name = "rdbMonths";
            this.rdbMonths.Size = new System.Drawing.Size(58, 19);
            this.rdbMonths.TabIndex = 1;
            this.rdbMonths.TabStop = true;
            this.rdbMonths.Text = "Meses";
            this.rdbMonths.UseVisualStyleBackColor = true;
            // 
            // rdbDays
            // 
            this.rdbDays.AutoSize = true;
            this.rdbDays.Location = new System.Drawing.Point(40, 32);
            this.rdbDays.Name = "rdbDays";
            this.rdbDays.Size = new System.Drawing.Size(47, 19);
            this.rdbDays.TabIndex = 0;
            this.rdbDays.TabStop = true;
            this.rdbDays.Text = "Días";
            this.rdbDays.UseVisualStyleBackColor = true;
            // 
            // Form04DateTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(595, 372);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxFormat);
            this.Name = "Form04DateTime";
            this.Text = "Form04DateTime";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox checkBoxFormat;
        private Label label1;
        private TextBox textDate;
        private GroupBox groupBox1;
        private RadioButton rdbYears;
        private RadioButton rdbMonths;
        private RadioButton rdbDays;
        private Button btnIncr;
        private Label label2;
        private TextBox txtIncr;
    }
}