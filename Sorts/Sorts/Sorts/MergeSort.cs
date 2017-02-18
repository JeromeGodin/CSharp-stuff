using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sorts
{
    public class MergeSort : ISort
    {
        public bool IsStable
        {
            get { return true; }
        }

        private TimeComplexity _timeComplexity = new TimeComplexity() { BestCase = "Ω(n log(n))", AverageCase = "Θ(n log(n))", WorstCase = "O(n log(n))" };
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
            int mid;

            if (right.CompareTo(left) > 0)
            {
                mid = (right + left) / 2;
                SortIteration(collectionToSort, left, mid);
                SortIteration(collectionToSort, (mid + 1), right);

                Merge(collectionToSort, left, (mid + 1), right);
            }
        }

        private void Merge(IComparable[] collectionToSort, int left, int mid, int right)
        {
            IComparable[] temporaryCollection = new IComparable[collectionToSort.Count()];
            int i, leftBound, numberOfElements, temporaryPosition;

            leftBound = (mid - 1);
            temporaryPosition = left;
            numberOfElements = (right - left + 1);

            while ((left <= leftBound) && (mid <= right))
            {
                if (collectionToSort[left].CompareTo(collectionToSort[mid]) <= 0)
                    temporaryCollection[temporaryPosition++] = collectionToSort[left++];
                else
                    temporaryCollection[temporaryPosition++] = collectionToSort[mid++];
            }

            while (left <= leftBound)
                temporaryCollection[temporaryPosition++] = collectionToSort[left++];

            while (mid <= right)
                temporaryCollection[temporaryPosition++] = collectionToSort[mid++];

            for (i = 0; i < numberOfElements; i++)
            {
                collectionToSort[right] = temporaryCollection[right];
                right--;
            }
        }
    }
}
