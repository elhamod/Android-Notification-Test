using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using System.Timers;
using MoeTestAndroidNotificationASP.Models;

namespace MoeTestAndroidNotificationASP
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static int index = 0;
        private const int period = 60000; //ms

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //send notifications every x
            Timer t = new Timer(period);
            t.Elapsed += new ElapsedEventHandler(SendNotification);
            t.Enabled = true;
        }

        private static void SendNotification(object sender, ElapsedEventArgs e)
        {
            // Android
            var notif = "{ \"data\" : {\"message number\":\"" + index++ + "\"}}";
            Notifications.Instance.Hub.SendGcmNativeNotificationAsync(notif);
        }
    }
}
