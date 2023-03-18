using Hillel_hw_11;

namespace Hillel_hw_11_MSTests
{
    [TestClass]
    public class MultiThreadMergeSorterMSTests
    {
        [TestMethod]
        [DataRow(new int[] { 8, 6, 99, 8, 777, 1, 3, 0, 161, 11 }, new int[] { 0, 1, 3, 6, 8, 8, 11, 99, 161, 777 })]
        public void Test_DivideAndMergeSort__Output(int[] values, int[] expectedResult)
        {
            CancellationToken token = CancellationToken.None;

            int[] result = MultiThreadMergeSorter.DivideAndMergeSort(values, token);

            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}