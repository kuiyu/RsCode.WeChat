using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.CommonMessage.Handler
{
    class SendShortVideoMessageHandler:IRequestHandler<ShortVideoMessage,string>
    {
        ISendWeCahtMsgIntegrationHandler sendWeCahtMsgIntegrationHandler;
        public SendShortVideoMessageHandler(ISendWeCahtMsgIntegrationHandler _sendWeCahtMsgIntegrationHandler)
        {
            sendWeCahtMsgIntegrationHandler = _sendWeCahtMsgIntegrationHandler;
        }

        public async Task<string> Handle(ShortVideoMessage request, CancellationToken cancellationToken)
        {
            string s = await sendWeCahtMsgIntegrationHandler.SendMsg<ShortVideoMessage>(request);
            return s;
        }
    }
}
