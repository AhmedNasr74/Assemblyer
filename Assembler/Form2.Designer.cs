namespace Assembler
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.save = new System.Windows.Forms.Button();
            this.btnbrose = new System.Windows.Forms.Button();
            this.parent = new System.Windows.Forms.Panel();
            this.binary = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.BinaryCode = new System.Windows.Forms.RichTextBox();
            this.mips = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.mipsCode = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.parent.SuspendLayout();
            this.binary.SuspendLayout();
            this.mips.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.save);
            this.panel1.Controls.Add(this.btnbrose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 433);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 57);
            this.panel1.TabIndex = 11;
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save.BackColor = System.Drawing.Color.Navy;
            this.save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.save.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.ForeColor = System.Drawing.Color.White;
            this.save.Location = new System.Drawing.Point(764, 6);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(128, 46);
            this.save.TabIndex = 9;
            this.save.Text = "Save Result";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // btnbrose
            // 
            this.btnbrose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbrose.BackColor = System.Drawing.Color.ForestGreen;
            this.btnbrose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbrose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnbrose.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbrose.ForeColor = System.Drawing.Color.White;
            this.btnbrose.Location = new System.Drawing.Point(572, 6);
            this.btnbrose.Name = "btnbrose";
            this.btnbrose.Size = new System.Drawing.Size(188, 46);
            this.btnbrose.TabIndex = 8;
            this.btnbrose.Text = "Convert To Binary";
            this.btnbrose.UseVisualStyleBackColor = false;
            this.btnbrose.Click += new System.EventHandler(this.btnbrose_Click);
            // 
            // parent
            // 
            this.parent.Controls.Add(this.binary);
            this.parent.Controls.Add(this.mips);
            this.parent.Controls.Add(this.panel1);
            this.parent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parent.Location = new System.Drawing.Point(0, 0);
            this.parent.Name = "parent";
            this.parent.Size = new System.Drawing.Size(895, 490);
            this.parent.TabIndex = 1;
            // 
            // binary
            // 
            this.binary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.binary.AutoScroll = true;
            this.binary.Controls.Add(this.pictureBox1);
            this.binary.Controls.Add(this.label2);
            this.binary.Controls.Add(this.BinaryCode);
            this.binary.Location = new System.Drawing.Point(449, 0);
            this.binary.Name = "binary";
            this.binary.Size = new System.Drawing.Size(446, 433);
            this.binary.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Azure;
            this.label2.Location = new System.Drawing.Point(158, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Machine  Code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BinaryCode
            // 
            this.BinaryCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BinaryCode.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BinaryCode.ForeColor = System.Drawing.Color.ForestGreen;
            this.BinaryCode.Location = new System.Drawing.Point(3, 40);
            this.BinaryCode.Name = "BinaryCode";
            this.BinaryCode.Size = new System.Drawing.Size(440, 387);
            this.BinaryCode.TabIndex = 11;
            this.BinaryCode.Text = "";
            // 
            // mips
            // 
            this.mips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mips.AutoScroll = true;
            this.mips.Controls.Add(this.label1);
            this.mips.Controls.Add(this.mipsCode);
            this.mips.Location = new System.Drawing.Point(0, 0);
            this.mips.Name = "mips";
            this.mips.Size = new System.Drawing.Size(443, 433);
            this.mips.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Azure;
            this.label1.Location = new System.Drawing.Point(125, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "MIPS Code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mipsCode
            // 
            this.mipsCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mipsCode.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mipsCode.ForeColor = System.Drawing.Color.MediumBlue;
            this.mipsCode.Location = new System.Drawing.Point(3, 40);
            this.mipsCode.Name = "mipsCode";
            this.mipsCode.Size = new System.Drawing.Size(435, 387);
            this.mipsCode.TabIndex = 9;
            this.mipsCode.Text = "Write Code Here";
            this.mipsCode.Click += new System.EventHandler(this.mipsCode_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(383, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(895, 490);
            this.Controls.Add(this.parent);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MIPS Converter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.parent.ResumeLayout(false);
            this.binary.ResumeLayout(false);
            this.binary.PerformLayout();
            this.mips.ResumeLayout(false);
            this.mips.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button btnbrose;
        private System.Windows.Forms.Panel parent;
        private System.Windows.Forms.Panel binary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox BinaryCode;
        private System.Windows.Forms.Panel mips;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox mipsCode;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}