using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RsCode.WeChat.Util;
using System.Threading;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.CommonMessage.Handler
{
    internal class SendTextMessageHandler : IRequestHandler<TextMessage, string>
    {
        ISendWeCahtMsgIntegrationHandler sendWeCahtMsgIntegrationHandler;
        public SendTextMessageHandler(
            ISendWeCahtMsgIntegrationHandler _sendWeCahtMsgIntegrationHandler
        )
        {
            sendWeCahtMsgIntegrationHandler = _sendWeCahtMsgIntegrationHandler;
        }
        public async Task<string> Handle(TextMessage request, CancellationToken cancellationToken)
        {
           string s= await sendWeCahtMsgIntegrationHandler.SendMsg<TextMessage>(request);
            return s;
        }

         
    }
}
