using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Aton.Core.Library.Net
{
    /// <summary>
    /// 网络相关帮助类
    /// </summary>
    public class NetFunc
    {
        /// <summary>
        /// 获取本机IPV4列表
        /// </summary>
        /// <returns></returns>
        public static string[] GetLocalIpv4()
        {
            List<string> IpArray = new List<string>();
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in localIPs)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    IpArray.Add(ip.ToString());
            }
            return IpArray.ToArray();
        }

        /// <summary>
        /// 获取本机IPV4列表
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIpv4String()
        {
            StringBuilder sb = new StringBuilder();
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in localIPs)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    sb.AppendFormat("{0};",ip.ToString());
            }
            return sb.Remove(sb.Length-1,1).ToString();
        }

        /// <summary>
        /// 获取当前计算机名
        /// </summary>
        /// <returns></returns>
        public static string GetLocalHostName()
        {
            return System.Environment.MachineName;
        }
    }
}
