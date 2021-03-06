﻿using System;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="DateTime"/> 扩展
    /// </summary>
    public static class DateTimeExtensions
    {
        #region Sql Server 数据库 DateTime 初始值 
        /// <summary>
        /// Sql Server 数据库 <see cref="DateTime"/> 初始值 : 公元 1900 年 1 月 1 号 00 点 00 分 00 秒 000 毫秒
        /// </summary>
        public static DateTime MsSQLDateTimeInitial { get => new DateTime(1900, 1, 1, 0, 0, 0, 0); }
        #endregion

        #region Sql Server 数据库 DateTime 最小值 
        /// <summary>
        /// Sql Server 数据库 <see cref="DateTime"/> 最小值 : 公元 1900 年 1 月 1 号 00 点 00 分 00 秒 000 毫秒
        /// </summary>
        public static DateTime MsSQLDateTimeMinValue { get => MsSQLDateTimeInitial; }
        #endregion

        #region Sql Server 数据库 DateTime 最大值 
        /// <summary>
        /// Sql Server 数据库 <see cref="DateTime"/> 最大值 : 公元 9999 年 12 月 31 号 11 点 59 分 59 秒 999 毫秒
        /// </summary>
        public static DateTime MsSQLDateTimeMaxValue { get => DateTime.MaxValue; }
        #endregion

        #region MySql 数据库 DateTime 初始值 
        /// <summary>
        /// MySql 数据库 <see cref="DateTime"/> 初始值 : 公元 1753 年 1 月 1 号 00 点 00 分 00 秒 000 毫秒
        /// </summary>
        public static DateTime MySqlDateTimeInitial { get => new DateTime(1753, 1, 1, 0, 0, 0, 0); }
        #endregion

        #region MySql 数据库 DateTime 最小值
        /// <summary>
        /// MySql 数据库 <see cref="DateTime"/> 最小值 : 公元 1753 年 1 月 1 号 00 点 00 分 00 秒 000 毫秒
        /// </summary>
        public static DateTime MySqlDateTimeMinValue { get => MySqlDateTimeInitial; }
        #endregion

        #region MySql 数据库 DateTime 最大值
        /// <summary>
        /// MySql 数据库 <see cref="DateTime"/> 最大值 : 公元 9999 年 12 月 31 号 11 点 59 分 59 秒 999 毫秒
        /// </summary>
        public static DateTime MySqlDateTimeMaxValue { get => DateTime.MaxValue; }
        #endregion

        #region 将当前 DateTime 实例转换为 Unix 时间
        /// <summary>
        /// 将当前 <see cref="DateTime"/> 实例转换为 Unix 时间
        /// </summary>
        /// <param name="date">要转换的 <see cref="DateTime"/> 实例</param>
        /// <returns><see cref="DateTime"/> 实例对应的 Unix 时间</returns>
        public static long ToUnixTime(this DateTime date) => (date.ToUniversalTime().Ticks - 621355968000000000L) / 10000000L;
        #endregion

        #region 将当前 DateTime 实例转换为格式化后的日期的字符串表示形式
        /// <summary>
        /// 将当前 <see cref="DateTime"/> 实例转换为格式化后的日期的字符串表示形式
        /// </summary>
        /// <param name="dateTime">要转换的 <see cref="DateTime"/> 实例</param>
        /// <param name="format">标准或自定义日期和时间格式的字符串，默认为"yyyy-MM-dd"。</param>
        /// <returns>当前 <see cref="DateTime"/> 对象的值的字符串表示形式，由 format 指定</returns>
        public static string ToFormatDate(this DateTime dateTime, string format = "yyyy-MM-dd") => dateTime.ToString(format);
        #endregion

        #region 将当前 DateTime 实例转换为格式化后的日期时间的字符串表示形式
        /// <summary>
        /// 将当前 <see cref="DateTime"/> 实例转换为格式化后的日期时间的字符串表示形式
        /// </summary>
        /// <param name="dateTime">要转换的 <see cref="DateTime"/> 实例</param>
        /// <param name="format">标准或自定义日期和时间格式的字符串，默认为"yyyy-MM-dd HH:mm:ss"。</param>
        /// <returns>当前 <see cref="DateTime"/> 对象的值的字符串表示形式，由 format 指定</returns>
        public static string ToFormatDateTime(this DateTime dateTime, string format = "yyyy-MM-dd HH:mm:ss") => dateTime.ToString(format);
        #endregion

        #region 从当前 DateTime 实例中计算出与当前时间的时间差
        /// <summary>
        /// 从当前 <see cref="DateTime"/> 实例中计算出与当前时间的时间差
        /// </summary>
        /// <param name="time">要取得时间差的 <see cref="DateTime"/> 实例</param>
        /// <returns>
        /// 如果是之前的时间差大于365天，则返回“N前年”；
        /// 如果是之前时间差小于365天，大于30天，则返回“N个月前”；
        /// 如果是之前时间差小于30天，则返回“N天前”；
        /// 如果是之前时间差小于24小时，则返回“N个小时前”；
        /// 如果是之前时间差小于60分钟，则返回“N分钟前”；
        /// 如果是之前时间差小于60秒，则返回“N秒前”；
        /// 如果是之后时间差大于365天，则返回“N年后”；
        /// 如果是之后时间差小于365天，大于30天，则返回“N个月后”；
        /// 如果是之后时间差小于30天，则返回“N天后”；
        /// 如果是之后时间差小于24小时，则返回“N个小时后”；
        /// 如果是之后时间差小于60分钟，则返回“N分钟后”；
        /// 如果是之后时间差小于60秒，则返回“N秒后”；
        /// </returns>
        public static string TimeRange(this DateTime time)
        {
            var diff = DateTime.Now.Subtract(time);
            if (diff.Seconds > 0) return GetBeforeTimeRange(time);
            return GetAfterTimeRange(time);
        }
        #endregion

        #region 从当前 DateTime 实例中计算出与当前时间之前的时间差
        /// <summary>
        /// 从当前 <see cref="DateTime"/> 实例中计算出与当前时间之前的时间差
        /// </summary>
        /// <param name="time">要取得时间差的 <see cref="DateTime"/> 实例</param>
        /// <returns>
        /// 如果时间差大于365天，则返回“N前年”；
        /// 如果时间差小于365天，大于30天，则返回“N个月前”；
        /// 如果时间差小于30天，则返回“N天前”；
        /// 如果时间差小于24小时，则返回“N个小时前”；
        /// 如果时间差小于60分钟，则返回“N分钟前”；
        /// 如果时间差小于60秒，则返回“N秒前”；
        /// </returns>
        public static string BeforeTimeRange(this DateTime time)
        {
            return GetBeforeTimeRange(time);
        }

        /// <summary>
        /// 从当前 <see cref="DateTime"/> 实例中计算出与当前时间之前的时间差
        /// </summary>
        /// <param name="time"></param>
        /// <returns>string</returns>
        private static string GetBeforeTimeRange(DateTime time)
        {
            var diff = DateTime.Now.Subtract(time);
            if (diff.Days > 0)
            {
                if (diff.Days >= 365)
                {
                    var year = diff.Days / 365;
                    return $"{year}年前";
                }

                if (diff.Days >= 30)
                {
                    if (diff.Days == 30) return "1个月前";

                    var month = diff.Days / 30.4;
                    return $"{(int)month}个月前";
                }

                return $"{diff.Days}天前";
            }

            if (diff.Hours > 0) return $"{diff.Hours}小时前";
            if (diff.Minutes > 0) return $"{diff.Minutes}分钟前";
            return $"{diff.Seconds}秒前";
        }
        #endregion

        #region 从当前 DateTime 实例中计算出与当前时间之后的时间差
        /// <summary>
        /// 从当前 <see cref="DateTime"/> 实例中计算出与当前时间之后的时间差
        /// </summary>
        /// <param name="time">要取得时间差的 <see cref="DateTime"/> 实例</param>
        /// <returns>
        /// 如果时间差大于365天，则返回“N年后”；
        /// 如果时间差小于365天，大于30天，则返回“N个月后”；
        /// 如果时间差小于30天，则返回“N天后”；
        /// 如果时间差小于24小时，则返回“N个小时后”；
        /// 如果时间差小于60分钟，则返回“N分钟后”；
        /// 如果时间差小于60秒，则返回“N秒后”；
        /// </returns>
        public static string AfterTimeRange(this DateTime time)
        {
            return GetAfterTimeRange(time);
        }

        /// <summary>
        /// 从当前 <see cref="DateTime"/> 实例中计算出与当前时间之后的时间差
        /// </summary>
        /// <param name="time"> <see cref="DateTime"/> </param>
        /// <returns>string</returns>
        private static string GetAfterTimeRange(DateTime time)
        {
            var diff = DateTime.Now.Subtract(time);
            var _days = diff.Days;
            var _hours = diff.Hours;
            var _minutes = diff.Minutes;
            var _second = diff.Seconds;
            _days = ~(_days - 1);
            _hours = ~(_hours - 1);
            _minutes = ~(_minutes - 1);
            _second = ~(_second - 1);
            if (_days > 0)
            {
                if (_days >= 365)
                {
                    var year = _days / 365;
                    return $"{year}年后";
                }

                if (_days >= 30)
                {
                    if (_days == 30) return "1个月后";

                    var month = _days / 30.4;
                    return $"{(int)month}个月后";
                }

                return $"{_days}天后";
            }

            if (_hours > 0) return $"{_hours}小时后";
            if (_minutes > 0) return $"{_minutes}分钟后";
            return $"{_second}秒后";
        }
        #endregion

        #region 从当前 DateTime 实例中取得当前月的第一天
        /// <summary>
        /// 从当前 <see cref="DateTime"/> 实例中取得当前月的第一天
        /// </summary>
        /// <param name="dateTime">要取得月份第一天的 <see cref="DateTime"/> 实例</param>
        /// <param name="mode">时间模式，默认为当前时间的时分秒</param>
        /// <returns>当前实例月份的第一天的 <see cref="DateTime"/> 实例</returns>
        public static DateTime FirstDayOfMonth(this DateTime dateTime, TimeMode mode = TimeMode.Now) => dateTime.AddDays(1 - dateTime.Day).ToDateTimeOfMode(mode);


        private static DateTime ToDateTimeOfMode(this DateTime dateTime, TimeMode timeMode = TimeMode.Now)
        {
            if (timeMode == TimeMode.Zero) return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, 0);
            if (timeMode == TimeMode.Full) return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999);
            return dateTime;
        }
        #endregion

        #region 从当前 DateTime 实例中取得当前月的最后一天
        /// <summary>
        /// 从当前 <see cref="DateTime"/> 实例中取得当前月的最后一天
        /// </summary>
        /// <param name="dateTime">要取得月份最后一天的 <see cref="DateTime"/> 实例</param>
        /// <param name="mode">时间模式，默认为当前时间的时分秒</param>
        /// <returns>当前实例月份的最后一天的 <see cref="DateTime"/> 实例</returns>
        public static DateTime LastDayOfMonth(this DateTime dateTime, TimeMode mode = TimeMode.Now) => dateTime.AddDays(1 - dateTime.Day).AddMonths(1).AddDays(-1).ToDateTimeOfMode(mode);
        #endregion

        #region 从当前 DateTime 实例中取得当前周以星期天开始的第一天
        /// <summary>  
        /// 从此实例中取得当前周以星期天开始的第一天
        /// </summary>
        /// <param name="dateTime">要取得当前周第一天的  <see cref="DateTime"/> 实例</param>
        /// <param name="mode">时间模式，默认为当前时间的时分秒</param>
        /// <returns>当前周的第一天的 <see cref="DateTime"/> 实例</returns>
        public static DateTime FirstDayOfWeekFromSunday(this DateTime dateTime, TimeMode mode = TimeMode.Now)
        {
            var weekNow = Convert.ToInt32(dateTime.DayOfWeek);
            var daydiff = (-1) * weekNow;
            return dateTime.AddDays(daydiff).ToDateTimeOfMode(mode);
        }
        #endregion

        #region 从当前 DateTime 实例中取得当前周以星期一开始的第一天
        /// <summary>
        /// 从当前 <see cref="DateTime"/> 实例中取得当前周以星期一开始的第一天
        /// </summary>
        /// <param name="dateTime">要取得当前周第一天的  <see cref="DateTime"/> 实例</param>
        /// <param name="mode">时间模式，默认为当前时间的时分秒</param>
        /// <returns>当前周的第一天的 <see cref="DateTime"/> 实例</returns>
        public static DateTime FirstDayOfWeekFromMonday(this DateTime dateTime, TimeMode mode = TimeMode.Now)
        {
            var weekNow = Convert.ToInt32(dateTime.DayOfWeek);
            weekNow = (weekNow == 0 ? (7 - 1) : (weekNow - 1));
            var daydiff = (-1) * weekNow;
            return dateTime.AddDays(daydiff).ToDateTimeOfMode(mode);
        }
        #endregion

        #region 从当前 DateTime 实例中取得当前周以星期天开始的最后一天
        /// <summary>
        /// 从当前 <see cref="DateTime"/> 实例中取得当前周以星期天开始的最后一天
        /// </summary>  
        /// <param name="dateTime">要取得当前周最后一天的  <see cref="DateTime"/> 实例</param>
        /// <param name="mode">时间模式，默认为当前时间的时分秒</param>
        /// <returns>当前周的最后一天的 <see cref="DateTime"/> 实例</returns>  
        public static DateTime LastDayOfWeekFromSunday(this DateTime dateTime, TimeMode mode = TimeMode.Now)
        {
            int weeknow = Convert.ToInt32(dateTime.DayOfWeek);
            int daydiff = (7 - weeknow) - 1;
            return dateTime.AddDays(daydiff).ToDateTimeOfMode(mode);
        }
        #endregion

        #region 从当前 DateTime 实例中取得当前周以星期一开始的最后一天
        /// <summary>  
        /// 从当前 <see cref="DateTime"/> 实例中取得当前周以星期一开始的最后一天
        /// </summary>  
        /// <param name="dateTime">要取得当前周最后一天的  <see cref="DateTime"/> 实例</param>
        /// <param name="mode">时间模式，默认为当前时间的时分秒</param>
        /// <returns>当前周的最后一天的 <see cref="DateTime"/> 实例</returns>  
        public static DateTime LastDayOfWeekFromMonday(this DateTime dateTime, TimeMode mode = TimeMode.Now)
        {
            int weeknow = Convert.ToInt32(dateTime.DayOfWeek);
            weeknow = (weeknow == 0 ? 7 : weeknow);
            int daydiff = (7 - weeknow);
            return dateTime.AddDays(daydiff).ToDateTimeOfMode(mode);
        }
        #endregion
    }

    #region 时间模式
    /// <summary>
    /// 时间模式
    /// </summary>
    public enum TimeMode
    {
        /// <summary>
        /// 返回当前的时分秒
        /// </summary>
        Now,

        /// <summary>
        /// 返回 00:00:00.000
        /// </summary>
        Zero,

        /// <summary>
        /// 返回 23:59:59.999
        /// </summary>
        Full
    }
    #endregion
}
