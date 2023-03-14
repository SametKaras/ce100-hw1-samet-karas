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
}
