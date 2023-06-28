using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace RsCode.WeChat.Message.EventMessage.Handler
{
     class SendSubscribeEventMessageHandler : IRequestHandler<SubscribeEventMessage, string>
    {
        ISendWeCahtMsgIntegrationHandler integrationHandler;
        public SendSubscribeEventMessageHandler(ISendWeCahtMsgIntegrationHandler _integrationHandler)
        {
            integrationHandler = _integrationHandler;
        }
        /// <summary>
        /// 用户未关注时，进行关注后的事件推送
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> Handle(SubscribeEventMessage request, CancellationToken cancellationToken)
        {
             
            return await integrationHandler.SendMsg<SubscribeEventMessage>(request);
        }
    }
}
