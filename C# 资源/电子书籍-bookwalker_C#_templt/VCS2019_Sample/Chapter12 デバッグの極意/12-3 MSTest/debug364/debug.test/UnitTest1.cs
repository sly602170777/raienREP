using System;
using debug364;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace debug.test
{
    [TestClass]
    public class UnitTest1
    {
        private int _a = 0;
        private int _b = 0;


        [TestInitialize]
        public void init()
        {
            // テストを実行する前処理を記述する
            this._a = 10;
            this._b = 10;
        }


        [TestMethod]
        public void 数値の加算()
        {
            var t = new TargetClass();
            int ans = t.add(_a, _b);
            Assert.AreEqual(20, ans);
        }
    }
}
