using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using redis_manage.lib;
using redis_manage.info;
using redis_manage.lib.component;
using redis_manage.tabcontrol;
using redis_manage.tools;
using redis_manage.module;

namespace redis_manage.controls
{
    /// <summary>
    /// 自定义ListView控件(显示Redis Key列表)
    /// </summary>
    public partial class XListView : UserControl , IControl
    {
        private KeysList keyslist;

        public KeysList Keyslist
        {
            get { return keyslist; }
        }
        /// <summary>
        /// 最后选择的节点
        /// </summary>
        private XTreeNode node;

        public frmRedisClient frmRedis;
        /// <summary>
        /// listview中呈现的是哪个数据库的keys
        /// </summary>
        private int currentdbid;

        public XListView()
        {
            InitializeComponent();
            this.lvKeyList.Items.Clear();
        }

        public void OnLoad()
        {
            this.currentdbid = -1;
            this.lblPageInfo.Text = "";
            this.keyslist = new KeysList();

            //计算listview可显示多少列
            int lvwidth = this.lvKeyList.ClientSize.Width;
            int tiwidth = this.lvKeyList.TileSize.Width;

            int column = lvwidth / tiwidth;
            int line = 30;
            int size = column * line;
            this.keyslist.PageSize = (size > 0 ? size : this.keyslist.PageSize);
        }

        public void OnActive()
        {
            
        }

        public void OnRefresh()
        {
            this.RefreshKeys();
            List<string> list = this.keyslist.Get(this.SearchKey, SearchKeyType.Contains);
            this.RefreshListView(list);

            XTreeNode dbnode = node == null ? null : node.FindDataBaseNode();
            if (dbnode != null)
            {
                dbnode.RefreshText();
                dbnode.RefreshFolder(this.Keyslist.KeyFolder, true);
                //2016-11-22 16:11:26 取消展开所有子节点
                //dbnode.ExpandAll();
            }
        }

        /// <summary>
        /// key包点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="databaseid"></param>
        public void OnKeyFolderChange(XTreeNode sender, int databaseid)
        {
            FolderInfo folder = sender.Tag as FolderInfo;
            if (folder == null)
            {
                return;
            }

            string pattern = sender.GetFullFolderName();

            this.node = sender;
            this.CheckChangeDataBase(databaseid, this.keyslist.Server.ServerName != sender.Server.ServerName);
            keyslist.Server = sender.Server;
            keyslist.DB = databaseid;
            List<string> list = this.keyslist.Get(pattern, SearchKeyType.StartsWith);
            this.RefreshListView(list);
        }
        /// <summary>
        /// 切换数据库事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="databaseid"></param>
        /// <param name="pattern"></param>
        public void OnDataBaseChange(XTreeNode sender, int databaseid, string pattern)
        {
            //当切换数据库时,清空搜索框文本
            this.txtSearchKey.Clear();

            this.node = sender;
            this.CheckChangeDataBase(databaseid , this.keyslist.Server.ServerName != sender.Server.ServerName);
            keyslist.Server = sender.Server;
            keyslist.DB = databaseid;
            List<string> list = this.keyslist.Get(pattern, SearchKeyType.Contains);
            this.RefreshListView(list);
        }

        /// <summary>
        /// 检查数据库是否切换
        /// </summary>
        /// <param name="databaseid"></param>
        private void CheckChangeDataBase(int databaseid , bool changeServer)
        {
            if (currentdbid != databaseid || changeServer)
            {
                this.RefreshKeys();
            }
            else
            {
                this.RefreshPageInfo();
            }
            this.currentdbid = databaseid;
        }

        public void RefreshListView(List<string> list)
        {
            this.btnPrevPage.Enabled = !this.keyslist.IsFirst;
            this.btnNextPage.Enabled = !this.keyslist.IsLast;
            this.lvKeyList.Items.Clear();
            ListViewItem lvi = null;
            KeyInfo keyinfo;
            this.lblPageInfo.Text = this.keyslist.Total > 0 ? string.Format("{0}/{1}", this.keyslist.PageIndex, this.keyslist.TotalPage) : "";
            foreach (string item in list)
            {
                keyinfo = new KeyInfo(item);
                lvi = new ListViewItem(keyinfo.NotNull);
                lvi.Tag = keyinfo;
                lvi.ToolTipText = item;
                this.lvKeyList.Items.Add(lvi);
            }
        }

        private void RefreshKeys()
        {
            this.keyslist.ResetAll();
        }

        private void RefreshPageInfo()
        {
            this.keyslist.ResetPageInfo();
        }

        private void lvKeyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKeyList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvKeyList.SelectedItems[0];
                KeyInfo keyinfo = selectedItem.Tag as KeyInfo;
                if( keyinfo == null)
                {
                    throw new Exception("ListViewItem的KeyInfo对象为空");
                }
                string contentkey = TextConvert.GetContentKey(this.node.Server.ServerName, this.currentdbid, keyinfo.Text);

                frmRedis.ShowKeyDetail(contentkey , keyinfo);
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            this.keyslist.PageIndex++;
            List<string> list = this.keyslist.Get(this.SearchKey , SearchKeyType.Contains);
            this.RefreshListView(list);
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            this.keyslist.PageIndex--;
            List<string> list = this.keyslist.Get(this.SearchKey, SearchKeyType.Contains);
            this.RefreshListView(list);
        }

        /// <summary>
        /// 强制刷新key
        /// </summary>
        private void cmsRefreshKeys_Click(object sender, EventArgs e)
        {
            this.OnRefresh();
        }

        private void cmsListView_Opening(object sender, CancelEventArgs e)
        {

        }
        /// <summary>
        /// 删除key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsDeleteKey_Click(object sender, EventArgs e)
        {
            if (this.lvKeyList.SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem lvi = this.lvKeyList.SelectedItems[0];
            if (lvi == null)
            {
                return;
            }
            KeyInfo keyinfo = lvi.Tag as KeyInfo;
            if (keyinfo == null)
            {
                return;
            }
            DialogResult dr = MessageBox.Show(string.Format("确定删除键值[{0}]吗?", keyinfo.Text), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr != DialogResult.OK)
            {
                return;
            }
            if (!this.keyslist.Exists(keyinfo.Text) || this.keyslist.Remove(keyinfo.Text))
            {
                this.lvKeyList.Items.Remove(lvi);
                frmRedis.CloseDocument(TextConvert.GetContentKey(this.node.Server.ServerName, this.currentdbid, keyinfo.Text));
            }
            else
            {
                Tip.Show("删除失败,请重新刷新后再操作");
            }
        }

        /// <summary>
        /// 从listview中删除一个元素
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItemFromListView(string item)
        {
            ListViewItem del = null;
            foreach (ListViewItem lvi in lvKeyList.Items)
            {
                if (lvi.Text == item)
                {
                    del = lvi;
                    break;
                }
            }
            if (del != null)
            {
                lvKeyList.Items.Remove(del);
            }
        }


        private void cmsRenameKey_Click(object sender, EventArgs e)
        {
            if (this.lvKeyList.SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem lvi = this.lvKeyList.SelectedItems[0];
            if (lvi == null)
            {
                return;
            }
            KeyInfo keyinfo = lvi.Tag as KeyInfo;
            if (keyinfo == null)
            {
                return;
            }
            frmRename rename = new frmRename(this.keyslist, keyinfo);
            rename.RenameSuccess += new frmRename.OnRenameSuccess(rename_RenameSuccess);
            rename.ShowDialog();
        }

        private void rename_RenameSuccess(string fromkey, string tokey)
        {
            frmRedis.CloseDocument(TextConvert.GetContentKey(this.node.Server.ServerName, this.currentdbid, fromkey));
            this.keyslist.Replace(fromkey, tokey);
            if (this.lvKeyList.SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem lvi = this.lvKeyList.SelectedItems[0];
            if (lvi == null)
            {
                return;
            }
            KeyInfo keyinfo = lvi.Tag as KeyInfo;
            if (keyinfo != null)
            {
                keyinfo.Text = tokey;
            }
            lvi.Text = tokey;
        }

        /// <summary>
        /// 清空所有项目
        /// </summary>
        public void ClearByServer(ServerInfo serverinfo)
        {
            if (this.keyslist.Server != null && this.keyslist.Server.ServerName == serverinfo.ServerName)
            {
                this.keyslist.ResetAll();
                this.RefreshListView(new List<string>());
            }
        }
        
        /// <summary>
        /// 获取搜索的关键字
        /// </summary>
        public string SearchKey { set; get; }

        /// <summary>
        /// 搜索键值按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //2016-11-22 16:11:44 添加搜索key关键字功能
            this.SearchKey = this.txtSearchKey.Text.Trim();
            this.OnRefresh();
        }
    }
}
