using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LL_SortingAlgorithm
{
    internal class Mergesort
    {
        public Mergesort()
        {

        }

        public int[] MergeSort(int[] array)
        {
            int[] left;
            int[] right;
            int[] result = new int[array.Length];
            if (array.Length <= 1)
            {
                return array;
            }
            int middle = array.Length / 2;
            left = new int[middle];

            if (array.Length % 2 == 0)
            {
                right = new int[middle];
            }
            else
            {
                right = new int[middle + 1];
            }
            for (int i = 0; i < middle; i++)
            {
                left[i] = array[i];
            }
            int x = 0;
            for (int i = middle; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }
            left = MergeSort(left);
            right = MergeSort(right);
            result = MergeArrays(left, right);
            return result;
        }

        private int[] MergeArrays(int[] left, int[] right)
        {
            int resultLenght = left.Length + right.Length;
            int[] result = new int[resultLenght];

            int indexLeft = 0, indexRight = 0, indexResult = 0;

            while (indexLeft < left.Length || indexRight < right.Length)
            {
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }
    }
}
