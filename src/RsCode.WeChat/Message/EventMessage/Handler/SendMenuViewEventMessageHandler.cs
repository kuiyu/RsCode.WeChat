using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.EventMessage.Handler
{
    class SendMenuViewEventMessageHandler : IRequestHandler<MenuViewEventMessage, string>
    {
        ISendWeCahtMsgIntegrationHandler integrationHandler;
        public SendMenuViewEventMessageHandler(ISendWeCahtMsgIntegrationHandler _integrationHandler)
        {
            integrationHandler = _integrationHandler;
        }
        public async Task<string> Handle(MenuViewEventMessage request, CancellationToken cancellationToken)
        {
            return await integrationHandler.SendMsg<MenuViewEventMessage>(request);
        }
    }
}
