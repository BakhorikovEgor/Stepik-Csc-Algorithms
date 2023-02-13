//Первая строка содержит число  1<=n<=10**4  вторая — 
//n натуральных чисел, не превышающих 10. Выведите упорядоченную по неубыванию последовательность этих чисел.



using System;
using System.Linq;

public class MainClass
{
    public static void Main()
    {
        int digitsLength = int.Parse(Console.ReadLine());
        int[] digits = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] digitsPositions = new int[11];
        int[] sortedDigits = new int[digitsLength];
        
        for (int i = 0; i < digitsLength; i++)
        {
            int digit = digits[i];
            digitsPositions[digit] ++;
        }

        digitsPositions[0] -= 1; // корректировка для обращений по индексу
        for (int i = 1;i < digitsPositions.Length; i++) digitsPositions[i] += digitsPositions[i - 1]; 
        
        for (int i = digitsLength - 1; i >= 0; i--)
        {
            int digit = digits[i];
            int position = digitsPositions[digit];

            sortedDigits[position] = digit;
            digitsPositions[digit]--;
        }

        for (int i = 0; i < digitsLength; i++)
        {
            int sortedDigit = sortedDigits[i];
            Console.Write($"{sortedDigit} ");
        }
    }
}