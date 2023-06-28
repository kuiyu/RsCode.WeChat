using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RsCode.WeChat.Util;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.CommonMessage.Handler
{
    public class ReceiveImageMessageHandler : IWeChatMessageManager
    {
         
        public string MsgType { get; set; } = "image";
        ILogger logger;
        Message.IWeChatEventHandler customMessageHandler;
        public ReceiveImageMessageHandler(
             ILogger<ReceiveImageMessageHandler> _logger,
            Message.IWeChatEventHandler _messageHandler
            )
        {
            logger = _logger;
            customMessageHandler = _messageHandler;
        }

        public async Task Invoke(string xml, HttpContext context)
        {
           
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImageMessage));
            var receiveMsg = xmlSerializer.Deserialize(xml) as ImageMessage;

            await customMessageHandler?.OnReceiveImageMessageEvent(receiveMsg); 
            
        }
    }

   
        
}
