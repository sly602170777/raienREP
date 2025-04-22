using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace pg197
{
    public class ModelConvertHelper
    {
        //该泛型必须是where后面的类，或者继承自该类，
        //new()说明所使用的泛型，必须具有无参构造函数
        public List<T> ConvertTomodel<T>(DataTable dt) where T : new() 
        {
            //定义集合
            List<T> ts = new List<T>();
            //获得此模型的类型
            //Type type = typeof(T);
            //定义一个临时变量
            string tempName = "";
            //遍历datatable中所有的数据行
            foreach (DataRow row in dt.Rows)
            {
                T t = new T();
                //获得此模型的公共属性
                PropertyInfo[] properInfos = t.GetType().GetProperties();
                //遍历所有属性
                foreach (PropertyInfo properInfo in properInfos)
                {
                    //将属性名称赋值给临时变量
                    tempName = properInfo.Name;
                    //检查datatable是否包含此列
                    if (dt.Columns.Contains(tempName))
                    {
                        ////判断此属性是否有setter  改属性不可写，直接跳出
                        if (!properInfo.CanWrite) continue;
                        //取值
                        object value = row[tempName];
                        //如果非空，则赋给对象的属性
                        if (value != DBNull.Value)
                        {
                            properInfo.SetValue(t,value,null);
                        }
                    }
                }
                //对象添加到泛型集合中
                ts.Add(t);
            }
            return ts;
        }


        //Datatable转list泛型 调用在D层中定义list来接收返回值

        public List<Student> GetStudents(Student student) 
        {
           // SqlHelper sqlHelper = new SqlHelper();
            SqlParameter[] sqlparams = 
                {
                    new SqlParameter("@ID", 9) ,
                    new SqlParameter("@name", "ee")
                };
            string sql = @"select * from AAA where ID =@ID or name=@name";
            //执行SQL文
            DataTable table = SqlHelper.ExcuteParamQuery(sql,sqlparams);

            ModelConvertHelper modelConvertHelper = new ModelConvertHelper();
            //将datatable转换为list泛型
          //  List<Student> students= modelConvertHelper.ConvertTomodel<Student>(table);
            List<Student> students = new List<Student>();
            return students;
        }
    }
}
