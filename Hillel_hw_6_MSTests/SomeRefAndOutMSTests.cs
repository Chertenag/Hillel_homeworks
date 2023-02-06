using Hillel_hw_6;

namespace Hillel_hw_6_MSTests
{
    [TestClass]
    public class SomeRefAndOutMSTests
    {
        [TestMethod]
        [DataRow(-352, 999, 999, -352)]
        [DataRow(5, 777, 777, 5)]
        public void Test_SwapTwoNumbers_Rez(int a, int b, int expected_a, int expected_b)
        {
            SomeRefAndOut.SwapTwoNumbers(ref a, ref b);

            Assert.AreEqual(expected_a, a);
            Assert.AreEqual(expected_b, b);
        }

        [TestMethod]
        [DataRow(77, 2)]
        [DataRow(-123, 3)]
        [DataRow(-555.6234, 7)]
        public void Test_OutDigitsCountInANumber_Output(double numb, int expectedCount)
        {
            SomeRefAndOut.OutDigitsCountInANumber(numb, out int count);

            Assert.AreEqual(expectedCount, count);
        }

        [TestMethod]
        [DataRow("Test text.", 3, 't')]
        [DataRow("Another @ test.", 8, '@')]
        public void Test_OutCharByIndex_Output(string text, int index, char expectedCharacter)
        {
            SomeRefAndOut.OutCharByIndex(text, index, out char character);

            Assert.AreEqual(expectedCharacter, character);
        }
    }
}