using System;
using System.Collections.Generic;
using System.Text;

namespace Replace_With_Alphabet_Position
{
    class Kata
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.AlphabetPosition("The sunset sets at twelve o' clock."));
            Console.ReadLine();
        }

        private static Dictionary<string,int> _map = new Dictionary<string, int>() {
            {"a",1},{"b",2},{"c",3},{"d",4},{"e",5},{"f",6},{"g",7},{"h",8},{"i",9},{"j",10},{"k",11},{"l",12},{"m",13}
            ,{"n",14},{"o",15},{"p",16},{"q",17},{"r",18},{"s",19},{"t",20},{"u",21},{"v",22},{"w",23},{"x",24},{"y",25},{"z",26}
        };

        public static string AlphabetPosition(string s)
        {
            StringBuilder sb = new StringBuilder(s.Length);
            foreach (char c in s) {
                int r = _map.GetValueOrDefault(c.ToString().ToLower());
                if (r > 0) sb.Append(r.ToString() + " ");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
