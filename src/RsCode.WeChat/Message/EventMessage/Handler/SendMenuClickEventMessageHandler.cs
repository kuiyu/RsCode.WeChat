using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.EventMessage.Handler
{
    public class SendMenuClickEventMessageHandler : IRequestHandler<MenuClickEventMessage, string>
    {
        ISendWeCahtMsgIntegrationHandler integrationHandler;
        public SendMenuClickEventMessageHandler(ISendWeCahtMsgIntegrationHandler _integrationHandler)
        {
            integrationHandler = _integrationHandler;
        }
        public async Task<string> Handle(MenuClickEventMessage request, CancellationToken cancellationToken)
        {
            return await integrationHandler.SendMsg<MenuClickEventMessage>(request);
        }
    }
}
