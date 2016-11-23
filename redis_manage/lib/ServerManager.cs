using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using redis_manage.info;
using Hibernate.Util;

namespace redis_manage.lib
{
    public class ServerManager
    {
        private static object _lock = new object();

        private static ServerManager instance;
        public static ServerManager Create()
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new ServerManager();
                }
                return instance;
            }
        }

        public List<ServerInfo> GetServers()
        {
            List<ServerInfo> servers = new List<ServerInfo>();
            if (!FSO.FileExists(Define.ServerXmlPath))
            {
                return servers;
            }
            ServerInfo server = null;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Define.ServerXmlPath);
                XmlElement rootElem = doc.DocumentElement;
                XmlNodeList personNodes = rootElem.GetElementsByTagName("connection");
                foreach (XmlNode node in personNodes)
                {
                    XmlElement xmlelement = (node as XmlElement);
                    if (xmlelement == null)
                    {
                        continue;
                    }
                    //<connection host="127.0.0.1" name="127.0.0.1" auth="" port="6379"/>
                    if (xmlelement.HasAttribute("host") && xmlelement.HasAttribute("name") && xmlelement.HasAttribute("port"))
                    {
                        server = new ServerInfo();
                        server.Host = xmlelement.GetAttribute("host");
                        server.ServerName = xmlelement.GetAttribute("name");
                        server.Port = Tools.ToInt(xmlelement.GetAttribute("port"), 6379);
                        server.Password = xmlelement.HasAttribute("auth") ? xmlelement.GetAttribute("auth") : string.Empty;
                        servers.Add(server);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return servers;
        }

        public bool Exists(string servername)
        {
            bool _exists = false;
            List<ServerInfo> list = this.GetServers();
            if (list != null & list.Count > 0)
            {
                foreach (ServerInfo item in list)
                {
                    if (item != null && item.ServerName == servername)
                    {
                        _exists = true;
                        break;
                    }
                }
            }
            return _exists;
        }

        public void AddServer(ServerInfo serverinfo)
        {
            List<ServerInfo> list = this.GetServers();
            list.Add(serverinfo);
            this.WriteXml(list);
        }

        public void DeleteServer(ServerInfo serverinfo)
        {
            List<ServerInfo> list = this.GetServers();
            ServerInfo s = null;
            foreach (ServerInfo item in list)
            {
                if(item.ServerName == serverinfo.ServerName)
                {
                    s = item;
                    break;
                }
            }
            if (s != null)
            {
                list.Remove(s);
            }
            this.WriteXml(list);
        }

        public void ModifyServer(ServerInfo from , ServerInfo to)
        {
            List<ServerInfo> list = this.GetServers();
            ServerInfo s = null;
            foreach (ServerInfo item in list)
            {
                if (item.ServerName == from.ServerName)
                {
                    s = item;
                    break;
                }
            }
            if (s != null)
            {
                s.ServerName = to.ServerName;
                s.Host = to.Host;
                s.Port = to.Port;
                s.Password = to.Password;
                this.WriteXml(list);
            }
        }

        private void WriteXml(List<ServerInfo> list)
        {
            StringBuilder xml = new StringBuilder();
            xml.AppendLine("<?xml version=\"1.0\"?>");
            xml.AppendLine("<connections>");
            foreach (ServerInfo item in list)
            {
                xml.AppendFormat("<connection host=\"{0}\" name=\"{1}\" auth=\"{2}\" port=\"{3}\"/>", item.Host, item.ServerName, item.Password, item.Port);
                xml.AppendLine();
            }
            xml.AppendLine("</connections>");
            FSO.WriteFile(Define.ServerXmlPath, xml.ToString(), false);
        }
    }
}
