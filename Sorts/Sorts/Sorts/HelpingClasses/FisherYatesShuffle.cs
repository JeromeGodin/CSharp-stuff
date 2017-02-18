using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sorts
{
    public class FisherYatesShuffle
    {
        static Random _random = new Random();

        public static void Shuffle(IComparable[] arrayToShuffle)
        {
            int n = arrayToShuffle.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + (int)(_random.NextDouble() * (n - i));
                IComparable temporaryElement = arrayToShuffle[r];
                arrayToShuffle[r] = arrayToShuffle[i];
                arrayToShuffle[i] = temporaryElement;
            }
        }
    }
}
