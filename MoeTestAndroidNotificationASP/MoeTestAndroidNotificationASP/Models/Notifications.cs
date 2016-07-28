using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.NotificationHubs;

namespace MoeTestAndroidNotificationASP.Models
{
    public class Notifications
    {
        public static Notifications Instance = new Notifications();

        public NotificationHubClient Hub { get; set; }

        private Notifications()
        {
            Hub = NotificationHubClient.CreateClientFromConnectionString("Endpoint=sb://moetestandroid.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=ZpPAbZKuOQ2U9sFpGJXXg88KKhNBgNHBzNbcJa/73EI=",
                                                                         "moeandroidtestnotificationhub");
        }
    }
}