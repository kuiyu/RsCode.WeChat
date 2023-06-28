using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.CommonMessage.Handler
{
    internal class SendVoiceMessageHandler : IRequestHandler<VoiceMessage, string>
    {
        ISendWeCahtMsgIntegrationHandler sendWeCahtMsgIntegrationHandler;
        public SendVoiceMessageHandler(ISendWeCahtMsgIntegrationHandler _sendWeCahtMsgIntegrationHandler)
        {
            sendWeCahtMsgIntegrationHandler = _sendWeCahtMsgIntegrationHandler;
        }
        public async Task<string> Handle(VoiceMessage request, CancellationToken cancellationToken)
        {
            string s = await sendWeCahtMsgIntegrationHandler.SendMsg<VoiceMessage>(request);
            return s;
        }
    }
}
