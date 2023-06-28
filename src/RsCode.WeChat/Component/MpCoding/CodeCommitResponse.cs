/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */

using RsCode.WeChat.Message;
using System.Linq;

namespace RsCode.WeChat.Component
{
    /// <summary>
    /// 上传代码并生成体验版
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/miniprogram-management/code-management/commit.html"/>
    /// </summary>
    public class CodeCommitResponse:WeChatResponse
    {
        public override WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(-60005, "", ""));
            ResponseMessages.Add(new WeChatResponseMessage(-1, "system error", "系统繁忙，此时请开发者稍候再试"));
            ResponseMessages.Add(new WeChatResponseMessage(40001, "invalid credential  access_token isinvalid or not latest", "获取 access_token 时 AppSecret 错误，或者 access_token 无效。请开发者认真比对 AppSecret 的正确性，或查看是否正在为恰当的公众号调用接口"));
            ResponseMessages.Add(new WeChatResponseMessage(40014, "invalid access_token", "不合法的 access_token ，请开发者认真比对 access_token 的有效性（如是否过期），或查看是否正在为恰当的公众号调用接口"));
            ResponseMessages.Add(new WeChatResponseMessage(80082, "没有权限使用该插件", "没有权限使用该插件"));
            ResponseMessages.Add(new WeChatResponseMessage(9402203, "标准模板 extjson 错误", "标准模板ext_json错误，传了不合法的参数， 如果是标准模板库的模板，则ext_json支持的参数仅为{\"extAppid\":'', \"ext\": {}, \"window\": {}}"));
            ResponseMessages.Add(new WeChatResponseMessage(85013, "invalid ext_json, parse fail or containing invalid path", "无效的自定义配置"));
            ResponseMessages.Add(new WeChatResponseMessage(9402202, "concurrent limit", "请勿频繁提交，待上一次操作完成后再提交"));
            ResponseMessages.Add(new WeChatResponseMessage(85014, "template not exist", "无效的模板编号"));
            ResponseMessages.Add(new WeChatResponseMessage(85043, "invalid template, something wrong?", "模板错误"));
            ResponseMessages.Add(new WeChatResponseMessage(85044, "package exceed max limit", "代码包超过大小限制"));
            ResponseMessages.Add(new WeChatResponseMessage(85045, "some path in ext_json not exist", "ext_json 有不存在的路径"));
            ResponseMessages.Add(new WeChatResponseMessage(85046, "pagepath missing in tabbar list", "tabBar 中缺少 path"));
            ResponseMessages.Add(new WeChatResponseMessage(85047, "pages are empty", "pages 字段为空"));
            ResponseMessages.Add(new WeChatResponseMessage(85048, "parse ext_json fail", "ext_json 解析失败"));
            ResponseMessages.Add(new WeChatResponseMessage(80067, "找不到使用的插件", "找不到使用的插件"));
            ResponseMessages.Add(new WeChatResponseMessage(80066, "非法的插件版本", "非法的插件版本"));
            ResponseMessages.Add(new WeChatResponseMessage(85310, "is wrong API name", "requiredPrivateInfos 的格式有问题或者 api 名称写错了"));
            ResponseMessages.Add(new WeChatResponseMessage(85312, "is not authorized", "requiredPrivateInfos 配置了没有权限的api"));
            ResponseMessages.Add(new WeChatResponseMessage(85311, "is mutually exclusive", "requiredPrivateInfos包含了互斥的api"));

            return ResponseMessages.LastOrDefault(c => c.Code == Code);
        }
    }
}
