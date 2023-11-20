namespace LL_SortingAlgorithm
{
    internal class Mergesort
    {
        public int[] MergeSort(int[] _array)
        {
            // create left and right array
            int[] left;
            int[] right;
            int[] result = new int[_array.Length];
            // recursion safety cancel
            if (_array.Length <= 1)
            {
                return _array;
            }
            // define middle point by splitting array length
            int middle = _array.Length / 2;
            // define length of left and right, where right gets one more entry if the original length is an odd number
            left = new int[middle];

            if (_array.Length % 2 == 0)
            {
                right = new int[middle];
            }
            else
            {
                right = new int[middle + 1];
            }
            // fill left array
            for (int i = 0; i < middle; i++)
            {
                left[i] = _array[i];
            }
            // fill right array
            int x = 0;
            for (int i = middle; i < _array.Length; i++)
            {
                right[x] = _array[i];
                x++;
            }
            // keep splitting and sorting till both left and right results are only one element
            left = MergeSort(left);
            right = MergeSort(right);
            // merge all arrays back together
            result = MergeArrays(left, right);
            return result;
        }

        private int[] MergeArrays(int[] _left, int[] _right)
        {
            //define resulting length of the new array and create it
            int resultLenght = _left.Length + _right.Length;
            int[] result = new int[resultLenght];

            // set starting index
            int indexLeft = 0, indexRight = 0, indexResult = 0;

            //lopp through the lenght of the arrays and merge, adding either the left or the right element depending on current index
            while (indexLeft < _left.Length || indexRight < _right.Length)
            {
                if (indexLeft < _left.Length && indexRight < _right.Length)
                {
                    if (_left[indexLeft] <= _right[indexRight])
                    {
                        result[indexResult] = _left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = _right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                else if (indexLeft < _left.Length)
                {
                    result[indexResult] = _left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < _right.Length)
                {
                    result[indexResult] = _right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }
    }
}
