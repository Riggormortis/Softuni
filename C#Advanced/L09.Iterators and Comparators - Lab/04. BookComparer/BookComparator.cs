using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Diagnostics.CodeAnalysis;


namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            int result = x.Title.CompareTo(y.Title);
            if (result == 0)
            {
                return y.Year.CompareTo(x.Year);
            }

            return result;
        }
    }
}
