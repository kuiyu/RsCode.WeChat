using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.CommonMessage.Handler
{
    /// <summary>
    /// 收到微信消息的处理程序
    /// </summary>
    public interface IWeChatMessageManager
    {
        string MsgType { get; set; }

        /// <summary>
        /// 执行消息处理
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="context"></param> 
        /// <returns></returns>
        Task Invoke(string xml, HttpContext context);
    }
}
