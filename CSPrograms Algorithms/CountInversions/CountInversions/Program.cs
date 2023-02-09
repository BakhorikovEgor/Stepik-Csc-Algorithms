using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Security;

class Program
{
    /// <summary>
    /// Если реализовать не на итераторном merge sort, то кода будет сильно меньше
    /// </summary>
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(CountInversions(data,n));
    }

    static System.Int64 CountInversions(int[] data,int currentLenght)
    {
        Queue<int[]> queue = new Queue<int[]>();
        Stack<int[]> oddParts = new Stack<int[]>(); 
        System.Int64 counter = 0;
        for (int i = 0; i < currentLenght; i++)
        {
            queue.Enqueue(new int[] { data[i] });
        }

        while (queue.Count > 1)
        {
            for(int i = 0; i < (currentLenght+1) / 2 ; i++)
            {
                if (currentLenght % 2 == 1 && i == currentLenght/2)
                {
                    oddParts.Push(queue.Dequeue());
                }
                else
                {
                    int[] part1 = queue.Dequeue();
                    int[] part2 = queue.Dequeue();
                    Tuple<int[], System.Int64> sortedAndTranspositions = MergeAndTranspositions(part1, part2);
                    counter += sortedAndTranspositions.Item2;
                    queue.Enqueue(sortedAndTranspositions.Item1);
                }
            }
            currentLenght /= 2;      
        }

        while(oddParts.Count > 0)
        {
            int[] part1 = queue.Dequeue();
            int[] part2 = oddParts.Pop();
            Tuple<int[], System.Int64> sortedAndTranspositions = MergeAndTranspositions(part1, part2);
            counter += sortedAndTranspositions.Item2;
            queue.Enqueue(sortedAndTranspositions.Item1);
        }
        return counter;
    }

    static Tuple<int[], System.Int64> MergeAndTranspositions(int[] part1, int[] part2) 
    {
        System.Int64 transpositions = 0;
        int lenght1 = part1.Length;int lenght2 = part2.Length;
        int pointer1 = 0;int pointer2 = 0;
        int[] merged = new int[lenght1 +lenght2] ;

        while (pointer1 < lenght1 && pointer2 < lenght2)
        {
            if (part1[pointer1] <= part2[pointer2])
            {
                merged[pointer1+pointer2] = part1[pointer1];
                pointer1++;
            }
            else
            {
                merged[pointer1 + pointer2] = part2[pointer2];
                transpositions += (lenght1 - pointer1);
                pointer2++;
            }
        }

        for(int i = pointer1; i < lenght1; i++)
        {
            merged[i + pointer2] = part1[i];
        }

        for (int i = pointer2; i < lenght2; i++)
        {
            merged[pointer1 + i] = part2[i];
        }

        return new Tuple<int[], System.Int64>(merged,transpositions);
    }
}