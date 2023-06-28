using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.CommonMessage.Handler
{
    class SendVideoMessageHandler:IRequestHandler<VideoMessage,string>
    {
        ISendWeCahtMsgIntegrationHandler sendWeCahtMsgIntegrationHandler;
        public SendVideoMessageHandler(ISendWeCahtMsgIntegrationHandler _sendWeCahtMsgIntegrationHandler)
        {
            sendWeCahtMsgIntegrationHandler = _sendWeCahtMsgIntegrationHandler;
        }

        public async Task<string> Handle(VideoMessage request, CancellationToken cancellationToken)
        {
            string s = await sendWeCahtMsgIntegrationHandler.SendMsg<VideoMessage>(request);
            return s;
        }
    }
}
