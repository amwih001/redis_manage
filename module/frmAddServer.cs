using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using redis_manage.lib;
using redis_manage.tools;
using redis_manage.info;

namespace redis_manage.module
{
    public partial class frmAddServer : ModuleBase
    {
        public frmAddServer()
        {
            InitializeComponent();
            base.InitFormStyle();
            base.redis = null;
        }

        private void frmAddServer_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.CloseSelf();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ServerInfo serverinfo = new ServerInfo();

            serverinfo.ServerName = txtServerName.Text.Trim();
            serverinfo.Host = txtServerHost.Text.Trim();
            serverinfo.Port = (int)nudServerPort.Value;
            serverinfo.Password = txtServerAuth.Text.Trim();

            if (string.IsNullOrEmpty(serverinfo.ServerName) || string.IsNullOrEmpty(serverinfo.Host) || serverinfo.Port == 0)
            {
                Tip.Show("请填写完整的服务器信息");
                txtServerName.Focus();
                return;
            }

            if (ServerManager.Create().Exists(serverinfo.ServerName))
            {
                Tip.Show("服务器名称已存在,请换一个吧!");
                txtServerName.Focus();
                return;
            }
            ServerManager.Create().AddServer(serverinfo);
            if (this.InsertSuccess != null)
            {
                this.InsertSuccess.Invoke(serverinfo);
            }
            Tip.Show("服务器添加成功!");
            base.CloseSelf();
        }

        public delegate void OnInsertSuccess(ServerInfo serverinfo);
        /// <summary>
        /// 重命名成功时回调事件
        /// </summary>
        public event OnInsertSuccess InsertSuccess;
    }
}
