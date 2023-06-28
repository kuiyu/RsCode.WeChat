/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using RsCode.WeChat.MP.CustomerMessage;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace RsCode.WeChat.MP.Message
{
    public class MpMessageManager
    {
        JsonSerializerOptions jsOption;

        WxMpClient wxMpClient;
        public MpMessageManager(WxMpClient _wxMpClient)
        {
            wxMpClient = _wxMpClient;
            jsOption = new JsonSerializerOptions();
            jsOption.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
        }

        /// <summary>
        /// 获取客服消息内的临时素材。即下载临时的多媒体文件。目前小程序仅支持下载图片文件
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetTempMediaResponse>GetTempMediaAsync(GetTempMediaRequest request)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/media/get?access_token={request.AccessToken}&media_id={request.MediaId}";
            return await wxMpClient.GetAsync<GetTempMediaResponse>(url);
        }

        /// <summary>
        /// 发送客服消息给用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<SendResponse> SendAsync(SendTextRequest request)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={request.AccessToken}";
            return await wxMpClient.PostAsync<SendResponse>(url, new StringContent(JsonSerializer.Serialize(request,jsOption)));
        }

        public async Task<SendResponse> SendAsync(SendImageRequest request)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={request.AccessToken}";
            return await wxMpClient.PostAsync<SendResponse>(url, new StringContent(JsonSerializer.Serialize(request,jsOption)));
        }

        public async Task<SendResponse> SendAsync(SendLinkRequest request)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={request.AccessToken}";
            return await wxMpClient.PostAsync<SendResponse>(url, new StringContent(JsonSerializer.Serialize(request,jsOption)));
        }

        public async Task<SendResponse> SendAsync(SendMiniProgramPageRequest request)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={request.AccessToken}";
            return await wxMpClient.PostAsync<SendResponse>(url, new StringContent(JsonSerializer.Serialize(request,jsOption)));
        }

        /// <summary>
        /// 下发客服当前输入状态给用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<SetTypingResponse> SetTyping(SetTypingRequest request)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/message/custom/typing?access_token={request.AccessToken}";
            return await wxMpClient.PostAsync<SetTypingResponse>(url, new StringContent(JsonSerializer.Serialize(request,jsOption)));
        }

        /// <summary>
        /// 把媒体文件上传到微信服务器。目前仅支持图片。用于发送客服消息或被动回复用户消息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UploadTempMediaResponse> UploadTempMediaAsync(UploadTempMediaReqeust request)
        {
            string url = $"https://api.weixin.qq.com/cgi-bin/media/upload?access_token={request.AccessToken}&type={request.Type}";
            return await wxMpClient.PostAsync<UploadTempMediaResponse>(url, new StringContent(JsonSerializer.Serialize(request,jsOption)));
        }
    }
}
