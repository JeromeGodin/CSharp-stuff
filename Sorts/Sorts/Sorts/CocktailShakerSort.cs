using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sorts
{
    public class CocktailShakerSort : ISort
    {
        public bool IsStable
        {
            get { return false; }
        }

        private TimeComplexity _timeComplexity = new TimeComplexity() { BestCase = "Ω(n)", AverageCase = "Θ(n^2)", WorstCase = "O(n^2)" };
        public TimeComplexity TimeComplexity
        {
            get { return _timeComplexity; }
        }

        public string SpaceComplexity
        {
            get { return "O(1)"; }
        }

        private TimeSpan _executionTime;
        public TimeSpan ExecutionTime
        {
            get { return _executionTime; }
        }

        public void Sort(IComparable[] collectionToSort)
        {
            var startTime = DateTime.Now;
            SortIteration(collectionToSort);
            _executionTime = DateTime.Now - startTime;
        }

        private void SortIteration(IComparable[] collectionToSort)
        {
            var lowerBound = 0;
            var upperBound = collectionToSort.Count() - 2;

            while ( lowerBound <= upperBound)
            {
                var newLowerBound = lowerBound;
                var newUpperBound = upperBound;

                var swapped = false;
                for (var i = lowerBound; i <= upperBound; i++)
                {
                    if (collectionToSort[i + 1].CompareTo(collectionToSort[i]) < 0)
                    {
                        var temporarySwap = collectionToSort[i];
                        collectionToSort[i] = collectionToSort[i + 1];
                        collectionToSort[i + 1] = temporarySwap;

                        newUpperBound = i;
                        swapped = true;
                    }
                }

                if (!swapped) break;

                upperBound = newUpperBound - 1;

                swapped = false;
                for (var i = upperBound; i >= lowerBound; i--)
                {
                    if (collectionToSort[i + 1].CompareTo(collectionToSort[i]) < 0)
                    {
                        var temporarySwap = collectionToSort[i];
                        collectionToSort[i] = collectionToSort[i + 1];
                        collectionToSort[i + 1] = temporarySwap;

                        newLowerBound = i;
                        swapped = true;
                    }
                }

                if (!swapped) break;

                lowerBound = newLowerBound + 1;
            }
        }
    }
}
