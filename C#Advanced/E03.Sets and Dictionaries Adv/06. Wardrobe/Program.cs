using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    static void Main(String[] args)
    {

        Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string color = tokens[0];
            var clothes = tokens[1]
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (!wardrobe.ContainsKey(color))
            {
                wardrobe.Add(color, new Dictionary<string, int>());
            }

            foreach (var item in clothes)
            {
                if (!wardrobe[color].ContainsKey(item))
                {
                    wardrobe[color][item] = 1;
                }
                else
                {
                    wardrobe[color][item]++;
                }
            }
        }

        var wantedCloth = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        string wantedColor = wantedCloth[0];
        string wantedClothing = wantedCloth[1];

        foreach (var kvp in wardrobe)
        {
            Console.WriteLine($"{kvp.Key} clothes:");

            foreach (var item in kvp.Value)
            {
                if (kvp.Key == wantedColor && item.Key == wantedClothing)
                {
                    Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                }
                else
                {
                    Console.WriteLine($"* {item.Key} - {item.Value}");
                }
            }
        }
    }
}
