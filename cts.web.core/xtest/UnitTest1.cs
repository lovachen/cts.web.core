using cts.web.core.Librs;
using System;
using Xunit;
using Xunit.Abstractions;

namespace xtest
{
    public class UnitTest1
    {
        protected readonly ITestOutputHelper Output;
        public UnitTest1(ITestOutputHelper output)
        {
            Output = output;
        }

        [Fact]
        public void Test1()
        {
            var py = PingYinHelper.ConvertToAllSpell("≤‚ ‘a");
            var py1 = PingYinHelper.GetFirstSpell("≤‚ ‘a");

           var d = DateTime.Now.ToMilliseconds();

           string s = DateTime.Now.ToBase64();

            DateTime dtStart = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1,0,0,0,DateTimeKind.Utc), TimeZoneInfo.Local);
            long lTime = long.Parse("1557127440000" + "0000");
            TimeSpan toNow = new TimeSpan(lTime);
            var time = dtStart.Add(toNow);
            Output.WriteLine(py);

        }
    }
}
