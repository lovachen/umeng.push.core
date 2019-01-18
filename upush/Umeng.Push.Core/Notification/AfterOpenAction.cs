using System;
using System.Collections.Generic;
using System.Text;

namespace Umeng.Push.Core.Notification
{
    /// <summary>
    /// after_open
    /// </summary>
    public enum AfterOpenAction
    {
        /// <summary>
        /// 打开应用
        /// </summary>
        go_app,

        /// <summary>
        /// 跳转到URL
        /// </summary>
        go_url,

        /// <summary>
        /// 打开特定的activity
        /// </summary>
        go_activity,

        /// <summary>
        /// 用户自定义内容
        /// </summary>
        go_custom
    }
}
