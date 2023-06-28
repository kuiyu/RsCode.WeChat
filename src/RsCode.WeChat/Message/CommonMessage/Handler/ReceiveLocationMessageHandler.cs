using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RsCode.WeChat.Util;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.CommonMessage.Handler
{
    public class ReceiveLocationMessageHandler : IWeChatMessageManager
    {
        ILogger logger;
        Message.IWeChatEventHandler customMessageHandler;
        public ReceiveLocationMessageHandler(
            ILogger<ReceiveLocationMessageHandler> _logger,
            Message.IWeChatEventHandler _messageHandler
            )
        {

            logger = _logger;
            customMessageHandler = _messageHandler;
        }
        public string MsgType { get; set; } = "location";

        public async Task Invoke(string xml, HttpContext context)
        {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(LocationMessage));
            var receiveMsg = xmlSerializer.Deserialize(xml) as LocationMessage;

            var ret = await customMessageHandler?.OnReceiveLocationMessageEvent(receiveMsg);
           // logger.LogInformation("OnReceiveTextMessageEvent ret=" + ret);
            if (!string.IsNullOrWhiteSpace(ret))
            {
                await context.Response.WriteAsync(ret);
            }
        }
    }
}
