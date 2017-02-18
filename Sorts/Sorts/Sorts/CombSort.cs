using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sorts
{
    public class CombSort : ISort
    {
        public bool IsStable
        {
            get { return false; }
        }

        private TimeComplexity _timeComplexity = new TimeComplexity() { BestCase = "Ω(n log(n))", AverageCase = "Θ(n^2 / 2^p)", WorstCase = "O(n^2)" };
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
			int gap = collectionToSort.Count();
			var shrinkFactor = 1.3;
			var sorted = false;

			while (!sorted)
			{
				gap = (int)Math.Floor(gap / shrinkFactor);

				if (gap > 1)
					sorted = false;
				else
				{
					gap = 1;
					sorted = true;
				}

				var i = 0;
				while (i + gap < collectionToSort.Count())
				{
					if (collectionToSort[i].CompareTo(collectionToSort[i + gap]) > 0)
					{
						var temporarySwap = collectionToSort[i];
						collectionToSort[i] = collectionToSort[i + gap];
						collectionToSort[i + gap] = temporarySwap;

						sorted = false;
					}

					i++;
				}
			}
        }
    }
}
