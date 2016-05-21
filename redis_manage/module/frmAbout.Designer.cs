namespace redis_manage.module
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblAppVs = new System.Windows.Forms.Label();
            this.linkUpgrade = new System.Windows.Forms.LinkLabel();
            this.linkBlogHome = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(316, 120);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "确定(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 120);
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppName.Location = new System.Drawing.Point(172, 23);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(82, 22);
            this.lblAppName.TabIndex = 38;
            this.lblAppName.Text = "label1";
            // 
            // lblAppVs
            // 
            this.lblAppVs.AutoSize = true;
            this.lblAppVs.Location = new System.Drawing.Point(174, 63);
            this.lblAppVs.Name = "lblAppVs";
            this.lblAppVs.Size = new System.Drawing.Size(41, 12);
            this.lblAppVs.TabIndex = 39;
            this.lblAppVs.Text = "label2";
            // 
            // linkUpgrade
            // 
            this.linkUpgrade.AutoSize = true;
            this.linkUpgrade.Location = new System.Drawing.Point(174, 101);
            this.linkUpgrade.Name = "linkUpgrade";
            this.linkUpgrade.Size = new System.Drawing.Size(53, 12);
            this.linkUpgrade.TabIndex = 40;
            this.linkUpgrade.TabStop = true;
            this.linkUpgrade.Text = "检查更新";
            this.linkUpgrade.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUpgrade_LinkClicked);
            // 
            // linkBlogHome
            // 
            this.linkBlogHome.AutoSize = true;
            this.linkBlogHome.Location = new System.Drawing.Point(259, 101);
            this.linkBlogHome.Name = "linkBlogHome";
            this.linkBlogHome.Size = new System.Drawing.Size(53, 12);
            this.linkBlogHome.TabIndex = 41;
            this.linkBlogHome.TabStop = true;
            this.linkBlogHome.Text = "博客信息";
            this.linkBlogHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBlogHome_LinkClicked);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 162);
            this.Controls.Add(this.linkBlogHome);
            this.Controls.Add(this.linkUpgrade);
            this.Controls.Add(this.lblAppVs);
            this.Controls.Add(this.lblAppName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSave);
            this.Name = "frmAbout";
            this.Text = "关于";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblAppVs;
        private System.Windows.Forms.LinkLabel linkUpgrade;
        private System.Windows.Forms.LinkLabel linkBlogHome;
    }
}