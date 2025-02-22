using System;
using debug358;
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
            int ans = t.add(10, 20);
            Assert.AreEqual(30, ans);
        }
    }
}
