using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQManagement.Models
{
    public class QQUser
    {
        //[QQId], [Password], [LastLogTime], [Level], [OnlineTime]
        /// <summary>
        /// QQ编号
        /// </summary>
        public long QQId { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLogTime { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        //public int LevelValue { get; set; } = 1;
        /// <summary>
        /// 在线时长
        /// </summary>
        public int OnlineTime { get; set; }
        public string LevelString
        {
            get
            {
                if (OnlineTime < 5) return "💧";
                if (OnlineTime < 32) return "🌟";
                if (OnlineTime < 320) return "🌙";
                return "☀";

            }
        }

    }
}
