using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hibernate.Util;

namespace redis_manage.module
{
    public partial class frmWinPatch : ModuleBase
    {
        public frmWinPatch()
        {
            InitializeComponent();
            base.InitFormStyle();
        }

        private void frmWinPatch_Load(object sender, EventArgs e)
        {
            lblMyPcBit.Text = string.Format(lblMyPcBit.Text, SystemInfo.GetSystemBit);
        }

        private void linkShowMsHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.OpenWebPage("http://support.microsoft.com/kb/2468871");
        }

        private void btnShowDoanLoad32_Click(object sender, EventArgs e)
        {
            Tools.OpenWebPage("http://download.microsoft.com/download/2/B/F/2BF4D7D1-E781-4EE0-9E4F-FDD44A2F8934/NDP40-KB2468871-v2-x86.exe");
        }

        private void btnShowDoanLoad64_Click(object sender, EventArgs e)
        {
            Tools.OpenWebPage("http://download.microsoft.com/download/2/B/F/2BF4D7D1-E781-4EE0-9E4F-FDD44A2F8934/NDP40-KB2468871-v2-x64.exe");
        }
    }
}
