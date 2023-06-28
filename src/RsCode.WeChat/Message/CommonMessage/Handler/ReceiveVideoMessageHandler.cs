using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RsCode.WeChat.Util;
using System;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.CommonMessage.Handler
{
    public class ReceiveVideoMessageHandler:IWeChatMessageManager
    {
        Message.IWeChatEventHandler customMessageHandler;
        ILogger logger;
        public ReceiveVideoMessageHandler(
          Message.IWeChatEventHandler _messageHandler,
            ILogger<ReceiveVideoMessageHandler> _logger)
        {
            customMessageHandler = _messageHandler;
            logger = _logger;
        }
        public string MsgType { get; set; } = "video";

        public async Task Invoke(string xml, HttpContext context)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(VideoMessage));
            var receiveMsg = xmlSerializer.Deserialize(xml) as VideoMessage;

            var ret = await customMessageHandler?.OnReceiveVideoMessageEvent(receiveMsg);
            //logger.LogInformation("OnReceiveTextMessageEvent ret=" + ret);
            if (!string.IsNullOrWhiteSpace(ret))
            {
                await context.Response.WriteAsync(ret);
            }
        }
    }
}
