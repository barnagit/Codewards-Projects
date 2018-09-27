using System;

namespace Factorial_Tail
{
    class FactorialTail
    {
        public static int zeroes (int b_ase, int number) {
            int factorial, trailingzeroes = 0;
            for (factorial = 1; number > 1; factorial *= number--);
            while (factorial % b_ase == 0) { factorial /= b_ase; ++trailingzeroes; };
            return trailingzeroes;
        }
    }
}
