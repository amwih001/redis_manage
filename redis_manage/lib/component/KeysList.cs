using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using redis_manage.info;
using Hibernate.Util;
using redis_manage.tools;

namespace redis_manage.lib.component
{
    public class KeysList : RedisKvBase
    {
        public int PageSize { set; get; }
        public int PageIndex { set; get; }
        public int Total { set; get; }

        private List<string> list;
        private List<KeyFolderInfo> folder;
        /// <summary>
        /// key 数据包
        /// </summary>
        public KeyFolderInfo KeyFolder { set; get; }

        public KeysList() : this(null , -1)
        {

        }

        public KeysList(ServerInfo serverinfo , int dbid)
            : base(serverinfo , dbid)
        {
            this.PageIndex = 1;
            this.PageSize = 300;
        }

        /// <summary>
        /// 重置所有数据
        /// </summary>
        public void ResetAll()
        {
            if (this.list != null)
            {
                this.list.Clear();
            }
            this.list = null;
            if (this.folder != null)
            {
                this.folder.Clear();
            }
            this.folder = null;
            this.Total = 0;
            this.ResetPageInfo();
        }

        /// <summary>
        /// 移除一个key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            bool flag = base.Del(key);
            if (this.list != null)
            {
                this.list.Remove(key);
                return flag;
            }
            return false;
        }
        /// <summary>
        /// 替换一个元素的值
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public bool Replace(string from , string to)
        {
            if (this.list != null)
            {
                int ix = this.list.IndexOf(from);
                if (ix != -1)
                {
                    this.list[ix] = to;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 重置分页数据
        /// </summary>
        public void ResetPageInfo()
        {
            this.PageIndex = 1;
        }

        public List<string> Get()
        {
            return this.Get(null);
        }

        public List<string> Get(string pattern)
        {
            return SplitListKey(pattern);
        }

        private List<string> SplitListKey(string pattern)
        {
            List<string> tmp = null;
            if (this.list == null)
            {
                this.list = base.Keys("*");
                if (this.list == null)
                {
                    this.list = new List<string>();
                }
                this.ParseKeyFolder();
            }

            if (pattern == null)
            {
                tmp = this.list;
            }
            else
            {
                tmp = this.list.FindAll((string item) => { return item.StartsWith(pattern); });
            }
            this.Total = tmp.Count;

            List<string> result = new List<string>();
            if (tmp != null)
            {
                int index = (this.PageIndex - 1) * this.PageSize;
                int count = this.PageSize;
                int lcount = tmp.Count;

                if (count + index > lcount)
                {
                    count = lcount - index;
                }
                if (count > lcount)
                {
                    count = Math.Max(0, lcount);
                }
                result = tmp.GetRange(index, count);
            }
            return result;
        }

        private void ParseKeyFolder()
        {
            if (this.list != null)
            {
                this.KeyFolder = null;
                this.KeyFolder = TextConvert.GetFolder(this.list);
            }
        }

        public int TotalPage
        {
            get
            {
                int _total = Tools.ToInt(Math.Ceiling((double)(this.Total) / (double)(this.PageSize)));
                return Math.Max(_total, 1);
            }
        }

        public bool IsFirst
        {
            get { return this.PageIndex <= 1; }
        }
        public bool IsLast
        {
            get { return this.TotalPage <= this.PageIndex; }
        }

        public override long Count(string key)
        {
            return this.Total;
        }
    }
}
