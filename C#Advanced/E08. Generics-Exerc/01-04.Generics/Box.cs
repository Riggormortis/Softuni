using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Box<T>
    {
        public Box()
        {
            this.Items = new List<T>();
        }

        public List<T> Items { get; set; }

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


    }
}
