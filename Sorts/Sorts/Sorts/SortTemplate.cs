using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sorts
{
    public class SortTemplate : ISort
    {
        private TimeSpan _executionTime;
        public TimeSpan ExecutionTime
        {
            get { return _executionTime; }
        }

        public bool IsStable
        {
            get { return true; }
        }

        public void Sort(IComparable[] collectionToSort)
        {
            var startTime = DateTime.Now;
            SortIteration(collectionToSort, 0, collectionToSort.Count() - 1);
            _executionTime = DateTime.Now - startTime;
        }

        private void SortIteration(IComparable[] collectionToSort, int left, int right)
        { 
            
        }
    }
}
