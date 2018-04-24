using System;
using System.Text;

namespace Simple_Encryption_Alternating_Split
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(Encrypt("This kata is very interesting!", 1));
        }

        static string Encrypt(string text, int n)
        {
            if (String.IsNullOrEmpty(text)) return text;
            
            string returnText = text;
            for (int i = 0;i <n;i++) returnText = Wind(returnText);
            return returnText;
        }

        static string Decrypt(string encryptedText, int n)
        {
            if (String.IsNullOrEmpty(encryptedText)) return encryptedText;
            string returnText = encryptedText;
            for (int i = 0; i<n;i++) returnText = Unwind(returnText);
            return returnText;
        }

        static string Wind(string text)
        {
            StringBuilder sb1 = new StringBuilder(text.Length/2+1);
            StringBuilder sb2 = new StringBuilder(text.Length/2+1);
            for (int i = 0; i < text.Length; i++)
            {
                if (i%2==0) sb1.Append(text[i]);
                else sb2.Append(text[i]);
            }

            return sb2.Append(sb1).ToString();
        }

        static string Unwind(string text)
        {
            StringBuilder sb = new StringBuilder(text.Length);
            int half = text.Length/2;
            for (int i=0; i<half; i++)
            {
                sb.Append(text[i+half]);
                sb.Append(text[i]);
            }
            if (text.Length%2==1) sb.Append(text[text.Length-1]);
            return sb.ToString();
        }

    }
}
