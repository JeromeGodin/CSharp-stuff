using Sorts.Sorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NUMBER_OF_ELEMENTS = 100;

            var arrayToSort = new IComparable[NUMBER_OF_ELEMENTS];
            for (var i = 0; i < NUMBER_OF_ELEMENTS; i++)
                arrayToSort[i] = i + 1;

            FisherYatesShuffle.Shuffle(arrayToSort);
            DisplayArrayToSort(NUMBER_OF_ELEMENTS, arrayToSort);

            var sorts = GetSorts();
            foreach (var sort in sorts)
            {
                var arrayTemp = (IComparable[])arrayToSort.Clone();
                sort.Sort(arrayTemp);
                Console.WriteLine(sort.GetType().ToString().Replace("Sorts.Sorts.", "") + "(" + (sort.IsStable ? "S" : "U") + ") : " + sort.ExecutionTime);
            }

            Console.ReadLine();
        }

        private static List<ISort> GetSorts()
        {
            var sorts = new List<ISort>();
            sorts.Add(new QuickSort());
            sorts.Add(new MergeSort());

            return sorts.OrderBy(s => s.IsStable).ToList();
        }

        private static void DisplayArrayToSort(int NUMBER_OF_ELEMENTS, IComparable[] arrayToSort)
        {
            Console.Write("Array to sort : [");
            for (var i = 0; i < NUMBER_OF_ELEMENTS - 1; i++)
                Console.Write(arrayToSort[i] + ", ");
            Console.WriteLine(arrayToSort[NUMBER_OF_ELEMENTS - 1] + "]");
            Console.WriteLine("-----------------------------------------------------");
        }
    }
}
