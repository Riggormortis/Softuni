using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Box<T> where T : IComparable
    {
        

        public Box()
        {
            this.Items = new List<T>();
        }

        public List<T> Items { get; set; }

        public int GetGreaterElementsCount(T value)
        {
            CheckIfEmpty();

            int counter = 0;

            foreach (var item in this.Items)
            {
                if (item.CompareTo(value) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }


        public void Swap(int firstIndex, int secondIndex)
        {
            (Items[firstIndex], Items[secondIndex]) = (Items[secondIndex], Items[firstIndex]); //python oriented solution
            //ili taka
            //T item = Items[firstIndex];
            //Items[firstIndex] = Items[secondIndex];
            //Items[secondIndex] = item;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in Items)
            {
                stringBuilder.AppendLine($"{typeof(T)}: {item}");
            }

            return stringBuilder.ToString();
        }


        private void CheckIfEmpty()
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException("Collection is empty!");
            }
        }

        private void CheckIndexOutOfRange(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= this.Items.Count
                            || secondIndex < 0 && secondIndex >= this.Items.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

    }
}
