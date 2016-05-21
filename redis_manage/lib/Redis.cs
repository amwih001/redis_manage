using System;
using System.Collections.Generic;
using ServiceStack.Redis;
using System.Text;
using redis_manage.info;
using Hibernate.Util;
using System.Text.RegularExpressions;
using System.Linq;

namespace redis_manage.lib
{
    public class Redis
    {
        public int VersionNumber { set; get; }

        private static object _lock = new object();
        public int ConnectTimeout = 3;
        private PooledRedisClientManager prcm;
        public int DB { set; get; }
        private ServerInfo server;

        public ServerInfo Server
        {
            get { return server; }
            set
            {
                if (this.prcm != null && server.ServerName != value.ServerName)
                {
                    this.prcm = null;
                }
                server = value;
            }
        }
        

        public Redis(ServerInfo serverinfo) : this(serverinfo , -1)
        {
            
        }

        public Redis(ServerInfo serverinfo , int dbid)
        {
            if (serverinfo == null)
            {
                serverinfo = new ServerInfo();
            }
            this.DB = -1;
            if (dbid > -1)
            {
                this.DB = dbid;
            }
            this.Server = serverinfo;
        }

        //private PooledRedisClientManager CreateManager()
        //{
        //    if (this.prcm == null)
        //    {
        //        var pwd = string.IsNullOrEmpty(Server.Password) ? string.Empty : Server.Password + "@";
        //        string[] redisServ = new string[1] { string.Format("{0}{1}:{2}", pwd, Server.Host, Server.Port) };
        //        this.prcm = new PooledRedisClientManager((IEnumerable<string>)redisServ, (IEnumerable<string>)redisServ, new RedisClientManagerConfig()
        //        {
        //            DefaultDb = 0,
        //            MaxReadPoolSize = 1,
        //            MaxWritePoolSize = 1,
        //            AutoStart = true
        //        });
        //    }
        //    return this.prcm;
        //}

        private RedisClient CreateManager()
        {
            return ClientManager.Create().GetClient(this.Server);
        }


        private void SetDB(RedisClient client)
        {
            
            if (this.DB > -1)
            {
                client.ChangeDb(this.DB);
            }
        }

        public int DataBases()
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    string val = client.GetConfig("databases");
                    return Tools.ToInt(val.ToLower().Replace("databases", "") , 16);
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public List<string> Keys(string pattern)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.SearchKeys(pattern);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Del(string key)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.Remove(key);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataType Type(string key)
        {
            DataType dt = DataType.Unknown;
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    string type = client.Type(key);

                    switch (type)
                    { 
                        case "string":
                            dt = DataType.String;
                            break;
                        case "hash":
                            dt = DataType.Hash;
                            break;
                        case "set":
                            dt = DataType.Set;
                            break;
                        case "list":
                            dt = DataType.List;
                            break;
                        case "zset":
                            dt = DataType.Zset;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return dt;
        }

        public Dictionary<string, string> Info()
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);

                    //#region 有问题,待修复
                    //if (ClientManager.Create().VersionNumber == 0)
                    //{
                    //    ClientManager.Create().VersionNumber = client.ServerVersionNumber;
                    //    Define.RedisVS = client.ServerVersionNumber;
                    //}
                    //#endregion
                    this.VersionNumber = client.ServerVersionNumber;
                    return client.GetInfo();
                }
            }
            catch (Exception ex)
            {
                return new Dictionary<string,string>();
            }
        }

        public long DbSize()
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.DbSize;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool Exists(string key)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.ContainsKey(key);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 重命名一个key
        /// </summary>
        /// <param name="fromkey"></param>
        /// <param name="tokey"></param>
        /// <returns></returns>
        public bool RenameKey(string fromkey , string tokey)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    client.RenameKey(fromkey, tokey);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string Get(string key)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.GetValue(key);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Set(string key , string value)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    client.SetEntry(key, value);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public long Ttl(string key)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.Ttl(key);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool Expire(string key, int seconds)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.Expire(key, seconds);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Persist(string key)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.Persist(key);
                }
            }
            catch
            {
                return false;
            }
        }

        public DebugInfo DebugObject(string key)
        {
            DebugInfo debug = new DebugInfo();
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);

                    string str = client.DebugObject(key);
                    
                    Match m = new Regex("Value at:(?<valueat>[\\w]+)").Match(str);
                    if (m.Success)
                    {
                        debug.Valueat = m.Groups["valueat"].Value;
                    }

                    m = new Regex("refcount:(?<refcount>[\\d]+)").Match(str);
                    if (m.Success)
                    {
                        debug.Refcount = Tools.ToInt(m.Groups["refcount"].Value);
                    }

                    m = new Regex("encoding:(?<encoding>[\\w]+)").Match(str);
                    if (m.Success)
                    {
                        debug.Encoding = m.Groups["encoding"].Value;
                    }

                    m = new Regex("serializedlength:(?<serializedlength>[\\d]+)").Match(str);
                    if (m.Success)
                    {
                        debug.Serializedlength = Tools.ToLong(m.Groups["serializedlength"].Value);
                    }

                    m = new Regex("lru:(?<lru>[\\d]+)").Match(str);
                    if (m.Success)
                    {
                        debug.Lru = Tools.ToInt(m.Groups["lru"].Value);
                    }

                    m = new Regex("lru_seconds_idle:(?<lru_seconds_idle>[\\d]+)").Match(str);
                    if (m.Success)
                    {
                        debug.Lru_seconds_idle = Tools.ToInt(m.Groups["lru_seconds_idle"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return debug;
        }


        public long GetHashCount(string hashId)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.GetHashCount(hashId);
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public List<string> GetHashKeys(string hashId)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.GetHashKeys(hashId);
                }
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// 判断hash里面是否存在域
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public bool HashContainsEntry(string hashId, string field)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.HashContainsEntry(hashId, field);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 根据多个hash的域返回对应的值
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public List<string> GetValuesFromHash(string hashId, List<string> keys)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.GetValuesFromHash(hashId, keys.ToArray());
                }
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// 从hash里面移除一个域和值
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public bool RemoveEntryFromHash(string hashId, string field)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.RemoveEntryFromHash(hashId, field);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 更新/添加hash单个域的值
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetEntryInHash(string hashId, string key, string value)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    client.SetEntryInHash(hashId, key, value);
                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 获取set列表
        /// </summary>
        /// <param name="setId"></param>
        /// <returns></returns>
        public List<string> GetAllItemsFromSet(string setId)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.GetAllItemsFromSet(setId).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// 检查一个值是否在set中
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool SetContainsItem(string setId, string item)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.SetContainsItem(setId, item);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 从set中删除一个值
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool RemoveItemFromSet(string setId, string item)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    client.RemoveItemFromSet(setId, item);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 对set添加一个新的值
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AddItemToSet(string setId, string item)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    client.AddItemToSet(setId, item);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 获取一个set的数据长度
        /// </summary>
        /// <param name="setId"></param>
        /// <returns></returns>
        public long GetSetCount(string setId)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.GetSetCount(setId);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 分页的方式获取一个list
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<string> GetRangeFromList(string listId, int start, int end)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.GetRangeFromList(listId, start, end);
                }
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }
        
        /// <summary>
        /// 获取一个list的长度
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        public long GetListCount(string listId)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.GetListCount(listId);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool LPushItemToList(string listId, string value)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    client.PrependItemToList(listId, value);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RPushItemToList(string listId, string value)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    client.PushItemToList(listId, value);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 获取头/尾并删除
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="fromstart"></param>
        /// <returns></returns>
        public string GetHeadOrTailAndRemove(string listId, bool fromstart)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    if (fromstart)
                    {
                        return client.RemoveStartFromList(listId);
                    }
                    else
                    {
                        return client.RemoveEndFromList(listId);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool SetItemInList(string listId, int index, string value)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    client.SetItemInList(listId, index, value);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 获取zset的长度
        /// </summary>
        /// <param name="setId"></param>
        /// <returns></returns>
        public long GetSortedSetCount(string setId)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.GetSortedSetCount(setId);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public IDictionary<string, double> GetRangeWithScoresFromSortedSet(string setId, int start, int end)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.GetRangeWithScoresFromSortedSet(setId, start, end);
                }
            }
            catch (Exception ex)
            {
                return new Dictionary<string, double>();
            }
        }

        /// <summary>
        /// 从zset中删除一个元素
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool RemoveItemFromSortedSet(string setId, string value)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.RemoveItemFromSortedSet(setId, value);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 在zset中添加一个元素,如果元素存在则覆盖其score
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public bool AddItemToSortedSet(string setId, string value , double score)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    client.AddItemToSortedSet(setId, value, score);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 根据zset中的一个value返回score
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public double GetItemScoreInSortedSet(string setId, string value)
        {
            try
            {
                using (RedisClient client = this.CreateManager())
                {
                    if (this.ConnectTimeout > 0)
                        client.ConnectTimeout = this.ConnectTimeout;
                    this.SetDB(client);
                    return client.GetItemScoreInSortedSet(setId, value);
                }
            }
            catch (Exception ex)
            {
                return Double.NaN;
            }
        }
        /// <summary>
        /// 检查一个值是否在zset中
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SortedSetContainsItem(string setId, string value)
        {
            double d = this.GetItemScoreInSortedSet(setId, value);
            return !Double.IsNaN(d);
        }
    }
}
