/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RsCode.WeChat.MP
{
    /// <summary>
    /// 把媒体文件上传到微信服务器。目前仅支持图片。用于发送客服消息或被动回复用户消息。
    /// <see cref="https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/customer-message/customerServiceMessage.uploadTempMedia.html"/>
    /// </summary>
    public class UploadTempMediaReqeust : WeChatRequest
    {
        public UploadTempMediaReqeust(string accessToken, IFormFile formFile, string type = "image")
        {
            AccessToken = accessToken;
            Type = type;
            FormFile = formFile;
        }
         

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary> 
        [JsonPropertyName("type")]
        public string Type { get; set; }

       IFormFile FormFile { get; set; }
        //MultipartFormDataContent FormData { get; set; }
        // public IFormFile FormData { get; set; }

         

        public override string RequestMethod()
        {
            return "POST";
        }

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/media/upload?access_token={AccessToken}&type={Type}";
        }

        public override MultipartFormDataContent RequestForm()
        {
            var formFile = FormFile;

            using (var stream = formFile.OpenReadStream())
            {
                var formData = new MultipartFormDataContent();
                formData.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                var content = new byte[stream.Length];
                stream.Read(content, 0, content.Length);
                var byteArrayContent = new ByteArrayContent(content);
                string fileName = System.Web.HttpUtility.UrlEncode(formFile.FileName);
                formData.Add(byteArrayContent, "\"media\"", "\"" + fileName + "\"");

                return formData;
            } 
        } 
    }

    public class MetaInfo
    {
        [JsonPropertyName("filename")]
        public string FileName { get; set; }
        [JsonPropertyName("sha256")]
        public string Sha256 { get; set; }
    }
      
}
