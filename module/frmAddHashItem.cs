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
    public partial class frmAddHashItem : ModuleBase
    {
        public frmAddHashItem(RedisKvBase _redis , KeyInfo _keyinfo)
        {
            InitializeComponent();
            base.InitFormStyle();
            base.redis = _redis;
            base.KeyInfo = _keyinfo;
        }

        private void frmAddHashItem_Load(object sender, EventArgs e)
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
            string field = txtField.Text;
            string value = txtValue.Text;
            if (string.IsNullOrEmpty(field))
            {
                Tip.Show("Hash的域不允许为空");
                txtField.Focus();
                return;
            }
            if (base.redis.HashContainsEntry(base.KeyInfo.Text, field) && Tip.ShowOKCancel(string.Format("域已经存在,是否覆盖值?"), "提示") != DialogResult.OK)
            {
                return;
            }

            if (base.redis.SetEntryInHash(base.KeyInfo.Text, field, value))
            {
                if (this.AddSuccess != null)
                {
                    this.AddSuccess.Invoke(base.KeyInfo, field, value);
                }
                base.CloseSelf();
            }
            else
            {
                Tip.Show("操作失败,请重新刷新后再操作");
            }
        }

        public delegate void OnAddSuccess(KeyInfo keyinfo,string field, string value);
        /// <summary>
        /// 添加成功时回调事件
        /// </summary>
        public event OnAddSuccess AddSuccess;
    }
}
