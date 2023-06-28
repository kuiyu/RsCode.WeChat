using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.CommonMessage.Handler
{
    class SendImageMessageHandler : IRequestHandler<ImageMessage, string>
    {
        ISendWeCahtMsgIntegrationHandler sendWeCahtMsgIntegrationHandler;
        public SendImageMessageHandler(ISendWeCahtMsgIntegrationHandler _sendWeCahtMsgIntegrationHandler)
        { sendWeCahtMsgIntegrationHandler = _sendWeCahtMsgIntegrationHandler; }
        public async Task<string> Handle(ImageMessage request, CancellationToken cancellationToken)
        {
            string s = await sendWeCahtMsgIntegrationHandler.SendMsg<ImageMessage>(request);
            return s;
        }
    }
}
