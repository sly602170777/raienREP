using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg197
{
    public class Student : school
    {
        public int ID { get; set; }
        public string name { get; set; }

        public DateTime createDate { get; set; }

        public int age { get; set; }
        public int flag { get; set; }
         //public Student() { }

        //書き方
        //多重継承禁止
        //子：サブクラス（派生クラス）


        //派生クラスのコンストラクタから基底クラスのコンストラクタを呼び出して初期化する
        public Student(int value) : base(value)
        {
            //派生クラスからはbaseキーワードで基底クラスの機能を使う
            base.ProtectedValue = value;
            int b=  base.GetData();
        }


    }
}
