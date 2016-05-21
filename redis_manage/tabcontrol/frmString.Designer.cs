namespace redis_manage.tabcontrol
{
    partial class frmString
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmString));
            this.plRight = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.operation = new redis_manage.controls.Operation();
            this.kattr = new redis_manage.controls.KeyAttribute();
            this.plLeft = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbValue = new System.Windows.Forms.RichTextBox();
            this.plRight.SuspendLayout();
            this.panel1.SuspendLayout();
            this.plLeft.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plRight
            // 
            this.plRight.Controls.Add(this.panel1);
            this.plRight.Controls.Add(this.kattr);
            this.plRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plRight.Location = new System.Drawing.Point(295, 10);
            this.plRight.Name = "plRight";
            this.plRight.Size = new System.Drawing.Size(439, 402);
            this.plRight.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.operation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 357);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 45);
            this.panel1.TabIndex = 1;
            // 
            // operation
            // 
            this.operation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operation.Location = new System.Drawing.Point(0, 0);
            this.operation.Name = "operation";
            this.operation.ShowReLoadButton = true;
            this.operation.ShowRemoveButton = true;
            this.operation.ShowSaveButton = true;
            this.operation.Size = new System.Drawing.Size(439, 45);
            this.operation.TabIndex = 0;
            this.operation.Operation_Click += new redis_manage.controls.Operation.OnOperation_Click(this.operation_Operation_Click);
            // 
            // kattr
            // 
            this.kattr.Count = ((long)(0));
            this.kattr.Debug = null;
            this.kattr.Dock = System.Windows.Forms.DockStyle.Top;
            this.kattr.Location = new System.Drawing.Point(0, 0);
            this.kattr.Name = "kattr";
            this.kattr.ParentControl = null;
            this.kattr.Size = new System.Drawing.Size(439, 202);
            this.kattr.TabIndex = 0;
            // 
            // plLeft
            // 
            this.plLeft.Controls.Add(this.groupBox1);
            this.plLeft.Cursor = System.Windows.Forms.Cursors.Default;
            this.plLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.plLeft.Location = new System.Drawing.Point(10, 10);
            this.plLeft.Name = "plLeft";
            this.plLeft.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.plLeft.Size = new System.Drawing.Size(285, 402);
            this.plLeft.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbValue);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 402);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据";
            // 
            // rtbValue
            // 
            this.rtbValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbValue.Location = new System.Drawing.Point(3, 17);
            this.rtbValue.Name = "rtbValue";
            this.rtbValue.Size = new System.Drawing.Size(269, 382);
            this.rtbValue.TabIndex = 0;
            this.rtbValue.Text = "";
            // 
            // frmString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 422);
            this.Controls.Add(this.plRight);
            this.Controls.Add(this.plLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmString";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.TabText = "frmString";
            this.Text = "frmString";
            this.Load += new System.EventHandler(this.frmString_Load);
            this.plRight.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.plLeft.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plLeft;
        private System.Windows.Forms.Panel plRight;
        private System.Windows.Forms.RichTextBox rtbValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private controls.KeyAttribute kattr;
        private System.Windows.Forms.Panel panel1;
        private controls.Operation operation;

    }
}