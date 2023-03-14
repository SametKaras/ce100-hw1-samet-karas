using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce100_hw1_algo_lib_cs
{
    public class SelectionSort
    {
        public static int[] SelectionSortFunction(int[] arr)
        {
            int j;
            int minIndex;
            /// This loop continues to run until the length of the string.
            for (int i = 0; i < arr.Length - 1; i++)
            {
                /// This loop works as much as an excess of the upper loop.
                minIndex = i;
                for (j = i + 1; j < arr.Length; j++)
                {
                    /// if the element on the right is smaller than the one on the left, they are replaced,if vice versa, the code returns to the beginning
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    int temp = arr[minIndex];
                    arr[minIndex] = arr[i];
                    arr[i] = temp;
                }
            }
            return arr;
        }
    }
    public class RecursiveMergeSort
    {
        /// <summary>
        /// It divides the array it receives as input into binary groups 
        /// until it becomes the smallest and sorts the array using the comparison method.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int[] MergeSortRecursive(ref int[] data, int left, int right)
        {
            if (left < right)
            {
                int m = left + (right - left) / 2;

                MergeSortRecursive(ref data, left, m);
                MergeSortRecursive(ref data, m + 1, right);
                Merge(ref data, left, m, right);
            }
            return data;
        }

        private static void Merge(ref int[] data, int left, int mid, int right)
        {
            int i, j, k;
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] L = new int[n1];
            int[] R = new int[n2];

            for (i = 0; i < n1; i++)
                L[i] = data[left + i];

            for (j = 0; j < n2; j++)
                R[j] = data[mid + 1 + j];

            i = 0;
            j = 0;
            k = left;

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    data[k] = L[i];
                    i++;
                }
                else
                {
                    data[k] = R[j];
                    j++;
                }

                k++;
            }

            while (i < n1)
            {
                data[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                data[k] = R[j];
                j++;
                k++;
            }
        }
    }
    public class HoareQuickSort
    {
        /// <summary>
        /// Hoare’s Partition Scheme works by initializing two indexes that 
        /// start at two ends, the two indexes move toward each other until 
        /// an inversion is (A smaller value on the left side and greater value
        /// on the right side) found. When an inversion is found, two values 
        /// are swapped and the process is repeated.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public static int[] Hoare(int[] arr, int low, int high)
        {
            if (low >= high)
            {
                return arr;
            }

            int pivot = arr[high]; /// Pivot set as an last element of array.
            int i = low;
            int j = high;
            /// Loop provide us to compare elements of the array. 
            while (i < j)
            {
                while (arr[i] < pivot)
                {
                    i++;
                }
                while (arr[j] > pivot)
                {
                    j--;
                }
                if (i < j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                }
            }

            Hoare(arr, low, i - 1);
            Hoare(arr, i, high);

            return arr;
        }
    }
    public class LomutoQuickSort
    {
        /// <summary>
        /// This algorithm works by assuming the pivot element as the last element. 
        /// If any other element is given as a pivot element then swap it first with the last element.
        /// And it performs its operations according to this method.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public static int[] Lomuto(int[] arr, int low, int high)
        {
            if (low >= high)
            {
                return arr;
            }

            int pivot = arr[high];
            int j = low;
            /// Loop provide us to compare elements of the array.
            for (int i = low; i < high; i++)
            {
                if (arr[i] <= pivot)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    j++;
                }
            }

            int temp2 = arr[high];
            arr[high] = arr[j];
            arr[j] = temp2;

            Lomuto(arr, low, j - 1);
            Lomuto(arr, j + 1, high);

            return arr;
        }
    }
}
