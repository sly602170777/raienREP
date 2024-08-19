using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QQManagement.Models;
using QQManagement.Services;

namespace QQManagement.Views
{
    public class QQManagermentPage
    {
        private readonly QQUserService _QQUserService = new QQUserService ();
        private readonly BaseInfoService _BaseInfoService = new BaseInfoService ();

        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        private bool LoginPage () 
        {
            Console.WriteLine ("请输入QQ账户：");
            var qqid = long.Parse (Console.ReadLine());
            Console.WriteLine ("请输入QQ密码：");
            var pwd = Console.ReadLine ();
            try
            {
                return _QQUserService.Login (qqid, pwd);
            }
            catch (Exception e)
            {

                Console.WriteLine (e.Message);
                return false;
            }

        }
        /// <summary>
        /// 展示基本信息页面
        /// </summary>
        private void ShowQQInfoPage () 
        {
            Console.WriteLine ("请输入账户：");
            var qqid = long.Parse (Console.ReadLine ());
            try
            {
                var baseInfo = _BaseInfoService.GetBaseInfoByQQId (qqid);
                Console.WriteLine ($"QQ号：{baseInfo.QQId}   QQ昵称：{baseInfo.NickName}   性别：{baseInfo.Sex}   手机号：{baseInfo.Phone}   等级：{baseInfo._QQUser.LevelString}   ");
            }
            catch (Exception e)
            {

                Console.WriteLine (e.Message);
            }
           
        }

        /// <summary>
        /// 展示所有的用户信息页面
        /// </summary>
        private void ShowAllQQInfoPage ()
        {
            try
            {
                var baseInfo = _BaseInfoService.getAllQQUserInfo ();
                foreach (var item in baseInfo)
                {
                    Console.WriteLine ($"QQ号：{item.QQId}　　QQ昵称：{item.NickName}　　性别：{item.Sex}　　 手机号：{item.Phone}　　等级：{item._QQUser.LevelString}　　");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine (e.ToString());
                Console.WriteLine (e.Message);
            }

        }

        /// <summary>
        /// 展示昵称的关键字用户信息页面
        /// </summary>
        private void ShowQQInfoLikeWordPage ()
        {
            try
            {
                Console.WriteLine ("请输入昵称的关键字：");
                var word = Console.ReadLine ();
                var baseInfo = _BaseInfoService.getAllQQUserInfoLikeWord (word);
                foreach (var item in baseInfo)
                {
                    Console.WriteLine ($"QQ号：{item.QQId}　　QQ昵称：{item.NickName}　　性别：{item.Sex}　　 手机号：{item.Phone}　　等级：{item._QQUser.LevelString}　　");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine (e.ToString());
                Console.WriteLine (e.Message);
            }

        }
        private void UpdateDayTimePage () 
        {
            Console.WriteLine ("请输入账户：");
            var qqid = long.Parse (Console.ReadLine ());
            Console.WriteLine ("请输入新增天数：");
            var day = int.Parse (Console.ReadLine ());
            try
            {
                _QQUserService.UpdateQQUserByOnlineTime (qqid,day);
            }
            catch (Exception e)
            {

                Console.WriteLine (e.Message);
            }
        }

        /// <summary>
        /// 更新密码页面
        /// </summary>
        public void UpdatePasswordPage ()
        {
            Console.WriteLine ("请输入账户：");
            var qqid = long.Parse (Console.ReadLine ());
            Console.WriteLine ("请输入旧密码：");
            var oldPwd = Console.ReadLine ();
            Console.WriteLine ("请输入新密码：");
            var newPwd = Console.ReadLine ();
            try
            {
                _QQUserService.UpdateQQUserByPwd (qqid, oldPwd, newPwd);
            }
            catch (Exception e)
            {

                Console.WriteLine (e.Message);
            }
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        private void CreateUserPage () 
        {

            Console.WriteLine ("请输入密码：");
            var newPwd = Console.ReadLine ();
            Console.WriteLine ("请输入昵称：");
            var nickName = Console.ReadLine ();
            Console.WriteLine ("请输入性别：");
            var sex = Console.ReadLine ();
            Console.WriteLine ("请输入出生日期：");
            var bornDate=DateTime.Parse( Console.ReadLine ());
            Console.WriteLine ("请输入城市：");
            var cuty = Console.ReadLine ();
            Console.WriteLine ("请输入手机号：");
            var phone = int.Parse(Console.ReadLine ());
            try
            {
                _BaseInfoService.CreateUserInfo (newPwd, nickName, sex, bornDate, cuty, phone);
            }
            catch (Exception e)
            {
                Console.WriteLine (e.ToString());
                Console.WriteLine (e.Message);
            }

        }
        /// <summary>
        /// 删除用户
        /// </summary>
        private void RemoveUserPage () 
        {
            Console.WriteLine ("请输入账户：");
            var qqid = long.Parse (Console.ReadLine ());
            try
            {
                _QQUserService.RemoveQQuser (qqid);
            }
            catch (Exception e)
            {

                Console.WriteLine (e.Message);
            }
        }

        public void StartPage () 
        {
            while (true)
            {
                Console.WriteLine ("欢迎使用QQ");
                Console.WriteLine ("1,登录");
                Console.WriteLine ("2,退出");
                switch (Console.ReadLine ())
                {
                    case "1":
                        if (LoginPage ())
                        {
                            Console.WriteLine ("进入主页面");
                            MainPage ();
                        }
                        break;
                    case "2":
                        Console.WriteLine ("谢谢使用");
                        Environment.Exit (0);
                        break;
                    default:
                        Console.WriteLine ("输入有误");
                        break;
                }
            }
            
        }

        private void MainPage () 
        {
            Console.WriteLine ("1, 添加用户");
            Console.WriteLine ("2, 查看所有用户");
            Console.WriteLine ("3, 查看指定用户");
            Console.WriteLine ("4, 查看模糊用户");//ShowQQInfoLikeWordPage
            Console.WriteLine ("5, 修改密码");
            Console.WriteLine ("6, 修改时长");
            Console.WriteLine ("7, 删除用户");
            Console.WriteLine ("8, 注销");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    CreateUserPage ();
                    break;
                case 2:
                    ShowAllQQInfoPage();
                    break;
                case 3:
                    ShowQQInfoPage ();
                    break;
                case 4:
                    ShowQQInfoLikeWordPage();
                    break;
                case 5:
                    UpdatePasswordPage();
                    break;
                case 6:
                    UpdateDayTimePage();
                    break;
                case 7:
                    RemoveUserPage ();
                    break;
                case 8:
                    return;
                default:
                    Console.WriteLine ("输入的有误");
                    break;
            }

        }
    }
}
