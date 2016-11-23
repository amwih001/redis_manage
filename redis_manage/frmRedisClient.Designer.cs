namespace redis_manage
{
    partial class frmRedisClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRedisClient));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Add_ServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Exit_ServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OperaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BlogHomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FeedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.cmServerNodeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.UpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.AttributeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.spcRightContent = new System.Windows.Forms.SplitContainer();
            this.dpTabControl = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.tvServers = new redis_manage.controls.XTreeView();
            this.lvPagePanel = new redis_manage.controls.XListView();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.cmServerNodeMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcRightContent)).BeginInit();
            this.spcRightContent.Panel1.SuspendLayout();
            this.spcRightContent.Panel2.SuspendLayout();
            this.spcRightContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ServerToolStripMenuItem,
            this.OperaToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(927, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ServerToolStripMenuItem
            // 
            this.ServerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Add_ServerToolStripMenuItem,
            this.toolStripSeparator1,
            this.Exit_ServerToolStripMenuItem});
            this.ServerToolStripMenuItem.Name = "ServerToolStripMenuItem";
            this.ServerToolStripMenuItem.Size = new System.Drawing.Size(71, 21);
            this.ServerToolStripMenuItem.Text = "服务器(&S)";
            // 
            // Add_ServerToolStripMenuItem
            // 
            this.Add_ServerToolStripMenuItem.Name = "Add_ServerToolStripMenuItem";
            this.Add_ServerToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.Add_ServerToolStripMenuItem.Text = "添加(&A)";
            this.Add_ServerToolStripMenuItem.Click += new System.EventHandler(this.Add_ServerToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // Exit_ServerToolStripMenuItem
            // 
            this.Exit_ServerToolStripMenuItem.Name = "Exit_ServerToolStripMenuItem";
            this.Exit_ServerToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.Exit_ServerToolStripMenuItem.Text = "退出(&E)";
            this.Exit_ServerToolStripMenuItem.Click += new System.EventHandler(this.Exit_ServerToolStripMenuItem_Click);
            // 
            // OperaToolStripMenuItem
            // 
            this.OperaToolStripMenuItem.Name = "OperaToolStripMenuItem";
            this.OperaToolStripMenuItem.Size = new System.Drawing.Size(62, 21);
            this.OperaToolStripMenuItem.Text = "选项(&O)";
            this.OperaToolStripMenuItem.Visible = false;
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateHistoryToolStripMenuItem,
            this.BlogHomeToolStripMenuItem,
            this.FeedbackToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.HelpToolStripMenuItem.Text = "帮助(&H)";
            // 
            // UpdateHistoryToolStripMenuItem
            // 
            this.UpdateHistoryToolStripMenuItem.Name = "UpdateHistoryToolStripMenuItem";
            this.UpdateHistoryToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.UpdateHistoryToolStripMenuItem.Text = "更新历史(&U)";
            this.UpdateHistoryToolStripMenuItem.Click += new System.EventHandler(this.UpdateHistoryToolStripMenuItem_Click);
            // 
            // BlogHomeToolStripMenuItem
            // 
            this.BlogHomeToolStripMenuItem.Name = "BlogHomeToolStripMenuItem";
            this.BlogHomeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.BlogHomeToolStripMenuItem.Text = "博客首页(&B)";
            this.BlogHomeToolStripMenuItem.Click += new System.EventHandler(this.BlogHomeToolStripMenuItem_Click);
            // 
            // FeedbackToolStripMenuItem
            // 
            this.FeedbackToolStripMenuItem.Name = "FeedbackToolStripMenuItem";
            this.FeedbackToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.FeedbackToolStripMenuItem.Text = "反馈信息(&F)";
            this.FeedbackToolStripMenuItem.Click += new System.EventHandler(this.FeedbackToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.AboutToolStripMenuItem.Text = "关于(&A)";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 463);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(927, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Visible = false;
            // 
            // spcMain
            // 
            this.spcMain.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 25);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.spcMain.Panel1.Controls.Add(this.tvServers);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.spcMain.Panel2.Controls.Add(this.spcRightContent);
            this.spcMain.Size = new System.Drawing.Size(927, 438);
            this.spcMain.SplitterDistance = 148;
            this.spcMain.SplitterWidth = 2;
            this.spcMain.TabIndex = 2;
            // 
            // cmServerNodeMenu
            // 
            this.cmServerNodeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.CloseToolStripMenuItem,
            this.toolStripSeparator3,
            this.UpdateToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.toolStripSeparator4,
            this.AttributeToolStripMenuItem});
            this.cmServerNodeMenu.Name = "cmServerNodeMenu";
            this.cmServerNodeMenu.Size = new System.Drawing.Size(119, 148);
            this.cmServerNodeMenu.Tag = "2";
            this.cmServerNodeMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmServerNodeMenu_Opening);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.RefreshToolStripMenuItem.Tag = "1";
            this.RefreshToolStripMenuItem.Text = "刷新(&R)";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.OpenToolStripMenuItem.Tag = "2";
            this.OpenToolStripMenuItem.Text = "打开(&O)";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.CloseToolStripMenuItem.Tag = "2";
            this.CloseToolStripMenuItem.Text = "关闭(&C)";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(115, 6);
            this.toolStripSeparator3.Tag = "";
            // 
            // UpdateToolStripMenuItem
            // 
            this.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem";
            this.UpdateToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.UpdateToolStripMenuItem.Tag = "2";
            this.UpdateToolStripMenuItem.Text = "修改(&U)";
            this.UpdateToolStripMenuItem.Click += new System.EventHandler(this.UpdateToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.DeleteToolStripMenuItem.Tag = "2";
            this.DeleteToolStripMenuItem.Text = "移除(&D)";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(115, 6);
            this.toolStripSeparator4.Tag = "1";
            // 
            // AttributeToolStripMenuItem
            // 
            this.AttributeToolStripMenuItem.Name = "AttributeToolStripMenuItem";
            this.AttributeToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.AttributeToolStripMenuItem.Tag = "1";
            this.AttributeToolStripMenuItem.Text = "属性(A)";
            this.AttributeToolStripMenuItem.Click += new System.EventHandler(this.AttributeToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "desktop.png");
            this.imageList.Images.SetKeyName(1, "redis_big_icon.png");
            this.imageList.Images.SetKeyName(2, "db.png");
            this.imageList.Images.SetKeyName(3, "namespace.png");
            this.imageList.Images.SetKeyName(4, "key.png");
            // 
            // spcRightContent
            // 
            this.spcRightContent.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.spcRightContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcRightContent.Location = new System.Drawing.Point(0, 0);
            this.spcRightContent.Name = "spcRightContent";
            this.spcRightContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcRightContent.Panel1
            // 
            this.spcRightContent.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.spcRightContent.Panel1.Controls.Add(this.lvPagePanel);
            // 
            // spcRightContent.Panel2
            // 
            this.spcRightContent.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.spcRightContent.Panel2.Controls.Add(this.dpTabControl);
            this.spcRightContent.Size = new System.Drawing.Size(777, 438);
            this.spcRightContent.SplitterDistance = 237;
            this.spcRightContent.SplitterWidth = 2;
            this.spcRightContent.TabIndex = 0;
            // 
            // dpTabControl
            // 
            this.dpTabControl.ActiveAutoHideContent = null;
            this.dpTabControl.BackColor = System.Drawing.SystemColors.Window;
            this.dpTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpTabControl.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingSdi;
            this.dpTabControl.Location = new System.Drawing.Point(0, 0);
            this.dpTabControl.Name = "dpTabControl";
            this.dpTabControl.Size = new System.Drawing.Size(777, 199);
            this.dpTabControl.TabIndex = 2;
            // 
            // tvServers
            // 
            this.tvServers.ContextMenuStrip = this.cmServerNodeMenu;
            this.tvServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvServers.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvServers.ImageIndex = 0;
            this.tvServers.ImageList = this.imageList;
            this.tvServers.ItemHeight = 22;
            this.tvServers.Location = new System.Drawing.Point(0, 0);
            this.tvServers.Name = "tvServers";
            this.tvServers.SelectedImageIndex = 0;
            this.tvServers.Size = new System.Drawing.Size(148, 438);
            this.tvServers.TabIndex = 1;
            // 
            // lvPagePanel
            // 
            this.lvPagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPagePanel.Location = new System.Drawing.Point(0, 0);
            this.lvPagePanel.Name = "lvPagePanel";
            this.lvPagePanel.Size = new System.Drawing.Size(777, 237);
            this.lvPagePanel.TabIndex = 0;
            // 
            // frmRedisClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 485);
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmRedisClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RedisManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRedisClient_FormClosed);
            this.Load += new System.EventHandler(this.frmRedisClient_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.cmServerNodeMenu.ResumeLayout(false);
            this.spcRightContent.Panel1.ResumeLayout(false);
            this.spcRightContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcRightContent)).EndInit();
            this.spcRightContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem ServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.SplitContainer spcRightContent;
        private controls.XTreeView tvServers;
        public WeifenLuo.WinFormsUI.Docking.DockPanel dpTabControl;
        private System.Windows.Forms.ImageList imageList;
        public controls.XListView lvPagePanel;
        private System.Windows.Forms.ToolStripMenuItem Add_ServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Exit_ServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OperaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmServerNodeMenu;
        private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem UpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem AttributeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BlogHomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FeedbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
    }
}