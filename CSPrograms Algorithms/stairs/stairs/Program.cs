//Найдите максимальную сумму, которую можно получить, идя по лестнице снизу вверх (от нулевой до n - й ступеньки), 
//каждый раз поднимаясь на одну или две ступеньки.


using System;
using System.Linq;

public class MainClass
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] costs = Console.ReadLine().Split().Select(int.Parse).ToArray();

        long[] countedCosts = new long[n];
        for (long i = 0; i < n; i++)
        {
            countedCosts[i] = int.MinValue;
        }

        Console.WriteLine(GetMaxStairCost(costs));
    }


    static long GetMaxStairCost(int[] costs)
    {

        if (costs.Length == 1)
        {
            return costs[0];
        }

        if (costs.Length == 2)
        {
            return Math.Max(costs[0] + costs[1], costs[1]);
        }

        int prev = Math.Max(costs[1] + costs[0], costs[1]);
        int prevPrev = costs[0];

        for (int i = 2;i < costs.Length; i++) 
        {
            int tempPrev = prev;
            prev = costs[i] + Math.Max(prev, prevPrev);
            prevPrev = tempPrev;
        }

        return prev;
    }
}