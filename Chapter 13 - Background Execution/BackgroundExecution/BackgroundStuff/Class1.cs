﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;

namespace BackgroundStuff
{
    public sealed class MyBackgroundTask: IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            SendToast("Hi this is background Task");
        }
        public static void SendToast(string message)
        {
            var template = ToastTemplateType.ToastText01;
            var xml = ToastNotificationManager.GetTemplateContent(template);
            var elements = xml.GetElementsByTagName("Test");
            var text = xml.CreateTextNode(message);

            elements[0].AppendChild(text);
            var toast = new ToastNotification(xml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
