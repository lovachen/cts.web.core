using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace System
{
    /// <summary>
    /// COMB Guid生成
    /// 1秒生成3万个顺序的guid，可以使用278年，278年后循序会重复，但是生成的ID依然唯一性
    /// </summary>
    public sealed class CombGuid
    {
        private static readonly long Twepoch = 1552922013928L; //2019.01.01开始
        private static readonly int SequenceBits = 5;
        private static readonly DateTime Jan1st1970 = new DateTime
           (1970, 1, 1, 0, 0, 0);
        private static long _sequence = 0L;
        private static long _lastTimestamp = -1L;
        private static readonly long SequenceMask = -1L ^ (-1L << SequenceBits);

        /// <summary>
        /// 获取可排序的guid
        /// </summary>
        /// <param name="atStart">时间戳排在字符串前面，对于mysql来说有用</param>
        /// <returns></returns>
        public static Guid NewGuid(bool atStart = false)
        {
            var guidArray = Guid.NewGuid().ToByteArray();

            var timestamp = TimeGen();
            if (timestamp < _lastTimestamp)
            {
                throw new Exception(String.Format("时间倒退，拒绝在{0} milliseconds 生成id", _lastTimestamp - timestamp));
            }
            if (_lastTimestamp == timestamp)
            {
                _sequence = (_sequence + 1) & SequenceMask;
                if (_sequence == 0)
                {
                    timestamp = TilNextMillis(_lastTimestamp);
                }
            }
            else
            {
                _sequence = 0;
            }
            _lastTimestamp = timestamp;
            var num = ((timestamp - Twepoch) << SequenceBits) | _sequence;
            var numArray = BitConverter.GetBytes(num);
            Array.Reverse(numArray);
            if (atStart)
            {
                Array.Copy(numArray, 2, guidArray, 0, 6);
            }
            else
            {
                Array.Copy(numArray, 2, guidArray, guidArray.Length - 6, 6);
            }
            return new Guid(guidArray);
        }

        /// <summary>
        /// 获取毫秒数
        /// </summary>
        /// <returns></returns>
        private static long TimeGen()
        {
            return (long)(DateTime.Now - Jan1st1970).TotalMilliseconds;
        }

        /// <summary>
        /// 获取下一毫秒
        /// </summary>
        /// <param name="lastTimestamp"></param>
        /// <returns></returns>
        private static long TilNextMillis(long lastTimestamp)
        {
            var timestamp = TimeGen();
            while (timestamp <= lastTimestamp)
            {
                timestamp = TimeGen();
            }
            return timestamp;
        }
    }
}
