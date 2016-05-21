using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using redis_manage.info;
using redis_manage.tools;

namespace redis_manage.module
{
    public partial class frmFeedback : ModuleBase
    {
        public frmFeedback()
        {
            InitializeComponent();
            base.InitFormStyle();
        }

        private void frmFeedback_Load(object sender, EventArgs e)
        {
            lblCurrentVs.Text = Define.Vs;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.CloseSelf();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string qq = txtContact.Text.Trim();
            string msg = rtbMsg.Text.Trim();
            if (string.IsNullOrEmpty(msg))
            {
                txtContact.Focus();
                Tip.Show("写点东西吧,要不人家怎么看呢");
                return;
            }
            btnSave.Enabled = false;
            bool ret = Cawd.Create().Feedback(qq, msg);
            btnSave.Enabled = true;

            Tip.Show("信息提交成功, 谢谢您的反馈!");
            base.CloseSelf();
        }
    }
}
