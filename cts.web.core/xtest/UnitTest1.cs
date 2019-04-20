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

            Output.WriteLine(py);

        }
    }
}
