using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Redis;
using redis_manage.info;

namespace redis_manage.lib
{
    public class ClientManager
    {
        //public int VersionNumber;

        private static object _lock = new object();
        private static ClientManager instance;
        public static ClientManager Create()
        {
            lock (_lock)
            {
                if (instance == null)
                {                    
                    instance = new ClientManager();
                }
                return instance;
            }
        }


        private Dictionary<string, RedisClient> ClientMap;

        public RedisClient GetClient(ServerInfo _server)
        {
            if (ClientMap == null)
            {
                ClientMap = new Dictionary<string, RedisClient>();
            }
            string serverkey = string.Format("{0}-{1}-{2}-{3}", _server.ServerName, _server.Host, _server.Port, _server.Password);
            if (!ClientMap.ContainsKey(serverkey))
            {
                if (string.IsNullOrEmpty(_server.Password))
                {
                    ClientMap[serverkey] = new RedisClient(_server.Host, _server.Port);
                }
                else
                {
                    ClientMap[serverkey] = new RedisClient(_server.Host, _server.Port, _server.Password);
                }
            }
            RedisClient rc = ClientMap[serverkey];
            return rc;
        }

    }
}

