using System;
using System.Collections.Generic;
using System.Linq;

namespace Factorial_Tail
{
    class PrimeCounter {
        int Prime {get;set;}
        int Count {get;set;}
    }
    class FactorialTail
    {
        public static int zeroes (int b_ase, int number) {
            /*
            int factorial, trailingzeroes = 0;
            for (factorial = 1; number > 1; factorial *= number--);
            while (factorial % b_ase == 0) { factorial /= b_ase; ++trailingzeroes; };
            return trailingzeroes;
             */

            /*
            base is an integer from 2 to 256
            number is an integer from 1 to 1'000'000
             */
            

            int[] primeFactorsOfBase = primeFactors(b_ase);
            Dictionary<int,int> primeCounter = new Dictionary<int, int>();
            Dictionary<int,int> primeCounterOfBase = new Dictionary<int, int>();
            foreach (int prime in primeFactorsOfBase) {
                if(!primeCounter.ContainsKey(prime)) {
                    primeCounter.Add(prime, 0);
                }
                if (!primeCounterOfBase.ContainsKey(prime)) {
                    primeCounterOfBase.Add(prime, 1);
                } else {
                    primeCounterOfBase[prime]++;
                }
                
            }
            IEnumerator<int> primes = primeCounterOfBase.Keys.GetEnumerator();
            while (primes.MoveNext()) {
                for (int j=2; j<=number; j++) {
                    int n = j;
                    while (n % primes.Current == 0) {
                        primeCounter[primes.Current]++;
                        n/=primes.Current;
                    }
                }
            }
            
            int[] factorCounter = new int[primeCounterOfBase.Count]; 
            int i = 0;
            primes.Reset();
            while (primes.MoveNext()) {
                factorCounter[i++] = primeCounter[primes.Current] / primeCounterOfBase[primes.Current];
            }
            
            return factorCounter.Min();
        }

        // from: https://www.geeksforgeeks.org/print-all-prime-factors-of-a-given-number/
        // A function to print all prime  
        // factors of a given number n 
        public static int[] primeFactors(int n) 
        {
            List<int> primeFactors = new List<int>(); 
            // Print the number of 2s that divide n 
            while (n % 2 == 0) 
            { 
                primeFactors.Add(2); 
                n /= 2; 
            } 
    
            // n must be odd at this point. So we can 
            // skip one element (Note i = i +2) 
            for (int i = 3; i <= Math.Sqrt(n); i+= 2) 
            { 
                // While i divides n, print i and divide n 
                while (n % i == 0) 
                { 
                    primeFactors.Add(i);
                    n /= i; 
                } 
            } 
    
            // This condition is to handle the case whien 
            // n is a prime number greater than 2 
            if (n > 2) 
                primeFactors.Add(n);

            return primeFactors.ToArray();
        } 
        
    }
}
