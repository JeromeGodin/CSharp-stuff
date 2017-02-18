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
            const int NUMBER_OF_ELEMENTS = 10000;

            var collectionToSort = new IComparable[NUMBER_OF_ELEMENTS];
            for (var i = 0; i < NUMBER_OF_ELEMENTS; i++)
                collectionToSort[i] = i + 1;

            FisherYatesShuffle.Shuffle(collectionToSort);
            //DisplayArrayToSort(NUMBER_OF_ELEMENTS, collectionToSort);

            var sorts = GetSorts();
            foreach (var sort in sorts)
            {
                var temporaryCollection = (IComparable[])collectionToSort.Clone();
                sort.Sort(temporaryCollection);
                Console.WriteLine(sort.GetType().ToString().Replace("Sorts.Sorts.", "") + "(" + (sort.IsStable ? "S" : "U") + ") : " + sort.ExecutionTime);
            }

            Console.ReadLine();
        }

        private static List<ISort> GetSorts()
        {
            var sorts = new List<ISort>();
            sorts.Add(new QuickSort());
            sorts.Add(new MergeSort());
            sorts.Add(new BubbleSort());
            sorts.Add(new CocktailShakerSort());
			sorts.Add(new CombSort());
			sorts.Add(new CycleSort());
			sorts.Add(new GnomeSort());

            return sorts.OrderByDescending(s => s.IsStable).ThenBy(s => s.GetType().Name).ToList();
        }

        private static void DisplayArrayToSort(int NUMBER_OF_ELEMENTS, IComparable[] arrayToSort)
        {
            Console.WriteLine("Most of the information to code these has been taken from http://bigocheatsheet.com/ and https://en.wikipedia.org/.");
            Console.Write("Array to sort : [");
            for (var i = 0; i < NUMBER_OF_ELEMENTS - 1; i++)
                Console.Write(arrayToSort[i] + ", ");
            Console.WriteLine(arrayToSort[NUMBER_OF_ELEMENTS - 1] + "]");
            Console.WriteLine("-----------------------------------------------------");
        }
    }
}
