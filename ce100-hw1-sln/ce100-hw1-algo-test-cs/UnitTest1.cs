using ce100_hw1_algo_lib_cs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
    }
}
