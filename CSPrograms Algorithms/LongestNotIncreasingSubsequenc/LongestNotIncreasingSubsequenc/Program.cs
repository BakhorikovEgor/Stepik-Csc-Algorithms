//Задача на программирование повышенной сложности: наибольшая невозрастающая подпоследовательность


using System;
using System.Linq;


class Program
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int[] subsequence = GetSubsequenceint(sequence, length);

        Console.WriteLine(subsequence.Length);
        foreach (int number in subsequence)
        {
            Console.Write($"{number} ");
        }
    }


    static int[] GetSubsequenceint(int[] sequence, int length)
    {
        int[] maxIndexLengthValues = new int[length + 1];
        maxIndexLengthValues[0] = int.MaxValue;

        for (int i = 1; i < length + 1; i++)
        {
            maxIndexLengthValues[i] = int.MinValue;
        }


        int[] previusElementIndex = new int[length];
        int[] optimalIndexes = new int[length + 1];
        int maxSubsequenceLength = 0;
        optimalIndexes[0] = -1;
        for (int i = 0; i < length; i++)
        {
            int value = sequence[i];
            int position = BinarySearchPosition(maxIndexLengthValues, 1, length + 1, value); ;

            maxIndexLengthValues[position] = value;
            optimalIndexes[position] = i;
            previusElementIndex[i] = optimalIndexes[position - 1];
            maxSubsequenceLength = Math.Max(maxSubsequenceLength, position);

        }

        int[] indexesOfSubsuquence = new int[maxSubsequenceLength];
        int indexToAdd = optimalIndexes[maxSubsequenceLength];
        for (int i = maxSubsequenceLength - 1; i >= 0; i--)
        {
            indexesOfSubsuquence[i] = indexToAdd + 1;
            indexToAdd = previusElementIndex[indexToAdd];
        }

        return indexesOfSubsuquence;
    }

    static int BinarySearchPosition(int[] maxIndexLengthValues, int left, int right, int value)
    {

        while (left < right)
        {
            int middle = (left + right) / 2;

            if (maxIndexLengthValues[middle - 1] >= value && maxIndexLengthValues[middle] < value)
            {
                return middle;
            }

            if (maxIndexLengthValues[middle - 1] < value)
            {
                right = middle - 1;
            }

            else if (maxIndexLengthValues[middle] >= value)
            {
                left = middle + 1;
            }
        }

        return (left + right) / 2;
    }
}

