using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using redis_manage.info;
using redis_manage.lib;
using redis_manage.tools;

namespace redis_manage.controls
{
    public class XTreeView : TreeView, IControl
    {

        public delegate void DataBaseChange(XTreeNode sender, int databaseid, string pattern);
        public event DataBaseChange OnDataBaseChange;

        public delegate void KeyFolderChange(XTreeNode sender, int databaseid);
        public event KeyFolderChange OnKeyFolderChange;

        public ServerInfo CurrentServer;
        public int CurrentDataBase = -1;

        private string lastdbInServerName;
        private FolderInfo lastfolder;

        private TreeNodeType lastselecttype;

        public XTreeView()
            : base()
        {
            lastselecttype = TreeNodeType.Top;
        }

        public void OnLoad()
        {
            XTreeNode xtn = new XTreeNode("Redis服务器列表");
            xtn.NodeType = TreeNodeType.Top;
            xtn.Name = "xtnRedisParenterNode";
            this.Nodes.Add(xtn);
            List<ServerInfo> serverlist = ServerManager.Create().GetServers();
            if (serverlist != null && serverlist.Count > 0)
            {
                foreach (ServerInfo serverinfo in serverlist)
                {
                    this.InsertServerNode(serverinfo);
                }
            }
            this.NodeMouseClick += new TreeNodeMouseClickEventHandler(XTreeView_NodeMouseClick);
            this.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(XTreeView_NodeMouseDoubleClick);

            this.MouseDown += new MouseEventHandler(XTreeView_MouseDown);
        }
        /// <summary>
        ///  treeview 右键选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//判断你点的是不是右键
            {
                System.Drawing.Point ClickPoint = new System.Drawing.Point(e.X, e.Y);
                TreeNode CurrentNode = this.GetNodeAt(ClickPoint);
                if (CurrentNode != null)//判断你点的是不是一个节点
                {
                    //switch (CurrentNode.Name)//根据不同节点显示不同的右键菜单，当然你可以让它显示一样的菜单
                    //{
                    //    case "errorUrl":
                    //        CurrentNode.ContextMenuStrip = contextMenuStripErrorUrl;
                    //        break;
                    //}
                    this.SelectedNode = CurrentNode;//选中这个节点
                }
            }
        }

        public void OnActive()
        {
            
        }

        public void OnRefresh()
        {
            XTreeNode xtn = this.SelectedNode as XTreeNode;
            if (xtn != null)
            {
                xtn.DataBaseComplete = false;
                this.SelectServerNode(xtn);
            }
        }

        public TreeNodeType SelectedNodeType
        {
            get
            {
                XTreeNode xtn = this.SelectedNode as XTreeNode;
                if (xtn == null)
                {
                    return TreeNodeType.Top;
                }
                return xtn.NodeType;
            }
        }

        /// <summary>
        /// 添加一个服务器节点
        /// </summary>
        /// <param name="serverinfo"></param>
        public void InsertServerNode(ServerInfo serverinfo)
        {
            if (this.Nodes.Count > 0 && this.Nodes[0] is XTreeNode && serverinfo != null)
            {
                XTreeNode xtn = this.Nodes[0] as XTreeNode;
                XTreeNode xtn_child = null;
                xtn_child = new XTreeNode(serverinfo.ServerName);
                xtn_child.NodeType = TreeNodeType.Server;
                xtn_child.Name = "xtn_child_server_" + serverinfo.ServerName;
                xtn_child.Server = serverinfo;
                xtn.Nodes.Add(xtn_child);
            }
        }

        private void XTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        private void XTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }
            XTreeNode xtn = e.Node as XTreeNode;
            if (xtn.NodeType == TreeNodeType.Server)
            {
                this.CurrentServer = xtn.Server;
                if (xtn.DataBaseComplete == false)
                {
                    this.SelectServerNode(xtn);
                }
            }
            else if (xtn.NodeType == TreeNodeType.DataBase)
            {
                this.CurrentServer = xtn.Server;
                this.SelectDataBaseNode(xtn);
            }
            else if (xtn.NodeType == TreeNodeType.Folder)
            {
                this.CurrentServer = xtn.Server;
                this.SelectFolderNode(xtn);
            }
            lastselecttype = xtn.NodeType;
        }

        /// <summary>
        /// 选择key包节点
        /// </summary>
        /// <param name="node"></param>
        private void SelectFolderNode(XTreeNode node)
        {
            FolderInfo folder = (node.Tag as FolderInfo);
            if (folder == null)
            {
                return;
            }

            if (this.lastfolder != null && this.lastfolder.Equals(folder))
            {
                //当点击当前key包时,不做动作
                return;
            }
            
            if (this.lastfolder == null || !this.lastfolder.Equals(folder))
            {
                this.CurrentDataBase = node.DB_Id;
                if (this.OnKeyFolderChange != null)
                {
                    this.OnKeyFolderChange.Invoke(node, this.CurrentDataBase);
                }
                this.lastfolder = folder;
                //重置上次数据库名
                this.lastdbInServerName = node.Server.ServerName;
            }
            else if (node.DB_Id != this.CurrentDataBase || node.Server.ServerName != lastdbInServerName)
            {
                this.CurrentDataBase = node.DB_Id;
                if (OnDataBaseChange != null)
                {
                    OnDataBaseChange.Invoke(node, this.CurrentDataBase, node.GetFullFolderName());
                }
                this.lastdbInServerName = node.Server.ServerName;
                this.lastfolder = folder;
            }
        }

        /// <summary>
        /// 点击数据库节点
        /// </summary>
        /// <param name="node"></param>
        private void SelectDataBaseNode(XTreeNode node)
        {
            XTreeNode xtParent = (node.Parent as XTreeNode);
            if (xtParent == null)
            {
                return;
            }
            if (node.DB_Id != this.CurrentDataBase || xtParent.Server.ServerName != lastdbInServerName
                || (lastselecttype == TreeNodeType.Folder))
            {
                this.CurrentDataBase = node.DB_Id;
                if (OnDataBaseChange != null)
                {
                    OnDataBaseChange.Invoke(node, this.CurrentDataBase , null);
                }
                lastdbInServerName = xtParent.Server.ServerName;
                //重置上次key包名
                this.lastfolder = null;

            }
        }

        /// <summary>
        /// 点击服务器节点
        /// </summary>
        /// <param name="node"></param>
        private void SelectServerNode(XTreeNode node)
        {
            
            Redis redis = new Redis(node.Server);
            int dbcount = redis.DataBases();
            if (dbcount == -1)
            {
                //try again
                dbcount = redis.DataBases();
                if (dbcount == -1)
                {
                    Tip.Show("链接服务器失败,请重试!");
                    return;
                }
            }
            node.Nodes.Clear();
            Dictionary<string, string> info = redis.Info();
            XTreeNode xtn_dbnode = null;
            string text = null;
            string dbname = null;
            for (int i = 0; i < dbcount; i++)
            {
                dbname = "db" + i;
                text = string.Format("{0}({1})", dbname, (info.ContainsKey(dbname) ? TextConvert.GetKeyCount(info[dbname]) : 0));
                xtn_dbnode = new XTreeNode(text);
                xtn_dbnode.DB_Id = i;
                xtn_dbnode.Name = "xtn_" + node.Index + "_" + "database_" + i;
                xtn_dbnode.NodeType = TreeNodeType.DataBase;
                xtn_dbnode.Server = node.Server;
                node.Nodes.Add(xtn_dbnode);
            }
            node.DataBaseComplete = true;
            node.Expand();
        }

        /// <summary>
        /// 当前选中的节点是否显示右键菜单
        /// </summary>
        public bool IsShowNodeMenu
        {
            get
            {
                TreeNodeType type = this.SelectedNodeType;
                return (type == TreeNodeType.DataBase || type == TreeNodeType.Server);
            }
        }

        public bool OpenServer()
        {
            XTreeNode xtn = this.SelectedNode as XTreeNode;
            if (xtn != null && xtn.NodeType == TreeNodeType.Server && xtn.Nodes.Count == 0)
            {
                xtn.DataBaseComplete = false;
                this.SelectServerNode(xtn);
                return true;
            }
            return false;
        }

        public bool CloseServer()
        { 
            XTreeNode xtn = this.SelectedNode as XTreeNode;
            if (xtn != null && xtn.NodeType == TreeNodeType.Server && xtn.DataBaseComplete)
            {
                xtn.DataBaseComplete = false;
                xtn.Nodes.Clear();
                if (xtn.Server.ServerName == this.lastdbInServerName)
                {
                    this.lastdbInServerName = string.Empty;
                }
                return true;
            }
            return false;
        }

        public bool DeleteServer()
        { 
            XTreeNode xtn = this.SelectedNode as XTreeNode;
            if (xtn != null && xtn.NodeType == TreeNodeType.Server)
            {
                int child = xtn.Nodes.Count;
                if (child > 0 || xtn.DataBaseComplete)
                {
                    Tip.Show("无法移除已打开的服务器链接");
                    return false;
                }
                ServerManager.Create().DeleteServer(xtn.Server);
                this.Nodes.Remove(xtn);
                return true;
            }
            return false;
        }
    }
}
