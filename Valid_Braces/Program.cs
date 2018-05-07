using System;
using System.Collections.Generic;

namespace Valid_Braces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(validBraces("(){}[]"));   //=>  True
            Console.WriteLine(validBraces("([{}])"));   //=>  True
            Console.WriteLine(validBraces("(}"));       //=>  False
            Console.WriteLine(validBraces("[(])"));     //=>  False
            Console.WriteLine(validBraces("[({})](]")); //=>  False
            Console.WriteLine(validBraces("}}]]))}])"));//=>  False
            Console.WriteLine(validBraces("(((({{"));   //=>  False
        }

        /* ()[]{} */

        enum TypeOfBrackets
        {
            Round, Square, Curly
        }
        public static bool validBraces(String braces)
        {
            Stack<TypeOfBrackets> stack = new Stack<TypeOfBrackets>();

            try {
                for (int i = 0; i < braces.Length; i++)
                {
                    switch (braces[i])
                    {
                        case '(': stack.Push(TypeOfBrackets.Round); break;
                        case ')': if (stack.Pop() != TypeOfBrackets.Round) throw new BracketException(); else break;
                        case '[': stack.Push(TypeOfBrackets.Square); break;
                        case ']': if (stack.Pop() != TypeOfBrackets.Square) throw new BracketException(); else break;
                        case '{': stack.Push(TypeOfBrackets.Curly); break;
                        case '}': if (stack.Pop() != TypeOfBrackets.Curly) throw new BracketException(); else break;
                    }
                }
            }
            catch (BracketException) {return false;}
            catch (InvalidOperationException) {return false;}

            if (stack.Count != 0) return false;

            return true;
        }
    }

    public class BracketException:Exception {}
}



