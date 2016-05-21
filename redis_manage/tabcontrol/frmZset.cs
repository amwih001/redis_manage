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
    public partial class frmZset : TabBase
    {
        private IDictionary<string, double> zset;
        public frmZset()
        {
            InitializeComponent();
        }

        private void frmZset_Load(object sender, EventArgs e)
        {
            plLeft.Width = ParentWidth / 2;

            //控制listview内列的宽度
            int lvwidth = this.dgvZset.Width;
            int lvwidth3 = lvwidth / 3;
            this.column_score.Width = lvwidth3 - 10;
            this.column_value.Width = lvwidth3 * 2 - 50;

            this.pageInfo.PageIndexChanged += pageInfo_PageIndexChanged;
        }

        public override void BeforeShowValue()
        {
            base.redis = new RedisZset(RedisClient.Server, RedisClient.DB);
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
            this.zset.Clear();
            this.zset = null;
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
            this.zset = base.redis.GetRangeWithScoresFromSortedSet(this.Key.Text, begin, limit);

            if (this.zset.Count > 0)
            {
                dgvZset.Rows.Clear();
                int count = this.zset.Count;
                int index = 0;
                DataGridViewRow dgvRow = null;

                foreach(string str in zset.Keys)
                {
                    index = this.dgvZset.Rows.Add();
                    dgvRow = this.dgvZset.Rows[index];
                    dgvRow.Cells[0].Value = zset[str];
                    dgvRow.Cells[1].Value = str;
                }
            }
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
            if (this.dgvZset.SelectedRows.Count == 0)
            {
                return;
            }
            this.dgvZset.CurrentCell = this.dgvZset.SelectedRows[0].Cells[0];
            this.dgvZset.BeginEdit(true);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddZsetItem additem = new frmAddZsetItem(base.redis, this.Key);
            additem.AddSuccess += new frmAddZsetItem.OnAddSuccess(additem_AddSuccess);
            additem.ShowDialog();
        }

        void additem_AddSuccess(KeyInfo keyinfo, double score, string value)
        {
            this.pageInfo.Total = (int)base.redis.Count(this.Key.Text);
            this.pageInfo.OnRefresh();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedCellRows = dgvZset.SelectedCells.Count;
            if (dgvZset.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewCell cell = dgvZset.SelectedRows[0].Cells[1];
            string value = Tools.ToString(cell.Value);
            if (base.redis.RemoveItemFromSortedSet(this.Key.Text, value))
            {
                this.zset.Remove(value);
                this.pageInfo.Total--;
                //成功则刷新列表
                this.pageInfo.OnRefresh();
            }
            else
            {
                Tip.Show("操作失败,请重新载入后再操作");
            }
        }

        private void dgvZset_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewCell gc = dgvZset.Rows[e.RowIndex].Cells[e.ColumnIndex];
            gc.Tag = gc.Value;
        }

        private void dgvZset_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell gc_score = dgvZset.Rows[e.RowIndex].Cells[0];
            DataGridViewCell gc_value = dgvZset.Rows[e.RowIndex].Cells[1];
            string oldval = Tools.ToString(gc_score.Tag);
            string newval = Tools.ToString(gc_score.Value);
            string value = Tools.ToString(gc_value.Value);

            double newval_double = double.NaN;
            bool isdouble = Double.TryParse(newval, out newval_double);

            if (oldval != newval && isdouble && !double.IsNaN(newval_double))
            {
                double score = base.redis.GetItemScoreInSortedSet(this.Key.Text, value);
                if (!double.IsNaN(score))
                {
                    base.redis.AddItemToSortedSet(this.Key.Text, value, newval_double);
                    //重新刷新
                    //this.pageInfo.OnRefresh();
                }
                else
                {
                    Tip.Show("元素不存在,请重新载入后再操作");
                }
            }
            else
            {
                gc_score.Value = gc_score.Tag;
            }
            gc_score.Tag = null;
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
