using System;
using debug365;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace debug.test
{
    [TestClass]
    public class UnitTest1
    {
        public string _path = @"D:\C#\2019\test.txt";

        [TestInitialize]
        public void init()
        {
            // テスト開始時の処理
            var sw = System.IO.File.CreateText(_path);
            sw.Write("10,20");
            sw.Close();
        }
        [TestCleanup]
        public void post()
        {
            // テスト終了時の処理
            System.IO.File.Delete(_path);
        }


        [TestMethod]
        public void 数値の加算()
        {
            var text = System.IO.File.ReadAllText(_path);
            var lst = text.Split(',');
            int a = int.Parse(lst[0]);
            int b = int.Parse(lst[1]);
            Assert.AreEqual(10, a);
            Assert.AreEqual(20, b);
        }
    }
}
