using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Aton.Core
{
    /// <summary>
    /// 系统常量
    /// </summary>
    public sealed class AtonConstant
    {
        private AtonConstant() { }

        #region 无效或未知时间
        /// <summary>
        /// 无效或未知时间
        /// </summary>
        public static DateTime InvalidDateTime
        {
            get { return DateTime.Parse("9999-12-31"); }
        }
        #endregion

        #region 平台参数
        /// <summary>
        /// 支持平台名称
        /// </summary>
        public static string PlatformName
        {
            get { return "Aton"; }
        }

        /// <summary>
        /// 支持平台名称
        /// </summary>
        public static string PlatformVer
        {
            get { return "V2.0"; }
        }

        /// <summary>
        /// 平台开发者
        /// </summary>
        public static string PlatformDeveloper
        {
            get { return "刘涛"; }
        }

        /// <summary>
        /// 平台开发者
        /// </summary>
        public static string PlatformCopyright
        {
            get { return "Copyright ©  2011-2012 The Aton Framework.Liutao"; }
        }
        #endregion
    }
}
