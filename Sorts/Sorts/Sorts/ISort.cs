using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sorts
{
    public interface ISort
    {
        TimeSpan ExecutionTime { get; }
        bool IsStable { get; }
        void Sort(IComparable[] collectionToSort);
    }
}
