using System;
using Xunit;

namespace Factorial_Tail
{
    public class UnitTest1
    {
        [Fact]
        public void Can_Be_Solved_With_Basic_Computations () {
            Assert.Equal (2, FactorialTail.zeroes (10, 10));
            Assert.Equal (3, FactorialTail.zeroes (16, 16));
        }
    }
}
