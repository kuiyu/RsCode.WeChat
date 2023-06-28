using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.CommonMessage.Handler
{
    public class ReceiveTextImageMessageHandler : IWeChatMessageManager
    {
        //TODO: 图文消息格式？
        public string MsgType { get; set; } = " ";

        public Task Invoke(string xml, HttpContext context)
        {
            throw new NotImplementedException();
        }
    }

}
