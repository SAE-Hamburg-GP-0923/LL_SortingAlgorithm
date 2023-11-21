namespace LL_SortingAlgorithm
{
    public static class Sorting
    {
        public static void BubbleSort(this int[] _source)
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

        public static void QuickSort(this int[] _source, int _left, int _right)
        {
            if (_left < _right)
            {
                // create pivot point to use for sorting
                int pivot = Partition(_source, _left, _right);

                //uses current pivot point to sort either the left side or right side of pivot point
                if (pivot > 1)
                {
                    QuickSort(_source, _left, pivot - 1);
                }
                if (pivot + 1 < _right)
                {
                    QuickSort(_source, pivot + 1, _right);
                }
            }

            int Partition(int[] _array, int _left, int _right)
            {
                // set local pivot point for partitioning
                int pivot = _array[_left];
                while (true)
                {
                    // change index depending on position towards pivot point
                    while (_array[_left] < pivot)
                    {
                        _left++;
                    }
                    while (_array[_right] > pivot)
                    {
                        _right--;
                    }

                    if (_left < _right)
                    {
                        // swap values if needed
                        if (_array[_left] == _array[_right]) return _right;
                        int tempVar = _array[_left];
                        _array[_left] = _array[_right];
                        _array[_right] = tempVar;
                    }
                    else
                    {
                        return _right;
                    }
                }
            }
        }

        public static void MergeSort(this int[] _source)
        {
            // create left and right array
            int[] left;
            int[] right;
            // recursion safety cancel
            if (_source.Length <= 1)
            {
                return;
            }
            // define middle point by splitting array length
            int middle = _source.Length / 2;
            // define length of left and right, where right gets one more entry if the original length is an odd number
            left = new int[middle];

            right = _source.Length % 2 == 0 ? new int[middle] : new int[middle + 1];

            // fill left array
            for (int i = 0; i < middle; i++) left[i] = _source[i];

            // fill right array
            int x = 0;
            for (int i = middle; i < _source.Length; i++, x++) right[x] = _source[i];

            // keep splitting and sorting till both left and right results are only one element
            left.MergeSort();
            right.MergeSort();

            // merge all arrays back together
            // set starting index
            int indexLeft = 0, indexRight = 0, indexResult = 0;

            //loop through the lenght of the arrays and merge, adding either the left or the right element depending on current index
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    if (left[indexLeft] <= right[indexRight])
                    {
                        _source[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        _source[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                else if (indexLeft < left.Length)
                {
                    _source[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < right.Length)
                {
                    _source[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
        }

        //private static int[] MergeArrays(int[] _left, int[] _right)
        //{
        //    //define resulting length of the new array and create it
        //    int resultLenght = _left.Length + _right.Length;
        //    int[] result = new int[resultLenght];

        //    // set starting index
        //    int indexLeft = 0, indexRight = 0, indexResult = 0;

        //    //loop through the lenght of the arrays and merge, adding either the left or the right element depending on current index
        //    while (indexLeft < _left.Length || indexRight < _right.Length)
        //    {
        //        if (indexLeft < _left.Length && indexRight < _right.Length)
        //        {
        //            if (_left[indexLeft] <= _right[indexRight])
        //            {
        //                result[indexResult] = _left[indexLeft];
        //                indexLeft++;
        //                indexResult++;
        //            }
        //            else
        //            {
        //                result[indexResult] = _right[indexRight];
        //                indexRight++;
        //                indexResult++;
        //            }
        //        }
        //        else if (indexLeft < _left.Length)
        //        {
        //            result[indexResult] = _left[indexLeft];
        //            indexLeft++;
        //            indexResult++;
        //        }
        //        else if (indexRight < _right.Length)
        //        {
        //            result[indexResult] = _right[indexRight];
        //            indexRight++;
        //            indexResult++;
        //        }
        //    }
        //}

        public static void SortZigZag(this int[] _source)
        {
            var tempArray = new int[_source.Length];
            for (int i = 0, x = _source.Length - 1, k = 0; k < x; i += 2, x--, k++)
            {
                tempArray[i] = _source[k];
                tempArray[i + 1] = _source[x];
            }
            for (int i = 0; i < _source.Length; i++)
            {
                _source[i] = tempArray[i];
            }
        }

        //public static void SortZigZagDoubleFor(this int[] _source)
        //{
        //    var indeXRight = _source.Length - 1;
        //    var tempArray = new int[_source.Length];
        //    for (int i = 0, k = 0; i < indeXRight; i++, k++)
        //    {
        //        tempArray[i] = _source[k];
        //        for (int x = _source.Length -1; k < x; x--, i++)
        //        {
        //            tempArray[i + 1] = _source[x];
        //            indeXRight = x;
        //        }
        //    }
        //    for (int i = 0; i < _source.Length; i++)
        //    {
        //        _source[i] = tempArray[i];
        //    }
        //}

        public static void SortDecending(this int[] _source)
        {
            int[] tempArray = new int[_source.Length];
            _source.CopyTo(tempArray, 0);

            for (int i = 0; i < _source.Length; i++)
            {
                int tempVar = tempArray[tempArray.Length - 1 - i];
                _source[i] = tempVar;
            }
        }
    }

}
