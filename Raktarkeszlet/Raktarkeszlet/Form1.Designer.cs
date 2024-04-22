namespace Raktarkeszlet
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonminus = new System.Windows.Forms.Button();
            this.buttonplus = new System.Windows.Forms.Button();
            this.textBoxmennyiseg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonsave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(92, 163);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(444, 579);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(444, 31);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonminus
            // 
            this.buttonminus.Location = new System.Drawing.Point(1267, 163);
            this.buttonminus.Name = "buttonminus";
            this.buttonminus.Size = new System.Drawing.Size(120, 120);
            this.buttonminus.TabIndex = 2;
            this.buttonminus.Text = "-";
            this.buttonminus.UseVisualStyleBackColor = true;
            // 
            // buttonplus
            // 
            this.buttonplus.Location = new System.Drawing.Point(1267, 410);
            this.buttonplus.Name = "buttonplus";
            this.buttonplus.Size = new System.Drawing.Size(120, 120);
            this.buttonplus.TabIndex = 3;
            this.buttonplus.Text = "+";
            this.buttonplus.UseVisualStyleBackColor = true;
            // 
            // textBoxmennyiseg
            // 
            this.textBoxmennyiseg.Location = new System.Drawing.Point(1005, 334);
            this.textBoxmennyiseg.Name = "textBoxmennyiseg";
            this.textBoxmennyiseg.Size = new System.Drawing.Size(100, 31);
            this.textBoxmennyiseg.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(837, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Készleten:";
            // 
            // buttonsave
            // 
            this.buttonsave.Location = new System.Drawing.Point(1221, 675);
            this.buttonsave.Name = "buttonsave";
            this.buttonsave.Size = new System.Drawing.Size(166, 77);
            this.buttonsave.TabIndex = 6;
            this.buttonsave.Text = "mentés";
            this.buttonsave.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1491, 828);
            this.Controls.Add(this.buttonsave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxmennyiseg);
            this.Controls.Add(this.buttonplus);
            this.Controls.Add(this.buttonminus);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonminus;
        private System.Windows.Forms.Button buttonplus;
        private System.Windows.Forms.TextBox textBoxmennyiseg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonsave;
    }
}

