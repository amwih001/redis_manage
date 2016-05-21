namespace redis_manage.controls
{
    partial class KeyAttribute
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDataType = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDataBaseId = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtKeyname = new System.Windows.Forms.TextBox();
            this.lblKeyName = new System.Windows.Forms.Label();
            this.lblSerializedlength = new System.Windows.Forms.Label();
            this.lblDataSize = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblEncoding = new System.Windows.Forms.Label();
            this.lblRefCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveLife = new System.Windows.Forms.Button();
            this.txtLifetime = new System.Windows.Forms.TextBox();
            this.lblLifetime = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDataType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblServerName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblDataBaseId);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtKeyname);
            this.groupBox1.Controls.Add(this.lblKeyName);
            this.groupBox1.Controls.Add(this.lblSerializedlength);
            this.groupBox1.Controls.Add(this.lblDataSize);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblEncoding);
            this.groupBox1.Controls.Add(this.lblRefCount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSaveLife);
            this.groupBox1.Controls.Add(this.txtLifetime);
            this.groupBox1.Controls.Add(this.lblLifetime);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 230);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "属性";
            // 
            // lblDataType
            // 
            this.lblDataType.AutoSize = true;
            this.lblDataType.Location = new System.Drawing.Point(79, 23);
            this.lblDataType.Name = "lblDataType";
            this.lblDataType.Size = new System.Drawing.Size(47, 12);
            this.lblDataType.TabIndex = 20;
            this.lblDataType.Text = "label10";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "数据类型:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "0时则是移除过期时间";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(81, 115);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(41, 12);
            this.lblServerName.TabIndex = 17;
            this.lblServerName.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "服务器:";
            // 
            // lblDataBaseId
            // 
            this.lblDataBaseId.AutoSize = true;
            this.lblDataBaseId.Location = new System.Drawing.Point(263, 115);
            this.lblDataBaseId.Name = "lblDataBaseId";
            this.lblDataBaseId.Size = new System.Drawing.Size(41, 12);
            this.lblDataBaseId.TabIndex = 15;
            this.lblDataBaseId.Text = "label3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(210, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "数据库:";
            // 
            // txtKeyname
            // 
            this.txtKeyname.BackColor = System.Drawing.SystemColors.Window;
            this.txtKeyname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKeyname.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKeyname.Location = new System.Drawing.Point(81, 50);
            this.txtKeyname.Multiline = true;
            this.txtKeyname.Name = "txtKeyname";
            this.txtKeyname.ReadOnly = true;
            this.txtKeyname.Size = new System.Drawing.Size(232, 14);
            this.txtKeyname.TabIndex = 12;
            this.txtKeyname.Click += new System.EventHandler(this.txtKeyname_Click);
            // 
            // lblKeyName
            // 
            this.lblKeyName.AutoSize = true;
            this.lblKeyName.Location = new System.Drawing.Point(18, 50);
            this.lblKeyName.Name = "lblKeyName";
            this.lblKeyName.Size = new System.Drawing.Size(59, 12);
            this.lblKeyName.TabIndex = 11;
            this.lblKeyName.Text = "复制键值:";
            this.lblKeyName.Click += new System.EventHandler(this.lblKeyName_Click);
            // 
            // lblSerializedlength
            // 
            this.lblSerializedlength.AutoSize = true;
            this.lblSerializedlength.Location = new System.Drawing.Point(263, 175);
            this.lblSerializedlength.Name = "lblSerializedlength";
            this.lblSerializedlength.Size = new System.Drawing.Size(41, 12);
            this.lblSerializedlength.TabIndex = 10;
            this.lblSerializedlength.Text = "label5";
            // 
            // lblDataSize
            // 
            this.lblDataSize.AutoSize = true;
            this.lblDataSize.Location = new System.Drawing.Point(81, 146);
            this.lblDataSize.Name = "lblDataSize";
            this.lblDataSize.Size = new System.Drawing.Size(41, 12);
            this.lblDataSize.TabIndex = 9;
            this.lblDataSize.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(200, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "占用内存:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "数据长度:";
            // 
            // lblEncoding
            // 
            this.lblEncoding.AutoSize = true;
            this.lblEncoding.Location = new System.Drawing.Point(81, 175);
            this.lblEncoding.Name = "lblEncoding";
            this.lblEncoding.Size = new System.Drawing.Size(41, 12);
            this.lblEncoding.TabIndex = 6;
            this.lblEncoding.Text = "label4";
            // 
            // lblRefCount
            // 
            this.lblRefCount.AutoSize = true;
            this.lblRefCount.Location = new System.Drawing.Point(263, 146);
            this.lblRefCount.Name = "lblRefCount";
            this.lblRefCount.Size = new System.Drawing.Size(41, 12);
            this.lblRefCount.TabIndex = 5;
            this.lblRefCount.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "编码格式:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "引用数量:";
            // 
            // btnSaveLife
            // 
            this.btnSaveLife.Location = new System.Drawing.Point(230, 73);
            this.btnSaveLife.Name = "btnSaveLife";
            this.btnSaveLife.Size = new System.Drawing.Size(75, 23);
            this.btnSaveLife.TabIndex = 2;
            this.btnSaveLife.Text = "设置";
            this.btnSaveLife.UseVisualStyleBackColor = true;
            this.btnSaveLife.Click += new System.EventHandler(this.btnSaveLife_Click);
            // 
            // txtLifetime
            // 
            this.txtLifetime.Location = new System.Drawing.Point(81, 76);
            this.txtLifetime.Name = "txtLifetime";
            this.txtLifetime.Size = new System.Drawing.Size(136, 21);
            this.txtLifetime.TabIndex = 1;
            // 
            // lblLifetime
            // 
            this.lblLifetime.AutoSize = true;
            this.lblLifetime.Location = new System.Drawing.Point(16, 84);
            this.lblLifetime.Name = "lblLifetime";
            this.lblLifetime.Size = new System.Drawing.Size(59, 12);
            this.lblLifetime.TabIndex = 0;
            this.lblLifetime.Text = "过期时间:";
            // 
            // KeyAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "KeyAttribute";
            this.Size = new System.Drawing.Size(390, 230);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveLife;
        private System.Windows.Forms.TextBox txtLifetime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLifetime;
        private System.Windows.Forms.Label lblEncoding;
        private System.Windows.Forms.Label lblRefCount;
        private System.Windows.Forms.Label lblSerializedlength;
        private System.Windows.Forms.Label lblDataSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblKeyName;
        private System.Windows.Forms.TextBox txtKeyname;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDataBaseId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDataType;
    }
}
