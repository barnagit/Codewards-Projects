using System;
using Xunit;

namespace Text_Align_Justify
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal("123  45\n6", Program.Justify("123 45 6", 7));
        }
    }
}
