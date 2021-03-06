﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sorts
{
    public class QuickSort : ISort
    {
        public bool IsStable
        {
            get { return false; }
        }

        private TimeComplexity _timeComplexity = new TimeComplexity() { BestCase = "Ω(n log(n))", AverageCase = "Θ(n log(n))", WorstCase = "O(n^2)" };
        public TimeComplexity TimeComplexity
        {
            get { return _timeComplexity; }
        }

        public string SpaceComplexity
        {
            get { return "O(log(n))"; }
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
            int i = left;
            int j = right;
            IComparable pivot = collectionToSort[(left + right) / 2];

            while (i <= j)
            {
                while (collectionToSort[i].CompareTo(pivot) < 0)
                    i++;

                while (collectionToSort[j].CompareTo(pivot) > 0)
                    j--;

                if (i <= j)
                {
                    IComparable temporaryCollection = collectionToSort[i];
                    collectionToSort[i] = collectionToSort[j];
                    collectionToSort[j] = temporaryCollection;

                    i++;
                    j--;
                }
            }

            if (left < j)
                SortIteration(collectionToSort, left, j);

            if (i < right)
                SortIteration(collectionToSort, i, right);
        }
    }
}
