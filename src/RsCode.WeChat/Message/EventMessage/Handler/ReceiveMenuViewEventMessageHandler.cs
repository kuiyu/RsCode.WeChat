using Microsoft.AspNetCore.Http;
using RsCode.WeChat.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.EventMessage.Handler
{
    public class ReceiveMenuViewEventMessageHandler : IWeChatMessageHandler
    {
        public string Event { get; set; } = "VIEW";
        Message.IWeChatEventHandler customMessageHandler;
        public ReceiveMenuViewEventMessageHandler(Message.IWeChatEventHandler _customMessageHandler)
        {
            customMessageHandler = _customMessageHandler;
        }
        public async Task Invoke(string xml, HttpContext context)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(MenuViewEventMessage));
            var receiveMsg = xmlSerializer.Deserialize(xml) as MenuViewEventMessage;

            var ret = await customMessageHandler?.OnMenuViewEvent(receiveMsg);

            if (!string.IsNullOrWhiteSpace(ret))
            {
                await context.Response.WriteAsync(ret);
            }
        }
    }
}
