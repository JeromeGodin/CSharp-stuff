using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sorts
{
    public class CycleSort : ISort
    {
        public bool IsStable
        {
            get { return false; }
        }

        private TimeComplexity _timeComplexity = new TimeComplexity() { BestCase = "Ω(n^2)", AverageCase = "Θ(n^2)", WorstCase = "O(n^2)" };
        public TimeComplexity TimeComplexity
        {
            get { return _timeComplexity; }
        }

        public string SpaceComplexity
        {
            get { return "Total : O(n), Auxiliary : O(1)"; }
        }

        private TimeSpan _executionTime;
        public TimeSpan ExecutionTime
        {
            get { return _executionTime; }
        }

		public int NumberOfWrites { get; private set; }

        public void Sort(IComparable[] collectionToSort)
        {
            var startTime = DateTime.Now;
            SortIteration(collectionToSort);
            _executionTime = DateTime.Now - startTime;
        }

        private int SortIteration(IComparable[] collectionToSort)
        {
			var writes = 0;

			for (var i = 0; i < collectionToSort.Count() - 1; i++)
			{
				var position = i;

				for (var j = i + 1; j < collectionToSort.Count(); j++)
					if (collectionToSort[j].CompareTo(collectionToSort[i]) < 0)
						position++;

				if (position == i)
					continue;

				while (collectionToSort[i].CompareTo(collectionToSort[position]) == 0)
					position++;

				var temporarySwap = collectionToSort[i];
				collectionToSort[i] = collectionToSort[position];
				collectionToSort[position] = temporarySwap;
				writes++;

				while (position != i)
				{
					position = i;
					for (var j = i + 1; j < collectionToSort.Count(); j++)
						if (collectionToSort[j].CompareTo(collectionToSort[i]) < 0)
							position++;

					if (position != i)
					{
						while (collectionToSort[i].CompareTo(collectionToSort[position]) == 0)
							position++;

						var temporarySwap2 = collectionToSort[i];
						collectionToSort[i] = collectionToSort[position];
						collectionToSort[position] = temporarySwap2;
						writes++;
					}
				}
			}

			return writes;
        }
    }
}
