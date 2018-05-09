using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Decode_the_Morse_code
{
    class Program
    {
        static Dictionary<string,string> MorseCode = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(Decode(".... . -.--   .--- ..- -.. ."));
        }

        public static string Decode(string morseCode)
        {
            //MorseCode.Get(".--");
            StringBuilder sb = new StringBuilder();

            bool inWordSeparationMode = false;
            string[] letters = morseCode.Split(' ');
            foreach (String letter in letters) {
                if (String.IsNullOrEmpty(letter)) {
                    if (!inWordSeparationMode) {
                        sb.Append(" ");
                        inWordSeparationMode = true;
                    }
                }
                else {
                    inWordSeparationMode = false;
                    sb.Append(MorseCode[letter]); //use MorseCode.Get(".--") in case of attempting.
                }
            }
            return sb.ToString().Trim();
        }
    }
}
