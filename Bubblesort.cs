
namespace LL_SortingAlgorithm
{
    internal class Bubblesort
    {
        int[] arrayA = new int[10]
        {
            9,
            3,
            4,
            1,
            16,
            69,
            2,
            42,
            27,
            7
        };

        bool swapNeeded;
        public Bubblesort()
        {
        }


        public void Sort()
        {
            for (int i = 0; i < arrayA.Length - 1; i++)
            {
                swapNeeded = false;
                for (int j = 0; j < arrayA.Length - i - 1; j++)
                {
                    if (arrayA[j] > arrayA[j + 1])
                    {
                        var tempValue = arrayA[j];
                        arrayA[j] = arrayA[j + 1];
                        arrayA[j + 1] = tempValue;
                        swapNeeded = true;
                    }
                }
                if (swapNeeded == false)
                    break;
            }
        }
    }
}
