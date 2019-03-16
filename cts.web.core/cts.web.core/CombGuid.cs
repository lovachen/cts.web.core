﻿using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    /// <summary>
    /// COMB Guid生成
    /// </summary>
    public sealed class CombGuid
    {
        /// <summary>
        /// 获取可排序的guid
        /// </summary>
        /// <returns></returns>
        public static Guid NewGuid()
        {
            byte[] guidArray = Guid.NewGuid().ToByteArray();

            DateTime baseDate = new DateTime(1900, 1, 1);
            DateTime now = DateTime.Now;
             
            TimeSpan days = new TimeSpan(now.Ticks - baseDate.Ticks);
            TimeSpan msecs = now.TimeOfDay;
               
            byte[] daysArray = BitConverter.GetBytes(days.Days);
            byte[] msecsArray = BitConverter.GetBytes((long)
              (msecs.TotalMilliseconds / 3.333333));

            Array.Reverse(daysArray);
            Array.Reverse(msecsArray);

            Array.Copy(daysArray, daysArray.Length - 2, guidArray,
              guidArray.Length - 6, 2);
            Array.Copy(msecsArray, msecsArray.Length - 4, guidArray,
              guidArray.Length - 4, 4);

            return new Guid(guidArray);
        }
    }
}
