using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using redis_manage.lib.component;
using redis_manage.info;
using redis_manage.tools;

namespace redis_manage.tabcontrol
{
    public partial class frmString : TabBase
    {
        public frmString()
        {
            InitializeComponent();
        }

        private void frmString_Load(object sender, EventArgs e)
        {
            plLeft.Width = ParentWidth / 2;
        }


        public override void BeforeShowValue()
        {
            base.redis = new RedisString(RedisClient.Server, RedisClient.DB);
            base.BeforeShowValue();
        }

        public override void InitValue()
        {
            this.kattr.ParentControl = this;
            this.kattr.OnLoad();

            this.rtbValue.Text = base.redis.Get(base.Key.Text);
            base.InitValue();
        }

        public override void Reload()
        {
            base.Reload();
        }

        public override void Remove()
        {
            base.Remove();
        }

        public override void CDispose()
        {
            this.kattr.Dispose();
            this.rtbValue.Clear();
            base.CDispose();
        }

        private void operation_Operation_Click(Opera _opera)
        {
            switch (_opera)
            {
                case Opera.Save:
                    this.Save();
                    break;
                case Opera.Reload:
                    this.Reload();
                    break;
                case Opera.Remove:
                    this.Remove();
                    break;
            }
        }

        private void Save()
        {
            if (!base.redis.Set(this.Key.Text, rtbValue.Text))
            {
                Tip.Show("操作失败,请重新载入后再操作");
            }
        }
    }
}
