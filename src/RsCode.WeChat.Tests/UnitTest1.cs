using RsCode.WeChat.Message;
using System.ComponentModel.DataAnnotations;

namespace RsCode.WeChat.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string xml = "<xml><AppId><![CDATA[wxbb351fd8902f163e]]></AppId>\r\n<CreateTime>1665300301</CreateTime>\r\n<InfoType><![CDATA[component_verify_ticket]]></InfoType>\r\n<ComponentVerifyTicket><![CDATA[ticket@@@Csaed7zh5SrJ0qX9dMBZ8HP2R4s9vHS73mmHdR9qbEDvs2Yje00vbZTb7oNmA-jMfSTBt-A0lK3ebj9WyORlJA]]></ComponentVerifyTicket>\r\n</xml> ";
            var msg = new ThirdPlatformMessage();
            msg.LoadData(xml, DataTransferFormatter.XML);
            Assert.Equal("wxbb351fd8902f163e",msg.AppId);
        }
    }
}