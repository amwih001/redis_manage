namespace redis_manage.module
{
    partial class frmWinPatch
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.linkShowMsHelp = new System.Windows.Forms.LinkLabel();
            this.btnShowDoanLoad32 = new System.Windows.Forms.Button();
            this.btnShowDoanLoad64 = new System.Windows.Forms.Button();
            this.lblMyPcBit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox1.Location = new System.Drawing.Point(14, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(427, 87);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "您的.Net Framework缺少关键性的更新。请安装 Microsoft .NET Framework 4 KB2468871 更新。您需要下载并安装此补丁(" +
                "安装完成需要重启本软件)才能正常使用！";
            // 
            // linkShowMsHelp
            // 
            this.linkShowMsHelp.AutoSize = true;
            this.linkShowMsHelp.Location = new System.Drawing.Point(14, 112);
            this.linkShowMsHelp.Name = "linkShowMsHelp";
            this.linkShowMsHelp.Size = new System.Drawing.Size(113, 12);
            this.linkShowMsHelp.TabIndex = 2;
            this.linkShowMsHelp.TabStop = true;
            this.linkShowMsHelp.Text = "Microsoft 官方说明";
            this.linkShowMsHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkShowMsHelp_LinkClicked);
            // 
            // btnShowDoanLoad32
            // 
            this.btnShowDoanLoad32.Location = new System.Drawing.Point(16, 148);
            this.btnShowDoanLoad32.Name = "btnShowDoanLoad32";
            this.btnShowDoanLoad32.Size = new System.Drawing.Size(151, 41);
            this.btnShowDoanLoad32.TabIndex = 3;
            this.btnShowDoanLoad32.Text = "下载地址(32位系统)";
            this.btnShowDoanLoad32.UseVisualStyleBackColor = true;
            this.btnShowDoanLoad32.Click += new System.EventHandler(this.btnShowDoanLoad32_Click);
            // 
            // btnShowDoanLoad64
            // 
            this.btnShowDoanLoad64.Location = new System.Drawing.Point(277, 148);
            this.btnShowDoanLoad64.Name = "btnShowDoanLoad64";
            this.btnShowDoanLoad64.Size = new System.Drawing.Size(151, 41);
            this.btnShowDoanLoad64.TabIndex = 4;
            this.btnShowDoanLoad64.Text = "下载地址(64位系统)";
            this.btnShowDoanLoad64.UseVisualStyleBackColor = true;
            this.btnShowDoanLoad64.Click += new System.EventHandler(this.btnShowDoanLoad64_Click);
            // 
            // lblMyPcBit
            // 
            this.lblMyPcBit.AutoSize = true;
            this.lblMyPcBit.Location = new System.Drawing.Point(303, 112);
            this.lblMyPcBit.Name = "lblMyPcBit";
            this.lblMyPcBit.Size = new System.Drawing.Size(131, 12);
            this.lblMyPcBit.TabIndex = 5;
            this.lblMyPcBit.Text = "检测到本机是{0}位系统";
            // 
            // frmWinPatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 201);
            this.Controls.Add(this.lblMyPcBit);
            this.Controls.Add(this.btnShowDoanLoad64);
            this.Controls.Add(this.btnShowDoanLoad32);
            this.Controls.Add(this.linkShowMsHelp);
            this.Controls.Add(this.richTextBox1);
            this.Name = "frmWinPatch";
            this.Text = "Microsoft .NET Framework 4 KB2468871补丁下载";
            this.Load += new System.EventHandler(this.frmWinPatch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.LinkLabel linkShowMsHelp;
        private System.Windows.Forms.Button btnShowDoanLoad32;
        private System.Windows.Forms.Button btnShowDoanLoad64;
        private System.Windows.Forms.Label lblMyPcBit;
    }
}