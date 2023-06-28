using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.EventMessage.Handler
{
    class SendUnSubscribeEventMessageHandler : IRequestHandler<SubscribeEventMessage, string>
    {
        ISendWeCahtMsgIntegrationHandler integrationHandler;
        public SendUnSubscribeEventMessageHandler(ISendWeCahtMsgIntegrationHandler _integrationHandler)
        {
            integrationHandler = _integrationHandler;
        }
        public async Task<string> Handle(SubscribeEventMessage request, CancellationToken cancellationToken)
        {
            return await integrationHandler.SendMsg<SubscribeEventMessage>(request);
        }
    }
}
