using System.Text;
class Program
{
    static void Main()
    {
        int n = int.Parse(System.Console.ReadLine());
        BinaryHeapQueue queue = new BinaryHeapQueue(n);
        StringBuilder output = new StringBuilder("");

        for (int i = 0; i < n; i++)
        {
            string s = System.Console.ReadLine();
            if (s == "ExtractMax")
            {
                output.Append(queue.ExtractMax() + "\n");
            }
            else
            {
                queue.Insert(int.Parse(s.Split()[1]));
            }
        }

        System.Console.WriteLine(output);
    }


}
