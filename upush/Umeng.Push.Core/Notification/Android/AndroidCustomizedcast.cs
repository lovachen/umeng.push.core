using System;
using System.Collections.Generic;
using System.Text;

namespace Umeng.Push.Core.Notification.Android
{
    /// <summary>
    ///  customizedcast，通过alias进行推送，包括以下两种case:
    ///  - alias: 对单个或者多个alias进行推送
    ///  - file_id: 将alias存放到文件后，根据file_id来推送
    /// </summary>
    public class AndroidCustomizedcast : AndroidNotification
    {
        public AndroidCustomizedcast()
        {
            SetPredefinedKeyValue("type", "customizedcast");
        }

        /// <summary>
        /// 设置别名
        /// </summary>
        /// <param name="alias"></param>
        /// <param name="aliasType">alias的类型, alias_type可由开发者自定义,</param>
        public void SetAlias(string alias, string aliasType = "alias_type")
        {
            SetPredefinedKeyValue("alias", alias);
            SetPredefinedKeyValue("alias_type", aliasType);
        }

        /// <summary>
        /// 将alias存放到文件后，根据file_id来推送
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="aliasType">alias的类型, alias_type可由开发者自定义</param>
        public void SetFileId(string fileId, string aliasType = "alias_type")
        {
            SetPredefinedKeyValue("file_id", fileId);
            SetPredefinedKeyValue("alias_type", aliasType);
        }

    }
}
