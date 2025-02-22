using System;
using debug360;
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
            var obj = t.CreatePointer(-1, 1);
            Assert.IsNotNull(obj);
            obj = t.CreatePointer(10, 20);
            Assert.IsNotNull(obj);
            Assert.AreEqual(10, obj.X);
            Assert.AreEqual(20, obj.Y);
        }
    }
}
