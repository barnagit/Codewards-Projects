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

            // if the first char is unknown we know the unknown digit is not zero
            if (expression[0].Equals('?')) numbers.Remove('0');

            // remove the known digits from the unknown list
            for (int i = 0; i < expression.Length; i++) {
                if (Char.IsDigit(expression[i])) {
                    numbers.Remove(expression[i]);
                }
            }
            
            // try to evaluate the expression
            foreach(var n in numbers) {

                string e = expression.Replace('?',n);

                var resultSide = e.Substring(e.IndexOf('=')+1);
                var operationSide = e.Substring(0,e.IndexOf('='));

                int i = 0;
                int resultValue = 0;
                foreach(var rc in resultSide.Reverse()) {
                    if (Char.IsDigit(rc)) resultValue += Convert.ToInt32(rc.ToString()) * (int)Math.Pow(10,i++);
                }

                if (resultSide.Contains('-')) resultValue *= -1;

                // left value
                string leftValueString = String.Empty;
                i=0;
                if (operationSide[0].Equals('-')) i = 1;
                while (Char.IsDigit(operationSide[i])) {
                    leftValueString += operationSide[i++];
                }
                
                int leftValue = Convert.ToInt32(leftValueString);
                leftValue *= operationSide[0].Equals('-')?-1:1;

                // operator
                
                Operator op = Operator.plus;
                switch (operationSide[i]) {
                    case '+':op = Operator.plus; break;
                    case '-':op = Operator.minus; break;
                    case '*':op = Operator.multiply; break;
                    default: throw new InvalidOperationException();
                }
                i++;

                // right va;ue
                string rightValueString = String.Empty;
                bool isRightNegative = false;
                if(operationSide[i].Equals('-')) {
                    i++;
                    isRightNegative = true;
                }

                while(i < operationSide.Length && Char.IsDigit(operationSide[i])) {
                    rightValueString += operationSide[i++];
                }

                int rightValue = Convert.ToInt32(rightValueString);
                rightValue *= isRightNegative?-1:1;

                // test

                int myResult = 0;
                switch (op) {
                    case Operator.plus: myResult = leftValue + rightValue; break;
                    case Operator.minus: myResult = leftValue - rightValue; break;
                    case Operator.multiply: myResult = leftValue * rightValue; break;
                }

                if (myResult == resultValue) {
                    missingDigit = Convert.ToInt32(n.ToString());
                    break;
                }

            }
            
            return missingDigit;
        }

        enum Operator {plus, minus, multiply};
    }

    public class Operation {
        public string Left;
        public string Right;
        public string Operator;
        public string Result;
    }
}
