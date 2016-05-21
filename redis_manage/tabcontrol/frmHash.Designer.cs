namespace redis_manage.tabcontrol
{
    partial class frmHash
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHash));
            this.cmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RefToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plRight = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.operation = new redis_manage.controls.Operation();
            this.kattr = new redis_manage.controls.KeyAttribute();
            this.plLeft = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvHash = new System.Windows.Forms.DataGridView();
            this.column_field = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageInfo = new redis_manage.controls.Pagination();
            this.cmMenu.SuspendLayout();
            this.plRight.SuspendLayout();
            this.panel1.SuspendLayout();
            this.plLeft.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHash)).BeginInit();
            this.SuspendLayout();
            // 
            // cmMenu
            // 
            this.cmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.AddToolStripMenuItem,
            this.DelToolStripMenuItem});
            this.cmMenu.Name = "cmMenuListView";
            this.cmMenu.Size = new System.Drawing.Size(118, 92);
            // 
            // RefToolStripMenuItem
            // 
            this.RefToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RefToolStripMenuItem.Image")));
            this.RefToolStripMenuItem.Name = "RefToolStripMenuItem";
            this.RefToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.RefToolStripMenuItem.Text = "刷新(&R)";
            this.RefToolStripMenuItem.Click += new System.EventHandler(this.RefToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("EditToolStripMenuItem.Image")));
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.EditToolStripMenuItem.Text = "编辑(&E)";
            this.EditToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("AddToolStripMenuItem.Image")));
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.AddToolStripMenuItem.Text = "添加(&A)";
            this.AddToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // DelToolStripMenuItem
            // 
            this.DelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DelToolStripMenuItem.Image")));
            this.DelToolStripMenuItem.Name = "DelToolStripMenuItem";
            this.DelToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.DelToolStripMenuItem.Text = "删除(&D)";
            this.DelToolStripMenuItem.Click += new System.EventHandler(this.DelToolStripMenuItem_Click);
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
            this.panel1.TabIndex = 2;
            // 
            // operation
            // 
            this.operation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operation.Location = new System.Drawing.Point(0, 0);
            this.operation.Name = "operation";
            this.operation.ShowReLoadButton = true;
            this.operation.ShowRemoveButton = true;
            this.operation.ShowSaveButton = false;
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
            this.groupBox1.Controls.Add(this.dgvHash);
            this.groupBox1.Controls.Add(this.pageInfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 402);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据";
            // 
            // dgvHash
            // 
            this.dgvHash.AllowUserToAddRows = false;
            this.dgvHash.AllowUserToDeleteRows = false;
            this.dgvHash.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvHash.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_field,
            this.column_value});
            this.dgvHash.ContextMenuStrip = this.cmMenu;
            this.dgvHash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHash.GridColor = System.Drawing.SystemColors.Window;
            this.dgvHash.Location = new System.Drawing.Point(3, 17);
            this.dgvHash.MultiSelect = false;
            this.dgvHash.Name = "dgvHash";
            this.dgvHash.RowTemplate.Height = 23;
            this.dgvHash.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHash.Size = new System.Drawing.Size(269, 343);
            this.dgvHash.TabIndex = 1;
            this.dgvHash.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvHash_CellBeginEdit);
            this.dgvHash.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHash_CellEndEdit);
            // 
            // column_field
            // 
            this.column_field.HeaderText = "域";
            this.column_field.Name = "column_field";
            this.column_field.ReadOnly = true;
            // 
            // column_value
            // 
            this.column_value.HeaderText = "值";
            this.column_value.Name = "column_value";
            // 
            // pageInfo
            // 
            this.pageInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageInfo.Location = new System.Drawing.Point(3, 360);
            this.pageInfo.Name = "pageInfo";
            this.pageInfo.PageIndex = 1;
            this.pageInfo.PageSize = 0;
            this.pageInfo.Size = new System.Drawing.Size(269, 39);
            this.pageInfo.TabIndex = 0;
            this.pageInfo.Total = 0;
            // 
            // frmHash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 422);
            this.Controls.Add(this.plRight);
            this.Controls.Add(this.plLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHash";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.TabText = "frmHash";
            this.Text = "frmHash";
            this.Load += new System.EventHandler(this.frmHash_Load);
            this.cmMenu.ResumeLayout(false);
            this.plRight.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.plLeft.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHash)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel plLeft;
        private System.Windows.Forms.Panel plRight;
        private System.Windows.Forms.GroupBox groupBox1;
        private controls.KeyAttribute kattr;
        #endregion

        private controls.Pagination pageInfo;
        private System.Windows.Forms.ContextMenuStrip cmMenu;
        private System.Windows.Forms.ToolStripMenuItem DelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RefToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvHash;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_field;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_value;
        private System.Windows.Forms.Panel panel1;
        private controls.Operation operation;
    }
}