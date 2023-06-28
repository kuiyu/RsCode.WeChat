using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.EventMessage.Handler
{
    /// <summary>
    /// 微信的事件推送处理
    /// </summary>
    public interface IWeChatMessageHandler
    { 
        string Event { get; set; }
        /// <summary>
        /// 执行消息处理
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="context"></param> 
        /// <returns></returns>
        Task Invoke(string xml, HttpContext context);
    }
}
