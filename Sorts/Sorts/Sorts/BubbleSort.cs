using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sorts
{
    public class BubbleSort : ISort
    {
        public bool IsStable
        {
            get { return true; }
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
            var n = collectionToSort.Count();
            
            while (n > 0)
            {
                var newN = 0;
                for (var i = 1; i < n; i++)
                {
                    if (collectionToSort[i].CompareTo(collectionToSort[i - 1]) < 0)
                    {
                        var temporarySwap = collectionToSort[i];
                        collectionToSort[i] = collectionToSort[i - 1];
                        collectionToSort[i - 1] = temporarySwap;

                        newN = i;
                    }
                }

                n = newN;
            }
        }
    }
}
