/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 获取草稿箱列表
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/thirdparty-management/template-management/getTemplatedRaftList.html"/>
    /// </summary>
    public class GetTemplatedRaftListRequest : WeChatRequest
    {
        public GetTemplatedRaftListRequest(string componentAccessToken)
        {
            ComponentAccessToken= componentAccessToken;
        }
        string ComponentAccessToken = "";

      
        public override string GetApiUrl()
        {
            return $"https://api.weixin.qq.com/wxa/gettemplatedraftlist?access_token={ComponentAccessToken}";
        }

        public override string RequestMethod()
        {
            return "GET";
        }
    }
}
