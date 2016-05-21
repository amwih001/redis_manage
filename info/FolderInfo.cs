using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using redis_manage.tools;

namespace redis_manage.info
{
    public class FolderInfo
    {
        /// <summary>
        /// key包的层次级别, 从0开始,默认-1
        /// </summary>
        public int Level { set; get; }
        /// <summary>
        /// 是否为最后节点
        /// </summary>
        public bool IsLast { set; get; }
        public FolderInfo(string _text)
            : this(_text, -1 , false)
        {
        }

        public FolderInfo(string _text , int _level , bool _islast)
        {
            this.Text = _text;
            this.Level = _level;
            this.IsLast = _islast;
        }

        /// <summary>
        /// key包名
        /// </summary>
        public string Text { set; get; }

        public string NotNull
        {
            get { return TextConvert.ParseKey(this.Text); }
        }

        public override string ToString()
        {
            return NotNull;
        }
    }
}
