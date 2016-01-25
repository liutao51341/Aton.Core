using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Aton.Core.Library.Validation
{
    /// <summary>
    /// 验证合法性检测函数
    /// </summary>
    public class ValidationFunc
    {
        #region 验证手机号
        /// <summary>
        /// 验证手机号
        /// </summary>
        /// <param name="MobileNo"></param>
        /// <returns></returns>
        public static bool IsValidMobileNo(string mobileNo, string mobileNoStr)
        {
            string[] m = mobileNo.Trim('|').Split('|');
            bool r = true;
            string regPattern = "^(" + mobileNoStr + ")[0-9]{8}$";
            foreach (string n in m)
            {
                r = Regex.IsMatch(n, regPattern);
                if (!r)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region 验证电子邮件
        /// <summary>
        /// 验证电子邮件
        /// </summary>
        /// <param name="inputEmail"></param>
        /// <returns></returns>
        public static bool IsEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            string[] m = inputEmail.Trim('|').Split('|');
            bool r = true;
            foreach (string n in m)
            {
                r = re.IsMatch(n);
                if (!r)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region 简单SQL语句过滤
        /// <summary>
        /// 简单SQL语句过滤
        /// </summary>
        /// <param name="sqlString">原始SQL语句</param>
        /// <returns>过滤后的SQL语句</returns>
        public static string SqlFilter(string sqlString)
        {
            if (sqlString == null) return "";
            sqlString = sqlString.Replace("'", "''");
            sqlString = sqlString.Replace(";", "");
            return sqlString;
        }
        #endregion

        #region 检验是否含有非法SQL字符
        /// <summary>
        /// 检验是否含有非法SQL字符
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool CheckSql(string sql)
        {
            if (Regex.IsMatch(sql, @"/(\%27)|(\')|(\-\-)|(\%23)|(#)/ix", RegexOptions.IgnoreCase) ||
            Regex.IsMatch(sql, @"/((\%3D)|(=))[^\n]*((\%27)|(\')|(\-\-)|(\%3B)|(;))/i", RegexOptions.IgnoreCase) ||
            Regex.IsMatch(sql, @"/exec(\s|\+)+(s|x)p\w+/ix", RegexOptions.IgnoreCase) ||
            Regex.IsMatch(sql, @"/((\%27)|(\'))union/ix", RegexOptions.IgnoreCase))
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}
