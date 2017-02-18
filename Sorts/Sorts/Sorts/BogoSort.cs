using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sorts
{
    //Not added to the tests or program execution due to its potential inability to converge to a solution.

    public class BogoSort : ISort
    {
        public bool IsStable
        {
            get { return false; }
        }

        private TimeComplexity _timeComplexity = new TimeComplexity() { BestCase = "Ω(n)", AverageCase = "Θ((n+1)!)", WorstCase = "O(∞)" };
        public TimeComplexity TimeComplexity
        {
            get { return _timeComplexity; }
        }

        public string SpaceComplexity
        {
            get { return "O(n)"; }
        }

        private TimeSpan _executionTime;
        public TimeSpan ExecutionTime
        {
            get { return _executionTime; }
        }

        public void Sort(IComparable[] collectionToSort)
        {
            var startTime = DateTime.Now;
            SortIteration(collectionToSort, 0, collectionToSort.Count() - 1);
            _executionTime = DateTime.Now - startTime;
        }

        private void SortIteration(IComparable[] collectionToSort, int left, int right)
        {
            while (!IsCollectionSorted(collectionToSort))
                FisherYatesShuffle.Shuffle(collectionToSort);
        }

        private bool IsCollectionSorted(IComparable[] collectionToValidate)
        {
            for (var i = 1; i < collectionToValidate.Count(); i++)
                if (collectionToValidate[i].CompareTo(collectionToValidate[i - 1]) < 0)
                    return false;

            return true;
        }
    }
}
