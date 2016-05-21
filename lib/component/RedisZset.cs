using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using redis_manage.info;

namespace redis_manage.lib.component
{
    class RedisZset : RedisKvBase
    {
        public RedisZset()
            : this(null, -1)
        {

        }

        public RedisZset(ServerInfo serverinfo, int dbid)
            : base(serverinfo, dbid)
        {

        }

        public override long Count(string key)
        {
            long length = base.GetSortedSetCount(key);
            return length;
        }
    }
}
