using Microsoft.VisualBasic;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;


class Program
{
    static Random rand = new Random();
    static void NotMain()
    {
        int[] lengths = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[][] segments = new int[lengths[0]][];
        int[] points = new int[lengths[1]];
        Dictionary<int, int> counter = new Dictionary<int, int>();

        for (int i = 0; i < lengths[0]; i++)
        {
            segments[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
        }

        points = Console.ReadLine().Split().Select(int.Parse).ToArray();
        foreach(int point in points)
        {
            counter.Add(point, 0);
        }

        int[] sortedPoints = points;
        PointsQuickSort(ref sortedPoints, 0, lengths[1] - 1);

        foreach (int[] segment in segments)
        {
            int firstIn = FindFirstIn(sortedPoints, 0, lengths[1] - 1, segment);
            if (firstIn == -1) continue;
            int lastInt = FindLastIn(sortedPoints, 0, lengths[1] - 1, segment);

            for (int i = firstIn; i < lastInt + 1; i++)
            {
                counter[sortedPoints[i]]++;
            }
        }

        foreach(int point in points)
        {
            Console.Write($"{counter[point]} ");
        }
    }


    static int FindFirstIn(int[] points,int left,int right, int[] segment)
    {
        int middle = (left + right) / 2;
        if (middle == left)
        {
            if (points.Length == 2 && !IsInsideSegment(segment, points[middle]))
            {
                return IsInsideSegment(segment, points[middle + 1]) ? middle + 1 : -1;
            }
            return IsInsideSegment(segment, points[middle]) ? middle : -1;
        }

        if (IsInsideSegment(segment, points[middle]) && !IsInsideSegment(segment, points[middle - 1]))
        {
            return middle;
        }


        if (middle == right)
        {
            return IsInsideSegment(segment, points[middle + 1]) ? middle + 1 : -1;
        }


        if (segment[0] >= points[middle]) return FindFirstIn(points, middle, right, segment);
        return FindFirstIn(points, left, middle, segment);

    }

    static int FindLastIn(int[] points, int left, int right, int[] segment)
    {
        int middle = (left + right) / 2;
        if (middle == left)
        {
            if (points.Length == 2 && IsInsideSegment(segment, points[middle + 1]))
            {
                return middle + 1;
            }
            return IsInsideSegment(segment, points[middle]) ? middle : -1;
        }

        if (IsInsideSegment(segment, points[middle]) && !IsInsideSegment(segment, points[middle + 1]))
        {
            return middle;
        }

        if (middle == right - 1)
        {
            if(points.Length == 3)
            {
                if (IsInsideSegment(segment, points[middle + 1])) return IsInsideSegment(segment, points[middle]) ? middle + 1 : middle;
                return IsInsideSegment(segment, points[middle - 1]) ? middle - 1 : -1; 
            }
            return IsInsideSegment(segment, points[middle + 1]) ? middle + 1 : -1;
        }

        if (segment[1] >= points[middle]) return FindLastIn(points, middle, right, segment);
        return FindLastIn(points, left, middle, segment);

    }


    static bool IsInsideSegment(int[] segment, int point) => point >= segment[0] && point <= segment[1];


    static void PointsQuickSort(ref int[] points, int start, int end)
    {
        while (start < end)
        {
            int separator = PointsSeparator(ref points, start, end);
            if (end - (separator + 1) >= separator - 1)
            {
                PointsQuickSort(ref points, start, separator - 1);
                start = separator + 1;
            }
            else
            {
                PointsQuickSort(ref points, separator + 1, end);
                end = separator - 1;
            }
        }
    }

    static int PointsSeparator(ref int[] points, int start, int end)
    {
        PointsSwap(ref points, start, rand.Next(start + 1, end));
        int sortedElement = points[start];
        int j = start;
    
        for (int i = start + 1; i < end + 1; i++)
        {
            if (points[i] <= sortedElement)
            {
                j += 1;
                PointsSwap(ref points, j, i);
            }
        }
        PointsSwap(ref points, start, j);
        return j;
    }
    
    static void PointsSwap(ref int[] points, int index1, int index2)
    {
        int temp = points[index1];
        points[index1] = points[index2];
        points[index2] = temp;
    }
}












































//class Program
//{
//    static Random rand = new Random();
//    static void Main()
//    {
//        int[] lengths = Console.ReadLine().Split().Select(int.Parse).ToArray();
//        int[][] segments = new int[lengths[0]][];
//        int[] points = new int[lengths[1]];
//        int[] counter = new int[lengths[1]];

//        for(int i = 0; i < lengths[0]; i++)
//        {
//            segments[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
//        }
//        points = Console.ReadLine().Split().Select(int.Parse).ToArray();


//        PointsQuickSort(ref points, 0, lengths[1] - 1);
//        SegmentsQuickSort(ref segments, 0 , lengths[0] - 1);

//        int previousPointFirstInsertion = FindPointFirstInsertion(segments, 0, lengths[0] - 1, points[0]);
//        int previousPointLastInsertion = int.MinValue;
//        if (previousPointFirstInsertion != int.MinValue)
//        {
//            previousPointLastInsertion = FindPointLastInsertion(segments, previousPointFirstInsertion, lengths[0] - 1, points[0]);
//            counter[0] = previousPointLastInsertion - previousPointFirstInsertion + 1;
//        }

//        for (int i = 1; i < lengths[1]; i++)
//        {
//            if (previousPointLastInsertion == int.MinValue) break;

//            int tempFirstInsertion = FindPointFirstInsertion(segments, previousPointFirstInsertion, previousPointLastInsertion, points[i]);
//            int oldCounter = previousPointLastInsertion - tempFirstInsertion + 1;
//            if (tempFirstInsertion == int.MinValue)
//            {
//                oldCounter = 0;
//                tempFirstInsertion = FindPointFirstInsertion(segments, previousPointLastInsertion, lengths[0] - 1, points[i]);
//                if (tempFirstInsertion == int.MinValue) break;
//            }

//            int tempLastInsertion = FindPointLastInsertion(segments, tempFirstInsertion, lengths[0] - 1, points[i]);
//            int newCounter = tempLastInsertion - Math.Max(tempFirstInsertion,previousPointLastInsertion);

//            previousPointFirstInsertion = tempFirstInsertion;
//            previousPointLastInsertion = tempLastInsertion;

//            counter[i] = oldCounter + newCounter;
//        }

//        foreach(int i in counter)
//        {
//            Console.Write($"{i} ");
//        }
//    }


//    static void PointsQuickSort(ref int[] points, int start, int end)
//    {
//        while (start < end)
//        {
//            int separator = PointsSeparator(ref points, start, end);
//            if (end - (separator + 1) >= separator - 1)
//            {
//                PointsQuickSort(ref points, start, separator - 1);
//                start = separator + 1;
//            }
//            else
//            {
//                PointsQuickSort(ref points, separator + 1, end);
//                end = separator - 1;
//            }
//        }
//    }

//    static int PointsSeparator(ref int[] points, int start, int end)
//    {
//        PointsSwap(ref points, start, rand.Next(start + 1, end));
//        int sortedElement = points[start];
//        int j = start;

//        for (int i = start + 1; i < end + 1; i++)
//        {
//            if (points[i] <= sortedElement)
//            {
//                j += 1;
//                PointsSwap(ref points, j, i);
//            }
//        }
//        PointsSwap(ref points, start, j);
//        return j;
//    }

//    static void PointsSwap(ref int[] points, int index1, int index2)
//    {
//        int temp = points[index1];
//        points[index1] = points[index2];
//        points[index2] = temp;
//    }


//    static void SegmentsQuickSort(ref int[][] segments, int start, int end)
//    {
//        while (start < end)
//        {
//            int separator = SegmentsSeparator(ref segments, start, end);
//            if (end - (separator + 1) >= separator - 1)
//            {
//                SegmentsQuickSort(ref segments, start, separator - 1);
//                start = separator + 1;
//            }
//            else
//            {
//                SegmentsQuickSort(ref segments, separator + 1, end);
//                end = separator - 1;
//            }
//        }
//    }

//    static int SegmentsSeparator(ref int[][] segments, int start, int end)
//    {
//        SegmentsSwap(ref segments, start, rand.Next(start + 1, end));
//        int[] sortedElement = segments[start];
//        int j = start;

//        for (int i = start + 1; i < end + 1; i++)
//        {
//            if (segments[i][0] <= sortedElement[0])
//            {
//                j += 1;
//                SegmentsSwap(ref segments, j, i);
//            }
//        }
//        SegmentsSwap(ref segments, start, j);
//        return j;
//    }

//    static void SegmentsSwap(ref int[][] segments, int index1, int index2)
//    {
//        int[] temp = segments[index1];
//        segments[index1] = segments[index2];
//        segments[index2] = temp;
//    }
//    static int FindPointFirstInsertion(int[][] segments, int start, int end, int point)
//    {
//        int middle = (end + start) / 2;
//        int left = segments[middle][0];
//        int right = segments[middle][1];

//        if(end == start)
//        {
//            return IsInsideSegment(left, right, point) ? start : int.MinValue;
//        }
//        if (IsInsideSegment(left, right, point))
//        {
//            if (end - start == 1)
//            {
//                return middle;
//            }

//            int rightPrevious = segments[middle - 1][1];
//            return point > rightPrevious ? middle : FindPointFirstInsertion(segments, start, middle, point);
//        }

//        if (point < left)
//        {
//            return end - start == 1 ? int.MinValue : FindPointFirstInsertion(segments, start, middle, point);
//        }


//        int leftNext = segments[middle + 1][0];
//        int rightNext = segments[middle + 1][1];
//        if (IsInsideSegment(leftNext, rightNext, point))
//        {
//            return middle + 1;
//        }

//        return end - start == 1 ? int.MinValue : FindPointFirstInsertion(segments, middle, end, point);
//    }


//    static int FindPointLastInsertion(int[][] segments ,int start,int end,int point)
//    {
//        for (int i = start; i < end + 1; i++)
//        {
//            int left = segments[i][0];
//            int right = segments[i][1];
//            if (!IsInsideSegment(left, right, point)) return i - 1;
//        }
//        return end - start;
//    }

//    static bool IsInsideSegment(int left,int right,int point) => point>=left && point <= right;



//}
