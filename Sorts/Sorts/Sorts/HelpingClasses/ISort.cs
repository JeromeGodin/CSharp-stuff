using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts.Sorts
{
    public interface ISort
    {
        bool IsStable { get; }
        TimeComplexity TimeComplexity { get; }
        string SpaceComplexity { get; }

        TimeSpan ExecutionTime { get; }
        void Sort(IComparable[] collectionToSort);
    }
}
