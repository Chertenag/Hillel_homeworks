using Hillel_hw_14;

namespace Hillel_hw_14_MsTests
{
    [TestClass]
    public class FooBarMsTests
    {
        [TestMethod]
        [DataRow(5, "foobarfoobarfoobarfoobarfoobar")]
        [DataRow(2, "foobarfoobar")]
        public async Task Test_FooBarToConsole_Console(int count, string expectedResult)
        {
            StringWriter stringWriter = new();
            Console.SetOut(stringWriter);

            await FooBar.Run(count);
            
            Assert.AreEqual(expectedResult, stringWriter.ToString());
        }
    }
}