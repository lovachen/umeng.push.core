﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umeng.Push.Core.Notification.IOS
{
    /// <summary>
    /// 组播，按照filter筛选用户群, 请参照filter参数
    /// </summary>
    public class IOSGroupcast : IOSNotification
    {
        public IOSGroupcast()
        {
            this.SetPredefinedKeyValue("type", "groupcast");
        }

        /// <summary>
        /// 过滤参数
        /// </summary>
        /// <param name="filter"></param>
        public void setFilter(JObject filter)
        {
            SetPredefinedKeyValue("filter", filter);
        }
    }
}
