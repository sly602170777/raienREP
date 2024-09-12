using QQManagement.Common;
using QQManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace QQManagement.Services
{
    public class BaseInfoService
    {
        private QQUserService _QQUserService = new QQUserService ();
        //[QQId], [NickName], [Sex], [BornDate], [City], [Phone] 
        /// <summary>
        /// 创建用户的基础信息
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="nickName"></param>
        /// <param name="sex"></param>
        /// <param name="bornDate"></param>
        /// <param name="city"></param>
        /// <param name="phone"></param>
        public void CreateUserInfo (string pwd,string nickName,string sex,DateTime bornDate,string city ,int phone ) 
        {
            var qqUser = _QQUserService.CreateQQUser (pwd);
            string born = DateTimeExtention.GetFormatDateString (bornDate);
            var sql = $"insert into [dbo].[BaseInfo] values({qqUser.QQId},'{nickName}','{sex}','{born}','{city}',{phone})";
            DBHelp.Update (sql);
            Console.WriteLine ("用户QQID："+qqUser.QQId+ "  基础信息创建成功！");

        }
        /// <summary>
        /// 获取QQ用户基础信息
        /// </summary>
        /// <param name="qqid"></param>
        /// <returns></returns>
        public BaseInfo GetBaseInfoByQQId (long qqid) 
        {
            var sql = $"select QQId, NickName, Sex, BornDate, City, Phone from [dbo].[BaseInfo] where QQId = {qqid}";

             var dataRead= DBHelp.SelectForReader (sql);
            BaseInfo baseInfo = null;
            if (dataRead.Read())
            {
                baseInfo = new BaseInfo
                {
                    QQId = qqid,
                    NickName = dataRead.GetString (1),
                    Sex = dataRead.GetString (2),
                    BornDate = dataRead.GetDateTime (3),
                    City = dataRead.GetString (4),
                    Phone = dataRead.GetInt32 (5),
                    _QQUser = _QQUserService.GetUserByID (qqid)
                };
                //baseInfo = new BaseInfo(
                //    qqid,
                //    dataRead.GetString (2),
                //    dataRead.GetString (3),
                //    dataRead.GetDateTime (4),
                //    dataRead.GetString (5),
                //    dataRead.GetInt32 (6),
                //    _QQUserService.GetUserByID (qqid)
                //);
            }

            return baseInfo;
        }
        /// <summary>
        /// 删除用户的基础信息
        /// </summary>
        /// <param name="qqid"></param>
        public void RemoveBaseInfoByQQId (long qqid) 
        {
            //校验qqid是否存在
            var sql = $"select count(0) from [dbo].[QQUser] where QQId ={qqid};";
            if (1 != (int)DBHelp.SelectForScalar (sql))
                throw new ArgumentException (message: "qqid 不存在");

            sql = $"delete from [dbo].[BaseInfo] where QQId ={qqid};";
            if (DBHelp.Update (sql)) 
            {
                _QQUserService.RemoveQQuser (qqid);

                Console.WriteLine ("QQ用户："+ qqid  + " 基础信息已删除");
            } ;
        }

        /// <summary>
        /// 查看所有用户基础信息
        /// </summary>
        /// <returns></returns>
        public List<BaseInfo> getAllQQUserInfo () 
        {
            var sql = $"select [QQId], [NickName], [Sex], [BornDate], [City], [Phone] from [dbo].[BaseInfo]";
            List<BaseInfo> baseInfos = new List<BaseInfo> ();
            var dataRead = DBHelp.SelectForReader (sql);
            while (dataRead.Read())
            {
baseInfos.Add (new BaseInfo(
                    (long)dataRead.GetInt32 (0),
                    dataRead.GetString (1),
                    dataRead.GetString (2),
                   //dataRead.GetString (3),
                    dataRead.GetDateTime (3),
                    dataRead.GetString (4),
                    dataRead.GetInt32 (5),
                    //QQId = dataRead.GetInt64 (1),
                    //NickName = dataRead.GetString (2),
                    //Sex = dataRead.GetString (3),
                    //BornDate = dataRead.GetDateTime (4),
                    //City = dataRead.GetString (5),
                    //Phone = dataRead.GetInt32 (6),
                     _QQUserService.GetUserByID ((long)dataRead.GetInt32 (0))
                    )
                );
            }
            dataRead.Close ();
            return baseInfos;
        }

        public List<BaseInfo> getAllQQUserInfoLikeWord (string word)
        {
            var sql = $"select [QQId], [NickName], [Sex], [BornDate], [City], [Phone] from [dbo].[BaseInfo] where NickName like '%{word}%'";
            List<BaseInfo> baseInfos = new List<BaseInfo> ();
            var dataRead = DBHelp.SelectForReader (sql);
            while (dataRead.Read ())
            {
                baseInfos.Add (new BaseInfo (
                    (long)dataRead.GetInt32 (0),
                    dataRead.GetString (1),
                    dataRead.GetString (2),
                    //dataRead.GetString (3),
                    dataRead.GetDateTime (3),
                    dataRead.GetString (4),
                    dataRead.GetInt32 (5),
                    _QQUserService.GetUserByID ((long)dataRead.GetInt32 (0))
                    //QQId = dataRead.GetInt64 (1),
                    //NickName = dataRead.GetString (2),
                    //Sex = dataRead.GetString (3),
                    //BornDate = dataRead.GetDateTime (4),
                    //City = dataRead.GetString (5),
                    //Phone = dataRead.GetInt32 (6),

                    //dataRead.GetInt64 (1),
                    //dataRead.GetString (2),
                    //dataRead.GetString (3),
                    //dataRead.GetDateTime (4),
                    //dataRead.GetString (5),
                    //dataRead.GetInt32 (6),
                    //_QQUserService.GetUserByID (dataRead.GetInt64 (1))
                    //QQId = dataRead.GetInt64 (1),
                    //NickName = dataRead.GetString (2),
                    //Sex = dataRead.GetString (3),
                    //BornDate = dataRead.GetDateTime (4),
                    //City = dataRead.GetString (5),
                    //Phone = dataRead.GetInt32 (6),
                    //QQUser = _QQUserService.GetUserByID (qqid)
                    )
                );
            }
            return baseInfos;
        }
    }
}
