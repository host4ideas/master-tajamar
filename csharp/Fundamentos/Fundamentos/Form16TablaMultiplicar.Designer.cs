namespace Fundamentos
{
    partial class Form16TablaMultiplicar
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
            this.txtNum = new System.Windows.Forms.TextBox();
            this.panelTabla = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.panelTabla.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(34, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(37, 69);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(100, 23);
            this.txtNum.TabIndex = 1;
            // 
            // panelTabla
            // 
            this.panelTabla.Controls.Add(this.textBox9);
            this.panelTabla.Controls.Add(this.textBox8);
            this.panelTabla.Controls.Add(this.textBox7);
            this.panelTabla.Controls.Add(this.textBox6);
            this.panelTabla.Controls.Add(this.textBox5);
            this.panelTabla.Controls.Add(this.textBox4);
            this.panelTabla.Controls.Add(this.textBox3);
            this.panelTabla.Controls.Add(this.textBox2);
            this.panelTabla.Controls.Add(this.textBox1);
            this.panelTabla.Location = new System.Drawing.Point(12, 191);
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Size = new System.Drawing.Size(157, 317);
            this.panelTabla.TabIndex = 2;
            this.panelTabla.TabStop = false;
            this.panelTabla.Text = "Tabla Multiplicar";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(30, 154);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 23);
            this.textBox5.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(30, 125);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 23);
            this.textBox4.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(30, 96);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 23);
            this.textBox3.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(30, 67);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(30, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 0;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(37, 119);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(100, 40);
            this.btnMostrar.TabIndex = 3;
            this.btnMostrar.Text = "Mostar tabla";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(30, 183);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 23);
            this.textBox6.TabIndex = 5;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(30, 212);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 23);
            this.textBox7.TabIndex = 6;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(30, 241);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 23);
            this.textBox8.TabIndex = 7;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(31, 270);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 23);
            this.textBox9.TabIndex = 8;
            // 
            // Form16TablaMultiplicar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 520);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.panelTabla);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.label1);
            this.Name = "Form16TablaMultiplicar";
            this.Text = "Form16TablaMultiplicar";
            this.panelTabla.ResumeLayout(false);
            this.panelTabla.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtNum;
        private GroupBox panelTabla;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button btnMostrar;
        private TextBox textBox9;
        private TextBox textBox8;
        private TextBox textBox7;
        private TextBox textBox6;
    }
}