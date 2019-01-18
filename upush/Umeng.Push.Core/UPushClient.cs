using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Umeng.Push.Core.Notification;
using Umeng.Push.Core.Utils;

namespace Umeng.Push.Core
{

    /// <summary>
    /// 发送客户端
    /// </summary>
    public class UPushClient
    {
        /// <summary>
        /// 域名
        /// </summary>
        private const string HOST = "https://msgapi.umeng.com";

        /// <summary>
        /// 推送消息地址
        /// </summary>
        private const string POST_PATH = "/api/send";

        private HttpClient httpClient;

        /// <summary>
        /// 
        /// </summary>
        public string AppKey { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        public string AppMasterSecret { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        public UPushClient()
        {
            httpClient = new HttpClient() { BaseAddress = new Uri(HOST) };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="masterSecret"></param>
        public UPushClient(string appkey, string masterSecret) : this()
        {
            AppKey = appkey;
            AppMasterSecret = masterSecret;
        }


        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendPush(UmengNotification msg)
        {
            DateTime startTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            var seconds = (int)((DateTime.Now.ToUniversalTime() - startTime).TotalMilliseconds / 1000);
            msg.SetPredefinedKeyValue("appkey", AppKey);
            msg.SetPredefinedKeyValue("timestamp", seconds.ToString());
            string url = HOST + POST_PATH;
            string postBody = msg.GetPostBody();
            string sign = Md5.GetMD5Hash("POST" + url + postBody + AppMasterSecret);
            url = url + "?sign=" + sign;

            var response = httpClient.PostAsync(url, new StringContent(postBody)).Result;

            string src = response.Content.ReadAsStringAsync().Result;
            System.Diagnostics.Debug.WriteLine(src);

            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }


    }
}
