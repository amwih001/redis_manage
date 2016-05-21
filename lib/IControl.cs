using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace redis_manage.lib
{
    public interface IControl
    {
        /// <summary>
        /// 加载时事件
        /// </summary>
        void OnLoad();
        /// <summary>
        /// 激活时事件
        /// </summary>
        void OnActive();
        /// <summary>
        /// 刷新时事件
        /// </summary>
        void OnRefresh();
    }
}
