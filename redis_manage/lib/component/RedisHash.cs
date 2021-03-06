﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using redis_manage.info;

namespace redis_manage.lib.component
{
    public class RedisHash : RedisKvBase
    {
        public RedisHash()
            : this(null, -1)
        {

        }

        public RedisHash(ServerInfo serverinfo, int dbid)
            : base(serverinfo, dbid)
        {

        }

        public override long Count(string key)
        {
            long length = base.GetHashCount(key);
            return length;
        }
    }
}
