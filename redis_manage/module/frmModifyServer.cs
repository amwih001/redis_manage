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
using redis_manage.lib;

namespace redis_manage.module
{
    public partial class frmModifyServer : ModuleBase
    {
        /// <summary>
        /// 修改前的服务器对象
        /// </summary>
        private ServerInfo OriServer;
        public frmModifyServer(ServerInfo _serverinfo)
        {
            InitializeComponent();
            base.InitFormStyle();
            base.redis = null;
            this.OriServer = _serverinfo;
        }

        private void frmModifyServer_Load(object sender, EventArgs e)
        {
            if (this.OriServer != null)
            {
                txtServerName.Text = this.OriServer.ServerName;
                txtServerHost.Text = this.OriServer.Host;
                txtServerAuth.Text = this.OriServer.Password;
                nudServerPort.Value = this.OriServer.Port;
            }
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

            if (serverinfo.ServerName != OriServer.ServerName && ServerManager.Create().Exists(serverinfo.ServerName))
            {
                Tip.Show("服务器名称已存在,请换一个吧!");
                txtServerName.Focus();
                return;
            }
            ServerManager.Create().ModifyServer(OriServer, serverinfo);
            OriServer.ServerName = serverinfo.ServerName;
            OriServer.Host = serverinfo.Host;
            OriServer.Port = serverinfo.Port;
            OriServer.Password = serverinfo.Password;
            base.CloseSelf();
        }
    }
}
