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
    public partial class frmRename : ModuleBase
    {
        public frmRename(RedisKvBase _redis, KeyInfo _keyinfo)
        {
            InitializeComponent();
            base.InitFormStyle();
            base.redis = _redis;
            base.KeyInfo = _keyinfo;
        }

        private void frmRename_Load(object sender, EventArgs e)
        {
            this.lblOriKeyName.Text = base.KeyInfo.NotNull;
            this.txtNewKeyName.Text = base.KeyInfo.Text;
            this.txtNewKeyName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.CloseSelf();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string newkey = txtNewKeyName.Text.Trim();
            if (newkey == base.KeyInfo.Text)
            {
                base.CloseSelf();
                return;
            }
            DialogResult dr = DialogResult.OK;
            if (base.redis.Exists(newkey))
            {
                dr = MessageBox.Show(string.Format("目标键值[{0}]已经存在,确定替换吗?", newkey), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            if (dr == DialogResult.OK)
            {
                if (base.redis.RenameKey(base.KeyInfo.Text, newkey))
                {
                    if (this.RenameSuccess != null)
                    {
                        RenameSuccess.Invoke(base.KeyInfo.Text, newkey);
                    }
                    base.CloseSelf();
                }
                else
                {
                    Tip.Show("操作失败,请重新刷新后再操作");
                }
            }
        }

        public delegate void OnRenameSuccess(string fromkey , string tokey);
        /// <summary>
        /// 重命名成功时回调事件
        /// </summary>
        public event OnRenameSuccess RenameSuccess;
    }
}
