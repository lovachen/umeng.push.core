using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umeng.Push.Core.Notification
{
    /// <summary>
    /// IOS消息
    /// </summary>
    public abstract class IOSNotification : UmengNotification
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="String"></typeparam>
        /// <param name=""></param>
        /// <returns></returns>
        protected static readonly HashSet<String> APS_KEYS = new HashSet<String>(new String[]{
            "alert", "badge", "sound", "content-available"});

        /// <summary>
        /// 设置预定义的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool SetPredefinedKeyValue(string key, object value)
        {
            var val = JToken.FromObject(value);

            if (ROOT_KEYS.Contains(key))
            {
                RootJson.Add(key, val);
            }
            else if (APS_KEYS.Contains(key))
            {
                JObject apsJson = null;
                JObject payloadJson = null;
                if (RootJson.ContainsKey("payload"))
                {
                    payloadJson = RootJson.Value<JObject>("payload");
                }
                else
                {
                    payloadJson = new JObject();
                    RootJson.Add("payload", payloadJson);
                }
                if (payloadJson.ContainsKey("aps"))
                {
                    apsJson = payloadJson.Value<JObject>("aps");
                }
                else
                {
                    apsJson = new JObject();
                    payloadJson.Add("aps", apsJson);
                }
                apsJson.Add(key, val);
            }
            else if (POLICY_KEYS.Contains(key))
            {
                JObject policyJson = null;
                if (RootJson.ContainsKey("policy"))
                {
                    policyJson = RootJson.Value<JObject>("policy");
                }
                else
                {
                    policyJson = new JObject();
                    RootJson.Add("policy", policyJson);
                }
                policyJson.Add(key, val);
            }
            else
            {
                if (key == "payload" || key == "aps" || key == "policy")
                {
                    throw new Exception(" 未找到 " + key + "在集合中");
                }
                else
                {
                    throw new Exception("未知 key: " + key);
                }
            }
            return true;
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetCustomizedField(string key, string value)
        {
            JObject payloadJson = null;
            if (RootJson.ContainsKey("payload"))
            {
                payloadJson = RootJson.Value<JObject>("payload");
            }
            else
            {
                payloadJson = new JObject();
                RootJson.Add("payload", payloadJson);
            }
            payloadJson.Add(key, value);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        public void SetAlert(string token)
        {
            SetPredefinedKeyValue("alert", token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="badge"></param>
        public void SetBadge(int badge)
        {
            SetPredefinedKeyValue("badge", badge);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sound"></param>
        public void SetSound(string sound)
        {
            SetPredefinedKeyValue("sound", sound);
        }

        /// <summary>
        /// 代表静默推送     1
        /// </summary>
        /// <param name="contentAvailable"></param>
        public void SetContentAvailable(int contentAvailable)
        {
            SetPredefinedKeyValue("content-available", contentAvailable);
        }
    }
}
