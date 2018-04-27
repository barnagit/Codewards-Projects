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

        private static int North_n_South = 0;
        private static int West_n_East = 0;
        public static bool IsValidWalk(string[] walk)
        {
            if (walk.Length != 10) return false;

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
