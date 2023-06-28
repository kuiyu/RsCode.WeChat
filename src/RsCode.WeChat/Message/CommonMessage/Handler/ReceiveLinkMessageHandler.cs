using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RsCode.WeChat.Util;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.CommonMessage.Handler
{
    public class ReceiveLinkMessageHandler : IWeChatMessageManager
    {
        public string MsgType { get; set; } = "link";
        ILogger logger;
        Message.IWeChatEventHandler customMessageHandler;
        public ReceiveLinkMessageHandler(
             ILogger<ReceiveLinkMessageHandler> _logger,
            Message.IWeChatEventHandler _messageHandler
            )
        {
            logger = _logger;
            customMessageHandler = _messageHandler;
        }
        public async  Task Invoke(string xml, HttpContext context)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(LinkMessage));
            var receiveMsg = xmlSerializer.Deserialize(xml) as LinkMessage;

            var ret = await customMessageHandler?.OnReceiveLinkMessageEvent(receiveMsg);
            
            if (!string.IsNullOrWhiteSpace(ret))
            {
                await context.Response.WriteAsync(ret);
            }
        }
    }
}
