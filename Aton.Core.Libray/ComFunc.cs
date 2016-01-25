using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Xml;
using System.Web.Script.Serialization;
using System.Globalization;

namespace Aton.Core.Library
{
    /// <summary>
    /// 常用函数
    /// </summary>
    public class ComFunc
    {
        /// <summary>
        /// 构造函数 防止实例化
        /// </summary>
        protected ComFunc() { }

        #region 静态变量
        /// <summary>
        /// 16进制字符串数组
        /// </summary>
        private static char[] hexDigits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        #endregion

        #region 获取当前时间戳
        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        /// <returns></returns>
        public string GetCurrentDTStamp()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        #endregion

        #region 全角-半角转换函数
        /// <summary>
        /// 半角转全角
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static String ToSBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new String(c);
        }

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static String ToDBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }
        #endregion

        #region 根据长度拆分字符串
        /// <summary>
        /// 根据长度拆分字符串
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string[] SplitStringByLength(string source, int length)
        {
            List<string> list = new List<string>();

            if (source == "" || length == 0)
            {
                list.Add(source);

                return list.ToArray();
            }

            int beginIndex = 0;
            while (source.Length - beginIndex >= length)
            {
                list.Add(source.Substring(beginIndex, length));
                beginIndex += length;
            }
            string lastStr = source.Substring(beginIndex);
            if (lastStr.Trim() != "")
            {
                list.Add(lastStr);
            }

            return list.ToArray();
        }
        #endregion

        #region 16进制转10进制Int
        /// <summary>
        /// 16进制转10进制Int
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static int HexToInt(string hex)
        {
            int result = 0;
            try
            {
                result = int.Parse(hex, NumberStyles.HexNumber);
            }
            catch (Exception)
            {
                return 0;
            }

            return result;
        }
        #endregion

        #region 16进制转10进制Long
        /// <summary>
        /// 16进制转10进制Long
        /// </summary>
        /// <param name="hex">16进制字符串</param>
        /// <returns></returns>
        public static long HexToLong(string hex)
        {
            long result = 0;
            try
            {
                result = long.Parse(hex, NumberStyles.HexNumber);
            }
            catch (Exception)
            {
                return 0;
            }

            return result;
        }
        #endregion

        #region 生成随机密码
        /// <summary>
        /// 生成随机密码
        /// </summary>
        /// <param name="pwdLength"></param>
        /// <param name="random">随机对象</param>
        /// <returns></returns>
        public static string MakePassword(int pwdLength, Random random)
        {
            var randomchars = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ@#$%{&(]";
            var sb = new StringBuilder();
            for (int i = 0; i < pwdLength; i++)
            {
                sb.Append(randomchars[random.Next() % 70]);
            }
            return sb.ToString();
        }
        #endregion

        #region 字节序列编码为字符串
        /// <summary>
        /// 字节序列编码为字符串
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string GetString(byte[] buffer)
        {

            return System.Text.Encoding.GetEncoding("UTF-8").GetString(buffer);
        }
        #endregion

        #region 字符串为字节序列编码
        /// <summary>
        /// 字符串为字节序列编码
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static byte[] GetBytes(string buffer)
        {
            return System.Text.Encoding.GetEncoding("UTF-8").GetBytes(buffer);
        }
        #endregion

        #region 10进制转多进制规则
        /// <summary>
        /// 10进制转多进制规则
        /// </summary>
        /// <param name="num">10进制数</param>
        /// <param name="chars">字符串(数字+字母)</param>
        /// <returns></returns>
        public static string BaseConvert(int num, string chars)
        {
            if (num == 0) return "0";

            StringBuilder builder = new StringBuilder();
            while (num > 0)
            {
                builder.Insert(0, (chars[num % chars.Length]));
                num /= chars.Length;
            }

            return builder.ToString();
        }
        #endregion

        #region 10进制转36进制规则
        /// <summary>
        /// 10进制转36进制规则
        /// </summary>
        /// <param name="num">10进制数</param>
        /// <returns></returns>
        public static string ConvertToBase36(int num)
        {
            string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return BaseConvert(num, chars);
        }
        #endregion

        #region 36进制转10机制规则
        /// <summary>
        /// 36进制转10机制规则
        /// </summary>
        /// <param name="Num">36进制数</param>
        /// <param name="n">10进制数</param>
        /// <returns></returns>
        public static string ConvertToBase10(string Num, int n)
        {
            char[] nums = Num.ToCharArray();
            int d = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                string number = nums[i].ToString();
                if (n == 36)
                {
                    switch (number.ToUpper())
                    {
                        case "A":
                            number = "10";
                            break;
                        case "B":
                            number = "11";
                            break;
                        case "C":
                            number = "12";
                            break;
                        case "D":
                            number = "13";
                            break;
                        case "E":
                            number = "14";
                            break;
                        case "F":
                            number = "15";
                            break;
                        case "G":
                            number = "16";
                            break;
                        case "H":
                            number = "17";
                            break;
                        case "I":
                            number = "18";
                            break;
                        case "J":
                            number = "19";
                            break;
                        case "K":
                            number = "20";
                            break;
                        case "L":
                            number = "21";
                            break;
                        case "M":
                            number = "22";
                            break;
                        case "N":
                            number = "23";
                            break;
                        case "O":
                            number = "24";
                            break;
                        case "P":
                            number = "25";
                            break;
                        case "Q":
                            number = "26";
                            break;
                        case "R":
                            number = "27";
                            break;
                        case "S":
                            number = "28";
                            break;
                        case "T":
                            number = "29";
                            break;
                        case "U":
                            number = "30";
                            break;
                        case "V":
                            number = "31";
                            break;
                        case "W":
                            number = "32";
                            break;
                        case "X":
                            number = "33";
                            break;
                        case "Y":
                            number = "34";
                            break;
                        case "Z":
                            number = "35";
                            break;
                    }
                }
                Double power = Math.Pow(Convert.ToDouble(n), Convert.ToDouble(nums.Length - (i + 1)));
                d = d + Convert.ToInt32(number) * Convert.ToInt32(power);
            }
            return d.ToString();
        }
        #endregion

        #region  将字节数组转换成16进制字符串
        /// <summary>
        /// 将字节数组转换成16进制字符串
        /// </summary>
        /// <param name="bytes">待转换的字节数组</param>
        /// <param name="revert">是否反转</param>
        /// <returns>转换结果</returns>
        public static string ToHexString(byte[] bytes, bool revert)
        {
            if (bytes == null) return "";
            char[] chars = new char[bytes.Length * 2];
            if (revert)
            {
                for (int i = bytes.Length - 1; i >= 0; i--)
                {
                    int b = bytes[i];
                    chars[(i - bytes.Length + 1) * 2] = hexDigits[b >> 4];
                    chars[(i - bytes.Length + 1) * 2 + 1] = hexDigits[b & 15];
                }
            }
            else
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    int b = bytes[i];
                    chars[i * 2] = hexDigits[b >> 4];
                    chars[i * 2 + 1] = hexDigits[b & 15];
                }
            }
            return new string(chars);
        }

        #endregion

        #region  将16进制字符串转换成字节数组
        /// <summary>
        /// 将16进制字符串转换成字节数组
        /// </summary>
        /// <param name="source">16进制字符串</param>
        /// <returns>转换结果</returns>
        public static byte[] FromHexString(string source)
        {
            if (string.IsNullOrEmpty(source)) return new byte[0];
            char[] chars = source.ToCharArray();
            byte[] bytes = new byte[chars.Length / 2];
            for (int i = 0; i < chars.Length / 2; i++)
            {
                bytes[i] = Convert.ToByte(chars[i * 2].ToString() + chars[i * 2 + 1].ToString(), 16);
            }
            return bytes;
        }
        #endregion

        #region IP地址转换为Uint32
        /// <summary>
        ///  IP地址转换为Uint32
        /// </summary>
        /// <param name="ipaddress"></param>
        /// <returns></returns>
        public static UInt32 ConvertIPToUInt32(string ipaddress)
        {
            UInt32 ipvalue = 0;
            IPAddress addr;
            if (IPAddress.TryParse(ipaddress, out addr))
            {
                foreach (byte b in addr.GetAddressBytes())
                {
                    ipvalue <<= 8;
                    ipvalue |= b;
                }
            }
            return ipvalue;
        }
        #endregion

        #region Uint32转换为IP地址
        /// <summary>
        /// Uint32转换为IP地址
        /// </summary>
        /// <param name="ipaddress"></param>
        /// <returns></returns>
        public static string ConvertUInt32ToIP(uint ipaddress)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}.", (ipaddress & 4278190080) >> 24);
            sb.AppendFormat("{0}.", (ipaddress & 16711680) >> 16);
            sb.AppendFormat("{0}.", (ipaddress & 65280) >> 8);
            sb.Append(ipaddress & 255);

            return sb.ToString();
        }
        #endregion

        #region 字节数组转换为Base64字符串
        /// <summary>
        /// 字节数组转换为Base64字符串
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns></returns>
        public static string BytesToBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        #endregion

        #region 字节数组转换为ASCII字符串
        /// <summary>
        /// 字节数组转换为ASCII字符串
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>ascii字符串</returns>
        public static string ToAsciiString(byte[] bytes)
        {
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
        /// <summary>
        /// ASCII字符串转换为字节数组
        /// </summary>
        /// <param name="asciiString"></param>
        /// <returns></returns>
        public static byte[] FromAsciiString(string asciiString)
        {
            return System.Text.Encoding.ASCII.GetBytes(asciiString);
        }
        #endregion

        #region Base64字符串转换为字节数组
        /// <summary>
        /// Base64字符串转换为字节数组
        /// </summary>
        /// <param name="base64string">Base64编码的字符串</param>
        /// <returns></returns>
        public static byte[] Base64ToBytes(string base64string)
        {
            return Convert.FromBase64String(base64string);
        }
        #endregion

        #region 数组转换为分隔字符串
        /// <summary>
        /// 数组转换为分隔字符串
        /// </summary>
        /// <param name="list">数组或List</param>
        /// <param name="splitChar">分隔符</param>
        /// <returns></returns>
        public static string ConvertToSplitString<T>(IEnumerable<T> list, char splitChar)
        {
            if (list == null) return string.Empty;
            var sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendFormat("{0}{1}", item, splitChar);
            }
            if (sb.Length == 0) return string.Empty;
            return sb.Remove(sb.Length - 1, 1).ToString();
        }
        /// <summary>
        /// 数组转换为包围分隔字符串
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="list">数组或List</param>
        /// <param name="splitChar">分隔符</param>
        /// <param name="wrapChar">包字符</param>
        /// <returns></returns>
        public static string ConvertToSplitString<T>(IEnumerable<T> list, char splitChar, char wrapChar)
        {
            var sb = new StringBuilder();

            foreach (var item in list)
            {
                sb.AppendFormat("{0}{1}{0}{2}", wrapChar, item, splitChar);
            }
            if (sb.Length == 0) return string.Empty;
            return sb.Remove(sb.Length - 1, 1).ToString();
        }
        #endregion
    }
}
