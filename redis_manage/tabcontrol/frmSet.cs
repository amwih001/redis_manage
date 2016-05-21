using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using redis_manage.lib.component;
using Hibernate.Util;
using redis_manage.tools;
using redis_manage.info;
using redis_manage.module;

namespace redis_manage.tabcontrol
{
    public partial class frmSet : TabBase
    {
        private List<string> setmembers;

        public frmSet()
        {
            InitializeComponent();
        }

        private void frmSet_Load(object sender, EventArgs e)
        {
            plLeft.Width = ParentWidth / 2;
            column_value.Width = dgvSet.Width - 60;

            this.pageInfo.PageIndexChanged += pageInfo_PageIndexChanged;
        }

        public override void BeforeShowValue()
        {
            base.redis = new RedisSet(RedisClient.Server, RedisClient.DB);
            base.BeforeShowValue();
        }

        public override void InitValue()
        {
            this.kattr.ParentControl = this;
            this.kattr.OnLoad();

            this.setmembers = base.redis.GetAllItemsFromSet(this.Key.Text);

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
            this.setmembers.Clear();
            this.setmembers = null;
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
            List<string> members = this.setmembers.GetRange(begin, limit);

            if (members.Count > 0)
            {
                dgvSet.Rows.Clear();
                int count = members.Count;
                int index = 0;
                DataGridViewRow dgvRow = null;

                for (int i = 0; i < count; i++)
                {
                    index = this.dgvSet.Rows.Add();
                    dgvRow = this.dgvSet.Rows[index];
                    dgvRow.Cells[0].Value = members[i];
                }
            }
        }
        /// <summary>
        /// 刷新页
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
            if (this.dgvSet.SelectedRows.Count == 0)
            {
                return;
            }
            this.dgvSet.CurrentCell = this.dgvSet.SelectedRows[0].Cells[0];
            this.dgvSet.BeginEdit(true);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddSetItem additem = new frmAddSetItem(base.redis, this.Key);
            additem.AddSuccess += new frmAddSetItem.OnAddSuccess(additem_AddSuccess);
            additem.ShowDialog();
        }

        void additem_AddSuccess(KeyInfo keyinfo, string value)
        {
            if (!this.setmembers.Contains(value))
            {
                this.setmembers.Insert(0, value);
            }
            this.pageInfo.OnRefresh();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedCellRows = dgvSet.SelectedCells.Count;
            if (dgvSet.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewCell cell = dgvSet.SelectedRows[0].Cells[0];
            string item = Tools.ToString(cell.Value);

            if (base.redis.RemoveItemFromSet(this.Key.Text, item))
            {
                this.setmembers.Remove(item);
                this.pageInfo.Total = this.setmembers.Count;
                //成功则刷新列表
                this.pageInfo.OnRefresh();
            }
            else
            {
                Tip.Show("操作失败,请重新载入后再操作");
            }
        }

        private void dgvSet_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewCell gc = dgvSet.Rows[e.RowIndex].Cells[e.ColumnIndex];
            gc.Tag = gc.Value;
        }

        private void dgvSet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell gc_value = dgvSet.Rows[e.RowIndex].Cells[0];
            string oldval = Tools.ToString(gc_value.Tag);
            string newval = Tools.ToString(gc_value.Value);

            if (oldval != newval)
            {
                if (base.redis.SetContainsItem(this.Key.Text, oldval))
                {
                    if (base.redis.RemoveItemFromSet(this.Key.Text, oldval)
                        &&
                        base.redis.AddItemToSet(this.Key.Text, newval))
                    {
                        int index = this.setmembers.FindIndex(s => s == oldval);
                        if (index >= 0)
                        {
                            this.setmembers[index] = newval;
                        }
                    }
                    else
                    {
                        Tip.Show("操作失败,请重新载入后再操作");
                    }
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
