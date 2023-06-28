using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RsCode.WeChat.Util;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.EventMessage.Handler
{
    public class ReceiveScanEventMessageHandler : IWeChatMessageHandler
    {
        public string Event { get; set; } = "SCAN";
        IWeChatEventHandler customMessageHandler;

        ILogger logger;
        public ReceiveScanEventMessageHandler(IWeChatEventHandler _customMessageHandler,
            ILogger<ReceiveScanEventMessageHandler> _logger
            )
        {
            customMessageHandler = _customMessageHandler;
            logger = _logger;
        }
        public async Task Invoke(string xml, HttpContext context)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ScanEventMessage));
            var receiveMsg = xmlSerializer.Deserialize(xml) as ScanEventMessage;
            //logger.LogInformation(receiveMsg==null ? "receiveMsg=null" : "receiveMsg有值");
            var ret = await customMessageHandler?.OnCanEvent(receiveMsg);

            if (!string.IsNullOrWhiteSpace(ret))
            {
                await context.Response.WriteAsync(ret);
            }
        }
    }
}
