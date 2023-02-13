using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Text;

public class Haffman
{
    static Dictionary<char, string> codes = new Dictionary<char, string>();
    public static void Main()
    {
        string s = Console.ReadLine();
        Dictionary<char, int[]> freq = new Dictionary<char, int[] >();
        List<(char,int, int)> tree = new List<(char,int, int)>();
        int sybmCount = 0;
        int pointer = 0;

        for (int i = 0; i < 26; i++) 
        {
            freq.Add((char)('a'+i), new int[] {0,-1,-1});
        }
        
        foreach (char ch in s)
        {
            if (freq[ch][0] == 0) sybmCount++;
            freq[ch][0] ++;      
        }


        for (int i = 0; i < sybmCount - 1; i++)
        {
            Tuple<char, int[]> FirstMin = ExtractMin(freq);
            Tuple<char, int[]> SecondMin = ExtractMin(freq);

            int[] parent = new int[] { FirstMin.Item2[0] + SecondMin.Item2[0], pointer, pointer + 1 };
            freq.Add((char)('z' + i + 1), parent);

            tree.Add((FirstMin.Item1, FirstMin.Item2[1], FirstMin.Item2[2]));
            tree.Add((SecondMin.Item1, SecondMin.Item2[1], SecondMin.Item2[2]));

            pointer += 2;
        }
        if (sybmCount == 1)
        {
            codes.Add(s[0], "0");
        }
        else
        {
            Coding(tree, new Tuple<int, int>(tree.Count - 1, tree.Count - 2), new Tuple<string, string>("1", "0"));
        }

        StringBuilder final = new StringBuilder("");
        foreach (char ch in s)
        {
            final.Append(codes[ch]);
        }
        Console.WriteLine($"{sybmCount} {final.Length}");

        for(int i = 'a';i <= 'z' ;i++)
        {
            char ch = (char)i;
            if (codes.TryGetValue(ch, out var code))
            {
                Console.WriteLine($"{ch}: {code}");
            }
        }

        Console.WriteLine(final.ToString());
    }


    private static Tuple<char, int[]> ExtractMin(Dictionary<char, int[]> freq)
    {
        char symb = new char();
        int[] min = new int[3];
        foreach (char ch in freq.Keys)
        {
            if (freq[ch][0]!=0 && (min[0] > freq[ch][0] || min[0] == 0))
            {
                min = freq[ch];
                symb = ch;
            }
        }
        freq.Remove(symb);
        return new Tuple<char, int[]>(symb, min);

    }
    private static void Coding(List<(char, int, int)> tree,Tuple<int,int> pointers,Tuple<string,string> values)
    {
        if ( tree[pointers.Item1].Item1 <= 'z')
        {
            codes.Add(tree[pointers.Item1].Item1, values.Item1);

        }
        else
        {
            Tuple<int, int> newPointers = new Tuple<int, int>(tree[pointers.Item1].Item2, tree[pointers.Item1].Item3);
            Coding(tree, newPointers, new Tuple<string, string>(values.Item1 + "0", values.Item1 + "1"));
        }

        if (tree[pointers.Item2].Item1 <= 'z')
        {
            codes.Add(tree[pointers.Item2].Item1, values.Item2);

        }
        else
        {
            Tuple<int, int> newPointers = new Tuple<int, int>(tree[pointers.Item2].Item2, tree[pointers.Item2].Item3);
            Coding(tree, newPointers, new Tuple<string, string>(values.Item2 + "0", values.Item2 + "1"));
        }
    }

}