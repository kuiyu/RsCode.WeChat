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
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.WeChat.MP.QrCode
{
    /// <summary>
    /// 获取小程序二维码，适用于需要的码数量较少的业务场景。通过该接口生成的小程序码，永久有效，有数量限制
    /// </summary>
    public class CreateQRCodeRequest
    {
     

        /// <summary>
        /// 扫码进入的小程序页面路径，最大长度 128 字节，不能为空；对于小游戏，可以只传入 query 部分，来实现传参效果，如：传入 "?foo=bar"，即可在 wx.getLaunchOptionsSync 接口中的 query 参数获取到 {foo:"bar"}。
        /// </summary>
        [JsonPropertyName("path")]
        public string Path { get; set; }

       

        /// <summary>
        /// 二维码的宽度，单位 px，最小 280px，最大 1280px
        /// </summary>
        [JsonPropertyName("width")]
        public int Width { get; set; } = 430;

    }
}
