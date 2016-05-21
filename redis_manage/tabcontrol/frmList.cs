using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using redis_manage.lib.component;
using redis_manage.tools;
using Hibernate.Util;
using redis_manage.info;
using redis_manage.module;

namespace redis_manage.tabcontrol
{
    public partial class frmList : TabBase
    {
        private List<string> list;

        public frmList()
        {
            InitializeComponent();
        }

        private void frmList_Load(object sender, EventArgs e)
        {
            plLeft.Width = ParentWidth / 2;
            column_value.Width = dgvList.Width - 60;

            this.pageInfo.PageIndexChanged += pageInfo_PageIndexChanged;
        }

        public override void BeforeShowValue()
        {
            base.redis = new RedisList(RedisClient.Server, RedisClient.DB);
            base.BeforeShowValue();
        }

        public override void InitValue()
        {
            this.kattr.ParentControl = this;
            this.kattr.OnLoad();

            this.pageInfo.PageSize = base.PageSize;
            this.pageInfo.Total = (int)this.kattr.Count;

            this.pageInfo.OnLoad();

            base.InitValue();
        }

        public override void Reload()
        {
            this.pageInfo.PageIndex = 1;
            base.Reload();
        }

        public override void Remove()
        {
            base.Remove();
        }

        public override void CDispose()
        {
            this.kattr.Dispose();
            this.pageInfo.Dispose();
            this.list.Clear();
            this.list = null;
            base.CDispose();
        }

        /// <summary>
        /// 页码改变时的事件
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="begin"></param>
        /// <param name="limit"></param>
        public void pageInfo_PageIndexChanged(int pageindex, int begin, int limit)
        {
            //list特殊处理
            limit = begin + limit - 1;
            this.list = base.redis.GetRangeFromList(this.Key.Text, begin, limit);

            if (this.list.Count > 0)
            {
                dgvList.Rows.Clear();
                int count = this.list.Count;
                int index = 0;
                DataGridViewRow dgvRow = null;

                for (int i = 0; i < count; i++)
                {
                    index = this.dgvList.Rows.Add();
                    dgvRow = this.dgvList.Rows[index];
                    dgvRow.Cells[0].Value = this.list[i];
                }
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddListItem additem = new frmAddListItem(base.redis, this.Key);
            additem.AddSuccess += new frmAddListItem.OnAddSuccess(additem_AddSuccess);
            additem.ShowDialog();
        }

        void additem_AddSuccess(KeyInfo keyinfo, string item)
        {
            this.pageInfo.Total = (int)base.redis.Count(this.Key.Text);
            this.pageInfo.OnRefresh();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pageInfo.OnRefresh();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
            {
                return;
            }
            this.dgvList.CurrentCell = this.dgvList.SelectedRows[0].Cells[0];
            this.dgvList.BeginEdit(true);
        }
        /// <summary>
        /// 删除尾
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelTailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (base.redis.GetHeadOrTailAndRemove(this.Key.Text, false) != null)
            {
                this.pageInfo.PageIndex = 1;
                this.pageInfo.OnRefresh();
            }
            else
            {
                Tip.Show("操作失败,请重新载入后再操作");
            }
        }

        /// <summary>
        /// 删除头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelHeadStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (base.redis.GetHeadOrTailAndRemove(this.Key.Text, true) != null)
            {
                this.pageInfo.Total--;
                this.pageInfo.PageIndex = 1;
                this.pageInfo.OnRefresh();
            }
            else
            {
                Tip.Show("操作失败,请重新载入后再操作");
            }
        }

        private void dgvList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewCell gc = dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex];
            gc.Tag = gc.Value;
        }

        private void dgvList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell gc_value = dgvList.Rows[e.RowIndex].Cells[0];
            string oldval = Tools.ToString(gc_value.Tag);
            string newval = Tools.ToString(gc_value.Value);
            if (oldval != newval)
            {
                int index = ((this.pageInfo.PageIndex - 1) * this.pageInfo.PageSize) + e.RowIndex;

                if (base.redis.SetItemInList(this.Key.Text, index, newval))
                {
                    //修改成功
                }
                else
                {
                    Tip.Show("元素不存在,请重新载入后再操作");
                }
            }
            gc_value.Tag = null;
        }

        private void operation_Operation_Click(info.Opera _opera)
        {
            switch (_opera)
            {
                case Opera.Reload:
                    this.Reload();
                    break;
                case Opera.Remove:
                    this.Remove();
                    break;
            }
        }
    }
}
