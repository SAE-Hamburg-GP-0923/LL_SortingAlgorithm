namespace LL_SortingAlgorithm
{
    internal class Program
    {
        static int[] newArray = new int[10]
        {
            27,
            3,
            12,
            48,
            80,
            10,
            22,
            32,
            9,
            2
        };

        static int[] sortedArray;
        static void Main(string[] args)
        {
            newArray.MergeSort();
            newArray.Decending();
            Print();
            //PrintZigZag();
        }

        static void Print()
        {
            foreach (int i in newArray)
            {
                Console.Write(i + " ");
            }
        }
    }
}