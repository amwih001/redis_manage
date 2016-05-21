using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hibernate.Util;

namespace redis_manage.tools
{
    public class Tip
    {
        public static DialogResult Show(bool ret)
        {
            string msg = ret ? "设置成功!" : "设置失败!";
            return Show(msg);
        }

        public static DialogResult Show(string message)
        {
             return Show(message, "提示");
        }

        public static DialogResult Show(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowOKCancel(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        public static void ShowUpgrade(string vs , string downurl , string detail)
        {
            detail = string.Format("发现新版本: {0},是否确定要更新? \n\n{1}", vs, detail.Replace("///", "\n"));
            if (Tip.ShowOKCancel(detail, "发现新版本") == System.Windows.Forms.DialogResult.OK)
            {
                Tools.OpenWebPage(downurl);
            }
        }
    }
}
