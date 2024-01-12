/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using System.Text.Json.Serialization;

namespace RsCode.WeChat
{
    public class WxQrCodeRequest:WeChatRequest
    {
        string AccessToken;
        /// <summary>
        /// 创建永久二维码
        /// </summary>
        /// <param name="wxQrCodeType"></param>
        /// <param name="sceneId"></param>
        public WxQrCodeRequest(string token,int sceneId)
        {
            ActionName = WxQrCodeType.QR_LIMIT_SCENE;
            ActionInfo = new ActionInfo { 
              Scene=new Scene { 
                SceneId=sceneId
              }
            };
            AccessToken = token;
        }
        /// <summary>
        /// 创建永久二维码
        /// </summary>
        /// <param name="wxQrCodeType"></param>
        /// <param name="sceneStr"></param>
        public WxQrCodeRequest(string token, string sceneStr)
        {
            ActionName = WxQrCodeType.QR_LIMIT_STR_SCENE;
            ActionInfo = new ActionInfo
            {
                Scene = new Scene
                {
                    SceneStr = sceneStr
                }
            };
            AccessToken = token;
        }

        /// <summary>
        /// 创建临时二维码
        /// </summary>
        /// <param name="wxQrCodeType"></param>
        /// <param name="sceneId"></param>
        /// <param name="expireSeconds"></param>
        public WxQrCodeRequest(string token, int sceneId,int expireSeconds)
        {
            ActionName = WxQrCodeType.QR_SCENE;
            ActionInfo = new ActionInfo
            {
                Scene = new Scene
                {
                    SceneId = sceneId
                }
            };
            if (expireSeconds < 1 || expireSeconds > 2592000) 
                expireSeconds = 300;

            ExpireSeconds = expireSeconds;
            AccessToken = token;
        }
        /// <summary>
        /// 创建临时二维码
        /// </summary>
        /// <param name="wxQrCodeType">WxQrCodeType定义的二维码类型</param>
        /// <param name="sceneStr">场景值ID（字符串形式的ID），字符串类型，长度限制为1到64</param>
        /// <param name="expireSeconds"></param>
        public WxQrCodeRequest(string token, string sceneStr,int expireSeconds)
        {
            ActionName = WxQrCodeType.QR_STR_SCENE;
            ActionInfo = new ActionInfo
            {
                Scene = new Scene
                {
                    SceneStr = sceneStr
                }
            };
            if (expireSeconds < 1 || expireSeconds > 2592000)
                expireSeconds = 300;
            ExpireSeconds = expireSeconds;
            AccessToken = token;
        }



        /// <summary>
        /// 二维码类型，
        /// QR_SCENE为临时的整型参数值，
        /// QR_STR_SCENE为临时的字符串参数值，
        /// QR_LIMIT_SCENE为永久的整型参数值，
        /// QR_LIMIT_STR_SCENE为永久的字符串参数值
        /// </summary>
        [JsonPropertyName("action_name")]
        public string ActionName { get; set; }
        /// <summary>
        /// 二维码详细信息
        /// </summary>
        [JsonPropertyName("action_info")]
        public ActionInfo ActionInfo { get; set; }
        /// <summary>
        /// 二维码过期时间，默认生成的是临时二维码，有效期30天
        /// 值为-1时生成永久二维码
        /// </summary>
       [JsonPropertyName("expire_seconds")] public int? ExpireSeconds { get; set; } = 2592000;

        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={AccessToken}";
        }
        public override string RequestMethod()
        {
            return "POST";
        }

    }

    public class ActionInfo
    {
        [JsonPropertyName("scene")]
        public Scene Scene { get; set; }
    }
    public class Scene
    {
        /// <summary>
        /// 场景值ID（字符串形式的ID），字符串类型，长度限制为1到64
        /// </summary>
        [JsonPropertyName("scene_str")]
        public string SceneStr { get; set; } = null;
        /// <summary>
        /// 场景值ID，临时二维码时为32位非0整型，永久二维码时最大值为100000（目前参数只支持1--100000）
        /// </summary>
        [JsonPropertyName("scene_id")]
        public int? SceneId { get; set; }
    }

    /// <summary>
    /// 二维码类型
    /// </summary>
     internal static class WxQrCodeType
    {
        /// <summary>
        /// 临时的整型参数值
        /// </summary>
        public static string QR_SCENE= "QR_SCENE";
        /// <summary>
        /// 临时的字符串参数值
        /// </summary>
        public static string QR_STR_SCENE = "QR_STR_SCENE";
        /// <summary>
        /// 永久的整型参数值
        /// </summary>
        public static string QR_LIMIT_SCENE = "QR_LIMIT_SCENE";
        /// <summary>
        /// 永久的字符串参数值
        /// </summary>
        public static string QR_LIMIT_STR_SCENE = "QR_LIMIT_STR_SCENE";
    }
     
}
