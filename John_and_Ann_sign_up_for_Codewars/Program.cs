using System;
using System.Collections.Generic;

namespace John_and_Ann_sign_up_for_Codewars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SumAnn(33440)); //345546811
            Console.WriteLine(SumAnn(31312)); //302967068
        }

        static void InitLists(long n)
        {
            if (AList[0] == 0) {
                AList[0] =1;
                ASum[0] =1;

                for (int i = 1; i < 50000; i++) {
                    JList[i] = i - AList[JList[i-1]];
                    JSum[i] = JSum[i-1] + JList[i];
                    AList[i] = i - JList[AList[i-1]];
                    ASum[i] = ASum[i-1] + AList[i];
                }
            }
        }

        static long[] JList = new long[50000];
        static long[] JSum = new long[50000];
        
        static long[] AList = new long[50000];
        static long[] ASum = new long[50000];

        public static List<long> John(long n) {
            InitLists(n);
            return (new List<long>(JList)).GetRange(0,(int)n);
        }

        public static List<long> Ann(long n) {
            InitLists(n);
            return (new List<long>(AList)).GetRange(0,(int)n);            
        }
        public static long SumJohn(long n) {
            InitLists(n);
            return JSum[(int)n-1];
        }
        public static long SumAnn(long n) {
            InitLists(n);
            return ASum[(int)n-1];
        }

    }
}
