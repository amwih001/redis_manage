using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using redis_manage.controls;
using redis_manage.info;
using redis_manage.tabcontrol;
using WeifenLuo.WinFormsUI.Docking;
using Hibernate.Util;
using redis_manage.lib;
using redis_manage.tools;
using redis_manage.module;

namespace redis_manage
{
    public partial class frmRedisClient : Form
    {
        public frmRedisClient()
        {
            InitializeComponent();
        }

        private void frmRedisClient_Load(object sender, EventArgs e)
        {
            this.InitControls();
            this.InitEvents();
            Cawd.Create().View();
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControls()
        {
            this.lvPagePanel.frmRedis = this;
            this.tvServers.OnLoad();
            this.lvPagePanel.OnLoad();
        }
        /// <summary>
        /// 当前服务器
        /// </summary>
        public ServerInfo Server
        {
            get { return this.tvServers.CurrentServer; }
        }
        /// <summary>
        /// 当前数据库
        /// </summary>
        public int DB
        {
            get { return this.tvServers.CurrentDataBase; }
        }

        private void InitEvents()
        {
            this.tvServers.OnDataBaseChange += new controls.XTreeView.DataBaseChange(tvServers_OnDataBaseChange);
            this.tvServers.OnKeyFolderChange += new XTreeView.KeyFolderChange(tvServers_OnKeyFolderChange);
        }

        /// <summary>
        /// key包改变时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="databaseid"></param>
        void tvServers_OnKeyFolderChange(XTreeNode sender, int databaseid)
        {
            this.lvPagePanel.OnKeyFolderChange(sender, databaseid);
        }

        /// <summary>
        /// 数据库改变时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="databaseid"></param>
        void tvServers_OnDataBaseChange(XTreeNode sender, int databaseid, string pattern)
        {
            this.lvPagePanel.OnDataBaseChange(sender, databaseid, pattern);
            //当点击的不是key包时才去加载key包到treeview
            if (pattern == null)
            {
                sender.RefreshFolder(this.lvPagePanel.Keyslist.KeyFolder, false);
            }
        }

        public void ShowKeyDetail(string contentkey, KeyInfo keyinfo)
        {
            IDockContent idc = this.FindDocument(contentkey);
            
            Redis redis = new Redis(this.Server, this.DB);

            if (redis.Exists(keyinfo.Text) == false)
            {
                if (idc != null && idc.DockHandler != null)
                {
                    idc.DockHandler.Close();
                }
                Tip.Show(string.Format("键值[{0}]已过期,请右键刷新列表获取最新key列表" , keyinfo.Text));
                return;
            }
            DataType dt = redis.Type(keyinfo.Text);

            if (idc == null)
            {
                TabBase tab = null;

                switch (dt)
                { 
                    case DataType.String:
                        tab = new frmString();
                        break;
                    case DataType.Hash:
                        tab = new frmHash();
                        break;
                    case DataType.List:
                        tab = new frmList();
                        break;
                    case DataType.Set:
                        tab = new frmSet();
                        break;
                    case DataType.Zset:
                        tab = new frmZset();
                        break;
                }

                if (tab == null)
                {
                    throw new Exception("未知的数据类型或获取数据类型失败");
                }
                tab.ParentWidth = spcRightContent.Width;
                tab.SetParams(contentkey, keyinfo, dt, this);
                tab.BeforeShowValue();
                tab.Show(this.dpTabControl);
                tab.DockTo(this.dpTabControl, DockStyle.None);

                tab.InitValue();
            }
            else
            {
                idc.DockHandler.Activate();
            }
        }

        /// <summary>
        /// 根据key唯一值关闭已有窗体
        /// </summary>
        /// <param name="contentkey"></param>
        public void CloseDocument(string contentkey)
        {
            IDockContent idc = this.FindDocument(contentkey);
            if (idc != null && idc.DockHandler != null)
            {
                idc.DockHandler.Close();
            }
        }

        ///<summary>
        /// 在dockPanel中查找已经打开的窗口
        /// </summary>
        /// <param name="text">传入的窗口标识符</param>
        /// <returns>返回的窗口</returns>
        private IDockContent FindDocument(string text)
        {
            if (this.dpTabControl.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    if (Tools.ToString(form.Tag) == text)
                        return form as IDockContent;
                return null;
            }
            else
            {
                foreach (DockContent content in this.dpTabControl.Documents)
                    if (Tools.ToString(content.Tag) == text)
                        return content;
                return null;
            }
        }

        private void CloseDocuments(string contentkey, int optype)
        {
            if (this.dpTabControl.DocumentStyle == DocumentStyle.SystemMdi)
            {
                List<Form> list = new List<Form>();
                foreach (Form form in MdiChildren)
                {
                    if ((optype == 1 && Tools.ToString(form.Tag) == contentkey) ||
                        optype == 2 && Tools.ToString(form.Tag).Contains(contentkey))
                    {
                        list.Add(form);
                    }
                }
                foreach (Form item in list)
                {
                    item.Close();
                }
            }
            else
            {
                List<DockContent> list = new List<DockContent>();
                foreach (DockContent content in this.dpTabControl.Documents)
                {
                    if ((optype == 1 && Tools.ToString(content.Tag) == contentkey) || 
                        optype == 2 && Tools.ToString(content.Tag).Contains(contentkey))
                    {
                        list.Add(content);
                    }
                }
                foreach (DockContent item in list)
                {
                    item.DockHandler.Close();
                }
            }
        }

        /// <summary>
        /// 退出菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_ServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int c = this.dpTabControl.Documents.Count();
                for (int i = 0; i < c; i++)
                {
                    this.dpTabControl.Documents.ElementAt(i).DockHandler.Close();
                }
            }
            catch (Exception ex)
            { 
                
            }
            Application.Exit();
        }
        /// <summary>
        /// 添加服务器菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_ServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddServer addserver = new frmAddServer();
            addserver.InsertSuccess += new frmAddServer.OnInsertSuccess(addserver_InsertSuccess);
            addserver.ShowDialog();
        }

        private void addserver_InsertSuccess(ServerInfo serverinfo)
        {
            this.tvServers.InsertServerNode(serverinfo);
        }

        /// <summary>
        /// 右键菜单正要打开时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmServerNodeMenu_Opening(object sender, CancelEventArgs e)
        {
            bool isshow = tvServers.IsShowNodeMenu;
            e.Cancel = !isshow;
            if (isshow && tvServers.SelectedNode is XTreeNode)
            {
                XTreeNode xtn = this.tvServers.SelectedNode as XTreeNode;
                int flag = xtn.NodeType == TreeNodeType.Server ? 2 : 1;
                foreach (ToolStripItem item in cmServerNodeMenu.Items)
                {
                    int tag = Tools.ToInt(item.Tag);
                    if (tag > 0)
                    {
                        item.Enabled = flag >= tag;
                    }
                }
            }
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNodeType nodetype = this.tvServers.SelectedNodeType;
            if (nodetype == TreeNodeType.Server)
            {
                this.tvServers.OnRefresh();
            }
            else if (nodetype == TreeNodeType.DataBase)
            {
                this.lvPagePanel.OnRefresh();
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tvServers.OpenServer();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tvServers.CloseServer() && this.tvServers.SelectedNode is XTreeNode)
            {
                XTreeNode xtn = this.tvServers.SelectedNode as XTreeNode;
                this.lvPagePanel.ClearByServer(xtn.Server);
                this.CloseDocuments(TextConvert.GetContentKeyPrefix(xtn.Server.ServerName) , 2);
            }
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tvServers.SelectedNodeType == TreeNodeType.Server && this.tvServers.SelectedNode is XTreeNode)
            {
                XTreeNode xtn = this.tvServers.SelectedNode as XTreeNode;
                if (xtn.DataBaseComplete)
                {
                    if (Tip.ShowOKCancel("当前服务器链接已打开,确定先关闭链接?", "提示") != DialogResult.OK)
                    {
                        return;
                    }
                    //先关闭链接
                    this.CloseToolStripMenuItem_Click(sender, e);
                }
                if (!xtn.DataBaseComplete)
                {
                    frmModifyServer modifyserver = new frmModifyServer(xtn.Server);
                    modifyserver.ShowDialog();
                }
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tvServers.DeleteServer();
        }

        private void AttributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XTreeNode xtn = this.tvServers.SelectedNode as XTreeNode;
            if (xtn == null)
            {
                return;
            }
            if (xtn.NodeType == TreeNodeType.DataBase)
            {
                frmServerAttr frm = new frmServerAttr(xtn.Server, 2);
                frm.DB = xtn.DB_Id;
                frm.ShowDialog();
            }
            else if (xtn.NodeType == TreeNodeType.Server)
            {
                if (!xtn.DataBaseComplete)
                {
                    Tip.Show("请先打开服务器链接");
                    return;
                }
                frmServerAttr frm = new frmServerAttr(xtn.Server , 1);
                frm.ShowDialog();
            }
        }

        private void UpdateHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.OpenWebPage(Define.VsHistory);
        }

        private void BlogHomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.OpenWebPage(Define.BlogHome);
        }

        private void FeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFeedback feedback = new frmFeedback();
            feedback.ShowDialog();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }
    }
}
