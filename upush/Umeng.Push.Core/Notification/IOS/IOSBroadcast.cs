using System;
using System.Collections.Generic;
using System.Text;

namespace Umeng.Push.Core.Notification.IOS
{
    /// <summary>
    /// broadcast-广播
    /// </summary>
    public class IOSBroadcast:IOSNotification
    {
        public IOSBroadcast()
        {
            SetPredefinedKeyValue("type", "broadcast");
        }


    }
}
