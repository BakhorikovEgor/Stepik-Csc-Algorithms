//У вас есть примитивный калькулятор, который умеет выполнять всего три операции с текущим числом x:заменить x на 2x,3x или x+1.
//По данному целому числу определите минимальное число операций k, необходимое, чтобы получить n из 1.
//Выведите k и последовательность промежуточных чисел.

using System;
using System.Text;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        (int, string) answer = ShortestWay(n);

        Console.WriteLine(answer.Item1);
        Console.WriteLine(answer.Item2);
    }


    static (int, string) ShortestWay(int n)
    {
        int[] shortestWays = new int[n + 1];

        int modThreeWay;
        int modTwoWay;
        int minusOneWay;
        for (int i = 1; i <= n; ++i)
        {
            modThreeWay = int.MaxValue;
            modTwoWay = int.MaxValue;
            minusOneWay = shortestWays[i - 1] + 1;

            if (i % 3 == 0)
            {
                modThreeWay = shortestWays[i / 3 + (i == 3 ? -1 : 0)] + 1;
            }

            if (i % 2 == 0)
            {
                modTwoWay = shortestWays[i / 2 + (i == 2 ? -1 : 0)] + 1;
            }

            shortestWays[i] = Math.Min(Math.Min(modThreeWay, modTwoWay), minusOneWay);
        }

        return n == 1 ? (0,"1") : (shortestWays[n], RecoverWay(shortestWays));
    }


    static string RecoverWay(int[] shortestWays)
    {
        int currentInd = shortestWays.Length - 1;

        List<int> reverseWay = new List<int>();
        reverseWay.Add(currentInd);
        while (shortestWays[currentInd] > 1)
        {
            if (shortestWays[currentInd - 1] == shortestWays[currentInd] - 1)
            {
                reverseWay.Add(currentInd - 1);
                currentInd--;
            }
            else if (currentInd % 3 == 0 && shortestWays[currentInd / 3] == shortestWays[currentInd] - 1)
            {
                reverseWay.Add(currentInd / 3);
                currentInd /= 3;
            }
            else
            {
                reverseWay.Add(currentInd / 2);
                currentInd /= 2;
            }
        }

        reverseWay.Add(1);

        StringBuilder way = new StringBuilder();
        for (int i = reverseWay.Count - 1; i >= 0; --i)
        {
            way.Append($"{reverseWay[i]} ");
        }

        return way.ToString();
    }
}