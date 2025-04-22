using aspnetMVCProject.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace aspnetMVCProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly ILog log = LogManager.GetLogger (typeof (MyLogger));
        protected void Application_Start ()
        {
            // 加载log4net配置
            log4net.Config.XmlConfigurator.Configure (new System.IO.FileInfo (Server.MapPath ("~/log4net.config")));

            // 记录应用程序启动日志
            log.Info ("Application started.");

            AreaRegistration.RegisterAllAreas ();
            FilterConfig.RegisterGlobalFilters (GlobalFilters.Filters);
            RouteConfig.RegisterRoutes (RouteTable.Routes);
            BundleConfig.RegisterBundles (BundleTable.Bundles);
            //log4net.Config.XmlConfigurator.Configure ();
        }
    }
}
