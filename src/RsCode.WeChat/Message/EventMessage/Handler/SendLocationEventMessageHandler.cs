using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.EventMessage.Handler
{
    class SendLocationEventMessageHandler : IRequestHandler<LocationEventMessage, string>
    {
        ISendWeCahtMsgIntegrationHandler integrationHandler;
        public SendLocationEventMessageHandler(ISendWeCahtMsgIntegrationHandler _integrationHandler)
        {
            integrationHandler = _integrationHandler;
        }
        public async Task<string> Handle(LocationEventMessage request, CancellationToken cancellationToken)
        {
            return await integrationHandler.SendMsg<LocationEventMessage>(request);
        }
    }
}
