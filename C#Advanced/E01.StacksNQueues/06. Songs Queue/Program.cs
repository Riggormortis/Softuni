using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songsQueue = new Queue<string>(Console.ReadLine().Split(", "));

            //stop: песните свършат
            //продължаваме: имаме песни

            while (songsQueue.Count > 0)
            {
                string cmd = Console.ReadLine();
                //"Play"
                if (cmd == "Play")
                {
                    songsQueue.Dequeue(); //first song
                }
                //"Add {song}".Split() -> ["Add", "{song}"]
                else if (cmd.Contains("Add"))
                {
                    //"Add Watch Me"
                    string song = cmd.Substring(4);
                    //да я има -> "{song} is already contained!"
                    if (songsQueue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    //да я няма -> слагаме на опашката
                    else
                    {
                        songsQueue.Enqueue(song);

                    }

                }

                //"Show"

                else if (cmd == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
            }

            Console.WriteLine("No more songs!");

        }
    }
}
