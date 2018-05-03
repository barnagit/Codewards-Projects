using System;
using System.Text;
using System.Collections.Generic;

namespace Rot13
{
    class Program
    {
        /*
        static void Main(string[] args)
        {
            Console.WriteLine(Rot13("abcdefghijklmnopqrstuvwxyz"));
        }
        */
        
        public static string Rot13(string message)
        {
            string _from = "abcdefghijklmnopqrstuvwxyz";
            _from += _from.ToUpper();
            string _to = "nopqrstuvwxyzabcdefghijklm";
            _to += _to.ToUpper();
            Dictionary<char,char> rep = new Dictionary<char, char>();
            for (int i = 0; i < _from.Length; i++) rep.Add(_from[i],_to[i]);

            char[] m = message.ToCharArray();
            for (int j = 0; j< m.Length; j++) {
                if (rep.ContainsKey(m[j])) m[j] = rep[m[j]];
            }

            return String.Concat(m);
        }
    }
}
