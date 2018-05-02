using System;
using System.Linq;

namespace Moving_Zeros_To_The_End
{
    class Program
    {
        static void Main(string[] args)
        {
            MoveZeroes(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1});
        }

        public static int[] MoveZeroes(int[] arr)
        {
            int[] ret = new int[arr.Length];
            int j = 0;
            for (int i = 0; i <arr.Length; i++) {
                if (arr[i]==0) continue;
                else ret[j++] = arr[i];
            }

            return ret;
        }
    }
}
