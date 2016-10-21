using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sorts
{
    public class MergeSort : ISort
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

        public void SortIteration(IComparable[] collectionToSort, int left, int right)
        {
            int mid;

            if (right.CompareTo(left) > 0)
            {
                mid = (right + left) / 2;
                SortIteration(collectionToSort, left, mid);
                SortIteration(collectionToSort, (mid + 1), right);

                DoMerge(collectionToSort, left, (mid + 1), right);
            }
        }

        public void DoMerge(IComparable[] collectionToSort, int left, int mid, int right)
        {
            IComparable[] temp = new IComparable[collectionToSort.Count()];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (collectionToSort[left].CompareTo(collectionToSort[mid]) <= 0)
                    temp[tmp_pos++] = collectionToSort[left++];
                else
                    temp[tmp_pos++] = collectionToSort[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = collectionToSort[left++];

            while (mid <= right)
                temp[tmp_pos++] = collectionToSort[mid++];

            for (i = 0; i < num_elements; i++)
            {
                collectionToSort[right] = temp[right];
                right--;
            }
        }
    }
}
