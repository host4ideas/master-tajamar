namespace Fundamentos
{
    partial class Form12Metodos
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
            this.btnDoubleRef = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.btnDoubleVal = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnDoubleNum = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoloNumeros = new System.Windows.Forms.TextBox();
            this.txtSoloLetras = new System.Windows.Forms.TextBox();
            this.lblMouseHover = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDoubleRef
            // 
            this.btnDoubleRef.Location = new System.Drawing.Point(89, 83);
            this.btnDoubleRef.Name = "btnDoubleRef";
            this.btnDoubleRef.Size = new System.Drawing.Size(75, 54);
            this.btnDoubleRef.TabIndex = 0;
            this.btnDoubleRef.Text = "Doble() Referencia";
            this.btnDoubleRef.UseVisualStyleBackColor = true;
            this.btnDoubleRef.Click += new System.EventHandler(this.btnDoubleRef_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Número";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(80, 6);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(100, 23);
            this.txtNum.TabIndex = 2;
            // 
            // btnDoubleVal
            // 
            this.btnDoubleVal.Location = new System.Drawing.Point(89, 54);
            this.btnDoubleVal.Name = "btnDoubleVal";
            this.btnDoubleVal.Size = new System.Drawing.Size(75, 23);
            this.btnDoubleVal.TabIndex = 3;
            this.btnDoubleVal.Text = "Doble() Valor";
            this.btnDoubleVal.UseVisualStyleBackColor = true;
            this.btnDoubleVal.Click += new System.EventHandler(this.btnDoubleVal_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(102, 308);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(52, 15);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "lblResult";
            // 
            // btnDoubleNum
            // 
            this.btnDoubleNum.Location = new System.Drawing.Point(89, 203);
            this.btnDoubleNum.Name = "btnDoubleNum";
            this.btnDoubleNum.Size = new System.Drawing.Size(75, 54);
            this.btnDoubleNum.TabIndex = 5;
            this.btnDoubleNum.Text = "Objeto Referencia";
            this.btnDoubleNum.UseVisualStyleBackColor = true;
            this.btnDoubleNum.Click += new System.EventHandler(this.btnObjRef_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 54);
            this.button1.TabIndex = 6;
            this.button1.Text = "Doble número";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            // 
            // txtSoloNumeros
            // 
            this.txtSoloNumeros.Location = new System.Drawing.Point(293, 31);
            this.txtSoloNumeros.Name = "txtSoloNumeros";
            this.txtSoloNumeros.Size = new System.Drawing.Size(100, 23);
            this.txtSoloNumeros.TabIndex = 9;
            this.txtSoloNumeros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // txtSoloLetras
            // 
            this.txtSoloLetras.Location = new System.Drawing.Point(293, 72);
            this.txtSoloLetras.Name = "txtSoloLetras";
            this.txtSoloLetras.Size = new System.Drawing.Size(100, 23);
            this.txtSoloLetras.TabIndex = 10;
            this.txtSoloLetras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoloLetras_KeyPress);
            // 
            // lblMouseHover
            // 
            this.lblMouseHover.BackColor = System.Drawing.Color.GreenYellow;
            this.lblMouseHover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMouseHover.Location = new System.Drawing.Point(227, 123);
            this.lblMouseHover.Name = "lblMouseHover";
            this.lblMouseHover.Size = new System.Drawing.Size(300, 200);
            this.lblMouseHover.TabIndex = 11;
            this.lblMouseHover.Text = "label4";
            this.lblMouseHover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMouseHover.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblMouseHover_MouseMove);
            // 
            // Form12Metodos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 332);
            this.Controls.Add(this.lblMouseHover);
            this.Controls.Add(this.txtSoloLetras);
            this.Controls.Add(this.txtSoloNumeros);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDoubleNum);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnDoubleVal);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDoubleRef);
            this.Name = "Form12Metodos";
            this.Text = "Form12Metodos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnDoubleRef;
        private Label label1;
        private TextBox txtNum;
        private Button btnDoubleVal;
        private Label lblResult;
        private Button btnDoubleNum;
        private Button button1;
        private Label label2;
        private Label label3;
        private TextBox txtSoloNumeros;
        private TextBox txtSoloLetras;
        private Label lblMouseHover;
    }
}