/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RsCode.WeChat.MP.QrCode
{
   public class MpQrCodeManager
    {
        WxMpClient client;
        public MpQrCodeManager(WxMpClient wxMpClient)
        {
            client = wxMpClient;
        }

        /// <summary>
        /// 获取小程序二维码，适用于需要的码数量较少的业务场景。通过该接口生成的小程序码，永久有效，有数量限制
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateQrCodeAsync(string accessToken,CreateQRCodeRequest request)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/wxaapp/createwxaqrcode?access_token={accessToken}";
            HttpContent content = new StringContent(JsonSerializer.Serialize(request));
            return await client.PostAsync(url,content); 
        }

        /// <summary>
        /// 获取小程序码，适用于需要的码数量较少的业务场景。通过该接口生成的小程序码，永久有效，有数量限制
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAsync(string accessToken, WxaCodeRequest request)
        {
            string url = $"https://api.weixin.qq.com/wxa/getwxacode?access_token={accessToken}";
            HttpContent content = new StringContent(JsonSerializer.Serialize(request));
            return await client.PostAsync(url, content);
        }

        /// <summary>
        /// 获取小程序码，适用于需要的码数量极多的业务场景
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetUnlimitedAsync(string accessToken, GetUnlimitedRequest request)
        {
            string url = $"https://api.weixin.qq.com/wxa/getwxacodeunlimit?access_token={accessToken}";
            HttpContent content = new StringContent(JsonSerializer.Serialize(request));
            return  await client.PostAsync(url, content);
        }
    }
}
