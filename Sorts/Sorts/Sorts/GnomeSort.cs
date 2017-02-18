using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sorts
{
    public class GnomeSort : ISort
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
			var position = 0;

			while (position < collectionToSort.Count())
			{
				if (position == 0 || collectionToSort[position].CompareTo(collectionToSort[position - 1]) >= 0)
					position++;
				else
				{
					var temporarySwap = collectionToSort[position - 1];
					collectionToSort[position - 1] = collectionToSort[position];
					collectionToSort[position] = temporarySwap;

					position--;
				}
			}
        }
    }
}
