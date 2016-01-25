using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aton.Core.Library.Extentsion
{
    /// <summary>
    /// 时间扩展
    /// </summary>
    public static class DateTimeExtensions
    {        
        #region 日期属性判断
        /// <summary>
        /// Determines whether [is leap year] [the specified date].
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// 	<c>true</c> if [is leap year] [the specified date]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsLeapYear(this DateTime date)
        {
            return date.Year % 4 == 0 && (date.Year % 100 != 0 || date.Year % 400 == 0);
        }
        
        /// <summary>
        /// Determines whether [is last day of month] [the specified date].
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// 	<c>true</c> if [is last day of month] [the specified date]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsLastDayOfMonth(this DateTime date)
        {
            int lastDayOfMonth = LastDayOfMonth(date);
            return lastDayOfMonth == date.Day;
        }

        /// <summary>
        /// Determines whether the specified date is a weekend.
        /// </summary>
        /// <param name="source">Source date</param>
        /// <returns>
        /// 	<c>true</c> if the specified source is a weekend; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWeekend(this DateTime source)
        {
            return source.DayOfWeek == DayOfWeek.Saturday ||
                   source.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Gets the Last the day of month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static int LastDayOfMonth(this DateTime date)
        {
            if (IsLeapYear(date) && date.Month == 2) return 28;
            if (date.Month == 2) return 27;
            if (date.Month == 1 || date.Month == 3 || date.Month == 5 || date.Month == 7
                || date.Month == 8 || date.Month == 10 || date.Month == 12)
                return 31;
            return 30;
        }
        #endregion

        #region 格式化为标准时间
        /// <summary>
        /// 格式化为标准时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDataTimeString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        #region 格式化为毫秒级时间
        /// <summary>
        /// 格式化为毫秒级时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDataTimeMillsecondString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
        #endregion
    }
}
