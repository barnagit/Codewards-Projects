using System;
using System.Collections.Generic;
using System.Linq;

namespace Consecutive_strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(LongestConsec(new String[] {"zone", "abigail", "theta", "form", "libe", "zas", "theta", "abigail"}, 2), "abigailtheta");
            Console.WriteLine(LongestConsec(new String[] {"ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh"}, 1), "oocccffuucccjjjkkkjyyyeehh");
            Console.WriteLine(LongestConsec(new String[] {}, 3), "");
            Console.WriteLine(LongestConsec(new String[] {"itvayloxrp","wkppqsztdkmvcuwvereiupccauycnjutlv","vweqilsfytihvrzlaodfixoyxvyuyvgpck"}, 2), "wkppqsztdkmvcuwvereiupccauycnjutlvvweqilsfytihvrzlaodfixoyxvyuyvgpck");
            Console.WriteLine(LongestConsec(new String[] {"wlwsasphmxx","owiaxujylentrklctozmymu","wpgozvxxiu"}, 2), "wlwsasphmxxowiaxujylentrklctozmymu");
            Console.WriteLine(LongestConsec(new String[] {"zone", "abigail", "theta", "form", "libe", "zas"}, -2), "");
            Console.WriteLine(LongestConsec(new String[] {"it","wkppv","ixoyx", "3452", "zzzzzzzzzzzz"}, 3), "ixoyx3452zzzzzzzzzzzz");
            Console.WriteLine(LongestConsec(new String[] {"it","wkppv","ixoyx", "3452", "zzzzzzzzzzzz"}, 15), "");
            Console.WriteLine(LongestConsec(new String[] {"it","wkppv","ixoyx", "3452", "zzzzzzzzzzzz"}, 0), "");
        }

        public static string LongestConsec(string[] strarr, int k) 
        {
            if (strarr.Length == 0 || k > strarr.Length || k<=0) return string.Empty;

            int longest_id = 0;
            int longest_length = 0;
            int length = 0;

            for (int i = 0; i <= strarr.Length - k; i++) {
                length = 0;
                for (int j = 0; j < k; j++) length += strarr[i+j].Length;

                if (length > longest_length) {
                    longest_length = length;
                    longest_id = i;
                }
            }
            
            return string.Concat((new List<string>(strarr).GetRange(longest_id,k)));
        }
    }
}
