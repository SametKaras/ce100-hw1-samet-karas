﻿using System;
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
    public class IterativeBinarySearch
    {
        public static int IterativeBinarySearchFunction(int[] nums, int target)
        {
            /// search space is nums[low…high]
            int low = 0, high = nums.Length - 1;

            /// loop till the search space is exhausted
            while (low <= high)
            {
                /// find the mid-value in the search space and
                /// compares it with the target

                int mid = (low + high) / 2;    /// overflow can happen

                /// target value is found
                if (target == nums[mid])
                {
                    return 0;
                }

                /// if the target is less than the middle element, discard all elements
                /// in the right search space, including the middle element
                else if (target < nums[mid])
                {
                    high = mid - 1;
                }

                /// if the target is more than the middle element, discard all elements
                /// in the left search space, including the middle element
                else
                {
                    low = mid + 1;
                }
            }

            /// target doesn't exist in the array
            return -1;
        }
    }
    public class RecursiveBinarySearch
    {
        public static int RecursiveBinarySearchFunction(int[] nums, int low, int high, int target)
        {
            /// Base condition (search space is exhausted)
            if (low > high)
            {
                return -1;
            }

            /// find the mid-value in the search space and
            /// compares it with the target
            int mid = (low + high) / 2; /// overflow can happen

            /// Base condition (target value is found)
            if (target == nums[mid])
            {
                return 0;
            }

            /// discard all elements in the right search space,
            /// including the middle element
            else if (target < nums[mid])
            {
                return RecursiveBinarySearchFunction(nums, low, mid - 1, target);
            }

            /// discard all elements in the left search space,
            /// including the middle element
            else
            {
                return RecursiveBinarySearchFunction(nums, mid + 1, high, target);
            }
        }
    }
    public class RecursiveMatrixMultiplication
    {
        public static void multiplyMatrixRec(int[,] A, int[,] B, int[,] C, int i, int j, int k)
        {
            int r1 = A.GetLength(0);
            int c1 = A.GetLength(1);

            int r2 = B.GetLength(0);
            int c2 = B.GetLength(1);

            if (i >= r1)
            {
                return;
            }

            if (j < c2)
            {
                int sum = 0;
                for (k = 0; k < c1; k++)
                {
                    sum += A[i, k] * B[k, j];
                }
                C[i, j] = sum;

                multiplyMatrixRec(A, B, C, i, j + 1, 0);
            }
            else
            {
                multiplyMatrixRec(A, B, C, i + 1, 0, 0);
            }
        }



        ///* @brief Multiply two matrices and return the result.
        /// This function takes two matrices A and B, and multiplies them together
        /// using a recursive algorithm. The result is returned as a new matrix C.
        /// * @param A The first matrix to multiply.
        /// * @param B The second matrix to multiply.
        /// * @param r1 The number of rows in matrix A.
        /// * @param c2 The number of columns in matrix B.
        /// * @return The result of multiplying matrices A and B.
        /// * @note The dimensions of the matrices A and B must be compatible for matrix
        /// multiplication (i.e. the number of columns in A must match the number of rows
        /// in B).
        /// * @see multiplyMatrixRec()

        public static int[,] multiplyMatrix(int[,] A, int[,] B, int r1, int c2)
        {

            int[,] C = new int[r1, c2];

            for (int i = 0; i < r1; i++)
            {
                for (int j = 0; j < c2; j++)
                {
                    C[i, j] = 0;
                }
            }

            multiplyMatrixRec(A, B, C, 0, 0, 0);

            return C;
        }
    }
    public class IterativeMatrixMultiplication
    {
        /// <summary>
        /// Iterative Matrix Multiplication is simpler than other methods, so the more inputs, the more difficult it is.
        ///With simple logic, it multiplies and multiplies the row columns of the two matrixes in the form of a loop and is transferred to the newly created matrix at the same level.
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>

        public static int[,] ItarativeMatrix(int[,] A, int[,] B)
        {


            int size = 10;

            int[,] expectedArray = new int[A.GetLength(0), B.GetLength(1)];

            for (int i = 0; i < size; i++)
            {

                for (int j = 0; j < size; j++)
                {
                    int sum = 0;

                    for (int k = 0; k < size; k++)
                    {
                        sum += A[i, k] * B[k, j];
                    }

                    expectedArray[i, j] = sum;
                }

            }
            return expectedArray;
        }
    }
    public class StrassenMatrixMultiplication
    {
        public static int[,] StrassenMatrix(int[,] A, int[,] B)
        {

            // r = row
            int r = A.GetLength(0);

            /// Creates the result matrix.
            int[,] finish = new int[r, r];

            // for n = 1 situation
            if (r == 1)
            {
                finish[0, 0] = A[0, 0] * B[0, 0];
            }

            else
            {
                /// The matrices are separated by sub-matrices.
                int nsize = r / 2;

                int[,] x111 = new int[nsize, nsize];
                int[,] x112 = new int[nsize, nsize];
                int[,] x121 = new int[nsize, nsize];
                int[,] x122 = new int[nsize, nsize];

                int[,] x211 = new int[nsize, nsize];
                int[,] x212 = new int[nsize, nsize];
                int[,] x221 = new int[nsize, nsize];
                int[,] x222 = new int[nsize, nsize];

                Divide(A, x111, 0, 0);
                Divide(A, x112, 0, nsize);
                Divide(A, x121, nsize, 0);
                Divide(A, x122, nsize, nsize);

                Divide(B, x211, 0, 0);
                Divide(B, x212, 0, nsize);
                Divide(B, x221, nsize, 0);
                Divide(B, x222, nsize, nsize);

                // Calculate c1-c7 sub-matrices
                int[,] c1 = StrassenMatrix(Add(x111, x122), Add(x211, x222));
                int[,] c2 = StrassenMatrix(Add(x121, x122), x211);
                int[,] c3 = StrassenMatrix(x111, pp(x212, x222));
                int[,] c4 = StrassenMatrix(x122, pp(x221, x211));
                int[,] c5 = StrassenMatrix(Add(x111, x112), x222);
                int[,] c6 = StrassenMatrix(pp(x121, x111), Add(x211, x212));
                int[,] c7 = StrassenMatrix(pp(x112, x122), Add(x221, x222));
                /// Multiplication of sub-matrices
                int[,] unfinish11 = Add(pp(Add(c1, c4), c5), c7);
                int[,] unfinish12 = Add(c3, c5);
                int[,] unfinish21 = Add(c2, c4);
                int[,] unfinish22 = Add(pp(Add(c1, c3), c2), c6);
                /// Combines the result matrix from the sub-matrices.
                Merge(unfinish11, finish, 0, 0);
                Merge(unfinish12, finish, 0, nsize);
                Merge(unfinish21, finish, nsize, 0);
                Merge(unfinish22, finish, nsize, nsize);
            }

            return finish;
        }

        public static int[,] Add(int[,] A, int[,] B)
        {
            int n = A.GetLength(0);
            int[,] finish = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    finish[i, j] = A[i, j] + B[i, j];
                }
            }

            return finish;
        }

        public static int[,] pp(int[,] A, int[,] B)
        {
            int r = A.GetLength(0);
            int[,] finish = new int[r, r];

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    finish[i, j] = A[i, j] - B[i, j];
                }
            }

            return finish;
        }

        public static void Divide(int[,] mm1, int[,] mm2, int rowss, int cStart)
        {
            for (int i = 0, i2 = rowss; i < mm2.GetLength(0); i++, i2++)
            {
                for (int j = 0, j2 = cStart; j < mm2.GetLength(1); j++, j2++)
                {
                    mm2[i, j] = mm1[i2, j2];
                }
            }
        }

        public static void Merge(int[,] mm2, int[,] mm1, int rowss, int cStart)
        {
            for (int i = 0, i2 = rowss; i < mm2.GetLength(0); i++, i2++)
            {
                for (int j = 0, j2 = cStart; j < mm2.GetLength(1); j++, j2++)
                {
                    mm1[i2, j2] = mm2[i, j];
                }
            }
        }

    }
}
