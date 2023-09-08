namespace sternografie_E1
{
    partial class Stenographer
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
            this.imageUploadBtn = new System.Windows.Forms.Button();
            this.imageLoaderPb = new System.Windows.Forms.PictureBox();
            this.backgroundPnl = new System.Windows.Forms.Panel();
            this.outputLb = new System.Windows.Forms.Label();
            this.secretTextTbx = new System.Windows.Forms.TextBox();
            this.encodeBtn = new System.Windows.Forms.Button();
            this.decodeBtn = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.imageLoaderPb)).BeginInit();
            this.backgroundPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageUploadBtn
            // 
            this.imageUploadBtn.Location = new System.Drawing.Point(40, 13);
            this.imageUploadBtn.Name = "imageUploadBtn";
            this.imageUploadBtn.Size = new System.Drawing.Size(130, 50);
            this.imageUploadBtn.TabIndex = 0;
            this.imageUploadBtn.Text = "Upload image";
            this.imageUploadBtn.UseVisualStyleBackColor = true;
            this.imageUploadBtn.Click += new System.EventHandler(this.ImageUploadBtn_Click);
            // 
            // imageLoaderPb
            // 
            this.imageLoaderPb.Location = new System.Drawing.Point(227, 0);
            this.imageLoaderPb.Name = "imageLoaderPb";
            this.imageLoaderPb.Size = new System.Drawing.Size(573, 450);
            this.imageLoaderPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageLoaderPb.TabIndex = 1;
            this.imageLoaderPb.TabStop = false;
            // 
            // backgroundPnl
            // 
            this.backgroundPnl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.backgroundPnl.Controls.Add(this.outputLb);
            this.backgroundPnl.Controls.Add(this.secretTextTbx);
            this.backgroundPnl.Controls.Add(this.encodeBtn);
            this.backgroundPnl.Controls.Add(this.decodeBtn);
            this.backgroundPnl.Controls.Add(this.imageUploadBtn);
            this.backgroundPnl.Location = new System.Drawing.Point(0, 0);
            this.backgroundPnl.Name = "backgroundPnl";
            this.backgroundPnl.Size = new System.Drawing.Size(230, 450);
            this.backgroundPnl.TabIndex = 2;
            // 
            // outputLb
            // 
            this.outputLb.BackColor = System.Drawing.SystemColors.Control;
            this.outputLb.Location = new System.Drawing.Point(40, 290);
            this.outputLb.Name = "outputLb";
            this.outputLb.Size = new System.Drawing.Size(130, 151);
            this.outputLb.TabIndex = 5;
            this.outputLb.Text = "output for the secret text.";
            // 
            // secretTextTbx
            // 
            this.secretTextTbx.ForeColor = System.Drawing.SystemColors.GrayText;
            this.secretTextTbx.Location = new System.Drawing.Point(40, 69);
            this.secretTextTbx.Multiline = true;
            this.secretTextTbx.Name = "secretTextTbx";
            this.secretTextTbx.Size = new System.Drawing.Size(130, 106);
            this.secretTextTbx.TabIndex = 3;
            this.secretTextTbx.Tag = "";
            this.secretTextTbx.Text = "Write your secret text here...";
            this.secretTextTbx.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            // 
            // encodeBtn
            // 
            this.encodeBtn.Location = new System.Drawing.Point(40, 181);
            this.encodeBtn.Name = "encodeBtn";
            this.encodeBtn.Size = new System.Drawing.Size(130, 50);
            this.encodeBtn.TabIndex = 2;
            this.encodeBtn.Text = "Encode uploaded image";
            this.encodeBtn.UseVisualStyleBackColor = true;
            this.encodeBtn.Click += new System.EventHandler(this.encodeBtn_Click);
            // 
            // decodeBtn
            // 
            this.decodeBtn.Location = new System.Drawing.Point(40, 237);
            this.decodeBtn.Name = "decodeBtn";
            this.decodeBtn.Size = new System.Drawing.Size(130, 50);
            this.decodeBtn.TabIndex = 1;
            this.decodeBtn.Text = "Decode uploaded image";
            this.decodeBtn.UseVisualStyleBackColor = true;
            this.decodeBtn.Click += new System.EventHandler(this.decodeBtn_Click);
            // 
            // Stenographer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backgroundPnl);
            this.Controls.Add(this.imageLoaderPb);
            this.Name = "Stenographer";
            this.Text = "Sternographer";
            ((System.ComponentModel.ISupportInitialize)(this.imageLoaderPb)).EndInit();
            this.backgroundPnl.ResumeLayout(false);
            this.backgroundPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button imageUploadBtn;
        private System.Windows.Forms.PictureBox imageLoaderPb;
        private System.Windows.Forms.Panel backgroundPnl;
        private System.Windows.Forms.Button encodeBtn;
        private System.Windows.Forms.Button decodeBtn;
        private System.Windows.Forms.TextBox secretTextTbx;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Label outputLb;
    }
}

