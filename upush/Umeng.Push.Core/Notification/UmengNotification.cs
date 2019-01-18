using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umeng.Push.Core.Notification
{
    public abstract class UmengNotification
    {
        /// <summary>
        /// 请求体对象
        /// </summary>
        public JObject RootJson = new JObject();

        /// <summary>
        /// 
        /// </summary>
        public static readonly HashSet<string> ROOT_KEYS = new HashSet<string>(new String[] {
            "appkey", "timestamp", "type", "device_tokens", "alias", "alias_type", "file_id",
            "filter", "production_mode", "feedback", "description", "thirdparty_id"});

        /// <summary>
        /// 
        /// </summary>
        public static readonly HashSet<String> POLICY_KEYS = new HashSet<String>(new String[]{
             "start_time", "expire_time", "max_send_num"});


        /// <summary>
        /// 设置预定义的值，需重写
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public abstract bool SetPredefinedKeyValue(string key, object value);


        /// <summary>
        /// 获取提交的数据json字符串
        /// </summary>
        /// <returns></returns>
        public string GetPostBody()
        {
            return RootJson.ToString();
        }

        /// <summary>
        /// 设置模式
        /// </summary>
        /// <param name="prod">true：正式，false：测试</param>
        public void SetProductionMode(bool prod = true)
        {
            SetPredefinedKeyValue("production_mode", prod.ToString().ToLower());
        }

        /// <summary>
        /// 发送消息描述，建议填写。
        /// </summary>
        /// <param name="description"></param>
        public void SetDescription(string description)
        {
            SetPredefinedKeyValue("description", description);
        }

        /// <summary>
        /// 定时发送时间，若不填写表示立即发送。格式: "YYYY-MM-DD hh:mm:ss"。
        /// </summary>
        /// <param name="startTime"></param>
        public void SetStartTime(string startTime)
        {
            SetPredefinedKeyValue("start_time", startTime);
        }

        /// <summary>
        /// 消息过期时间,格式: "YYYY-MM-DD hh:mm:ss"。
        /// </summary>
        /// <param name="expireTime"></param>
        public void SetExpireTime(String expireTime)
        {
            SetPredefinedKeyValue("expire_time", expireTime);
        }
        /// <summary>
        /// 发送限速，每秒发送的最大条数。
        /// </summary>
        /// <param name="num"></param>
        public void SetMaxSendNum(int num)
        {
            SetPredefinedKeyValue("max_send_num", num);
        }


    }
}
