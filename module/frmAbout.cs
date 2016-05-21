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
using Hibernate.Util;

namespace redis_manage.module
{
    public partial class frmAbout : ModuleBase
    {
        public frmAbout()
        {
            InitializeComponent();
            base.InitFormStyle();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblAppName.Text = Define.AppName;
            lblAppVs.Text = "当前版本: " + Define.Vs;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            base.CloseSelf();
        }

        private void linkUpgrade_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string vs = string.Empty;
            string detail = string.Empty;
            string downurl = string.Empty;
            if (Cawd.Create().Upgrade(ref vs,ref downurl , ref detail))
            {
                if (vs == Define.Vs)
                {
                    Tip.Show("已是最新版本,谢谢您的关注");
                }
                else
                {
                    Tip.ShowUpgrade(vs, downurl, detail);
                }
                return;
            }
            Tip.Show("网络链接失败,请检查网络是否通畅");
        }

        private void linkBlogHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.OpenWebPage(Define.BlogHome);
        }
    }
}
