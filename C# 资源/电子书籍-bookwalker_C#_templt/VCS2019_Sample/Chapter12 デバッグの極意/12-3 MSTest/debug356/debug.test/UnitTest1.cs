using System;
using debug356;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace debug.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var t = new TargetClass();
            Assert.AreEqual(30, t.add(10, 20));
            int aa = t.add(10,10);
            Assert.AreEqual(20, aa);
        }
    }
}
