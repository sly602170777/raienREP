using System;
using System.Collections.Generic;
namespace CalculateDemo
{
    class Program
    {
        /// <summary>
        /// 记录方法的Dictionary
        /// </summary>
        static Dictionary<string, string> cfg = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            Load();
            while(true)
            {
                Console.Write("请输入操作数1：");
                decimal x = decimal.Parse(Console.ReadLine());
                Console.Write("请输入操作数2：");
                decimal y = decimal.Parse(Console.ReadLine());
                
                Console.Write("请输入运算符:");
                string op = Console.ReadLine();
                string a = cfg[op];
                Operator opr = OperatorFactory.Create(a);
                opr.Left = x;
                opr.Right = y;
                decimal r = opr.Calc();
                Console.WriteLine($"{x}{op}{y}={r}");
            }
        }
        /// <summary>
        /// 初始化赋值
        /// </summary>
        static void Load()
        {
            cfg.Add("+", "CalculateDemo.AddOperator");
            cfg.Add("-","CalculateDemo.SubOperator");
            cfg.Add("*", "CalculateDemo.MulOperator");
            cfg.Add("/", "CalculateDemo.DivOperrator"); 
        }
    }
}
