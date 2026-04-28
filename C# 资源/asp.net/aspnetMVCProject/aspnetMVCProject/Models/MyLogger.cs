using log4net;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace aspnetMVCProject.Models
{
    public class MyLogger : Page
    {
        private static readonly ILog log = LogManager.GetLogger (typeof (MyLogger));

        public void Page_Load (object sender, EventArgs e)
        {
            if (!IsPostBack && sender != null)
            {
                log.Info (sender.ToString ());
                
                log.Info ("Page_Load called for the first time.");
            }
            else
            {
                log.Debug ("Page_Load called on postback.");
            }

            try
            {
                // 模拟一些操作
                //throw new Exception ("Simulated error.");
            }
            catch (Exception ex)
            {
                log.Error ("An error occurred in Page_Load.", ex);
            }
        }
    }
}