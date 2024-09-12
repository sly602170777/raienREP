using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQManagement.Models
{
    public class BaseInfo
    {
        //private long v1;
        //private string v2;
        //private string v3;
        //private DateTime dateTime;
        //private string v4;
        //private int v5;



        //[QQId], [NickName], [Sex], [BornDate], [City], [Phone]
        /// <summary>
        /// QQ编号
        /// </summary>
        public long QQId { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// /性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BornDate { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public int Phone { get; set; }

        public QQUser _QQUser { get; set; }
        /// <summary>
        /// 创建一个实体类
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="dateTime"></param>
        /// <param name="v4"></param>
        /// <param name="v5"></param>
        public BaseInfo (long v1, string v2, string v3, DateTime dateTime, string v4, int v5)
        {
            QQId = v1;
            NickName = v2;
            Sex = v3;
            BornDate = dateTime;
            City = v4;
            Phone = v5;
        }

        public BaseInfo ()
        {
        }

        /// <summary>
        /// 创建一个实体类
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="dateTime"></param>
        /// <param name="v4"></param>
        /// <param name="v5"></param>
        public BaseInfo (long v1, string v2, string v3, DateTime dateTime, string v4, int v5, QQUser qQUser)
        {
            QQId = v1;
            NickName = v2;
            Sex = v3;
            BornDate = dateTime;
            City = v4;
            Phone = v5;
            _QQUser = qQUser;
        }
    }
}
