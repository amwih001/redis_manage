using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using redis_manage.info;
using redis_manage.lib;
using redis_manage.tools;

namespace redis_manage.module
{
    public partial class frmAddSetItem : ModuleBase
    {
        public frmAddSetItem(RedisKvBase _redis, KeyInfo _keyinfo)
        {
            InitializeComponent();
            base.InitFormStyle();
            base.redis = _redis;
            base.KeyInfo = _keyinfo;
        }

        private void frmAddSetItem_Load(object sender, EventArgs e)
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
            string value = txtValue.Text;
            if (base.redis.SetContainsItem(base.KeyInfo.Text, value))
            {
                Tip.Show("值已经存在于Set集合中,添加失败");
                return;
            }

            if (base.redis.AddItemToSet(this.KeyInfo.Text, value))
            {
                if (this.AddSuccess != null)
                {
                    this.AddSuccess.Invoke(base.KeyInfo, value);
                }
                base.CloseSelf();
            }
            else
            {
                Tip.Show("操作失败,请重新刷新后再操作");
            }
        }

        public delegate void OnAddSuccess(KeyInfo keyinfo, string value);
        /// <summary>
        /// 添加成功时回调事件
        /// </summary>
        public event OnAddSuccess AddSuccess;
    }
}
