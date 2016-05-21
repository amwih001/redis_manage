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
    public partial class frmAddListItem : ModuleBase
    {
        public frmAddListItem(RedisKvBase _redis, KeyInfo _keyinfo)
        {
            InitializeComponent();
            base.InitFormStyle();
            base.redis = _redis;
            base.KeyInfo = _keyinfo;
        }

        private void frmAddListItem_Load(object sender, EventArgs e)
        {
            lblDBId.Text = base.redis.DB.ToString();
            lblServerName.Text = base.redis.Server.ServerName;
            lblKeyName.Text = base.KeyInfo.Text;
            cmbPos.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.CloseSelf();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int index = cmbPos.SelectedIndex;
            string item = txtValue.Text;
            if (string.IsNullOrEmpty(item))
            {
                Tip.Show("元素值不能为空,请重新输入");
                txtValue.Focus();
                return;
            }
            bool flag = false;
            if (index == 1)
            {
                flag = base.redis.RPushItemToList(base.KeyInfo.Text, item);
            }
            else if (index == 0)
            {
                flag = base.redis.LPushItemToList(base.KeyInfo.Text, item);
            }

            if (flag)
            {
                if (this.AddSuccess != null)
                {
                    this.AddSuccess.Invoke(base.KeyInfo, item);
                }
                base.CloseSelf();
            }
            else
            {
                Tip.Show("操作失败,请重新刷新后再操作");
            }
        }

        public delegate void OnAddSuccess(KeyInfo keyinfo, string item);
        /// <summary>
        /// 添加成功时回调事件
        /// </summary>
        public event OnAddSuccess AddSuccess;
    }
}
