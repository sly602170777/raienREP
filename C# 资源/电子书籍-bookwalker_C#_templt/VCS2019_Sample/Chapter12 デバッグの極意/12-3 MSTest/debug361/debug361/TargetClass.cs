using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace debug361
{

    /// <summary>
    /// テスト対象のクラス
    /// </summary>
    public class TargetClass
    {
        /// <summary>
        /// 足し算
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int add(int a, int b)
        {
            return a + b;
        }
        /// <summary>
        /// 文字列の連結
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string add(string a, string b)
        {
            return a + b;
        }
        /// <summary>
        /// オブジェクトの生成
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public XY CreatePointer(int x, int y)
        {
            if (x < 0 && y < 0)
            {
                return null;
            }
            else
            {
                return new XY { X = x, Y = y };
            }
        }

        /// <summary>
        /// 例外を発生させる
        /// </summary>
        public void FireException()
        {
            throw new Exception("-------例外発生------");
        }
    }
    /// <summary>
    /// 座標を保持するクラス
    /// </summary>
    public class XY
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
