using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg197
{
   public class school
    {
        private int _privateValue;
        protected int ProtectedValue;

        public school(int value)
        {
            _privateValue = value;
        }

        public int GetData()
        {
            return 1;
        }

    }
}
