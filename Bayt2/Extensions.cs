using System.Collections.Generic;
using System.Numerics;

namespace Bayt2
{
    public static class Extensions
    {
        public static BigInteger Sum(this IEnumerable<BigInteger> source)
        {
            BigInteger sum = 0;
            foreach (BigInteger num in source)
            {
                sum += num;
            }

            return sum;
        }
    }
}