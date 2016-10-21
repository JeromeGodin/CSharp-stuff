using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    public class FisherYatesShuffle
    {
        static Random _random = new Random();

        public static void Shuffle(IComparable[] arrayToShuffle)
        {
            int n = arrayToShuffle.Length;
            for (int i = 0; i < n; i++)
            {
                // NextDouble returns a random number between 0 and 1.
                // ... It is equivalent to Math.random() in Java.
                int r = i + (int)(_random.NextDouble() * (n - i));
                IComparable t = arrayToShuffle[r];
                arrayToShuffle[r] = arrayToShuffle[i];
                arrayToShuffle[i] = t;
            }
        }
    }
}
