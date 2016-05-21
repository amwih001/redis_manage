using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using redis_manage.lib;
using redis_manage.info;

namespace redis_manage.module
{
    public class ModuleBase : Form
    {
        public frmRedisClient RedisClient { set; get; }

        public KeyInfo KeyInfo;

        public Redis redis;

        public void InitFormStyle()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.KeyPress += new KeyPressEventHandler(ModuleBase_KeyPress);
        }

        protected void CloseSelf()
        {
            this.Close();
        }
    }
}
