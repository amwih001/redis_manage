using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using redis_manage.lib;
using redis_manage.info;
using redis_manage.tools;

namespace redis_manage.module
{
    public partial class frmAddZsetItem : ModuleBase
    {
        public frmAddZsetItem(RedisKvBase _redis, KeyInfo _keyinfo)
        {
            InitializeComponent();
            base.InitFormStyle();
            base.redis = _redis;
            base.KeyInfo = _keyinfo;
        }


        private void frmAddZsetItem_Load(object sender, EventArgs e)
        {
            lblDBId.Text = base.redis.DB.ToString();
            lblServerName.Text = base.redis.Server.ServerName;
            lblKeyName.Text = base.KeyInfo.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.CloseSelf();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string score_str = txtScore.Text;
            string value = txtValue.Text;
            double score = 0d;
            if (string.IsNullOrEmpty(score_str) || !Double.TryParse(score_str, out score))
            {
                Tip.Show("请输入有效的分值");
                txtScore.SelectAll();
                txtScore.Focus();
                return;
            }

            if (base.redis.SortedSetContainsItem(base.KeyInfo.Text, value) && Tip.ShowOKCancel(string.Format("值已经存在,是否覆盖分?"), "提示") != DialogResult.OK)
            {
                return;
            }

            if (base.redis.AddItemToSortedSet(base.KeyInfo.Text, value, score))
            {
                if (this.AddSuccess != null)
                {
                    this.AddSuccess.Invoke(base.KeyInfo, score, value);
                }
                base.CloseSelf();
            }
            else
            {
                Tip.Show("操作失败,请重新刷新后再操作");
            }
        }

        public delegate void OnAddSuccess(KeyInfo keyinfo, double score, string value);
        /// <summary>
        /// 添加成功时回调事件
        /// </summary>
        public event OnAddSuccess AddSuccess;
    }
}
