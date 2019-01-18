using System;
using System.Collections.Generic;
using System.Text;

namespace Umeng.Push.Core.Notification.IOS
{
    /// <summary>
    /// 文件播，多个device_token可通过文件形式批量发送
    /// </summary>
    public class IOSFilecast : IOSNotification
    {
        public IOSFilecast(String appkey, String appMasterSecret)
        {
            SetPredefinedKeyValue("type", "filecast");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileId"></param>
        public void SetFileId(string fileId)
        {
            SetPredefinedKeyValue("file_id", fileId);
        }
    }
}
