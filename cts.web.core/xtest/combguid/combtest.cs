using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace xtest.combguid
{
    public class combtest
    {
        protected readonly ITestOutputHelper Output;

        public combtest(ITestOutputHelper output)
        {
            Output = output;
        }

        [Fact]
        public void Test()
        {
            var guid = CombGuid.NewGuid();

            Output.WriteLine(guid.ToString());
            
        }
    }
}
