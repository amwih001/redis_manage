namespace redis_manage.tabcontrol
{
    partial class frmList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmList));
            this.plRight = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.operation = new redis_manage.controls.Operation();
            this.kattr = new redis_manage.controls.KeyAttribute();
            this.plLeft = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.column_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.InsertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelHeadStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.RefToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelTailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageInfo = new redis_manage.controls.Pagination();
            this.plRight.SuspendLayout();
            this.panel1.SuspendLayout();
            this.plLeft.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.cmMenu.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.dgvList);
            this.groupBox1.Controls.Add(this.pageInfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 402);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_value});
            this.dgvList.ContextMenuStrip = this.cmMenu;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.GridColor = System.Drawing.SystemColors.Window;
            this.dgvList.Location = new System.Drawing.Point(3, 17);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(269, 343);
            this.dgvList.TabIndex = 3;
            this.dgvList.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvList_CellBeginEdit);
            this.dgvList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellEndEdit);
            // 
            // column_value
            // 
            this.column_value.HeaderText = "值";
            this.column_value.Name = "column_value";
            this.column_value.Width = 200;
            // 
            // cmMenu
            // 
            this.cmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DelHeadStripMenuItem1,
            this.RefToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.InsertToolStripMenuItem,
            this.DelTailToolStripMenuItem});
            this.cmMenu.Name = "cmMenuListView";
            this.cmMenu.Size = new System.Drawing.Size(153, 136);
            // 
            // InsertToolStripMenuItem
            // 
            this.InsertToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("InsertToolStripMenuItem.Image")));
            this.InsertToolStripMenuItem.Name = "InsertToolStripMenuItem";
            this.InsertToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.InsertToolStripMenuItem.Text = "添加(&A)";
            this.InsertToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // DelHeadStripMenuItem1
            // 
            this.DelHeadStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("DelHeadStripMenuItem1.Image")));
            this.DelHeadStripMenuItem1.Name = "DelHeadStripMenuItem1";
            this.DelHeadStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.DelHeadStripMenuItem1.Text = "删除头(&H)";
            this.DelHeadStripMenuItem1.Click += new System.EventHandler(this.DelHeadStripMenuItem1_Click);
            // 
            // RefToolStripMenuItem
            // 
            this.RefToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RefToolStripMenuItem.Image")));
            this.RefToolStripMenuItem.Name = "RefToolStripMenuItem";
            this.RefToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.RefToolStripMenuItem.Text = "刷新(&R)";
            this.RefToolStripMenuItem.Click += new System.EventHandler(this.RefToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("EditToolStripMenuItem.Image")));
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.EditToolStripMenuItem.Text = "编辑(&E)";
            this.EditToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // DelTailToolStripMenuItem
            // 
            this.DelTailToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DelTailToolStripMenuItem.Image")));
            this.DelTailToolStripMenuItem.Name = "DelTailToolStripMenuItem";
            this.DelTailToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DelTailToolStripMenuItem.Text = "删除尾(&D)";
            this.DelTailToolStripMenuItem.Click += new System.EventHandler(this.DelTailToolStripMenuItem_Click);
            // 
            // pageInfo
            // 
            this.pageInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageInfo.Location = new System.Drawing.Point(3, 360);
            this.pageInfo.Name = "pageInfo";
            this.pageInfo.PageIndex = 1;
            this.pageInfo.PageSize = 0;
            this.pageInfo.Size = new System.Drawing.Size(269, 39);
            this.pageInfo.TabIndex = 1;
            this.pageInfo.Total = 0;
            // 
            // frmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 422);
            this.Controls.Add(this.plRight);
            this.Controls.Add(this.plLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmList";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.TabText = "frmList";
            this.Text = "frmList";
            this.Load += new System.EventHandler(this.frmList_Load);
            this.plRight.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.plLeft.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.cmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        protected System.Windows.Forms.Panel plLeft;
        protected System.Windows.Forms.Panel plRight;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected controls.KeyAttribute kattr;
        #endregion
        private controls.Pagination pageInfo;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_value;
        private System.Windows.Forms.ContextMenuStrip cmMenu;
        private System.Windows.Forms.ToolStripMenuItem InsertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RefToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DelTailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DelHeadStripMenuItem1;
        private System.Windows.Forms.Panel panel1;
        private controls.Operation operation;
    }
}