using ce100_hw1_algo_lib_cs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ce100_hw1_algo_lib_cs.Tests
{

}

namespace ce100_hw1_algo_test_cs
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void SelectionSortFunctionTest()
        {
            int[] series = new int[10000];
            Random random = new Random();

            for (int i = 0; i < series.Length; i++)
            {
                series[i] = random.Next(0, 10000);
            }

            int size = series.Length;

            int[] ff = SelectionSort.SelectionSortFunction(series);

            int[] sorted = (int[])series.Clone();
            Array.Sort(sorted);

            CollectionAssert.AreEqual(sorted, ff);
        }
        [TestMethod()]
        public void MergeSortRecursiveTest()
        {
            int[] series = new int[10000];
            Random random = new Random();

            for (int i = 0; i < series.Length; i++)
            {
                series[i] = random.Next(0, 10000);
            }

            int size = series.Length;

            int[] ff = RecursiveMergeSort.MergeSortRecursive(ref series, 0, size - 1);

            int[] sorted = (int[])series.Clone();
            Array.Sort(sorted);

            CollectionAssert.AreEqual(sorted, ff);
        }
        [TestMethod()]
        public void HoareTest() //Hoare
        {
            int[] series = new int[10000];
            Random random = new Random();

            for (int i = 0; i < series.Length; i++)
            {
                series[i] = random.Next(0, 10000);
            }

            int size = series.Length;

            int[] ff = HoareQuickSort.Hoare(series, 0, size - 1);

            int[] sorted = (int[])series.Clone();
            Array.Sort(sorted);

            CollectionAssert.AreEqual(sorted, ff);
        }

        [TestMethod()]
        public void LomutoTest() //Lomuto
        {
            {

                int[] series = new int[10000];
                Random random = new Random();

                for (int i = 0; i < series.Length; i++)
                {
                    series[i] = random.Next(0, 10000);
                }

                int size = series.Length;

                int[] ff = LomutoQuickSort.Lomuto(series, 0, size - 1);

                int[] sorted = (int[])series.Clone();
                Array.Sort(sorted);

                CollectionAssert.AreEqual(sorted, ff);

            }
        }
        [TestMethod()]
        public void IterativeBinarySearchFunctionTest()
        {
            int[] ss = new int[10000];
            Random random = new Random();

            for (int i = 0; i < ss.Length; i++)
            {
                ss[i] = random.Next(0, 10000);
            }

            Random n2x = new Random();
            int j = n2x.Next(1, 10000);

            int sz = ss.Length;

            int[] ss2 = (int[])ss.Clone();
            Array.Sort(ss2);

            int n2 = ss2[j];

            int finish = IterativeBinarySearch.IterativeBinarySearchFunction(ss2, n2);

            Assert.AreEqual(0, finish);
        }
        [TestMethod()]
        public void RecursiveBinarySearchFunctionTest()
        {
            int[] ss = new int[10000];
            Random random = new Random();

            for (int i = 0; i < ss.Length; i++)
            {
                ss[i] = random.Next(0, 10000);
            }

            Random n1 = new Random();
            int j = n1.Next(1, 10000);

            int sz = ss.Length;

            int[] ss2 = (int[])ss.Clone();
            Array.Sort(ss2);

            int n2 = ss2[j];

            int finish = RecursiveBinarySearch.RecursiveBinarySearchFunction(ss2, 0, sz - 1, n2);

            Assert.AreEqual(0, finish);
        }
        [TestMethod()]
        public void RecursiveMatrixMultiplicationTest()
        {
            int i, j;

            Random random = new Random();
            int[,] m1 = new int[10, 10];
            int[,] m2 = new int[10, 10];
            int[,] m3 = new int[10, 10];


            int sz = 10;

            for (i = 1; i < sz; i++)
            {
                for (j = 1; j < sz; j++)
                {
                    m1[i, j] = random.Next(0, 10);
                }

            }
            for (i = 1; i < sz; i++)
            {
                for (j = 1; j < sz; j++)
                {
                    m2[i, j] = random.Next(0, 10);
                }
            }

            int r1 = m1.GetLength(0);
            int c1 = m1.GetLength(1);

            int r2 = m2.GetLength(0);
            int c2 = m2.GetLength(1);


            int[,] finish = RecursiveMatrixMultiplication.multiplyMatrix(m1, m2, r1, c2);

            int[,] expectedArray = new int[m1.GetLength(0), m2.GetLength(1)];

            for (i = 0; i < sz; i++)
            {
                for (j = 0; j < sz; j++)
                {
                    int ss3 = 0;

                    for (int k = 0; k < sz; k++)
                    {
                        ss3 += m1[i, k] * m2[k, j];
                    }

                    expectedArray[i, j] = ss3;
                }
            }

            CollectionAssert.AreEqual(expectedArray, finish);



        }
        [TestMethod()]
        public void ItarativeMatrixTest()
        {
            int[,] matrix1 = new int[,]
                        {

                    { 2, 4, 5, 3, 3, 1, 9, 4, 3, 5 },
                    { 7, 5, 0, 0, 3, 2, 3, 8, 2, 4},
                    {9, 8, 2, 5, 3, 2, 0, 1, 5, 0},
                    {7, 8, 9, 0, 6, 5, 8, 2, 5, 7},
                    {3, 0, 9, 4, 7, 9, 1, 9, 2, 9},
                    {0, 6, 6, 4, 8, 4, 2, 0, 9, 0},
                    {1, 8, 9, 2, 8, 8, 5, 0, 3, 8},
                    {4, 0, 3, 5, 0, 9, 9, 8, 7, 3},
                    {1, 0, 8, 6, 0, 0, 2, 5, 1, 2},
                    {3, 7, 2, 4, 6, 5, 1, 6, 6, 8}

                        };

            int[,] matrix2 = new int[,]
            {
                  { 2, 4, 5, 3, 3, 1, 9, 4, 3, 5 },
                    { 7, 5, 0, 0, 3, 2, 3, 8, 2, 4},
                    {9, 8, 2, 5, 3, 2, 0, 1, 5, 0},
                    {7, 8, 9, 0, 6, 5, 8, 2, 5, 7},
                    {3, 0, 9, 4, 7, 9, 1, 9, 2, 9},
                    {0, 6, 6, 4, 8, 4, 2, 0, 9, 0},
                    {1, 8, 9, 2, 8, 8, 5, 0, 3, 8},
                    {4, 0, 3, 5, 0, 9, 9, 8, 7, 3},
                    {1, 0, 8, 6, 0, 0, 2, 5, 1, 2},
                    {3, 7, 2, 4, 6, 5, 1, 6, 6, 8}

            };

            int[,] expected = new int[,]
            {
                 { 150, 205, 207, 123, 182, 199, 151, 155, 157, 204 },
                 {107, 117, 149, 115, 121, 168, 180, 193, 146, 166 },
                 {145, 144, 176, 92, 124, 98, 171, 172, 114, 152},
                 {211, 283, 269, 194, 260, 232, 178, 238, 224, 257},
                 {202, 241, 256, 213, 243, 274, 183, 228, 291, 217},
                 {159, 150, 234, 136, 164, 148, 94, 179, 129, 158},
                 {209, 276, 246, 172, 274, 229, 112, 216, 228, 233},
                 {127, 227, 292, 175, 213, 230, 228, 146, 241, 189},
                 {145, 146, 120, 86,   91,   118, 116, 81, 127, 96},
                 {174, 189, 230, 163, 198, 217, 175, 258, 209, 227 }
            };

            int[,] actual = IterativeMatrixMultiplication.ItarativeMatrix(matrix1, matrix2);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
