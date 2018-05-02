using System;
using NUnit.Framework;

namespace Take_a_Ten_Minute_Walk
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        public static bool IsValidWalk(string[] walk)
        {
            if (walk.Length != 10) return false;
            int North_n_South = 0;
            int West_n_East = 0;

            foreach (string s in walk)
            {
                switch (s) {
                    case "n": North_n_South++; break;
                    case "s": North_n_South--; break;
                    case "w": West_n_East++; break;
                    case "e": West_n_East--; break;
                }
            }

            return North_n_South == 0 && West_n_East == 0;
        }
    }
}
