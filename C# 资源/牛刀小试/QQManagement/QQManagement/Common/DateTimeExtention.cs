using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQManagement.Common
{
    public static class DateTimeExtention
    {
        public static string GetFormatDateString (this DateTime dateTime)
        {
            return dateTime.ToString (format: "yyyy-MM-dd");

        }
        public static string GetFormatDateTimeString (this DateTime dateTime)
        {
            return dateTime.ToString (format: "yyyy-MM-dd HH:mm:ss");

        }
    }
}
