using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;
using redis_manage.info;
using redis_manage.lib;
using redis_manage.tools;
using System.Windows.Forms;

namespace redis_manage.tabcontrol
{
    public class TabBase : DockContent
    {
        public KeyInfo Key;

        public DataType dt;

        public int PageSize;

        public int ParentWidth;

        public frmRedisClient RedisClient { set; get; }

        public RedisKvBase redis;


        //protected System.Windows.Forms.Panel plLeft;
        //protected System.Windows.Forms.Panel plRight;
        //protected System.Windows.Forms.GroupBox groupBox1;
        //protected controls.KeyAttribute kattr;

        public TabBase()
        {
            this.dt = DataType.Unknown;
            this.PageSize = 200;
            this.BackColor = System.Drawing.SystemColors.Window;
        }


        public void BaseInitializeComponent()
        {
            //this.plLeft = new System.Windows.Forms.Panel();
            //this.groupBox1 = new System.Windows.Forms.GroupBox();
            //this.plRight = new System.Windows.Forms.Panel();
            //this.kattr = new redis_manage.controls.KeyAttribute();
            //this.plLeft.SuspendLayout();
            //this.groupBox1.SuspendLayout();
            //this.plRight.SuspendLayout();
            //this.SuspendLayout();
            //// 
            //// plLeft
            //// 
            //this.plLeft.Controls.Add(this.groupBox1);
            //this.plLeft.Cursor = System.Windows.Forms.Cursors.Default;
            //this.plLeft.Dock = System.Windows.Forms.DockStyle.Left;
            //this.plLeft.Location = new System.Drawing.Point(10, 10);
            //this.plLeft.Name = "plLeft";
            //this.plLeft.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            //this.plLeft.Size = new System.Drawing.Size(285, 402);
            //this.plLeft.TabIndex = 0;
            //// 
            //// groupBox1
            //// 
            //this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.groupBox1.Location = new System.Drawing.Point(0, 0);
            //this.groupBox1.Name = "groupBox1";
            //this.groupBox1.Size = new System.Drawing.Size(275, 402);
            //this.groupBox1.TabIndex = 0;
            //this.groupBox1.TabStop = false;
            //this.groupBox1.Text = "数据";
            //// 
            //// plRight
            //// 
            //this.plRight.Controls.Add(this.kattr);
            //this.plRight.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.plRight.Location = new System.Drawing.Point(295, 10);
            //this.plRight.Name = "plRight";
            //this.plRight.Size = new System.Drawing.Size(439, 402);
            //this.plRight.TabIndex = 1;
            //// 
            //// kattr
            //// 
            //this.kattr.Debug = null;
            //this.kattr.Dock = System.Windows.Forms.DockStyle.Top;
            //this.kattr.Location = new System.Drawing.Point(0, 0);
            //this.kattr.Name = "kattr";
            //this.kattr.ParentControl = null;
            //this.kattr.Size = new System.Drawing.Size(439, 202);
            //this.kattr.TabIndex = 0;
            //// 
            //// frmString
            //// 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(744, 422);
            //this.Controls.Add(this.plRight);
            //this.Controls.Add(this.plLeft);
            //this.Name = "frmString";
            //this.Padding = new System.Windows.Forms.Padding(10);
            //this.TabText = "frmString";
            //this.Text = "frmString";
            //this.plLeft.ResumeLayout(false);
            //this.groupBox1.ResumeLayout(false);
            //this.plRight.ResumeLayout(false);
            //this.ResumeLayout(false);
        }


        public void SetParams(string contentkey, KeyInfo key , DataType type , frmRedisClient redisclient)
        {
            this.Tag = contentkey;
            this.Key = key;
            this.dt = type;
            this.RedisClient = redisclient;

            this.TabText = key.NotNull;
            this.Text = key.NotNull;
        }


        public virtual void BeforeShowValue()
        {
            
        }

        public virtual void InitValue()
        { 
            
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        public virtual void Reload()
        {
            if (!this.redis.Exists(this.Key.Text))
            {
                Tip.Show(string.Format("键值[{0}]已过期,点击确定关闭本窗口", this.Key.Text));
                RedisClient.CloseDocument(TextConvert.GetContentKey(this.redis.Server.ServerName, this.redis.DB, this.Key.Text));
            }
            else
            {
                this.InitValue();
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public virtual void Remove()
        {
            DialogResult dr = MessageBox.Show(string.Format("确定删除键值[{0}]吗?", this.Key.Text), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr != DialogResult.OK)
            {
                return;
            }
            if (!this.redis.Exists(this.Key.Text) || this.redis.Del(this.Key.Text))
            {
                RedisClient.CloseDocument(TextConvert.GetContentKey(this.redis.Server.ServerName, this.redis.DB, this.Key.Text));
                RedisClient.lvPagePanel.RemoveItemFromListView(this.Key.NotNull);
            }
            else
            {
                Tip.Show("删除失败,请重新刷新后再操作");
            }
        }

        public virtual void CDispose()
        {

        }

        public string GetTypeName
        {
            get
            {
                if (this.dt == DataType.String)
                {
                    return "String";
                }
                else if (this.dt == DataType.Zset)
                {
                    return "Zset";
                }
                else if (this.dt == DataType.Hash)
                {
                    return "Hash";
                }
                else if (this.dt == DataType.List)
                {
                    return "List";
                }
                else if (this.dt == DataType.Set)
                {
                    return "Set";
                }
                else
                {
                    return "Unknown";
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            this.CDispose();
            base.Dispose(disposing);
        }
    }
}
