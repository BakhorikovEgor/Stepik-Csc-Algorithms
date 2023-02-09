
internal class BinaryHeapQueue
{
    int[] heap;
    int pointer = -1;

    public BinaryHeapQueue(int lenght)
    {
        heap = new int[lenght];
    }

    public void Insert(int value)
    {
        pointer++;
        heap[pointer] = value;
        SiftUp(pointer);
    }

    public int ExtractMax()
    {
        int maximum = heap[0];

        heap[0] = heap[pointer];
        pointer--;
        SiftDown(0);

        return maximum;
    }


    private void SiftUp(int tempPointer)
    {
        if (tempPointer == 0) return;

        if (heap[(tempPointer - 1) / 2] < heap[tempPointer])
        {
            Swap(tempPointer, (tempPointer - 1) / 2);
            SiftUp((tempPointer - 1) / 2);
        }
    }

    private void SiftDown(int tempPointer)
    {
        if (tempPointer * 2 + 1 > pointer) return;

        if (tempPointer * 2 + 1 == pointer)
        {
            if (heap[tempPointer * 2 + 1] > heap[tempPointer])
            {
                Swap(tempPointer * 2 + 1, tempPointer);
            }
        }

        else
        {
            int maxChildIndex = tempPointer * 2 + 2;
            if (heap[tempPointer * 2 + 1] > heap[tempPointer * 2 + 2])
            {
                maxChildIndex = tempPointer * 2 + 1;
            }

            if (heap[maxChildIndex] > heap[tempPointer])
            {
                Swap(maxChildIndex, tempPointer);
                SiftDown(maxChildIndex);
            }
        }
    }


    private void Swap(int firstIndex, int secondIndex)
    {
        int temp = heap[firstIndex];
        heap[firstIndex] = heap[secondIndex];
        heap[secondIndex] = temp;
    }
}