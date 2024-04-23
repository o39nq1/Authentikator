namespace Raktar
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
            this.buttonsave = new System.Windows.Forms.Button();
            this.buttonmegse = new System.Windows.Forms.Button();
            this.buttonplus = new System.Windows.Forms.Button();
            this.buttondelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxmennyiseg = new System.Windows.Forms.TextBox();
            this.textBoxPR = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(51, 167);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(549, 554);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(549, 31);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonsave
            // 
            this.buttonsave.Location = new System.Drawing.Point(1151, 654);
            this.buttonsave.Name = "buttonsave";
            this.buttonsave.Size = new System.Drawing.Size(190, 67);
            this.buttonsave.TabIndex = 2;
            this.buttonsave.Text = "Mentés";
            this.buttonsave.UseVisualStyleBackColor = true;
            this.buttonsave.Click += new System.EventHandler(this.buttonsave_Click);
            // 
            // buttonmegse
            // 
            this.buttonmegse.Location = new System.Drawing.Point(843, 654);
            this.buttonmegse.Name = "buttonmegse";
            this.buttonmegse.Size = new System.Drawing.Size(190, 67);
            this.buttonmegse.TabIndex = 3;
            this.buttonmegse.Text = "Mégse";
            this.buttonmegse.UseVisualStyleBackColor = true;
            // 
            // buttonplus
            // 
            this.buttonplus.Location = new System.Drawing.Point(1221, 167);
            this.buttonplus.Name = "buttonplus";
            this.buttonplus.Size = new System.Drawing.Size(120, 120);
            this.buttonplus.TabIndex = 4;
            this.buttonplus.Text = "+";
            this.buttonplus.UseVisualStyleBackColor = true;
            this.buttonplus.Click += new System.EventHandler(this.buttonplus_Click);
            // 
            // buttondelete
            // 
            this.buttondelete.Location = new System.Drawing.Point(1221, 392);
            this.buttondelete.Name = "buttondelete";
            this.buttondelete.Size = new System.Drawing.Size(120, 120);
            this.buttondelete.TabIndex = 5;
            this.buttondelete.Text = "-";
            this.buttondelete.UseVisualStyleBackColor = true;
            this.buttondelete.Click += new System.EventHandler(this.buttondelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(799, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Készleten:";
            // 
            // textBoxmennyiseg
            // 
            this.textBoxmennyiseg.Location = new System.Drawing.Point(981, 325);
            this.textBoxmennyiseg.Name = "textBoxmennyiseg";
            this.textBoxmennyiseg.Size = new System.Drawing.Size(100, 31);
            this.textBoxmennyiseg.TabIndex = 7;
            // 
            // textBoxPR
            // 
            this.textBoxPR.Location = new System.Drawing.Point(814, 131);
            this.textBoxPR.Name = "textBoxPR";
            this.textBoxPR.Size = new System.Drawing.Size(100, 31);
            this.textBoxPR.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 799);
            this.Controls.Add(this.textBoxPR);
            this.Controls.Add(this.textBoxmennyiseg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttondelete);
            this.Controls.Add(this.buttonplus);
            this.Controls.Add(this.buttonmegse);
            this.Controls.Add(this.buttonsave);
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
        private System.Windows.Forms.Button buttonsave;
        private System.Windows.Forms.Button buttonmegse;
        private System.Windows.Forms.Button buttonplus;
        private System.Windows.Forms.Button buttondelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxmennyiseg;
        private System.Windows.Forms.TextBox textBoxPR;
    }
}

