using System;

namespace Highest_Scoring_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(High("man i need a taxi up to ubud"));
        }

        public static string High(string s)
        {
            var words = s.Split(" ");
            string maxScoreWord = null;
            int maxScore = 0;
            int score = 0;
            foreach (var w in words) {
                score = 0;
                foreach (var c in w) {
                    score += (int)(c-'a'+1);
                }
                if (score > maxScore) {
                    maxScore = score;
                    maxScoreWord = w;
                }
            }

            return maxScoreWord;
        }
    }
}
