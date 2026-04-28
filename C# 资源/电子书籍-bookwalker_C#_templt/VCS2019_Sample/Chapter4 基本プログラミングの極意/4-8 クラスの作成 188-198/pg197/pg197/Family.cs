using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg197
{
    public class Family:Student
    {
        public string a;

        public Family(int p) :base(p)
          {
            //派生クラスからはbaseキーワードで基底クラスの機能を使う
            int d= base.GetData();
            int k=base.ProtectedValue;
             a= k.ToString();
            
        }
    }
}
