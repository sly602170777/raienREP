using QQManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQManagement.Services
{
    public class QQUserService
    {
        /// <summary>
        /// 登录功能
        /// </summary>
        /// <param name="qqid">QQ编号</param>
        /// <param name="pwd">QQ密码</param>
        /// <returns></returns>
        public bool Login(long qqid, string pwd)
        {
            var sql = $@"select count(0) from [dbo].[QQUser] where QQId ={qqid} and Password ='{pwd}'";
            return (int)DBHelp.SelectForScalar(sql) == 1;
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public QQUser CreateQQUser(string pwd)
        {
            if (pwd.Trim().Length < 5)
            {
                //抛出异常后，后边的代码不会执行 等同于 return
                throw new ArgumentException(message: "您输入的密码位数不够");
            }
            var qqid = RanddomQQId();
            var logTime = DateTime.Now;
            var onLineTime = 0;
            var sql = $"insert into [dbo].[QQUser] values({qqid},'{pwd.Trim()}','{logTime.ToString(format: "yyyy-MM-dd HH:mm:ss")}',{onLineTime});";
            //插入一条数据
            DBHelp.Update(sql);

            return new QQUser
            {
                QQId = qqid,
                Password = pwd,
                LastLogTime = logTime,
                OnlineTime = onLineTime
            };

        }

        /// <summary>
        /// 随机生成可用的QQid
        /// </summary>
        /// <returns></returns>
        public long RanddomQQId()
        {
            Random qqid = new Random();
            while (true)
            {
                long id = qqid.Next(10000, 1000000000);
                var sql = $"select count(0) from [dbo].[QQUser] where QQId ={id}";
                //如果不存在则一直循环生成新的id
                if ((int)DBHelp.SelectForScalar(sql) == 0)
                {
                    return id;

                }

            }
        }
        /// <summary>
        /// 通过账户更新密码
        /// </summary>
        /// <param name="qqid"></param>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        public void UpdateQQUserByPwd(long qqid,string oldPwd,string newPwd) 
        {
            newPwd = newPwd.Trim();
            if (!Login(qqid,oldPwd))
            {
                throw new ArgumentException(message: "输入的原始账户密码不正确");
            }
            if (newPwd.Length<5)
            {
                throw new ArgumentException(message: "输入的密码位数不足5位");
            }
            var sql = $"update [dbo].[QQUser] set Password ='{newPwd}' where QQId ={qqid};";

            DBHelp.Update(sql);

            Console.WriteLine("账户："+ qqid + "的密码已经更新");
        }
        
        /// <summary>
        /// 通过账户更新在线时长
        /// </summary>
        /// <param name="qqid"></param>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        public void UpdateQQUserByOnlineTime(long qqid, int time)
        {

            if (time<=0)
                throw new ArgumentException(message:"输入的时长有误");

            var sql = $"select count(0) from [dbo].[QQUser] where QQId ={qqid};";
            if (1 != (int)DBHelp.SelectForScalar(sql))
                throw new ArgumentException(message:"qqid 不存在") ;

            sql = $"update [dbo].[QQUser] set OnlineTime =OnlineTime+{time} where QQId ={qqid};";

            DBHelp.Update(sql);

            Console.WriteLine("账户：" + qqid + "的在线时长已经更新");
        }
        
        /// <summary>
        /// 通过QQID获取用户基础信息
        /// </summary>
        /// <param name="qqid"></param>
        /// <returns></returns>
        public QQUser GetUserByID(long qqid) 
        {
            var sql = $"select QQId, Password, LastLogTime, OnlineTime from [dbo].[QQUser] where QQId ={qqid}";
            var dr = DBHelp.SelectForReader(sql);
            QQUser qQUser = new QQUser();
            if (dr.Read())
            {
                qQUser.QQId = qqid;
                qQUser.Password = dr.GetString(1);
                qQUser.LastLogTime = dr.GetDateTime(2);
                qQUser.OnlineTime = dr.GetInt32(3);
            }
            dr.Close();
            return qQUser;

        }

        public void RemoveQQuser(long  qqid) 
        {
            var sql = $"select count(0) from [dbo].[QQUser] where QQId ={qqid};";
            if (1 != (int)DBHelp.SelectForScalar(sql))
                throw new ArgumentException(message: "qqid 不存在");

            sql = $"delete from [dbo].[QQUser] where QQId ={qqid};";
            DBHelp.Update(sql);

            Console.WriteLine("用户："+qqid +" 已经删除成功");

        }
    }
}
