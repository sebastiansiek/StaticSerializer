using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StaticSerializer.Core;

namespace StaticSerializer.Tests
{
    [TestClass]
    public class SerializerTest
    {
        private TestClass _testClass;

        public class TestClass
        {
            public string TestString { get; set; }
            public int TestInt { get; set; }
            public List<string> TestList { get; set; }
        }


        [TestInitialize]
        public void Initialize()
        {
            _testClass = new TestClass()
                {
                    TestInt = 666,
                    TestList = new List<string>()
                        {
                            "Test1",
                            "Test2",
                            "Test3"
                        },
                    TestString = "TestClassString"
                };
        }

        [TestMethod]
        public void CheckIfSerializerNotReturningAnEmptyString()
        {
            var result = Serializer.Serialize(_testClass);

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void CheckIfSerializerDoesNotReturnNullValueWhenDeserializing()
        {
            var serialized = Serializer.Serialize(_testClass);
            var result = Serializer.Desezialize<TestClass>(serialized);

            Assert.IsTrue(result.TestInt == _testClass.TestInt);
        }
    }
}
