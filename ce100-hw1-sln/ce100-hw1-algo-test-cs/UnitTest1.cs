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
    }
}
