using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace redis_manage.info
{
    public class DebugInfo
    {
        public DebugInfo()
        {
            this.Valueat = "";
            this.Refcount = 0;
            this.Encoding = "";
            this.Serializedlength = 0;
            this.Lru = 0;
            this.Lru_seconds_idle = 0;
        }

        public string Valueat { set; get; }
        /// <summary>
        /// 引用数量
        /// </summary>
        public int Refcount { set; get; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Encoding { set; get; }
        /// <summary>
        /// 值大小,单位(B)
        /// </summary>
        public long Serializedlength { set; get; }

        public int Lru { set; get; }

        /// <summary>
        /// 空闲时间 , 单位秒
        /// </summary>
        public int Lru_seconds_idle { set; get; }
    }
}
