using System;
using Xunit;

namespace Twice_linear.Src
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Console.WriteLine("Fixed Tests DblLinear");
            Assert.Equal(DoubleLinear.DblLinear(10), 22);
            Assert.Equal(DoubleLinear.DblLinear(20), 57);
            Assert.Equal(DoubleLinear.DblLinear(30),91);
            Assert.Equal(DoubleLinear.DblLinear(50),175);

            Assert.Equal(DoubleLinear.DblLinear(27723),583663);
            Assert.Equal(DoubleLinear.DblLinear(7279),105951);
            Assert.Equal(DoubleLinear.DblLinear(60000),1511311);
        }
    }
}
