using NUnit.Framework;
using utils;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Class1 c1 = new utils.Class1();
            string initial = "hey";
            var rtn = c1.testing(initial);
            
            Assert.AreEqual(initial, rtn);
        }
    }
}