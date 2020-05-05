using System;
using System.Collections.Generic;
using Xunit;

namespace All_Balanced_Parentheses
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var warriorsList = new List<string>();
            //test for n = 0
            warriorsList = Balanced.BalancedParens(0);
            Assert.Equal(new List<string> { "" }, warriorsList);
            //test for n = 1
            warriorsList = Balanced.BalancedParens(1);
            Assert.Equal(new List<string> { "()" }, warriorsList);
            //test for n = 2
            warriorsList = Balanced.BalancedParens(2);
            warriorsList.Sort();
            Assert.Equal(new List<string> { "(())", "()()" }, warriorsList);
            //test for n = 3
            warriorsList = Balanced.BalancedParens(3);
            warriorsList.Sort();
            Assert.Equal(new List<string> { "((()))", "(()())", "(())()", "()(())", "()()()" }, warriorsList);
            //test for n = 4
            warriorsList = Balanced.BalancedParens(4);
            warriorsList.Sort();
            Assert.Equal(new List<string> { "(((())))", "((()()))", "((())())", "((()))()", "(()(()))", "(()()())", "(()())()", "(())(())", "(())()()", "()((()))", "()(()())", "()(())()", "()()(())", "()()()()" }, warriorsList);
        }
    }
}
