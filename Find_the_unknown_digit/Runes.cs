using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_the_unknown_digit
{
    public class Runes
    {
        public static int solveExpression(string expression)
        {
            int missingDigit = -1;

            //Write code to determine the missing digit or unknown rune
            //Expression will always be in the form
            //(number)[opperator](number)=(number)
            //Unknown digit will not be the same as any other digits used in expression

            HashSet<char> numbers = new HashSet<char>(new char[] {'0','1','2','3','4','5','6','7','8','9'});

            if (expression[0].Equals('0')) numbers.Remove('0');

            for (int i = 0; i < expression.Length; i++) {
                if (Char.IsDigit(expression[i])) {
                    numbers.Remove(expression[i]);
                }
            }

            foreach(var n in numbers) {
                string e = expression.Replace('?',n);

                var rightSide = e.Substring(e.IndexOf('='));
                var leftSide = e.Substring(0,e.IndexOf('='));

                

            }
            
            return missingDigit;
        }
    }

    public class Operation {
        public string Left;
        public string Right;
        public string Operator;
        public string Result;
    }
}
