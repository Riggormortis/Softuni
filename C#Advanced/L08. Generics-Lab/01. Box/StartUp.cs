using System;
using System.Collections.Generic;

namespace BoxOfT
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Box box = new Box();
            box.Add()
        }
    }

    public class Box
    {
        private List<int> internalList = new List<int>();

        public void Add (int item)
        {
            internalList.Add(item);
        }

        public int Remove()
        {
            int removedItem = internalList[internalList.Count - 1];
            internalList.RemoveAt(internalList.Count - 1);
            return removedItem;
        }

        public int Count => internalList.Count;           // get{ } 
    }
}
