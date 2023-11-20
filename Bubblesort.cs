
namespace LL_SortingAlgorithm
{
    static public class Bubblesort
    {
        public static void Sort(this int[] _source)
        {
            bool swapNeeded;
            // iterates through entire array aka outer loop
            for (int i = 0; i < _source.Length - 1; i++)
            {
                swapNeeded = false;
                // iterates and compares 2 values next to each other aka inner loop
                for (int j = 0; j < _source.Length - i - 1; j++)
                {
                    if (_source[j] > _source[j + 1])
                    {
                        var tempValue = _source[j];
                        _source[j] = _source[j + 1];
                        _source[j + 1] = tempValue;
                        swapNeeded = true;
                    }
                }
                //skips iteration if no swap is needed anymore
                if (swapNeeded == false)
                    break;
            }
        }
    }
}
