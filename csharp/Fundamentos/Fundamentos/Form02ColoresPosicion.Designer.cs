namespace Fundamentos
{
    partial class Form02ColoresPosicion
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
            this.btnChangeColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textR = new System.Windows.Forms.TextBox();
            this.textG = new System.Windows.Forms.TextBox();
            this.textB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textX = new System.Windows.Forms.TextBox();
            this.textY = new System.Windows.Forms.TextBox();
            this.btnChangePos = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChangeColor
            // 
            this.btnChangeColor.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnChangeColor.Location = new System.Drawing.Point(81, 211);
            this.btnChangeColor.Name = "btnChangeColor";
            this.btnChangeColor.Size = new System.Drawing.Size(200, 53);
            this.btnChangeColor.TabIndex = 0;
            this.btnChangeColor.Text = "Cambiar color";
            this.btnChangeColor.UseVisualStyleBackColor = true;
            this.btnChangeColor.Click += new System.EventHandler(this.btnChangeColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "R";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "G";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "B";
            // 
            // textR
            // 
            this.textR.Location = new System.Drawing.Point(159, 77);
            this.textR.Name = "textR";
            this.textR.Size = new System.Drawing.Size(100, 23);
            this.textR.TabIndex = 4;
            // 
            // textG
            // 
            this.textG.Location = new System.Drawing.Point(159, 106);
            this.textG.Name = "textG";
            this.textG.Size = new System.Drawing.Size(100, 23);
            this.textG.TabIndex = 5;
            // 
            // textB
            // 
            this.textB.Location = new System.Drawing.Point(159, 135);
            this.textB.Name = "textB";
            this.textB.Size = new System.Drawing.Size(100, 23);
            this.textB.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(471, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pos X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(471, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Pos Y";
            // 
            // textX
            // 
            this.textX.Location = new System.Drawing.Point(571, 77);
            this.textX.Name = "textX";
            this.textX.Size = new System.Drawing.Size(100, 23);
            this.textX.TabIndex = 9;
            // 
            // textY
            // 
            this.textY.Location = new System.Drawing.Point(571, 111);
            this.textY.Name = "textY";
            this.textY.Size = new System.Drawing.Size(100, 23);
            this.textY.TabIndex = 10;
            // 
            // btnChangePos
            // 
            this.btnChangePos.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnChangePos.Location = new System.Drawing.Point(471, 189);
            this.btnChangePos.Name = "btnChangePos";
            this.btnChangePos.Size = new System.Drawing.Size(200, 97);
            this.btnChangePos.TabIndex = 12;
            this.btnChangePos.Text = "Cambiar posición";
            this.btnChangePos.UseVisualStyleBackColor = true;
            this.btnChangePos.Click += new System.EventHandler(this.btnChangePos_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(697, 95);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form02ColoresPosicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnChangePos);
            this.Controls.Add(this.textY);
            this.Controls.Add(this.textX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textB);
            this.Controls.Add(this.textG);
            this.Controls.Add(this.textR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChangeColor);
            this.Name = "Form02ColoresPosicion";
            this.Text = "Form02ColoresPosicion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnChangeColor;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textR;
        private TextBox textG;
        private TextBox textB;
        private Label label4;
        private Label label5;
        private TextBox textX;
        private TextBox textY;
        private Button btnChangePos;
        private Button btnReset;
    }
}