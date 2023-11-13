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
        static void Main(string[] args)
        {
            Quicksort quicksort = new Quicksort();
            var sortedArray = quicksort.QuickSort(newArray, 0, newArray.Length - 1);
            foreach (int i in sortedArray)
            {
                Console.WriteLine(i + " ");
            }
        }
    }
}