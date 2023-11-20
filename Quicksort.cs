//namespace LL_SortingAlgorithm
//{
//    internal class Quicksort
//    {
//        static public void QuickSort(this int[] _array, int _left, int _right)
//        {
//            if (_left < _right)
//            {
//                // create pivot point to use for sorting
//                int pivot = Partition(_array, _left, _right);

//                //uses current pivot point to sort either the left side or right side of pivot point
//                if (pivot > 1)
//                {
//                    QuickSort(_array, _left, pivot - 1);
//                }
//                if (pivot + 1 < _right)
//                {
//                    QuickSort(_array, pivot + 1, _right);
//                }
//            }

//            int Partition(int[] _array, int _left, int _right)
//            {
//                // set local pivot point for partitioning
//                int pivot = _array[_left];
//                while (true)
//                {
//                    // change index depending on position towards pivot point
//                    while (_array[_left] < pivot)
//                    {
//                        _left++;
//                    }
//                    while (_array[_right] > pivot)
//                    {
//                        _right--;
//                    }

//                    if (_left < _right)
//                    {
//                        // swap values if needed
//                        if (_array[_left] == _array[_right]) return _right;
//                        int temp = _array[_left];
//                        _array[_left] = _array[_right];
//                        _array[_right] = temp;
//                    }
//                    else
//                    {
//                        return _right;
//                    }
//                }
//            }
//        }

//    }
//}
