using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.CommonMessage.Handler
{
    class SendLinkMessageHandler : IRequestHandler<LinkMessage, string>
    {
        ISendWeCahtMsgIntegrationHandler sendWeCahtMsgIntegrationHandler;
        public SendLinkMessageHandler(ISendWeCahtMsgIntegrationHandler _sendWeCahtMsgIntegrationHandler)
        {
            sendWeCahtMsgIntegrationHandler = _sendWeCahtMsgIntegrationHandler;
        }
        public async Task<string> Handle(LinkMessage request, CancellationToken cancellationToken)
        {
            string s = await sendWeCahtMsgIntegrationHandler.SendMsg<LinkMessage>(request);
            return s;
        }

       
    }
}
