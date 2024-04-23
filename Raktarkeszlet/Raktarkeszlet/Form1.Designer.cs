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
            this.textBoxmennyiseg = new System.Windows.Forms.TextBox();
            this.buttonplus = new System.Windows.Forms.Button();
            this.buttonminus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonsave = new System.Windows.Forms.Button();
            this.buttonmegse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(95, 161);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(583, 604);
            this.listBox1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(565, 31);
            this.textBox1.TabIndex = 1;
            // 
            // textBoxmennyiseg
            // 
            this.textBoxmennyiseg.Location = new System.Drawing.Point(1044, 348);
            this.textBoxmennyiseg.Name = "textBoxmennyiseg";
            this.textBoxmennyiseg.Size = new System.Drawing.Size(100, 31);
            this.textBoxmennyiseg.TabIndex = 2;
            // 
            // buttonplus
            // 
            this.buttonplus.Location = new System.Drawing.Point(1243, 161);
            this.buttonplus.Name = "buttonplus";
            this.buttonplus.Size = new System.Drawing.Size(120, 120);
            this.buttonplus.TabIndex = 3;
            this.buttonplus.Text = "+";
            this.buttonplus.UseVisualStyleBackColor = true;
            // 
            // buttonminus
            // 
            this.buttonminus.Location = new System.Drawing.Point(1243, 431);
            this.buttonminus.Name = "buttonminus";
            this.buttonminus.Size = new System.Drawing.Size(120, 120);
            this.buttonminus.TabIndex = 4;
            this.buttonminus.Text = "-";
            this.buttonminus.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(890, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Készleten:";
            // 
            // buttonsave
            // 
            this.buttonsave.Location = new System.Drawing.Point(1203, 701);
            this.buttonsave.Name = "buttonsave";
            this.buttonsave.Size = new System.Drawing.Size(160, 64);
            this.buttonsave.TabIndex = 6;
            this.buttonsave.Text = "Mentés";
            this.buttonsave.UseVisualStyleBackColor = true;
            // 
            // buttonmegse
            // 
            this.buttonmegse.Location = new System.Drawing.Point(911, 701);
            this.buttonmegse.Name = "buttonmegse";
            this.buttonmegse.Size = new System.Drawing.Size(160, 64);
            this.buttonmegse.TabIndex = 7;
            this.buttonmegse.Text = "Mégse";
            this.buttonmegse.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1494, 832);
            this.Controls.Add(this.buttonmegse);
            this.Controls.Add(this.buttonsave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonminus);
            this.Controls.Add(this.buttonplus);
            this.Controls.Add(this.textBoxmennyiseg);
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
        private System.Windows.Forms.TextBox textBoxmennyiseg;
        private System.Windows.Forms.Button buttonplus;
        private System.Windows.Forms.Button buttonminus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonsave;
        private System.Windows.Forms.Button buttonmegse;
    }
}

