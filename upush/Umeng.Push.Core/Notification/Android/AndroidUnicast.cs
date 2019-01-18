using System;
using System.Collections.Generic;
using System.Text;

namespace Umeng.Push.Core.Notification.Android
{
    /// <summary>
    /// 单播
    /// </summary>
    public class AndroidUnicast : AndroidNotification
    {
        
        public AndroidUnicast()
        {
            this.SetPredefinedKeyValue("type", "unicast");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        public void SetDeviceToken(string token)
        {
            SetPredefinedKeyValue("device_tokens", token);
        }
    }
}
