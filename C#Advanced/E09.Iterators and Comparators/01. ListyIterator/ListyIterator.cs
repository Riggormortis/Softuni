using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class ListyIterator<T>
    {
        private readonly List<T> elements;
        private int index;

        public ListyIterator(List<T> elements)
        {
            this.elements = elements;
            this.index = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            return false;
        }


        public bool HasNext()
            => index < elements.Count - 1;

        //same
        //{
           // if (index < elements.Count - 1)
          //  {
         //       return true;
         //   }

          //  return false;
       // }

        public void Print()
        {
            if (elements.Count == 0)
            {
                throw new Exception("Invalid Operation!");
            }

            Console.WriteLine(elements[index]);
        }
    }
}
