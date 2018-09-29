using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Text_Align_Justify
{
    class Program
    {
        /*
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program.Justify("123 45 6", 7);
        }
        */
        static string NL = "\n"; //Environment.NewLine;

        public static string Justify(string str, int len)
        {  
            if (String.IsNullOrWhiteSpace(str)) return String.Empty; 

            StringBuilder text = new StringBuilder(str.Length * 2);
            string[] words = str.Split(' ');

            List<string> row = new List<string>();
            int lenWordsInRow = 0;
            int cntWordsInRow = 0;

            int i = 0;
            // iterate through all the words.
            while (i < words.Length) {
                
                lenWordsInRow = 0;
                cntWordsInRow = 0;
                row.Clear();

                // make a row
                while (lenWordsInRow < len) {
                    // the length of the words + the single spaces between them + the following word + that space belonging
                    if (i < words.Length && lenWordsInRow + cntWordsInRow -1 + words[i].Length + 1  <= len && words[i] != NL)  {
                        lenWordsInRow += words[i].Length;
                        row.Add(words[i]);
                        row.Add(" ");
                        cntWordsInRow++;
                        i++;
                    }
                    else break;
                }

                // remove the last trailing space
                row.RemoveAt(row.Count()-1);

                // if we have more than one word in the row and it is not the last row
                if (row.Count() > 1 && i < words.Length) {
                    // the spaces we need to disperse: total length - character in words - separating spaces
                    int extraSpaces = len - lenWordsInRow - cntWordsInRow + 1;

                    // dispersing spaces
                    while (extraSpaces > 0) {
                        for (int j = 1; j < row.Count()-1 && extraSpaces > 0; j+=2) {
                            row[j] = row[j] + " ";
                            extraSpaces--;
                        }
                    }
                }

                row.ForEach(x => text.Append(x));
                if (i < words.Length) text.Append(NL);
            }

            Console.WriteLine(text.ToString());
            return text.ToString();
        }
    }
}
