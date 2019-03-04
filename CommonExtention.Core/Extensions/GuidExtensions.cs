using System;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="Guid"/> 扩展
    /// </summary>
    public static class GuidExtensions
    {
        /// <summary>
        /// Guid for database
        /// </summary>
        public static Guid NewID
        {
            get
            {
                var guidArray = Guid.NewGuid().ToByteArray();
                var dbMinDate = DateTimeExtensions.MsSQLDateTimeInitial;
                var nowDate = DateTime.Now;

                var days = new TimeSpan(nowDate.Ticks - dbMinDate.Ticks);
                var msSecond = new TimeSpan(nowDate.Ticks - (new DateTime(nowDate.Year, nowDate.Month, nowDate.Day).Ticks));

                var daysArray = BitConverter.GetBytes(days.Days);
                var msSecondArray = BitConverter.GetBytes((long)(msSecond.TotalMilliseconds / 3.333333));

                Array.Reverse(daysArray);
                Array.Reverse(msSecondArray);

                Array.Copy(daysArray, daysArray.Length - 2, guidArray, guidArray.Length - 6, 2);
                Array.Copy(msSecondArray, daysArray.Length - 4, guidArray, guidArray.Length - 4, 4);

                return new Guid(guidArray);
            }
        }

        #region 指示指定的 Guid 是否为 System.Guid.Empty
        /// <summary>
        /// 指示指定的 <see cref="Guid"/> 是否为 <see cref="Guid.Empty"/>
        /// </summary>
        /// <param name="value">要检测的 <see cref="Guid"/> </param>
        /// <returns>如果 <see cref="Guid"/> 为 <see cref="Guid.Empty"/>，则为 true；否则为 false。</returns>
        public static bool IsEmpty(this Guid value) => value == Guid.Empty;
        #endregion

        #region 指示指定的 Guid 是否不为 System.Guid.Empty
        /// <summary>
        /// 指示指定的 <see cref="Guid"/> 是否不为 <see cref="Guid.Empty"/>
        /// </summary>
        /// <param name="value">要检测的 <see cref="Guid"/></param>
        /// <returns>如果 <see cref="Guid"/> 不为 <see cref="Guid.Empty"/>，则为 true；否则为 false。</returns>
        public static bool NotEmpty(this Guid value) => value != Guid.Empty;
        #endregion

        #region 指示指定的 Guid? 是否为 null
        /// <summary>
        /// 指示指定的 <see cref="Guid"/>? 是否为 null
        /// </summary>
        /// <param name="value">要检测的 <see cref="Guid"/>?</param>
        /// <returns>如果 <see cref="Guid"/>? 为 null，则返回true；否则为 false。</returns>
        public static bool IsNull(this Guid? value) => value.HasValue;
        #endregion

        #region 指示指定的 Guid? 是否不为 null
        /// <summary>
        /// 指示指定的 Guid 是否不为 null
        /// </summary>
        /// <param name="value">要检测的 <see cref="Guid"/>?</param>
        /// <returns>如果 <see cref="Guid"/>? 不为 null ，则为 true；否则为 false。</returns>
        public static bool NotNull(this Guid? value) => value != null;
        #endregion

        #region 指示指定的 Guid? 是 null 还是 System.Guid.Empty
        /// <summary>
        /// 指示指定的 <see cref="Guid"/>? 是 null 还是 <see cref="Guid.Empty"/>
        /// </summary>
        /// <param name="value">要检测的 <see cref="Guid"/>?</param>
        /// <returns>如果 <see cref="Guid"/>? 为 null 或 <see cref="Guid.Empty"/>，则为 true；否则为 false。</returns>
        public static bool IsNullOrEmpty(this Guid? value)
        {
            if (value.HasValue) return true;
            if (value.Value == Guid.Empty) return true;
            return false;
        }
        #endregion

        #region 指示指定的 Guid? 不为 null 和 System.Guid.Empty
        /// <summary>
        /// 指示指定的 <see cref="Guid"/>? 不为 null 和不为 <see cref="Guid.Empty"/>
        /// </summary>
        /// <param name="value">要检测的 <see cref="Guid"/>?</param>
        /// <returns>如果 <see cref="Guid"/>? 不为 null 和 <see cref="Guid.Empty"/>，则为 true；否则为 false。</returns>
        public static bool NotNullAndEmpty(this Guid? value) => !value.IsNullOrEmpty();
        #endregion
    }
}
