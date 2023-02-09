using System;
using System.Collections.Generic;
using System.Linq;

class ScanLineRealization
{
    static Random rand = new Random();
    static void Main()
    {
        int[] lengths = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Point[] allPoints = new Point[lengths[0] + lengths[0] + lengths[1]];

        for (int i = 0; i < lengths[0] + lengths[0]; i += 2)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            allPoints[i] = new Point(1, data[0]);
            allPoints[i + 1] = new Point(-1, data[1]);
        }

        int[] points = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < lengths[1]; i++)
        {
            allPoints[lengths[0] + lengths[0] + i] = new Point(0, points[i], i);
        }

        Array.Sort(allPoints);

        int[] answer = new int[lengths[1]];
        int tempIn = 0;
        for (int i = 0; i < lengths[0] * 2 + lengths[1]; i++)
        {
            Point point = allPoints[i];
            if (point.Type == 0) answer[point.Index] = tempIn;
            else tempIn += point.Type;
        }

        for (int i = 0; i < lengths[1]; i++)
        {
            Console.Write($"{answer[i]} ");
        }

    }
}

struct Point:IComparable<Point>
{
    public int Index { get;set; }
    public int Type { get; set; }
    public int Value { get;set; }

    public Point(int type, int value)
    {
        Type = type;
        Value = value;
        Index = -1;
    }

    public Point(int type, int value, int index) : this(type, value)
    {
        Index = index;
    }

    public int CompareTo(Point point)
    {
        if (point.Value > Value) return -1;

        if (point.Value < Value) return 1;

        if (point.Type > Type) return 1;

        if (point.Type < Type) return -1;

        return 0;
    }
}