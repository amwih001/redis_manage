using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using redis_manage.info;

namespace redis_manage.lib
{
    public abstract class RedisKvBase : Redis
    {
        public RedisKvBase(ServerInfo serverinfo , int dbid)
            : base(serverinfo , dbid)
        {

        }

        public abstract long Count(string key);        

    }
}
