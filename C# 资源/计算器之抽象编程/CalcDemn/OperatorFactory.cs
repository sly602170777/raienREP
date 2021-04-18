using System;
using System.Reflection;
using System.Runtime;

namespace CalculateDemo
{
    class OperatorFactory
    {

        /// <summary>
        /// 利用反射
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Operator Create(string name)
        {
            Operator opr = null;

            var cls = Type.GetType(name);

            //GetConstructor(), GetConstructors()：返回ConstructorInfo类型，用于取得该类的构造函数的信息
            ConstructorInfo ci = cls.GetConstructor(Type.EmptyTypes);
            //调用具有指定参数的实例反映的构造函数，为不常用的参数提供默认值
            opr = (Operator)ci.Invoke(null);

            return opr;
        }


        public static Operator CreatObject1(string str)
        {
            Operator opr = null;
            var type = Type.GetType(str);
            ConstructorInfo inf = type.GetConstructor(Type.EmptyTypes);
            opr=(Operator)inf.Invoke(null);
            return opr;
        }

    }


   
}
