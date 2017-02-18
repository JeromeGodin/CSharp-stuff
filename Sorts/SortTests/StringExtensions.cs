using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTests
{
    public static class StringExtensions
    {
        public static string ReplaceLastOccurrence(this string source, string oldValue, string newValue)
        {
            int index = source.LastIndexOf(oldValue);
            return index == -1 ? source : source.Remove(index, oldValue.Length).Insert(index, newValue);
        }
    }
}
