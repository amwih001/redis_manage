using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using redis_manage.info;
using Hibernate.Util;
using System.ComponentModel;

namespace redis_manage.tools
{
    public class Cawd
    {
        private static object _lock = new object();
        private static Cawd instance;
        public static Cawd Create()
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new Cawd();
                }
                return instance;
            }
        }

        private string Upgrade_Vs = string.Empty;
        private string Upgrade_DownUrl = string.Empty;
        private string Upgrade_Detail = string.Empty;


        public void View()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.RunWorkerAsync();
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Upgrade_Vs) && !string.IsNullOrEmpty(this.Upgrade_DownUrl))
            {
                Tip.ShowUpgrade(this.Upgrade_Vs, this.Upgrade_DownUrl, this.Upgrade_Detail);
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string url = string.Format("{0}/app/redis?op=1&os={1}&vs={2}&mac={3}&bit={4}&appid={5}&svs={6}", Define.Host, SystemInfo.GetOsname, Define.Vs, SystemInfo.MACAddress, SystemInfo.GetSystemBit, Define.AppID , Define.RedisVS);
            string output = Collects.GetHtmlCode(url, Define.CharSet);
            if (output != "")
            {
                string[] arr = output.Split('|');
                if (arr.Length > 3)
                {
                    Define.ViewID = Tools.ToInt(arr[0]);
                    this.Upgrade_Vs = arr[1];
                    this.Upgrade_DownUrl = arr[2];
                    this.Upgrade_Detail = arr[3];
                }
            }
        }

        public bool Feedback(string contact, string content)
        {
            string url = string.Format("{0}/app/redis?op=2&os={1}&vs={2}&bit={3}&viewid={4}&contact={5}&content={6}&appid={7}&svs={8}", Define.Host, SystemInfo.GetOsname, Define.Vs, SystemInfo.GetSystemBit, Define.ViewID, contact, content , Define.AppID,Define.RedisVS);
            string output = Collects.GetHtmlCode(url, Define.CharSet);
            return Tools.ToInt(output) == 1;
        }

        public bool Upgrade(ref string vs , ref string downurl , ref string detail)
        {
            string url = string.Format("{0}/app/redis?op=3&vs={1}&appid={2}&rnd={3}&svs={4}", Define.Host, Define.Vs, Define.AppID, Tools.GetRandNum(short.MaxValue) , Define.RedisVS);
            string output = Collects.GetHtmlCode(url, Define.CharSet);
            if (output != "" && output.Contains("|"))
            {
                string[] arr = output.Split('|');
                if (arr.Length > 2)
                {
                    vs = arr[0];
                    downurl = arr[1];
                    detail = arr[2];
                    return true;
                }
            }
            return false;
        }

        public bool UploadException(string ex)
        {
            ex = ex.Replace("&", "").Replace("?", "");
            string url = string.Format("{0}/app/redis?op=5&vs={1}&appid={2}&rnd={3}&svs={4}&os={5}&bit={6}&viewid={7}&exception={8}", Define.Host, Define.Vs, Define.AppID, Tools.GetRandNum(short.MaxValue), Define.RedisVS, SystemInfo.GetOsname, SystemInfo.GetSystemBit, Define.ViewID, ex);
            string output = Collects.GetHtmlCode(url, Define.CharSet);
            return true;
        }
    }
}
