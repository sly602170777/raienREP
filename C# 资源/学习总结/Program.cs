using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Oracle.ManagedDataAccess.Client;

namespace OracleConnectDemo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string a = string.Empty;
            string b = "";
            //判断a 和b 是否相等
            if (a == b)
            {
                Console.WriteLine("a 和 b 相等");
            }
            else
            {
                Console.WriteLine("a 和 b 不相等");
            }
            Console.WriteLine(a);

            // 客户端通过工厂类获取产品对象
            IProduct productA = SimpleFactory.CreateProduct(ProductType.A);
            productA.Show(); // 输出: Product A is created.

            IProduct productB = SimpleFactory.CreateProduct(ProductType.B);
            productB.Show(); // 输出: Product B is created.

            Console.WriteLine("-----------------");

            //int aa = ProcessMain.Main();

            // Oracleデータベースへの接続文字列を指定します。
            string connectionString =
                "User Id=sys;Password=123456;Data Source=localhost:1521/orcl;DBA Privilege=SYSDBA";

            // PostgreSQLデータベースへの接続文字列を指定します。
            string postgresConnectionString =
                "Host=localhost;Username=postgres;Password=123456;Database=postgres;SSL Mode=Prefer";

            // オラクルデータベースに接続
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("オラクルデータベース接続成功！");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("接続に失敗しました: " + ex.Message);
                }
            }

            // PostgreSQLデータベースに接続
            using (NpgsqlConnection postconn = new NpgsqlConnection(postgresConnectionString))
            {
                try
                {
                    postconn.Open();
                    Console.WriteLine("PostgreSQLデータベース接続成功！");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("接続に失敗しました: " + ex.Message);
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine($"InvalidCastException: {ex.Message}");
                    Console.WriteLine($"Error Code: {ex.HResult}");
                    Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                    Console.WriteLine($"Source: {ex.Source}");
                    Console.WriteLine($"Target Site: {ex.TargetSite}");
                }
            }

            Console.ReadLine();
        }
    }

    // 定义一个产品接口，所有产品类都将实现这个接口
    public interface IProduct
    {
        void Show();
    }

    // 具体产品类A
    public class ProductA : IProduct
    {
        public void Show()
        {
            Console.WriteLine("Product A is created.");
        }
    }

    // 具体产品类B
    public class ProductB : IProduct
    {
        public void Show()
        {
            Console.WriteLine("Product B is created.");
        }
    }

    // 工厂类，负责创建产品对象
    public class SimpleFactory
    {
        // 根据输入参数决定创建哪种产品
        public static IProduct CreateProduct(ProductType type)
        {
            switch (type)
            {
                case ProductType.A:
                    return new ProductA();
                case ProductType.B:
                    return new ProductB();
                default:
                    throw new ArgumentException("Invalid product type.");
            }
        }
    }

    public enum ProductType
    {
        A,
        B,
    }
}
