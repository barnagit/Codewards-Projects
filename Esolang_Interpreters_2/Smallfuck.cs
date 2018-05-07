using System;

namespace Esolang_Interpreters_2
{
    class Smallfuck
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Hello World!");
            Console.WriteLine(Interpreter("*", "00101100"));
            Console.WriteLine(Interpreter(">*>*", "00101100"));
            Console.WriteLine(Interpreter("*>*>*>*>*>*>*>*", "00101100"));
            Console.WriteLine(Interpreter("*>*>>*>>>*>*", "00101100"));
            Console.WriteLine(Interpreter(">>>>>*<*<<*", "00101100"));
            Console.WriteLine(Interpreter("*>>>>>*","11"));
            */
            Console.WriteLine(Interpreter("*[>]*","1111")); 
            Console.WriteLine(Interpreter("[*>>]*","0101"));
            Console.WriteLine(Interpreter("[*>*>]","1111"));
            Console.WriteLine(Interpreter("[[*>*]*>]","1011111"));
        }

        /*
        > - Move pointer to the right (by 1 cell)
        < - Move pointer to the left (by 1 cell)
        * - Flip the bit at the current cell
        [ - Jump past matching ] if value at current cell is 0
        ] - Jump back to matching [ (if value at current cell is nonzero)
        */

        public static string Interpreter(string code, string tape)
        {
            char[] data = tape.ToCharArray();
            int c = 0;
            int d = 0;
            int nestedness_counter;
            bool in_nested = false;
            
            try {
                while (c<code.Length && c>=0) {
                    
                    switch (code[c])
                    {
                        case '>': c++; d++; break;
                        case '<': c++; d--; break;
                        case '*':
                            data[d] = ((int)char.GetNumericValue(data[d])^1).ToString().ToCharArray()[0];
                            c++;
                            break;
                        case '[': 
                            if (data[d] != '0') {
                                c++;
                                break;
                            }
                            int i = c;
                            nestedness_counter = 0;
                            while (i++ < code.Length && (code[i] != ']' || in_nested)) {
                                if (code[i] == '[') nestedness_counter ++;
                                if (code[i] == ']') nestedness_counter --;
                                in_nested = nestedness_counter > 0;
                            }
                            c = i;
                        break;
                        case ']':
                            if (data[d] == '0') {
                                c++;
                                break;
                            }
                            int j = c;
                            nestedness_counter = 0;
                            while (j-- >= 0 && (code[j] != '[' || in_nested)) {
                                if (code[j] == ']') nestedness_counter ++;
                                if (code[j] == '[') nestedness_counter --;
                                in_nested = nestedness_counter > 0;
                            }
                            c = j;
                        break;
                        default: c++; break;
                    }

                }
            }
            catch (IndexOutOfRangeException) {

            }

            // Implement your interpreter here
            return String.Concat(data);
        }
    }
}
