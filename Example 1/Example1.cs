using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        while (true)
        {
            bool[] münzen = new[] { true, true, true, true, true, true, false, false, false, false, false, false };
            münzen.Shuffle();

            Stack<bool> links = new Stack<bool>();
            Stack<bool> rechts = new Stack<bool>();
            for (int  i = 0;  i < 12;  i++)
            {
                if(i % 2 == 0)
                {
                    rechts.Push(münzen[i]);
                }
                else
                {
                    links.Push(münzen[i]);
                }
            }

            Console.WriteLine("Ausgang: " + string.Join(",", münzen.Select(x => x ? "Zahl" : "Kopf").ToArray()));
            Console.WriteLine("Links: " + string.Join(",", links.Select(x => x ? "Zahl" : "Kopf").ToArray()));
            Console.WriteLine("Rechts: " + string.Join(",", rechts.Select(x => x ? "Kopf" : "Zahl").ToArray()));

            if (Math.Abs(rechts.Select(x => x ? -1 : 1).Sum()) == Math.Abs(links.Select(x => x ? -1 : 1).Sum()))
                Console.WriteLine("Passt");
            else
                Console.WriteLine("Passt nicht");

            Console.ReadKey();
        }
    }
}

internal static class Utils
{
    private static Random rng = new Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}