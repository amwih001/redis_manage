using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using redis_manage.lib;
using Hibernate.Util;

namespace redis_manage.controls
{
    public partial class Pagination : UserControl, IControl
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { set; get; }
        /// <summary>
        /// 每页显示
        /// </summary>
        public int PageSize { set; get; }

        /// <summary>
        /// 总长度
        /// </summary>
        public int Total { set; get; }

        public int TotalPage
        {
            get
            {
                int _total = Tools.ToInt(Math.Ceiling((double)(this.Total) / (double)(this.PageSize)));
                return Math.Max(_total, 1);
            }
        }

        public delegate void OnPrevClick();
        /// <summary>
        /// 上一页事件
        /// </summary>
        public event OnPrevClick PrevClick;

        public delegate void OnNextClick();
        /// <summary>
        /// 下一页事件
        /// </summary>
        public event OnNextClick NextClick;

        public delegate void OnPageIndexChanged(int pageindex, int begin, int limit);
        /// <summary>
        /// 页码改变时事件
        /// </summary>
        public event OnPageIndexChanged PageIndexChanged;

        public Pagination()
        {
            InitializeComponent();
        }

        private void Pagination_Load(object sender, EventArgs e)
        {
            this.lblPageInfo.Text = "";
            this.PageIndex = 1;
        }

        public void OnLoad()
        {
            this.GetBeginLimit();

            this.TriggerPageIndexChanged();
        }

        public void OnActive()
        {

        }

        public void OnRefresh()
        {
            this.OnLoad();
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (this.PageIndex <= 1)
            {
                return;
            }
            this.PageIndex--;
            this.GetBeginLimit();
            if (this.PrevClick != null)
            {
                this.PrevClick.Invoke();
            }
            this.TriggerPageIndexChanged();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (this.PageIndex > this.TotalPage)
            {
                return;
            }
            this.PageIndex++;
            this.GetBeginLimit();
            if (this.NextClick != null)
            {
                this.NextClick.Invoke();
            }
            this.TriggerPageIndexChanged();
        }

        private void TriggerPageIndexChanged()
        {
            int totalpage = this.TotalPage;
            if (totalpage > 1)
            {
                this.btnPrevPage.Enabled = !(this.PageIndex <= 1);
                this.btnNextPage.Enabled = !(totalpage <= this.PageIndex);
            }
            this.lblPageInfo.Text = string.Format("{0}/{1}", this.PageIndex, totalpage);
            if (this.PageIndexChanged != null)
            {
                this.PageIndexChanged.Invoke(this.PageIndex, begin, limit);
            }
        }


        private int begin;
        private int limit;
        private void GetBeginLimit()
        {
            begin = (this.PageIndex - 1) * this.PageSize;
            limit = this.PageSize;
            int lcount = this.Total;

            if (limit + begin > lcount)
            {
                limit = lcount - begin;
            }
            if (limit > lcount)
            {
                limit = Math.Max(0, lcount);
            }
        }
    }
}
