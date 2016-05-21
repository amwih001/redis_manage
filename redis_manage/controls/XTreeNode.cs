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
    public class XTreeNode : TreeNode
    {
        private TreeNodeType _nodeType;

        public TreeNodeType NodeType
        {
            get { return _nodeType; }
            set
            {
                _nodeType = value;
                this.SetImage();
            }
        }

        public ServerInfo Server { set; get; }
        public bool DataBaseComplete { set; get; }
        
        public int DB_Id { set; get; }

        public XTreeNode(string text)
            : base(text)
        {

        }

        /// <summary>
        /// 刷新数据库节点数据(key数量的刷新)
        /// </summary>
        public void RefreshText()
        {
            Redis redis = new Redis(Server);
            Dictionary<string, string> info = redis.Info();
            string dbname = "db" + this.DB_Id;
            string text = string.Format("{0}({1})", dbname, (info.ContainsKey(dbname) ? TextConvert.GetKeyCount(info[dbname]) : 0));
            this.Text = text;
        }

        /// <summary>
        /// 刷新key包
        /// </summary>
        /// <param name="keyfolder"></param>
        /// <param name="force"></param>
        public void RefreshFolder(KeyFolderInfo keyfolder , bool force)
        {
            int c = this.Nodes.Count;
            if (!force && c > 0)
            {
                return;
            }
            if (c > 0)
            {
                this.Nodes.Clear();
            }
            if (keyfolder.Map != null && keyfolder.IsFolder)
            {
                XTreeNode xtn_folder = null;
                foreach (string item in keyfolder.Map.Keys)
                {
                    xtn_folder = new XTreeNode(TextConvert.ParseKey(item));
                    xtn_folder.Server = this.Server;
                    xtn_folder.DB_Id = this.DB_Id;
                    xtn_folder.NodeType = TreeNodeType.Folder;
                    xtn_folder.Tag = (new FolderInfo(item, 0, !keyfolder.Map[item].HasChildFolder) as object);
                    this.CycleFolderNodes(xtn_folder, keyfolder.Map[item] , 1);
                    this.Nodes.Add(xtn_folder);
                }
            }
        }

        private void CycleFolderNodes(XTreeNode node, KeyFolderInfo keyfolder , int level)
        {
            if (keyfolder != null && keyfolder.Map != null)
            {
                XTreeNode xtn_folder = null;
                foreach (string item in keyfolder.Map.Keys)
                {
                    xtn_folder = new XTreeNode(TextConvert.ParseKey(item));
                    xtn_folder.Server = node.Server;
                    xtn_folder.DB_Id = node.DB_Id;
                    xtn_folder.NodeType = TreeNodeType.Folder;
                    xtn_folder.Tag = (new FolderInfo(item, level, !keyfolder.Map[item].HasChildFolder) as object);
                    this.CycleFolderNodes(xtn_folder, keyfolder.Map[item], ++level);
                    node.Nodes.Add(xtn_folder);
                }
            }
        }

        public string GetFullFolderName()
        {
            if (this.NodeType != TreeNodeType.Folder)
            {
                throw new Exception("节点类型不是数据包类型");
            }
            string foldername = null;
            FolderInfo folder = this.Tag as FolderInfo;
            if (folder == null)
            {
                return foldername;
            }

            foldername = string.Format("{0}", folder.Text);
            XTreeNode xtn = this.Parent as XTreeNode;

            while (xtn != null && xtn.NodeType == TreeNodeType.Folder)
            {
                folder = xtn.Tag as FolderInfo;
                if (folder != null)
                {
                    foldername = string.Format("{0}{1}{2}", folder.Text , Define.KeyFolder, foldername);
                }
                xtn = xtn.Parent as XTreeNode;
            }
            if (foldername != null)
            {
                //不能trim
                //foldername = foldername.Trim(Define.KeyFolder) + Define.KeyFolder;
                foldername = foldername + Define.KeyFolder;
            }
            return foldername;
        }

        /// <summary>
        /// 根据数据库/key包节点查找所属的数据库节点
        /// </summary>
        /// <returns></returns>
        public XTreeNode FindDataBaseNode()
        {
            if (this.NodeType == TreeNodeType.DataBase)
            {
                return this;
            }
            else if (this.NodeType == TreeNodeType.Folder)
            {
                XTreeNode xtn = this.Parent as XTreeNode;
                while (xtn != null && xtn.NodeType != TreeNodeType.DataBase)
                {
                    xtn = xtn.Parent as XTreeNode;
                }
                return xtn;
            }
            return null;
        }

        public void SetImage()
        {
            int _ix = -1;
            if (this.NodeType == TreeNodeType.Top)
            {
                _ix = 1;
            }
            else if (this.NodeType == TreeNodeType.Server)
            {
                _ix = 1;
            }
            else if (this.NodeType == TreeNodeType.DataBase)
            {
                _ix = 2;
            }
            else if (this.NodeType == TreeNodeType.Folder)
            {
                _ix = 3;
            }
            if (_ix >= 0)
            {
                this.ImageIndex = _ix;
                this.SelectedImageIndex = _ix;
            }
        }
    }
}
