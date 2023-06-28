using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.EventMessage.Handler
{
    class SendScanEventMessageHandler : IRequestHandler<ScanEventMessage, string>
    {
        ISendWeCahtMsgIntegrationHandler integrationHandler;
        public SendScanEventMessageHandler(ISendWeCahtMsgIntegrationHandler _integrationHandler)
        {
            integrationHandler = _integrationHandler;
        }
        public async Task<string> Handle(ScanEventMessage request, CancellationToken cancellationToken)
        {
            return await integrationHandler.SendMsg<ScanEventMessage>(request);
        }
    }
}
