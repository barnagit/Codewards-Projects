using System;
using System.Numerics;

namespace Sum_Strings_as_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(sumStrings("123","456"));
            Console.WriteLine(sumStrings("50095301248058391139327916261","81055900096023504197206408605"));
        }

        public static string sumStrings(string a, string b)
        {
            BigInteger A;
            BigInteger B;

                if (!BigInteger.TryParse(a, out A)) A = 0;
                if (!BigInteger.TryParse(b, out B)) B = 0;
                return (A+B).ToString();            
        }
    }
}
