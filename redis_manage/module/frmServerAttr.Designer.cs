namespace redis_manage.module
{
    partial class frmServerAttr
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblServerHost = new System.Windows.Forms.Label();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDBCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblKeyCount = new System.Windows.Forms.Label();
            this.lblRedisVs = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(131, 229);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "确定(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "服务器端口:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "服务器主机:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "服务器名称:";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(151, 32);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(41, 12);
            this.lblServerName.TabIndex = 19;
            this.lblServerName.Text = "label4";
            // 
            // lblServerHost
            // 
            this.lblServerHost.AutoSize = true;
            this.lblServerHost.Location = new System.Drawing.Point(151, 66);
            this.lblServerHost.Name = "lblServerHost";
            this.lblServerHost.Size = new System.Drawing.Size(41, 12);
            this.lblServerHost.TabIndex = 20;
            this.lblServerHost.Text = "label4";
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Location = new System.Drawing.Point(151, 100);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(41, 12);
            this.lblServerPort.TabIndex = 21;
            this.lblServerPort.Text = "label4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "数据库数量:";
            // 
            // lblDBCount
            // 
            this.lblDBCount.AutoSize = true;
            this.lblDBCount.Location = new System.Drawing.Point(151, 162);
            this.lblDBCount.Name = "lblDBCount";
            this.lblDBCount.Size = new System.Drawing.Size(41, 12);
            this.lblDBCount.TabIndex = 23;
            this.lblDBCount.Text = "label5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "键值总数量:";
            // 
            // lblKeyCount
            // 
            this.lblKeyCount.AutoSize = true;
            this.lblKeyCount.Location = new System.Drawing.Point(151, 193);
            this.lblKeyCount.Name = "lblKeyCount";
            this.lblKeyCount.Size = new System.Drawing.Size(41, 12);
            this.lblKeyCount.TabIndex = 25;
            this.lblKeyCount.Text = "label5";
            // 
            // lblRedisVs
            // 
            this.lblRedisVs.AutoSize = true;
            this.lblRedisVs.Location = new System.Drawing.Point(151, 130);
            this.lblRedisVs.Name = "lblRedisVs";
            this.lblRedisVs.Size = new System.Drawing.Size(41, 12);
            this.lblRedisVs.TabIndex = 27;
            this.lblRedisVs.Text = "2.1.18";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "服务器版本:";
            // 
            // frmServerAttr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 273);
            this.Controls.Add(this.lblRedisVs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblKeyCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblDBCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblServerPort);
            this.Controls.Add(this.lblServerHost);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmServerAttr";
            this.Text = "服务器属性";
            this.Load += new System.EventHandler(this.frmServerAttr_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblServerHost;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDBCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblKeyCount;
        private System.Windows.Forms.Label lblRedisVs;
        private System.Windows.Forms.Label label7;
    }
}