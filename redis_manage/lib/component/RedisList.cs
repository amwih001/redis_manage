using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using redis_manage.info;

namespace redis_manage.lib.component
{
    class RedisList : RedisKvBase
    {
        public RedisList()
            : this(null, -1)
        {

        }

        public RedisList(ServerInfo serverinfo, int dbid)
            : base(serverinfo, dbid)
        {

        }

        public override long Count(string key)
        {
            long length = base.GetListCount(key);
            return length;
        }
    }
}
