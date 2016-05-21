using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hibernate.Util;

namespace redis_manage.info
{
    public class Define
    {
        /// <summary>
        /// 最后链接的redis版本
        /// </summary>
        public static int RedisVS = 0;

        public const string AppName = "RedisManager";

        public const int AppID = 10000;

        public const char KeyFolder = ':';

        public static string ServerXmlPath = Constant.AppDir + "connections.xml";

        public static string LogPath = Constant.AppDir + "log/" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

        /// <summary>
        /// 末尾不带/
        /// </summary>
        public const string Host = "http://www.likelys.com";  //"http://127.0.0.1:81/blog";// 


        public static string VsHistory = Host + "/article/topic-10533.html?from=redismanager";
        public static string BlogHome = Host + "?from=redismanager";

        public static string Vs
        {
            get
            {
                try
                {
                    Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                    return v.Major + "." + v.Minor;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public static int ViewID { set; get; }

        public const string CharSet = "utf-8";

        public static string NewVs { set; get; }
    }

    public enum TreeNodeType
    { 
        Top = 1,
        Server = 2,
        DataBase = 3,
        Folder = 4
    }

    public enum DataType
    {
        Unknown = 0,
        String = 1,
        Hash = 2,
        Zset = 3,
        List = 4,
        Set = 5
    }

    public enum Opera
    { 
        Save = 1,
        Reload = 2,
        Remove = 3
    }
}
