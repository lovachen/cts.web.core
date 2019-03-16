using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 时间扩展
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// 时间转为10位时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ToUnix(this DateTime time)
        {
            DateTime startTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            return (long)(time.ToUniversalTime() - startTime).TotalSeconds;
        }

        /// <summary>
        /// 时间戳转为时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime ToTime(this long timeStamp)
        {
            DateTime dtStart = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }


    }
}
