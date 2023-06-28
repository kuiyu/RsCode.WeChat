using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RsCode.WeChat.Util;
using System;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.CommonMessage.Handler
{
    public class ReceiveVoiceMessageHandler : IWeChatMessageManager
    {
        Message.IWeChatEventHandler customMessageHandler;
        ILogger logger;
        public ReceiveVoiceMessageHandler(Message.IWeChatEventHandler _messageHandler, ILogger<ReceiveVoiceMessageHandler> _logger)
        {
            customMessageHandler = _messageHandler;
            logger = _logger;
        }
        public string MsgType { get; set; } = "voice";

        public async Task Invoke(string xml, HttpContext context)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(VoiceMessage));
            VoiceMessage receiveMsg = xmlSerializer.Deserialize(xml) as VoiceMessage;

            var ret = await customMessageHandler?.OnReceiveVoiceMessageEvent(receiveMsg);
            //logger.LogInformation("OnReceiveTextMessageEvent ret=" + ret);
            if (!string.IsNullOrWhiteSpace(ret))
            {
                await context.Response.WriteAsync(ret);
            }

        }
    }
}
