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
    public partial class frmServerAttr : ModuleBase
    {
        /// <summary>
        /// 1.服务器  2.数据库
        /// </summary>
        private int Type;
        public int DB { set; get; }
        private ServerInfo Server;
        public frmServerAttr(ServerInfo _server , int _type)
        {
            InitializeComponent();
            base.InitFormStyle();
            this.Server = _server;
            this.Type = _type;
        }

        private void frmServerAttr_Load(object sender, EventArgs e)
        {
            this.lblServerName.Text = this.Server.ServerName;
            this.lblServerHost.Text = this.Server.Host;
            this.lblServerPort.Text = this.Server.Port.ToString();

            if (this.Type == 1)
            {
                base.redis = new Redis(this.Server);
                int dbcount = base.redis.DataBases();
                this.lblDBCount.Text = dbcount + "个";
                Dictionary<string, string> info = base.redis.Info();
                int keycount = 0;
                string dbname = null;
                for (int i = 0; i < dbcount; i++)
                {
                    dbname = "db" + i;
                    keycount += (info.ContainsKey(dbname) ? TextConvert.GetKeyCount(info[dbname]) : 0);
                }
                this.lblKeyCount.Text = keycount + "个";

                this.lblRedisVs.Text = this.SplitRedisVs(this.redis.VersionNumber);
            }
            else if (this.Type == 2)
            {
                base.redis = new Redis(this.Server, this.DB);
                base.redis.Info();
                this.label4.Text = "当前数据库:";
                this.Text = "数据库属性";
                this.lblDBCount.Text = DB.ToString();
                this.lblKeyCount.Text = base.redis.DbSize().ToString();
                this.lblRedisVs.Text = this.SplitRedisVs(this.redis.VersionNumber);
            }
        }

        private string SplitRedisVs(int vsnum)
        {
            if (vsnum >= 1000)
            {
                return vsnum.ToString().Insert(1, ".").Insert(3, ".");
            }
            return vsnum.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            base.CloseSelf();
        }
    }
}
