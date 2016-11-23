namespace redis_manage.controls
{
    partial class XListView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("aaaaaa");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("aaaaaa");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("aaaaaa");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("aaaaaa");
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("aaaaaa");
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("aaaaaa");
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("aaaaaa");
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("aaaaaa");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XListView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvKeyList = new System.Windows.Forms.ListView();
            this.cmsListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsRefreshKeys = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRenameKey = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeleteKey = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSearchKey = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.cmsListView.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 442);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(823, 39);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblPageInfo);
            this.panel3.Controls.Add(this.btnPrevPage);
            this.panel3.Controls.Add(this.btnNextPage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(473, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 39);
            this.panel3.TabIndex = 0;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(31, 12);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(41, 12);
            this.lblPageInfo.TabIndex = 2;
            this.lblPageInfo.Text = "label1";
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Enabled = false;
            this.btnPrevPage.Location = new System.Drawing.Point(123, 7);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(75, 23);
            this.btnPrevPage.TabIndex = 1;
            this.btnPrevPage.Text = "<<";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Enabled = false;
            this.btnNextPage.Location = new System.Drawing.Point(244, 7);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(75, 23);
            this.btnNextPage.TabIndex = 0;
            this.btnNextPage.Text = ">>";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvKeyList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(823, 442);
            this.panel2.TabIndex = 1;
            // 
            // lvKeyList
            // 
            this.lvKeyList.ContextMenuStrip = this.cmsListView;
            this.lvKeyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvKeyList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvKeyList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16});
            this.lvKeyList.Location = new System.Drawing.Point(0, 0);
            this.lvKeyList.MultiSelect = false;
            this.lvKeyList.Name = "lvKeyList";
            this.lvKeyList.Size = new System.Drawing.Size(823, 442);
            this.lvKeyList.TabIndex = 0;
            this.lvKeyList.TileSize = new System.Drawing.Size(220, 30);
            this.lvKeyList.UseCompatibleStateImageBehavior = false;
            this.lvKeyList.View = System.Windows.Forms.View.Tile;
            this.lvKeyList.SelectedIndexChanged += new System.EventHandler(this.lvKeyList_SelectedIndexChanged);
            // 
            // cmsListView
            // 
            this.cmsListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsRefreshKeys,
            this.cmsRenameKey,
            this.cmsDeleteKey});
            this.cmsListView.Name = "cmsListView";
            this.cmsListView.Size = new System.Drawing.Size(117, 70);
            this.cmsListView.Opening += new System.ComponentModel.CancelEventHandler(this.cmsListView_Opening);
            // 
            // cmsRefreshKeys
            // 
            this.cmsRefreshKeys.Image = ((System.Drawing.Image)(resources.GetObject("cmsRefreshKeys.Image")));
            this.cmsRefreshKeys.Name = "cmsRefreshKeys";
            this.cmsRefreshKeys.Size = new System.Drawing.Size(116, 22);
            this.cmsRefreshKeys.Text = "刷新(&R)";
            this.cmsRefreshKeys.Click += new System.EventHandler(this.cmsRefreshKeys_Click);
            // 
            // cmsRenameKey
            // 
            this.cmsRenameKey.Image = ((System.Drawing.Image)(resources.GetObject("cmsRenameKey.Image")));
            this.cmsRenameKey.Name = "cmsRenameKey";
            this.cmsRenameKey.Size = new System.Drawing.Size(116, 22);
            this.cmsRenameKey.Text = "重命名";
            this.cmsRenameKey.Click += new System.EventHandler(this.cmsRenameKey_Click);
            // 
            // cmsDeleteKey
            // 
            this.cmsDeleteKey.Image = ((System.Drawing.Image)(resources.GetObject("cmsDeleteKey.Image")));
            this.cmsDeleteKey.Name = "cmsDeleteKey";
            this.cmsDeleteKey.Size = new System.Drawing.Size(116, 22);
            this.cmsDeleteKey.Text = "删除";
            this.cmsDeleteKey.Click += new System.EventHandler(this.cmsDeleteKey_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSearch);
            this.panel4.Controls.Add(this.txtSearchKey);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(473, 39);
            this.panel4.TabIndex = 1;
            // 
            // txtSearchKey
            // 
            this.txtSearchKey.Location = new System.Drawing.Point(11, 7);
            this.txtSearchKey.Name = "txtSearchKey";
            this.txtSearchKey.Size = new System.Drawing.Size(151, 21);
            this.txtSearchKey.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(171, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(77, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "搜索键值";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // XListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "XListView";
            this.Size = new System.Drawing.Size(823, 481);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.cmsListView.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvKeyList;
        private System.Windows.Forms.ContextMenuStrip cmsListView;
        private System.Windows.Forms.ToolStripMenuItem cmsRefreshKeys;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.ToolStripMenuItem cmsDeleteKey;
        private System.Windows.Forms.ToolStripMenuItem cmsRenameKey;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtSearchKey;
        private System.Windows.Forms.Button btnSearch;





    }
}
