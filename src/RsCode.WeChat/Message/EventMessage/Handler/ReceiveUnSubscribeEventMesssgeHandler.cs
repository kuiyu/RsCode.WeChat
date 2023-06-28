using Microsoft.AspNetCore.Http;
using RsCode.WeChat.Util;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.EventMessage.Handler
{
    public class ReceiveUnSubscribeEventMesssgeHandler : IWeChatMessageHandler
    {


        public string Event { get; set; } = "unsubscribe";
        Message.IWeChatEventHandler customMessageHandler;
        public ReceiveUnSubscribeEventMesssgeHandler(Message.IWeChatEventHandler _customMessageHandler)
        {
            customMessageHandler = _customMessageHandler;
        }
        public async Task Invoke(string xml, HttpContext context)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SubscribeEventMessage));
            var receiveMsg = xmlSerializer.Deserialize(xml) as UnSubscribeEventMessage;

            var ret = await customMessageHandler?.OnUnSubscribeEvent(receiveMsg);

            if (!string.IsNullOrWhiteSpace(ret))
            {
                await context.Response.WriteAsync(ret);
            }

        }
    }
}
