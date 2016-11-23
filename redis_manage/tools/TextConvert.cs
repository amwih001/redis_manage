using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Hibernate.Util;
using redis_manage.info;

namespace redis_manage.tools
{
    public class TextConvert
    {
        public static int GetKeyCount(string str)
        {
            Regex regex = new Regex("keys=(?<count>\\d*)");
            Match match = regex.Match(str);
            if (match.Success)
            {
                return Tools.ToInt(match.Groups["count"].Value);
            }
            return 0;
        }

        public static string ParseKey(string key)
        {
            return string.IsNullOrEmpty(key) ? "\"\"" : key;
        }

        public static KeyFolderInfo GetFolder(List<string> keys)
        {
            KeyFolderInfo folder = new KeyFolderInfo();

            foreach (string key in keys)
            {
                if (key != null && key.Contains(Define.KeyFolder))
                {
                    string[] arr = key.Substring(0, key.LastIndexOf(Define.KeyFolder)).Split(Define.KeyFolder);
                    folder.ResolveKey(arr);
                    Console.WriteLine(arr.Length);
                }
            }
            return folder;
        }

        /// <summary>
        /// 文件大小单位转换 , 传入时的单位是B
        /// </summary>
        /// <param name="fileSize"></param>
        /// <returns></returns>
        public static string ConvertSizeToShow(long fileSize)
        {
            if (fileSize < 0)
            {
                return "0 B";
            }
            else if (fileSize >= 1024 * 1024 * 1024)
            {
                return string.Format("{0:########0.00} GB", ((Double)fileSize) / (1024 * 1024 * 1024));
            }
            else if (fileSize >= 1024 * 1024)
            {
                return string.Format("{0:####0.00} MB", ((Double)fileSize) / (1024 * 1024));
            }
            else if (fileSize >= 1024)
            {
                return string.Format("{0:####0.00} KB", ((Double)fileSize) / 1024);
            }
            else
            {
                return string.Format("{0} B", fileSize);
            }
        }

        /// <summary>
        /// 根据key,获取一个唯一标识, servername-dbid-key
        /// </summary>
        /// <param name="servername"></param>
        /// <param name="dbid"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetContentKey(string servername , int dbid , string key)
        {
            string contentkey = string.Format("{0}-.-{1}-.-{2}", servername, dbid, key);
            return contentkey;
        }

        public static string GetContentKeyPrefix(string servername)
        {
            string contentkey = string.Format("{0}-.-", servername);
            return contentkey;
        }

    }
}
