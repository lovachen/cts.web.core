using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace System
{
    /// <summary>
    /// COMB Guid生成
    /// </summary>
    public sealed class CombGuid
    {
        private static readonly DateTime _CombBaseDate = new DateTime(1900, 1, 1);
        private static Int32 _LastDays; // 天数
        private static Int32 _LastTenthMilliseconds; // 单位：1/10 毫秒

        /// <summary>
        /// 获取可排序的guid
        /// </summary>
        /// <returns></returns>
        public static Guid NewGuid()
        {
            var guidArray = Guid.NewGuid().ToByteArray();

            var now = DateTime.Now;

            var days = new TimeSpan(now.Ticks - _CombBaseDate.Ticks).Days;
            var tenthMilliseconds = (Int32)(now.TimeOfDay.TotalMilliseconds * 10D);
            var lastDays = _LastDays;
            var lastTenthMilliseconds = _LastTenthMilliseconds;
            if (days > lastDays)
            {
                Interlocked.CompareExchange(ref _LastDays, days, lastDays);
                Interlocked.CompareExchange(ref _LastTenthMilliseconds, tenthMilliseconds, lastTenthMilliseconds);
            }
            else
            {
                if (tenthMilliseconds > lastTenthMilliseconds)
                {
                    Interlocked.CompareExchange(ref _LastTenthMilliseconds, tenthMilliseconds, lastTenthMilliseconds);
                }
                else
                {
                    if (_LastTenthMilliseconds < Int32.MaxValue) { Interlocked.Increment(ref _LastTenthMilliseconds); }
                    tenthMilliseconds = _LastTenthMilliseconds;
                }
            }
            var daysArray = BitConverter.GetBytes(days);
            var msecsArray = BitConverter.GetBytes(tenthMilliseconds);

            Array.Reverse(daysArray);
            Array.Reverse(msecsArray);

            Array.Copy(daysArray, daysArray.Length - 2, guidArray, guidArray.Length - 6, 2);
            Array.Copy(msecsArray, 0, guidArray, guidArray.Length - 4, 4);


            return new Guid(guidArray);
        }
    }
}
