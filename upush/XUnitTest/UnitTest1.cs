using System;
using Umeng.Push.Core;
using Umeng.Push.Core.Notification;
using Umeng.Push.Core.Notification.Android;
using Umeng.Push.Core.Notification.IOS;
using Xunit;

namespace XUnitTest
{
    public class UnitTest1
    {

        [Fact]
        public void Test1()
        {
            UPushClient pushClient = new UPushClient("5c418a1ff1f5564f1f0007c0", "zmkcoh4cen1xcl5pufmfgovciikvf1lh");

            var customizedcast = new AndroidBroadcast();
            customizedcast.SetTicker("Android customizedcast ticker");
            customizedcast.SetTitle("ÏûÏ¢Title");
            customizedcast.SetText("Android customizedcast text");
            customizedcast.GoAppAfterOpen();
            customizedcast.SetDisplayType(DisplayType.notification);
            customizedcast.SetProductionMode();
            Assert.True(pushClient.SendPush(customizedcast));


        }
 
    }
}
