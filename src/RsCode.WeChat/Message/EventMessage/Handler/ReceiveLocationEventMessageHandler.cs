using Microsoft.AspNetCore.Http;
using RsCode.WeChat.Util;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.EventMessage.Handler
{
    /// <summary>
    /// 上报地理位置事件的处理
    /// </summary>
    public class ReceiveLocationEventMessageHandler : IWeChatMessageHandler
    {
        public string Event { get; set; } = "LOCATION";
        Message.IWeChatEventHandler customMessageHandler;
        public ReceiveLocationEventMessageHandler(Message.IWeChatEventHandler _customMessageHandler)
        {
            customMessageHandler = _customMessageHandler;
        }
        public async Task Invoke(string xml, HttpContext context)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(LocationEventMessage));
            var receiveMsg = xmlSerializer.Deserialize(xml) as LocationEventMessage;

            var ret = await customMessageHandler?.OnLocationEvent(receiveMsg);

            if (!string.IsNullOrWhiteSpace(ret))
            {
                await context.Response.WriteAsync(ret);
            }
        }
    }
}
