namespace LL_SortingAlgorithm
{
    public static class Sorting
    {
        public static void BubbleSort<T>(this T[] _source) where T : IComparable
        {
            _source.BubbleSort((a, b) => a.CompareTo(b));
        }
        public static void BubbleSort<T>(this T[] _source, Comparison<T> _sortingRule)
        {
            bool swapNeeded;
            // iterates through entire array aka outer loop
            for (int i = 0; i < _source.Length - 1; i++)
            {
                swapNeeded = false;
                // iterates and compares 2 values next to each other aka inner loop
                for (int j = 0; j < _source.Length - i - 1; j++)
                {
                    //if (_source[j].CompareTo(_source[j + 1]) > 0)
                    if (_sortingRule.Invoke(_source[j], _source[j + 1]) > 0)
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


        public static void QuickSort<T>(this T[] _source) where T : IComparable
        {
            _source.QuickSort((a, b) => a.CompareTo(b));
        }

        public static void QuickSort<T>(this T[] _source, Comparison<T> _sortingRule)
        {
            _source.QuickSort(0, _source.Length - 1, _sortingRule);
        }

        public static void QuickSort<T>(this T[] _source, int _left, int _right, Comparison<T> _sortingRule)
        {
            if (_left < _right)
            {
                // create pivot point to use for sorting
                int pivot = Partition(_source, _left, _right, _sortingRule);

                //uses current pivot point to sort either the left side or right side of pivot point
                if (pivot > 1)
                {
                    QuickSort(_source, _left, pivot - 1, _sortingRule);
                }
                if (pivot + 1 < _right)
                {
                    QuickSort(_source, pivot + 1, _right, _sortingRule);
                }
            }

            int Partition<T>(T[] _array, int _left, int _right, Comparison<T> _sortingRule)
            {
                // set local pivot point for partitioning
                T pivot = _array[_left];
                while (true)
                {
                    // change index depending on position towards pivot point
                    //while (_array[_left].CompareTo(pivot) < 0)
                    while (_sortingRule.Invoke(_array[_left], pivot) < 0)
                    {
                        _left++;
                    }
                    //while (_array[_right].CompareTo(pivot) > 0)
                    while (_sortingRule.Invoke(_array[_right], pivot) > 0)
                    {
                        _right--;
                    }

                    if (_left < _right)
                    {
                        // swap values if needed
                        //if (_array[_left].CompareTo(_array[_right]) == 0) return _right;
                        if (_sortingRule.Invoke(_array[_left], _array[_right]) == 0) return _right;
                        T tempVar = _array[_left];
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

        public static void MergeSort<T>(this T[] _source) where T : IComparable
        {
            _source.MergeSort((a, b) => a.CompareTo(b));
        }

        public static void MergeSort<T>(this T[] _source, Comparison<T> _sortingRule)
        {
            // create left and right array
            T[] left;
            T[] right;
            // recursion safety cancel
            if (_source.Length <= 1)
            {
                return;
            }
            // define middle point by splitting array length
            int middle = _source.Length / 2;
            // define length of left and right, where right gets one more entry if the original length is an odd number
            left = new T[middle];

            right = _source.Length % 2 == 0 ? new T[middle] : new T[middle + 1];

            // fill left array
            for (int i = 0; i < middle; i++) left[i] = _source[i];

            // fill right array
            int x = 0;
            for (int i = middle; i < _source.Length; i++, x++) right[x] = _source[i];

            // keep splitting and sorting till both left and right results are only one element
            left.MergeSort(_sortingRule);
            right.MergeSort(_sortingRule);

            // merge all arrays back together
            // set starting index
            int indexLeft = 0, indexRight = 0, indexResult = 0;

            //loop through the lenght of the arrays and merge, adding either the left or the right element depending on current index
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    //if (left[indexLeft].CompareTo(right[indexRight]) <= 0)
                    if (_sortingRule.Invoke(left[indexLeft], right[indexRight]) <= 0)
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



        public static void SortZigZag<T>(this T[] _source)
        {
            var tempArray = new T[_source.Length];
            for (int i = 0, x = _source.Length - 1, k = 0; i < _source.Length; i++, x--, k++)
            {
                tempArray[i] = _source[x];
                i++;
                if (i >= _source.Length) break;
                tempArray[i] = _source[k];
            }
            for (int i = 0; i < _source.Length; i++)
            {
                _source[i] = tempArray[i];
            }
        }

        public static void SortDecending<T>(this T[] _source)
        {
            var tempArray = new T[_source.Length];
            _source.CopyTo(tempArray, 0);

            for (int i = 0; i < _source.Length; i++)
            {
                T tempVar = tempArray[tempArray.Length - 1 - i];
                _source[i] = tempVar;
            }
        }
    }

}
