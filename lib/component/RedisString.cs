using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using redis_manage.info;

namespace redis_manage.lib.component
{
    class RedisString : RedisKvBase
    {
        public RedisString()
            : this(null, -1)
        {

        }

        public RedisString(ServerInfo serverinfo, int dbid)
            : base(serverinfo, dbid)
        {

        }

        public override long Count(string key)
        {
            long length = 1;

            return length;
        }

        public string GetValue(string key)
        {
            return base.Get(key);
        }
    }
}
