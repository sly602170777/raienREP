using System;
using debug362;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace debug.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void 数値の加算()
        {
            var t = new TargetClass();
            int ans = t.add(10, 20);
            Assert.AreEqual(30, ans);
        }
        [TestMethod]
        public void 文字列の結合()
        {
            var t = new TargetClass();
            string ans = t.add("マスダ", "トモアキ");
            Assert.AreEqual("マスダトモアキ", ans);
        }
        [TestMethod]
        public void NULLチェック()
        {
            var t = new TargetClass();
            var obj = t.CreatePointer(10, 20);
            Assert.IsNotNull(obj);
            Assert.AreEqual(10, obj.X);
            Assert.AreEqual(20, obj.Y);
        }
    }
}
