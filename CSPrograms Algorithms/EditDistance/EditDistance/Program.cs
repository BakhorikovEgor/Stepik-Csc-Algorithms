//Вычислите расстояние редактирования двух данных непустых строк
//длины не более 10**2, содержащих строчные буквы латинского алфавита

using System;


class Program
{
    static void Main()
    {
        string first = Console.ReadLine();
        string second = Console.ReadLine();

        Console.WriteLine(GetEditDistance(first, second));
    }


    static int GetEditDistance (string first, string second)
    {
        int firstLength = first.Length;
        int secondLength = second.Length;

        int[] prev = new int[secondLength + 1];
        int[] current = new int[secondLength + 1];
 
        for (int i = 0; i < secondLength + 1; i++)
        {
            prev[i] = i;
        }

        for (int i = 1; i <= firstLength ; i++)
        {
            current[0] = i;
            for (int j = 1; j <= secondLength; j++)
            {
                int delete = prev[j] + 1;
                int insert = current[j - 1] + 1;
                int compare = prev[j - 1] + AreEqual(first[i - 1], second[j - 1]);

                current[j] = Math.Min(Math.Min(delete, insert), compare);
            }
      
            for (int k = 0; k < secondLength + 1; k++)
            {
                prev[k] = current[k];
                current[k] = 0;
            }
        }

        return prev[secondLength];
    }


    static int AreEqual(char first, char second) => first == second ? 0 : 1;
}