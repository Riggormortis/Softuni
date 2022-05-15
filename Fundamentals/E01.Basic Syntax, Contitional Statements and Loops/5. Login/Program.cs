using System;

namespace _5._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            string username = Console.ReadLine();


            //actions
            //Reverse the username

            string password = string.Empty; // string.Empty e ekvivalentno na ""

            //C# Fund
            //0123456 - ot nula do 6, no stringa e 7 simvola - Sting.Lenght = 7 => index from 0 to lenght - 1
            for (int reverseIndex = username.Length - 1; reverseIndex >= 0; reverseIndex--)
            {
                password += username[reverseIndex];
            }

            for (int count = 1; count <= 4; count++)
            {
                string enteredPassword = Console.ReadLine();

                if (enteredPassword == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else
                {
                    if (count == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                        continue;
                    }
                }



            }




        }
    }
}
