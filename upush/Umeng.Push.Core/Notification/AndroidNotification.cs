using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umeng.Push.Core.Notification
{
    /// <summary>
    /// android 消息
    /// </summary>
    public abstract class AndroidNotification : UmengNotification
    {

        /// <summary>
        /// 消息PLAYLOAD keys
        /// </summary>
        protected static readonly HashSet<string> PAYLOAD_KEYS = new HashSet<string>(new string[]{
            "display_type"});

        /// <summary>
        /// 消息体keys
        /// </summary>
        protected static readonly HashSet<string> BODY_KEYS = new HashSet<string>(new string[]{
            "ticker", "title", "text", "builder_id", "icon", "largeIcon", "img", "play_vibrate", "play_lights", "play_sound",
            "sound", "after_open", "url", "activity", "custom"});
          
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
            else if (PAYLOAD_KEYS.Contains(key))
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
                payloadJson.Add(key, val);
            }
            else if (BODY_KEYS.Contains(key))
            {
                JObject bodyJson = null;
                JObject payloadJson = null;
                //
                if (RootJson.ContainsKey("payload"))
                {
                    payloadJson = RootJson.Value<JObject>("payload");
                }
                else
                {
                    payloadJson = new JObject();
                    RootJson.Add("payload", payloadJson);
                }
                if (payloadJson.ContainsKey("body"))
                {
                    bodyJson = payloadJson.Value<JObject>("body");
                }
                else
                {
                    bodyJson = new JObject();
                    payloadJson.Add("body", bodyJson);
                }
                bodyJson.Add(key, val);
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
                if (key == "payload" || key == "body" || key == "policy" || key == "extra")
                {
                    throw new Exception("没有添加 " + key + " , 到HashSet集合");
                }
                else
                {
                    throw new Exception("未知的 key: " + key);
                }
            }
            return true;
        }

        /// <summary>
        /// 设置扩展
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetExtraField(string key, string value)
        {
            JObject payloadJson = null;
            JObject extraJson = null;
            if (RootJson.ContainsKey("payload"))
            {
                payloadJson = RootJson.Value<JObject>("payload");
            }
            else
            {
                payloadJson = new JObject();
                RootJson.Add("payload", payloadJson);
            }

            if (payloadJson.ContainsKey("extra"))
            {
                extraJson = payloadJson.Value<JObject>("extra");
            }
            else
            {
                extraJson = new JObject();
                payloadJson.Add("extra", extraJson);
            }
            extraJson.Add(key, value);
            return true;
        }

        /// <summary>
        /// 设置通知类型
        /// </summary>
        /// <param name="d"></param>
        public void SetDisplayType(DisplayType d)
        {
            SetPredefinedKeyValue("display_type", d.ToString());
        }
        
        /// <summary>
        /// 通知栏提示文字
        /// </summary>
        /// <param name="ticker"></param>
        public void SetTicker(string ticker)
        {
            SetPredefinedKeyValue("ticker", ticker);
        }

        /// <summary>
        /// 通知标题
        /// </summary>
        /// <param name="title"></param>
        public void SetTitle(string title)
        {
            SetPredefinedKeyValue("title", title);
        }

        /// <summary>
        /// 通知文字描述
        /// </summary>
        /// <param name="text"></param>
        public void SetText(string text)
        {
            SetPredefinedKeyValue("text", text);
        }

        /// <summary>
        /// 用于标识该通知采用的样式。使用该参数时, 必须在SDK里面实现自定义通知栏样式。
        /// </summary>
        /// <param name="builder_id"></param>
        public void SetBuilderId(int builder_id)
        {
            SetPredefinedKeyValue("builder_id", builder_id);
        }

        /// <summary>
        /// 状态栏图标ID, R.drawable.[smallIcon],如果没有, 默认使用应用图标。
        /// </summary>
        /// <param name="icon"></param>
        public void SetIcon(string icon)
        {
            SetPredefinedKeyValue("icon", icon);
        }

        /// <summary>
        /// 通知栏拉开后左侧图标ID
        /// </summary>
        /// <param name="largeIcon"></param>
        public void SetLargeIcon(string largeIcon)
        {
            SetPredefinedKeyValue("largeIcon", largeIcon);
        }

        /// <summary>
        /// 通知栏大图标的URL链接。该字段的优先级大于largeIcon。该字段要求以http或者https开头。
        /// </summary>
        /// <param name="img"></param>
        public void SetImg(string img)
        {
            SetPredefinedKeyValue("img", img);
        }

        /// <summary>
        /// 收到通知是否震动,默认为"true"
        /// </summary>
        /// <param name="play_vibrate"></param>
        public void SetPlayVibrate(bool play_vibrate)
        {
            SetPredefinedKeyValue("play_vibrate", play_vibrate.ToString());
        }

        /// <summary>
        /// 收到通知是否闪灯,默认为"true"
        /// </summary>
        /// <param name="play_lights"></param>
        public void SetPlayLights(Boolean play_lights)
        {
            SetPredefinedKeyValue("play_lights", play_lights.ToString());
        }

        /// <summary>
        /// 收到通知是否发出声音,默认为"true"
        /// </summary>
        /// <param name="play_sound"></param>
        public void SetPlaySound(Boolean play_sound)
        {
            SetPredefinedKeyValue("play_sound", play_sound.ToString());
        }

        /// <summary>
        /// 通知声音，R.raw.[sound]. 如果该字段为空，采用SDK默认的声音
        /// </summary>
        /// <param name="sound"></param>
        public void SetSound(String sound)
        {
            SetPredefinedKeyValue("sound", sound);
        }

        /// <summary>
        /// 收到通知后播放指定的声音文件
        /// </summary>
        /// <param name="sound"></param>
        public void SetPlaySound(String sound)
        {
            SetPlaySound(true);
            SetSound(sound);
        }

        /// <summary>
        /// 点击"通知"的后续行为，默认为打开app。
        /// </summary>
        public void GoAppAfterOpen()
        {
            SetAfterOpenAction(AfterOpenAction.go_app);
        }

        /// <summary>
        /// 点开后打开连接地址
        /// </summary>
        /// <param name="url"></param>
        public void GoUrlAfterOpen(string url)
        {
            SetAfterOpenAction(AfterOpenAction.go_url);
            SetUrl(url);
        }

        /// <summary>
        /// 点击后打开相对的 activity
        /// </summary>
        /// <param name="activity"></param>
        public void GoActivityAfterOpen(string activity)
        {
            SetAfterOpenAction(AfterOpenAction.go_activity);
            SetActivity(activity);
        }

        /// <summary>
        /// 点开后打开用户自定义内容。
        /// </summary>
        /// <param name="custom"></param>
        public void GoCustomAfterOpen(string custom)
        {
            SetAfterOpenAction(AfterOpenAction.go_custom);
            SetCustomField(custom);
        }

        /// <summary>
        /// 点开后打开用户自定义内容。json对象
        /// </summary>
        /// <param name="custom"></param>
        public void GoCustomAfterOpen(JObject custom)
        {
            SetAfterOpenAction(AfterOpenAction.go_custom);
            SetCustomField(custom);
        }

        /// <summary>
        /// 点击"通知"的后续行为，默认为打开app。原始接口
        /// </summary>
        /// <param name="action"></param>
        public void SetAfterOpenAction(AfterOpenAction action)
        {
            SetPredefinedKeyValue("after_open", action.ToString());
        }

        #region 私有方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        private void SetUrl(string url)
        {
            SetPredefinedKeyValue("url", url);
        }

        /// <summary>
        /// 通知栏点击后打开的Activity
        /// </summary>
        /// <param name="activity"></param>
        private void SetActivity(string activity)
        {
            SetPredefinedKeyValue("activity", activity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custom"></param>
        private void SetCustomField(string custom)
        {
            SetPredefinedKeyValue("custom", custom);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custom"></param>
        private void SetCustomField(JObject custom)
        {
            SetPredefinedKeyValue("custom", custom);
        }

        #endregion

    }
}
