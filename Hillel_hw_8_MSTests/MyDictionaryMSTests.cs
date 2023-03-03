using Hillel_hw_8;
using Newtonsoft.Json.Linq;

namespace Hillel_hw_8_MSTests

{
    [TestClass]
    public class MyDictionaryMSTests
    {
        [TestMethod]
        [DataRow(null, "testValue")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_AddTKeyTValue_ArgumentNullException(string key, string value)
        {
            MyDictionary<string, string> myDictionary = new()
            {
                { key, value }
            };
        }

        [TestMethod]
        [DataRow("key1", "testValue1", "key1", "testValue2")]
        [DataRow("key1", "testValue1", "key1", "testValue1")]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_AddTKeyTValue_ArgumentException(string key1, string value1, string key2, string value2)
        {
            MyDictionary<string, string> myDictionary = new()
            {
                { key1, value1 },
                { key2, value2 }
            };
        }

        [TestMethod]
        [DataRow(null, "testValue")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_AddKeyValuePair_ArgumentNullException(string key, string value)
        {
            MyDictionary<string, string> myDictionary = new()
            {
                { new KeyValuePair<string, string> (key, value) }
            };
        }

        [TestMethod]
        [DataRow(77, "testValue1", 77, "testValue2")]
        [DataRow(17, "testValue1", 17, "testValue1")]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_AddKeyValuePair_ArgumentException(int key1, string value1, int key2, string value2)
        {
            MyDictionary<int, string> myDictionary = new()
            {
                { new KeyValuePair<int, string> (key1, value1) },
                { new KeyValuePair<int, string> (key2, value2) }
            };
        }

        [TestMethod]
        [DataRow(77, "testValue1", 77, true)]
        [DataRow(17, "testValue2", 77, false)]
        public void Test_ContainsKey_Output(int keyInTable, string valueInTable, int keyToCheck, bool expectedResult)
        {
            MyDictionary<int, string> myDictionary = new();
            myDictionary.Add(keyInTable, valueInTable);

            bool result = myDictionary.ContainsKey(keyToCheck);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow("key1", "testValue1", "key1", "testValue1", true)]
        [DataRow("key2", "testValue2", "key1", "testValue1", false)]
        [DataRow("key2", "testValue2", "key2", "testValue1", false)]
        [DataRow("key2", "testValue2", "key1", "testValue2", false)]
        public void Test_ContainsKeyValuePair_Output(string keyInTable, string valueInTable, string keyToCheck, string valueToCheck, bool expectedResult)
        {

            MyDictionary<string, string> myDictionary = new();
            KeyValuePair<string, string> keyValuePairInTable = new(keyInTable, valueInTable);
            myDictionary.Add(keyValuePairInTable);
            KeyValuePair<string, string> keyValueToCheck = new(keyToCheck, valueToCheck);

            bool result = myDictionary.Contains(keyValueToCheck);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow("key1", "testValue1", "key1", true)]
        [DataRow("key2", "testValue2", "key1", false)]
        [DataRow("key2", "testValue2", "key2", true)]
        public void Test_RemoveKey_Output(string keyInTable, string valueInTable, string keyToRemove, bool expectedResult)
        {
            MyDictionary<string, string> myDictionary = new();
            myDictionary.Add(keyInTable, valueInTable);

            bool rezult = myDictionary.Remove(keyToRemove);

            Assert.AreEqual(expectedResult, rezult);
        }

        [TestMethod]
        [DataRow("key1", "testValue1", "key1", "testValue1", true)]
        [DataRow("key2", "testValue2", "key1", "testValue1", false)]
        [DataRow("key2", "testValue2", "key2", "testValue1", false)]
        [DataRow("key2", "testValue2", "key1", "testValue2", false)]
        public void Test_RemoveKeyValuePair_Output(string keyInTable, string valueInTable, string keyToRemove, string valueToRemove, bool expectedResult)
        {
            MyDictionary<string, string> myDictionary = new();
            KeyValuePair<string, string> keyValuePairInTable = new(keyInTable, valueInTable);
            myDictionary.Add(keyValuePairInTable);
            KeyValuePair<string, string> keyValuePairToRemove = new(keyToRemove, valueToRemove);

            bool rezult = myDictionary.Remove(keyValuePairToRemove);

            Assert.AreEqual(expectedResult, rezult);
        }

        [TestMethod]
        [DataRow(new string[] { "key1", "key2", "key3" }, new string[] { "key3", "key4" }, 2)]
        [DataRow(new string[] { "key1", "key2", "key3" }, new string[] { }, 3)]
        [DataRow(new string[] { "key1", "key3" }, new string[] { "key1", "key3", "key4" }, 0)]
        public void Test_Count_Output(string[] keysInTable, string[] keysToRemove, int expectedCount)
        {
            MyDictionary<string, string> myDictionary = new();
            foreach (string key in keysInTable)
            {
                myDictionary.Add(key, "RandomValue");
            }
            foreach (string key in keysToRemove)
            {
                myDictionary.Remove(key);
            }

            int count = myDictionary.Count;

            Assert.AreEqual(expectedCount, count);
        }

        [TestMethod]
        [DataRow(new string[] { "key1", "key2", "key3" }, 0)]
        [DataRow(new string[] { "key1", "key3" }, 0)]
        public void Test_Clear_Result(string[] keysInTable, int expectedCount)
        {
            MyDictionary<string, string> myDictionary = new();
            foreach (string key in keysInTable)
            {
                myDictionary.Add(key, "RandomValue");
            }

            myDictionary.Clear();
            int count = myDictionary.Count;

            Assert.AreEqual(expectedCount, count);
        }

        [TestMethod]
        [DataRow(new string[] { "key1", "key2", "key3" }, new string[] { "value1", "value2", "value3" }, new string[] { "key2" }, new string[] { "value1", "value3" })]
        [DataRow(new string[] { "key1", "key3", "key2" }, new string[] { "value1", "value2", "value3" }, new string[] { }, new string[] { "value1", "value2", "value3" })]
        public void Test_GetValuesList_Output(string[] keysInTable, string[] ValuesInTable, string[] keysToRemove, string[] expectedValues)
        {
            MyDictionary<string, string> myDictionary = new();
            for (int i = 0; i < keysInTable.Length; i++)
            {
                myDictionary.Add(keysInTable[i], ValuesInTable[i]);
            }
            foreach (string key in keysToRemove)
            {
                myDictionary.Remove(key);
            }

            string[] values = myDictionary.Values.Order().ToArray();

            Assert.IsTrue(values.SequenceEqual(expectedValues));
        }

        [TestMethod]
        [DataRow(new string[] { "key1", "key2", "key3" }, new string[] { "value1", "value2", "value3" }, new string[] { "key2" }, new string[] { "key1", "key3" })]
        [DataRow(new string[] { "key3", "key2", "key1" }, new string[] { "value1", "value2", "value3" }, new string[] { }, new string[] { "key1", "key2", "key3" })]
        public void Test_GetKeysList_Output(string[] keysInTable, string[] ValuesInTable, string[] keysToRemove, string[] expectedKeys)
        {
            MyDictionary<string, string> myDictionary = new();
            for (int i = 0; i < keysInTable.Length; i++)
            {
                myDictionary.Add(keysInTable[i], ValuesInTable[i]);
            }
            foreach (string key in keysToRemove)
            {
                myDictionary.Remove(key);
            }

            string[] keys = myDictionary.Keys.Order().ToArray();

            Assert.IsTrue(keys.SequenceEqual(expectedKeys));
        }

        [TestMethod]
        [DataRow(new string[] { "key1", "key2", "key4" }, "key3")]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_GetValueByKey_ArgumentException(string[] keysInTable, string indexKey)
        {
            MyDictionary<string, string> myDictionary = new();
            foreach (string key in keysInTable)
            {
                myDictionary.Add(key, "RandomValue");
            }

            var value = myDictionary[indexKey];
        }

        [TestMethod]
        [DataRow(new string[] { "key1", "key2", "key4" }, "key3")]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_SetValueByKey_ArgumentException(string[] keysInTable, string indexKey)
        {
            MyDictionary<string, string> myDictionary = new();
            foreach (string key in keysInTable)
            {
                myDictionary.Add(key, "RandomValue");
            }

            myDictionary[indexKey] = "RandomValue2";
        }

        [TestMethod]
        [DataRow(new string[] { "key1", "key2", "key4" }, new string[] { "value2", "value4", "value6" }, "key2", "value4")]
        public void Test_GetValueByKey_Output(string[] keysInTable, string[] ValuesInTable, string indexKey, string expectedValue)
        {
            MyDictionary<string, string> myDictionary = new();
            for (int i = 0; i < keysInTable.Length; i++)
            {
                myDictionary.Add(keysInTable[i], ValuesInTable[i]);
            }

            var value = myDictionary[indexKey];

            Assert.AreEqual(expectedValue, value);
        }

        [TestMethod]
        [DataRow(new string[] { "key1", "key2", "key4" }, new string[] { "value2", "value4", "value6" }, "key2", "value10")]
        public void Test_SetValueByKey_Output(string[] keysInTable, string[] ValuesInTable, string indexKey, string setAndExpectedValue)
        {
            MyDictionary<string, string> myDictionary = new();
            for (int i = 0; i < keysInTable.Length; i++)
            {
                myDictionary.Add(keysInTable[i], ValuesInTable[i]);
            }

            myDictionary[indexKey] = setAndExpectedValue;
            var value = myDictionary[indexKey];

            Assert.AreEqual(setAndExpectedValue, value);
        }

        [TestMethod]
        [DataRow(new string[] { "key1", "key2", "key4" }, null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_TryGetValue_ArgumentNullException(string[] keysInTable, string searchKey)
        {
            MyDictionary<string, string> myDictionary = new();
            foreach (string key in keysInTable)
            {
                myDictionary.Add(key, "RandomValue");
            }

            bool result = myDictionary.TryGetValue(searchKey, out var value);
        }

        [TestMethod]
        [DataRow(new string[] { "key1", "key2", "key4" }, "key3", false)]
        public void Test_TryGetValue_Result(string[] keysInTable, string searchKey, bool expectedResult)
        {
            MyDictionary<string, string> myDictionary = new();
            foreach (string key in keysInTable)
            {
                myDictionary.Add(key, "RandomValue");
            }

            bool result = myDictionary.TryGetValue(searchKey, out var value);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow(new string[] { "key1", "key2", "key4" }, new string[] { "value2", "value4", "value6" }, "key2", "value4")]
        public void Test_TryGetValue_Output(string[] keysInTable, string[] ValuesInTable, string searchKey, string expectedValue)
        {
            MyDictionary<string, string> myDictionary = new();
            for (int i = 0; i < keysInTable.Length; i++)
            {
                myDictionary.Add(keysInTable[i], ValuesInTable[i]);
            }

            bool result = myDictionary.TryGetValue(searchKey, out var value);

            Assert.AreEqual(expectedValue, value);
        }

        [TestMethod]
        [DataRow(new string[] { "key1", "key2", "key3", "key4" }, 10, 7)]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_CopyTo_ArgumentException (string[] keysInTable, int arrayLength, int arrayStartCopy)
        {
            MyDictionary<string, string> myDictionary = new();
            foreach (string key in keysInTable)
            {
                myDictionary.Add(key, "RandomValue");
            }
            KeyValuePair<string, string>[] array = new KeyValuePair<string, string>[arrayLength];

            myDictionary.CopyTo(array, arrayStartCopy);
        }
    }
}