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
            Assert.Equal(DoubleLinear.DblLinear(10), (ulong)22);
            Assert.Equal(DoubleLinear.DblLinear(20),(ulong) 57);
            Assert.Equal(DoubleLinear.DblLinear(30), (ulong)91);
            Assert.Equal(DoubleLinear.DblLinear(50), (ulong)175);

            Assert.Equal(DoubleLinear.DblLinear(27723),(ulong)583663);
            Assert.Equal(DoubleLinear.DblLinear(7279),(ulong)105951);
            Assert.Equal(DoubleLinear.DblLinear(60000),(ulong)1511311);
        }
    }
}
