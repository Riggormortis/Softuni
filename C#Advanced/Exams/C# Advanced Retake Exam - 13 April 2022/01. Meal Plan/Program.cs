using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Meal_Plan
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

            Stack<int> caloriesPerDay = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int mealsNumber = meals.Count;

            while ((meals.Count > 0) && (caloriesPerDay.Count > 0))
            {
                int currentDayCal = caloriesPerDay.Pop();

                int currentMealCal = CaloriesFromMeal(meals.Peek());

                if (currentDayCal - currentMealCal >= 0)
                {
                    currentDayCal -= currentMealCal;
                    meals.Dequeue();
                    caloriesPerDay.Push(currentDayCal);
                }
                else if (caloriesPerDay.Count > 0)
                {
                    currentDayCal -= currentMealCal;
                    currentDayCal += caloriesPerDay.Pop();
                    if (currentDayCal > 0)
                    {
                        caloriesPerDay.Push(currentDayCal);
                        meals.Dequeue();
                    }

                    if (caloriesPerDay.Count == 0)
                    {
                        meals.Dequeue();
                    }
                }
                else
                {
                    if (caloriesPerDay.Count == 0)
                    {
                        meals.Dequeue();
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            if (caloriesPerDay.Count > 0)
            {
                sb.AppendLine($"John had {mealsNumber} meals.");
                sb.AppendLine($"For the next few days, he can eat {string.Join(", ", caloriesPerDay)} calories.");
            }
            else
            {
                sb.AppendLine($"John ate enough, he had {mealsNumber - meals.Count} meals.");
                sb.AppendLine($"Meals left: {string.Join(", ", meals)}.");

            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
        private static int CaloriesFromMeal(string currentMeal)
        {
            const int saladCalories = 350;
            const int soupCalories = 490;
            const int pastaCalories = 680;
            const int steakCalories = 790;
            if (currentMeal == "salad")
            {
                return saladCalories;
            }
            else if (currentMeal == "soup")
            {
                return soupCalories;
            }
            else if (currentMeal == "pasta")
            {
                return pastaCalories;
            }
            else if (currentMeal == "steak")
            {
                return steakCalories;
            }
            return 0;
        }

    }
}
