using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using redis_manage.tools;

namespace redis_manage.info
{
    public class KeyFolderInfo
    {
        public KeyFolderInfo()
        {
            this.Map = new Dictionary<string, KeyFolderInfo>();
            this.HasChildFolder = false;
        }
        
        public Dictionary<string, KeyFolderInfo> Map { set; get; }
       

        /// <summary>
        /// 解析key
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public int ResolveKey(string[] keys)
        {
            if (keys == null || keys.Length == 0)
            {
                return 0;
            }
            int count = keys.Length;
            int depth = 1;
            KeyFolderInfo parent = this;
            if (!parent.HasChildFolder && count > 1)
            {
                parent.HasChildFolder = true;
            }
            string key;
            foreach (string item in keys)
            {
                key = item;// TextConvert.ParseKey(item);
                if (!parent.Map.ContainsKey(key))
                {
                    parent.Map[key] = new KeyFolderInfo();
                }
                parent = parent.Map[key];
                if (!parent.HasChildFolder && count > depth)
                {
                    parent.HasChildFolder = true;
                }
                depth++;
            }
            return depth;
        }


        public bool HasChildFolder { set; get; }

        public bool IsFolder
        {
            get { return this.Map != null && this.Map.Count > 0; }
        }
    }
}
