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
    public partial class frmHash : TabBase
    {
        private List<string> hashkeys;
        public frmHash()
        {
            InitializeComponent();
        }

        private void frmHash_Load(object sender, EventArgs e)
        {
            plLeft.Width = ParentWidth / 2;

            //控制listview内列的宽度
            int lvwidth = this.dgvHash.Width;
            int lvwidth3 = lvwidth / 3;
            this.column_field.Width = lvwidth3 - 10;
            this.column_value.Width = lvwidth3 * 2 - 50;


            this.pageInfo.PageIndexChanged += pageInfo_PageIndexChanged;
        }

        public override void BeforeShowValue()
        {
            base.redis = new RedisHash(RedisClient.Server, RedisClient.DB);
            base.BeforeShowValue();
        }

        public override void InitValue()
        {
            this.kattr.ParentControl = this;
            this.kattr.OnLoad();

            this.hashkeys = base.redis.GetHashKeys(this.Key.Text);

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
            this.hashkeys.Clear();
            this.hashkeys = null;
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
            List<string> fields = this.hashkeys.GetRange(begin, limit);

            List<string> values = base.redis.GetValuesFromHash(this.Key.Text, fields);

            if (fields.Count == values.Count && values.Count > 0)
            {
                dgvHash.Rows.Clear();
                int count = values.Count;
                int index = 0;
                DataGridViewRow dgvRow = null;
                
                for (int i = 0; i < count; i++)
                {
                    index = this.dgvHash.Rows.Add();
                    dgvRow = this.dgvHash.Rows[index];
                    dgvRow.Cells[0].Value = fields[i];
                    dgvRow.Cells[1].Value = values[i];
                }
            }
        }
        /// <summary>
        /// 删除域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedCellRows = dgvHash.SelectedCells.Count;
            if (dgvHash.SelectedRows.Count == 0)
            {
                if (selectedCellRows == 0)
                {
                    return;
                }
                if (selectedCellRows > 0)
                {
                    Tip.Show("移除时必须选中一整行,请点击左侧的小箭头进行移除");
                    return;
                }
            }
            DataGridViewCell cell = dgvHash.SelectedRows[0].Cells[0];
            string field = Tools.ToString(cell.Value);
            if (base.redis.RemoveEntryFromHash(this.Key.Text, field))
            {
                this.hashkeys.Remove(field);
                this.pageInfo.Total = this.hashkeys.Count;
                //成功则刷新列表
                this.pageInfo.OnRefresh();
            }
            else
            {
                Tip.Show("删除失败,请重新载入后再操作");
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
        /// 添加域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddHashItem additem = new frmAddHashItem(base.redis , base.Key);
            additem.AddSuccess += new frmAddHashItem.OnAddSuccess(additem_AddSuccess);
            additem.ShowDialog();
        }

        void additem_AddSuccess(KeyInfo keyinfo, string field, string value)
        {
            if (!this.hashkeys.Contains(field))
            {
                this.hashkeys.Insert(0, field);
            }
            this.pageInfo.OnRefresh();
        }
        /// <summary>
        /// 编辑域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvHash.SelectedRows.Count == 0)
            {
                return;
            }
            this.dgvHash.CurrentCell = this.dgvHash.SelectedRows[0].Cells[1];
            this.dgvHash.BeginEdit(true);
        }

        private void dgvHash_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewCell gc = dgvHash.Rows[e.RowIndex].Cells[e.ColumnIndex];
            gc.Tag = gc.Value;
        }

        private void dgvHash_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell gc_key = dgvHash.Rows[e.RowIndex].Cells[0];
            DataGridViewCell gc_value = dgvHash.Rows[e.RowIndex].Cells[1];
            string oldval = Tools.ToString(gc_value.Tag);
            string newval = Tools.ToString(gc_value.Value);

            string field = Tools.ToString(gc_key.Value);

            if (oldval != newval)
            {
                base.redis.SetEntryInHash(this.Key.Text, field, newval);
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
