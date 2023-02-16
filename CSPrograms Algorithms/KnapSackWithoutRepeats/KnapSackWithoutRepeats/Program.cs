//Найдите максимальный вес золота, который можно унести в рюкзаке.


using System.Linq;


class Program
{
    static void Main()
    {
        int[] lengths = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        int[] weights = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

        Console.WriteLine(EvaluateMaxWeiht(weights, lengths[1], lengths[0]));
    }


    static long EvaluateMaxWeiht(int[] weights, int weightsCount, int capacity)
    {
        long[,] best = new long[weightsCount + 1, capacity + 1];

        for (int i = 1; i <= weightsCount; i++)
        { 
            for (int w = 0; w <= capacity; w++)
            {
                best[i, w] = best[i - 1, w];
                if (weights[i - 1] <= w)
                {
                    best[i, w] = Math.Max(best[i, w], weights[i - 1] + best[i - 1, w - weights[i - 1]]);
                }
            }

        }

        return best[weightsCount, capacity];
    }
}
