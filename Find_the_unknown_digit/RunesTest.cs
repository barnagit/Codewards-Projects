using System;
using Xunit;

namespace Find_the_unknown_digit
{
    public class RunesTest 
    {
        [Fact]
        public void testSample()
        {
            Assert.Equal(2, Runes.solveExpression("1+1=?")); //, "Answer for expression '1+1=?' ");
            Assert.Equal(6, Runes.solveExpression("123*45?=5?088")); //, "Answer for expression '123*45?=5?088' ");      
            Assert.Equal(0, Runes.solveExpression("-5?*-1=5?")); //, "Answer for expression '-5?*-1=5?' ");
            Assert.Equal(-1, Runes.solveExpression("19--45=5?")); //, "Answer for expression '19--45=5?' ");
            Assert.Equal(5, Runes.solveExpression("??*??=302?")); //, "Answer for expression '??*??=302?' ");
            Assert.Equal(2, Runes.solveExpression("?*11=??")); //, "Answer for expression '?*11=??' ");
            Assert.Equal(2, Runes.solveExpression("??*1=??")); //, "Answer for expression '??*1=??' ");
            Assert.Equal(-1, Runes.solveExpression("??+??=??")); //, "Answer for expression '??+??=??' ");
        }
    }
}