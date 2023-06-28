using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RsCode.WeChat.Util;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.CommonMessage.Handler
{
    public class ReceiveTextMessageHandler : IWeChatMessageManager
    {
        ILogger logger;
        Message.IWeChatEventHandler customMessageHandler;
        public ReceiveTextMessageHandler(
            ILogger<ReceiveTextMessageHandler> _logger,
            Message.IWeChatEventHandler _messageHandler
            )
        {
           
            logger = _logger;
            customMessageHandler = _messageHandler;
        }
        public string MsgType { get; set; } = "text";

        public async Task Invoke(string xml, HttpContext context)
        {  
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TextMessage));
            var receiveMsg = xmlSerializer.Deserialize(xml) as TextMessage;

            if (receiveMsg.Content == "【收到不支持的消息类型，暂无法显示】")
                return;

            var ret = await customMessageHandler?.OnReceiveTextMessageEvent(receiveMsg);
            //logger.LogInformation("OnReceiveTextMessageEvent ret="+ret);
            if (!string.IsNullOrWhiteSpace(ret))
            {
                await context.Response.WriteAsync(ret);
            } 
        }
    }

}
