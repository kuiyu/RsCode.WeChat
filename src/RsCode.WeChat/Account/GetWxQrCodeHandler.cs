/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RsCode.WeChat.Account
{
    class GetWxQrCodeHandler : IRequestHandler<GetWxQrCode, WxQrCodeResponse>
    {
        HttpClient httpClient;
        ILogger logger;
        public GetWxQrCodeHandler(HttpClient _httpClient,ILogger<GetWxQrCodeHandler> _logger)
        {
            httpClient = _httpClient;
            logger = _logger;
        }
        public async Task<WxQrCodeResponse> Handle(GetWxQrCode request, CancellationToken cancellationToken)
        {
            return await CreateQrCodeAsync(request.AccessToken, request.WxQrCodeRequest);
        }
        /// <summary>
        /// 创建二维码信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<WxQrCodeResponse> CreateQrCodeAsync(string access_token, WxQrCodeRequest request)
        {
            try
            {
                logger.LogDebug("start create qrcode");
                string strApiUrl = string.Format("https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}", access_token);

                string postData = JsonSerializer.Serialize(request);
                using (StringContent content = new StringContent(postData))
                {
                    var response = await httpClient.PostAsync(strApiUrl, content);
                    string strResponseText = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<WxQrCodeResponse>(strResponseText);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return null;
            }

        }
    }
}
