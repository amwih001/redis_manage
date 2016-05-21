using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace redis_manage.info
{
    public class ServerInfo
    {
        public ServerInfo()
        {
            this.Host = "127.0.0.1";
            this.Password = "";
            this.Port = 6379;
            this.ServerName = this.Host + ":" + this.Port;
        }

        /// <summary>
        /// 服务器名
        /// </summary>
        public string ServerName { set; get; }
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string Host { set; get; }
        /// <summary>
        /// 端口
        /// </summary>
        public int Port { set; get; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { set; get; }
    }
}
