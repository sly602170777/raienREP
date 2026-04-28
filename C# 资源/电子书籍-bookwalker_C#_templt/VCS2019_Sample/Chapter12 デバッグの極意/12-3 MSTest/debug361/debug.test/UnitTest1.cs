using System;
using debug361;
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
            try
            {
                // ��O�𔭐�������
                t.FireException();
            }
            catch ( Exception ex )
            {
                // 因为例外発生所以 测试成功
                Assert.AreEqual("-------例外発生------", ex.Message);
                return;
            }
            // 因为例外没有発生所以 测试失败
            Assert.Fail();
        }
    }
}
