using System;
using System.Collections.Generic;
using System.Text;

namespace Umeng.Push.Core.Notification.Android
{
    /// <summary>
    /// broadcast-广播
    /// </summary>
    public class AndroidBroadcast : AndroidNotification
    {
        public AndroidBroadcast()
        {
            SetPredefinedKeyValue("type", "broadcast");
        }
    }
}
