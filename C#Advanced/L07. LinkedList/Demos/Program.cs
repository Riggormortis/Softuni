using System;

namespace Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList linked list = new



                DoublyLinkedList linkedList = new DoublyLinkedList();

            linkedList.AddFirst(new Node(1));
            linkedList.AddFirst(new Node(2));
            linkedList.AddFirst(new Node(3));
            linkedList.AddFirst(new Node(4));

            linkedList.ForEach(node =>
            {
                Console.WriteLine(node.Value);
            });
            Console.WriteLine("Reversed");
            linkedList.Reverse();

            linkedList.ForEach(node =>
            {
                Console.WriteLine(node.Value);
            });
            Console.WriteLine("Reversed");
            linkedList.Reverse();

            linkedList.ForEach(node =>
            {
                Console.WriteLine(node.Value);
            });
            Console.WriteLine("Reversed");
            linkedList.Reverse();
            foreach (var node in linkedList.ToArray())
            {
                Console.WriteLine("In Foreach");
                Console.WriteLine(node.Value);
            }
        }
    }
}
