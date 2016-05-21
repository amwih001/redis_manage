using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using redis_manage.info;

namespace redis_manage.lib.component
{
    class RedisSet : RedisKvBase
    {
        public RedisSet()
            : this(null, -1)
        {

        }

        public RedisSet(ServerInfo serverinfo, int dbid)
            : base(serverinfo, dbid)
        {

        }

        public override long Count(string key)
        {
            long length = base.GetSetCount(key);
            return length;
        }
    }
}
