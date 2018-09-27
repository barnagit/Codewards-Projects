using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Text_Align_Justify
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static string NL = Environment.NewLine;

        public static string Justify(string str, int len)
        {  
            StringBuilder text = new StringBuilder(str.Length * 2);
            string[] words = str.Split(' ');

            Queue<string> row = new Queue<string>();
            int conLen = 0;

            int i = 0;
            while (i < words.Length) {
                
                conLen = 0;
                row.Clear();

                while (conLen < len) {
                    if (conLen + words[i].Length + 1 < len) {
                        conLen += words[i].Length + 1;
                        row.Enqueue(words[i]);
                    }
                    i++;
                }

                
            }

            return text.ToString();
        }
    }
}
