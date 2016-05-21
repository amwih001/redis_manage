using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using redis_manage.tools;

namespace redis_manage.info
{
    public class KeyInfo
    {
        public KeyInfo(string _text)
        {
            this.Text = _text;
        }

        public string Text { set; get; }

        /// <summary>
        /// 不为空的key显示方式
        /// </summary>
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
