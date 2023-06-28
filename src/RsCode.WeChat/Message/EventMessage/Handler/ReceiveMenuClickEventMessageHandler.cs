using Microsoft.AspNetCore.Http;
using RsCode.WeChat.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.EventMessage.Handler
{
    /// <summary>
    /// 
    /// </summary>
    public class ReceiveMenuClickEventMessageHandler : IWeChatMessageHandler
    {
        public string Event { get; set; } = "CLICK";
        Message.IWeChatEventHandler customMessageHandler;
        public ReceiveMenuClickEventMessageHandler(Message.IWeChatEventHandler _customMessageHandler)
        {
            customMessageHandler = _customMessageHandler;
        }
        public async Task Invoke(string xml, HttpContext context)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(MenuClickEventMessage));
            var receiveMsg = xmlSerializer.Deserialize(xml) as MenuClickEventMessage;

            var ret = await customMessageHandler?.OnMenuClickEvent(receiveMsg);

            if (!string.IsNullOrWhiteSpace(ret))
            {
                await context.Response.WriteAsync(ret);
            }
        }
    }
}
