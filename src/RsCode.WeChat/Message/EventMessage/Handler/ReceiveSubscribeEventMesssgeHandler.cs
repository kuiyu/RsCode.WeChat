using Microsoft.AspNetCore.Http;
using RsCode.WeChat.Util;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.EventMessage.Handler
{
    public class ReceiveSubscribeEventMesssgeHandler : IWeChatMessageHandler
    {
         

        public string Event { get; set; } = "subscribe";
        Message.IWeChatEventHandler customMessageHandler;
        public ReceiveSubscribeEventMesssgeHandler(Message.IWeChatEventHandler _customMessageHandler)
        {
            customMessageHandler = _customMessageHandler;
        }
        public async Task Invoke(string xml, HttpContext context)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SubscribeEventMessage));
            var receiveMsg = xmlSerializer.Deserialize(xml) as SubscribeEventMessage;

            var ret = await customMessageHandler?.OnSubscribeEvent(receiveMsg);

            if (!string.IsNullOrWhiteSpace(ret))
            {
                await context.Response.WriteAsync(ret);
            }
            
        }
    }

    
}
