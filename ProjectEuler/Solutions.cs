using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEuler
{
    public static class Solutions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int Solution1()
        {
            //const int MAX = 10;
            const int MAX = 1000;

            var array = Enumerable.Range(1, MAX - 1).ToList();
            //var multiplesOfThree = array.Where(item => item % 3 == 0);
            //var multiplesOfFive = array.Where(item => item % 5 == 0);
            //var answer = multiplesOfThree.Concat(multiplesOfFive).Sum();

            return Enumerable.Range(1, MAX - 1).ToList().Where(item => item % 3 == 0 || item % 5 == 0).Sum();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int Solution2()
        {
            #region Generate Fibonacci Sequence
            const int MAX = 4000000;

            int x = 0;
            int fibonacciTerm = 0;

            var fibonacciSequence = new List<int>();

            while (fibonacciTerm < MAX)
            {
                int a = 1;
                int b = 2;

                // In N steps compute Fibonacci sequence iteratively.
                for (int y = 0; y < x; y++)
                {
                    int temp = a;

                    a = b;
                    b = temp + b;
                }

                fibonacciTerm = a;
                fibonacciSequence.Add(fibonacciTerm);

                x++;
            }
            #endregion

            //var answer = Fibonacci().TakeWhile(item => item < MAX).Where(item => item % 2 == 0).Sum();  // NOTE: For testing only

            return fibonacciSequence.Where(item => item % 2 == 0).Sum();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long Solution3()
        {
            //long MAX = 13195L;
            long MAX = 600851475143L;

            //var primeNumbers = SieveOfEratosthenes(MAX).TakeWhile(item => item < MAX).ToList();
            var primeNumbers = PrimeGenerator().TakeWhile(item => item < MAX).ToList();
            long largestPrimeFactor = primeNumbers.Where(item => MAX % item == 0).Max();

            //foreach (var number in primeNumbers)
            //{
            //    if (MAX % number == 0 && number > largestPrimeFactor)  // True of the largest prime factor
            //    {
            //        largestPrimeFactor = number;
            //    }
            //}

            return largestPrimeFactor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long Solution4()
        {
            const long MIN = 101L;  // Lowest number can never be a zero
            const long MAX = 999L;

            long largestPalindrome = 0L;

            foreach (var number in PalindromeSequence(MIN, MAX))
            {
                if (number > largestPalindrome)  // True if the largest palindrome
                {
                    largestPalindrome = number;
                }
            }

            return largestPalindrome;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int Solution5()
        {
            //const int MAX = 10;
            const int MAX = 20;

            var sequence = Solution5Helper(MAX).FirstOrDefault();

            return sequence;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long Solution6()
        {
            //const int MAX = 10;
            const int MAX = 100;

            var array = Enumerable.Range(1, MAX).ToList();
            long sumOfSquares = array.Select(item => item * item).Sum();
            long squareOfSum = array.Sum() * array.Sum();

            return squareOfSum - sumOfSquares;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long Solution7()
        {
            //const int MAX = 6;
            const int MAX = 10001;

            var lastPrimeNumber = PrimeGenerator().Take(MAX).Last();

            return lastPrimeNumber;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long Solution8()
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long Solution9()
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long Solution10()
        {
            return 0;
        }

        #region Helpers
        /// <summary>
        /// Fibonacci generator
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<long> Fibonacci()
        {
            long current = 0;
            long next = 1;

            while (true)
            {
                yield return current;

                long temp = next;

                next = current + next;
                current = temp;
            }
        }

        /// <summary>
        /// Prime number gnerator.
        /// Learned about Sieves after code was complete.
        /// Could have used Sieve of Eratosthenes.
        /// This took way too long for Solution 3!
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<int> PrimeGenerator()
        {
            int primeFactor = 2;

            while (true)
            {
                int i = 2;

                for (; i <= primeFactor; i++)
                {
                    if (primeFactor % i == 0)
                    {
                        break;
                    }
                }

                if (i == primeFactor)
                {
                    yield return primeFactor;
                }

                primeFactor++;
            }
        }

        /// <summary>
        /// Prime number generator using Sieve of Eratosthenes.
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        private static IEnumerable<long> SieveOfEratosthenes(long max)
        {
            HashSet<long> skipped = new HashSet<long>();
            List<long> test = new List<long>();

            for (long i = 2; i <= max; i++)
            {
                if (!skipped.Contains(i))
                {
                    test.Add(i);
                    yield return i;
                }

                for (long j = i + i; j <= max; j += i)
                {
                    if (!skipped.Contains(j))
                    {
                        skipped.Add(j);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<long> PalindromeSequence(long min, long max)
        {
            long result = min * max;
            bool fail = false;

            for (long x = min; x <= max; x++)
            {
                for (long y = x; y <= max; y++)  // To avoid repeats, don't start from the beginning
                {
                    result = x * y;
                    fail = false;

                    string test = result.ToString();

                    for (int i = 0; i < test.Length / 2; i++)  // No need to go more than half way
                    {
                        if (test[i] != test[test.Length - i - 1])
                        {
                            fail = true;
                            break;
                        }
                    }

                    if (!fail)
                    {
                        yield return result;

                        fail = false;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        private static IEnumerable<int> Solution5Helper(int max)
        {
            int number = max % 2 == 0 ? max : max + 1;  // The numbe will always be an even one, otherwise it is not divisible by 2
            bool fail = false;

            while (true)
            {
                fail = false;

                for (int i = 2; i <= max; i++)  // 0 and 1 will always work
                {
                    if (number % i != 0)
                    {
                        fail = true;
                        break;
                    }
                }

                if (!fail)
                {
                    yield return number;

                    fail = false;
                }

                number += 2;  // The number will always be an even one, otherwise it is not divisible by 2
            }
        }
        #endregion
    }
}