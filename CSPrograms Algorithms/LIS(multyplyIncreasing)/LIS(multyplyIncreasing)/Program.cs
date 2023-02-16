//Задача на программирование: наибольшая последовательнократная подпоследовательность


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(GetMaxMultiplyIncreasingSubsequnceLength(n,sequence));
    }


    static int GetMaxMultiplyIncreasingSubsequnceLength(int length, int[] sequence)
    {
        int[] tempLengths = new int[length];
        for (int i = 0; i < length; i++)
        {
            tempLengths[i] = 1;
            for (int j = 0; j < i; j++)
            {
                if (sequence[i] % sequence[j] == 0 && tempLengths[j] + 1 > tempLengths[i])
                {
                    tempLengths[i] = tempLengths[j] + 1;
                }
            }
        }

        int maxLength = 0;
        foreach (int tempLength in tempLengths)
        {
            if (tempLength > maxLength)
            {
                maxLength = tempLength;
            }
        }

        return maxLength;
    }
}