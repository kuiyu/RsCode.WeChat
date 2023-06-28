using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RsCode.WeChat.Util;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.CommonMessage.Handler
{
    public class ReceiveShortVideoMessageHandler : IWeChatMessageManager
    {
        public string MsgType { get; set; } = "shortvideo";

        ILogger logger;
        Message.IWeChatEventHandler customMessageHandler;
        public ReceiveShortVideoMessageHandler(
              ILogger<ReceiveShortVideoMessageHandler> _logger,
            Message.IWeChatEventHandler _messageHandler
            )
        {
            logger = _logger;
            customMessageHandler = _messageHandler;
        }
        public async Task Invoke(string xml, HttpContext context)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ShortVideoMessage));
            var receiveMsg = xmlSerializer.Deserialize(xml) as ShortVideoMessage;

            var ret = await customMessageHandler?.OnReceiveShortVideoMessageEvent(receiveMsg);
            //logger.LogInformation("OnReceiveTextMessageEvent ret=" + ret);
            if (!string.IsNullOrWhiteSpace(ret))
            {
                await context.Response.WriteAsync(ret);
            }
        }
    }
}
