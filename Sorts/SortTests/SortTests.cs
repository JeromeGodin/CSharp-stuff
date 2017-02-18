using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorts.Sorts;
using Sorts;
using System.Collections.Generic;
using System.Linq;

namespace SortTests
{
	[TestClass]
	public class SortTests
	{
		Type[] _sortsToTest = { 
            typeof(QuickSort), 
            typeof(MergeSort), 
            typeof(BubbleSort), 
            typeof(CocktailShakerSort), 
			typeof(CombSort), 
			typeof(CycleSort), 
			typeof(GnomeSort)
        };

		[TestMethod]
		public void Sort_ShouldSortTheDataInAscending_GivenAShuffledCollection()
		{
			//Arrange
			const int NUMBER_OF_ELEMENTS = 1000;
			List<Type> failedSorts = new List<Type>();

			var collectionToSort = new IComparable[NUMBER_OF_ELEMENTS];
			for (var i = 0; i < NUMBER_OF_ELEMENTS; i++)
				collectionToSort[i] = i + 1;

			FisherYatesShuffle.Shuffle(collectionToSort);

			foreach (var sortType in _sortsToTest)
			{
				//Act
				var temporaryCollection = (IComparable[])collectionToSort.Clone();
				((ISort)Activator.CreateInstance(sortType)).Sort(temporaryCollection);

				//Assert
				for (var i = 1; i < NUMBER_OF_ELEMENTS; i++)
				{
					if (temporaryCollection[i].CompareTo(temporaryCollection[i - 1]) < 0)
					{
						failedSorts.Add(sortType);
						break;
					}
				}
			}

			if (failedSorts.Any())
			{
				string names = "";
				foreach (var sortType in failedSorts)
					names += sortType.Name + ", ";

				names = names.Substring(0, names.Length - 2);
				names = names.ReplaceLastOccurrence(", ", " and ");

				Assert.Fail("The " + names + " failed.");
			}
		}
	}
}
