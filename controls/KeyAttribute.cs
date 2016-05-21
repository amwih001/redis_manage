using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using redis_manage.lib;
using redis_manage.info;
using redis_manage.tools;
using redis_manage.tabcontrol;
using System.Text.RegularExpressions;
using Hibernate.Util;

namespace redis_manage.controls
{
    public partial class KeyAttribute : UserControl , IControl
    {
        private string Key { set; get; }
        public DebugInfo Debug { set; get; }
        private long Ttl { set; get; }

        public TabBase ParentControl { set; get; }

        /// <summary>
        /// 数据的长度
        /// </summary>
        public long Count { set; get; }

        public KeyAttribute()
        {
            InitializeComponent();
        }

        public void OnLoad()
        {
            this.Key = ParentControl.Key.Text;
            this.Count = ParentControl.redis.Count(this.Key);
            this.lblDataType.Text = ParentControl.GetTypeName;
            this.Debug = ParentControl.redis.DebugObject(this.Key);
            
            this.Ttl = ParentControl.redis.Ttl(this.Key);
            this.lblEncoding.Text = Debug.Encoding;
            this.lblDataSize.Text = this.Count.ToString();
            this.lblRefCount.Text = Debug.Refcount.ToString();
            this.lblSerializedlength.Text = TextConvert.ConvertSizeToShow(Debug.Serializedlength);

            this.lblServerName.Text = ParentControl.RedisClient.Server.ServerName;
            this.lblDataBaseId.Text = ParentControl.RedisClient.DB.ToString();

            this.txtKeyname.Text = this.Key;
            this.txtLifetime.Text = (this.Ttl > 0 ? this.Ttl.ToString() : "");
        }

        public void OnActive()
        {

        }

        /// <summary>
        /// 强制刷新
        /// </summary>
        public void OnRefresh()
        {
            this.OnLoad();
        }

        private void txtKeyname_Click(object sender, EventArgs e)
        {
            CopyKeyValue();
        }

        private void btnSaveLife_Click(object sender, EventArgs e)
        {
            string text = txtLifetime.Text.Trim();
            if (text == "0")
            {
                bool ret = ParentControl.redis.Persist(this.Key);
                string msg = "";
                if (ret)
                {
                    msg = "移除成功!";
                    this.txtLifetime.Clear();
                }
                else
                {
                    msg = "移除失败,key不存在或没有设置生存时间!";
                }
                Tip.Show(msg);
                return;
            }
            else if (new Regex("^\\d+$").Match(text).Success == false)
            {
                txtLifetime.Focus();
                Tip.Show("请输入一个非负数!");
                return;
            }
            Tip.Show(ParentControl.redis.Expire(this.Key, Tools.ToInt(text)));
        }

        private void lblKeyName_Click(object sender, EventArgs e)
        {
            CopyKeyValue();
        }

        private void CopyKeyValue()
        {
            txtKeyname.SelectAll();
            Clipboard.SetDataObject(txtKeyname.Text);
        }
    }
}
