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
}
