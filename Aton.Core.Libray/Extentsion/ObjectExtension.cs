using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.Library.Extentsion
{
    /// <summary>
    /// 基础类扩展
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// 空时间
        /// </summary>
        public static DateTime NullDateTime
        {
            get { return DateTime.Parse("9999-1-1 00:00:00"); }
        }

        #region 转换成Int型
        /// <summary>
        /// 转换成Int型,转换失败则为0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>转换成Int型,转换失败则为0</returns>
        public static int ToInt32(this object value)
        {
            if (value == null || value.GetType() == typeof(DBNull))
            {
                return 0;
            }
            int result;
            return int.TryParse(value.ToString(), out result) ? result : 0;
        }
        #endregion

        #region 转换为UInt32类型
        /// <summary>
        /// 转换为UInt32类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static uint ToUInt32(this object value)
        {
            if (value == null || value.GetType() == typeof(DBNull))
            {
                return 0;
            }

            uint result;
            return uint.TryParse(value.ToString(), out result) ? result : 0;
        }
        #endregion

        #region 转换为Short类型
        /// <summary>
        /// 转换为UInt16类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ushort ToUShort(this object value)
        {
            if (value == null || value.GetType() == typeof(DBNull))
            {
                return 0;
            }

            UInt16 result;
            return UInt16.TryParse(value.ToString(), out result) ? result : UInt16.MinValue;
        }
        /// <summary>
        /// 转换为Int16类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static short ShortParse(object value)
        {
            if (value == null || value.GetType() == typeof(DBNull))
            {
                return 0;
            }

            Int16 result;
            return Int16.TryParse(value.ToString(), out result) ? result : Int16.MinValue;
        }
        #endregion

        #region 转换为Byte类型
        /// <summary>
        /// 转换为Byte类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte ToByte(this object value)
        {
            if (value == null || value.GetType() == typeof(DBNull))
            {
                return 0;
            }

            byte result;
            return Byte.TryParse(value.ToString(), out result) ? result : Byte.MinValue;
        }
        #endregion

        #region  转换为Long类型
        /// <summary>
        /// 转换为Long类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToLong(this object value)
        {
            if (value == null || value.GetType() == typeof(DBNull))
            {
                return 0;
            }

            long result;
            return long.TryParse(value.ToString(), out result) ? result : long.MinValue;
        }
        #endregion

        #region  转换为ULong类型
        /// <summary>
        /// 转换为ULong类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ulong ToULong(this object value)
        {
            if (value == null || value.GetType() == typeof(DBNull))
            {
                return 0;
            }

            ulong result;
            return UInt64.TryParse(value.ToString(), out result) ? result : ulong.MinValue;
        }
        /// <summary>
        /// 转换为Int64类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long Int64Parse(object value)
        {
            if (value == null || value.GetType() == typeof(DBNull))
            {
                return 0;
            }
            long result;
            return Int64.TryParse(value.ToString(), out result) ? result : long.MinValue;
        }
        #endregion

        #region  转换为Double类型
        /// <summary>
        /// 转换为Double类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToDouble(this object value)
        {
            if (value == null || value.GetType() == typeof(DBNull))
            {
                return 0;
            }

            double result;
            return double.TryParse(value.ToString(), out result) ? result : double.MinValue;
        }
        #endregion

        #region  转换为Decimal类型
        /// <summary>
        /// 转换为Decimal类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this object value)
        {
            if (value == null || value.GetType() == typeof(DBNull))
            {
                return 0;
            }

            decimal result;
            return decimal.TryParse(value.ToString(), out result) ? result : decimal.MinValue;
        }
        #endregion

        #region  转换为Foat类型
        /// <summary>
        /// 转换为Foat类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float ToFloat(this object value)
        {
            if (value == null || value.GetType() == typeof(DBNull))
            {
                return 0;
            }

            float result;
            return float.TryParse(value.ToString(), out result) ? result : float.MinValue;
        }
        #endregion

        #region 转换为Bool类型
        /// <summary>
        /// 转换为Bool类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBool(this object value)
        {
            if (value == null || value.GetType() == typeof(DBNull))
            {
                return false;
            }

            bool result;
            return bool.TryParse(value.ToString(), out result) ? result : false;
        }
        #endregion

        #region 转换为String类型
        /// <summary>
        /// 转换为String类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToSafeString(this object value)
        {
            if (value == null || value.GetType() == typeof(DBNull))
            {
                return string.Empty;
            }

            return value.ToString();
        }
        #endregion

        #region 转换为DateTime类型
        /// <summary>
        /// 转换为DateTime类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object value)
        {
            if (value == null || value.GetType() == typeof(DBNull))
            {
                return NullDateTime;
            }
            DateTime dt = new DateTime();
            return DateTime.TryParse(value.ToString(), out dt) ? dt : NullDateTime;
        }
        #endregion
    }
}
