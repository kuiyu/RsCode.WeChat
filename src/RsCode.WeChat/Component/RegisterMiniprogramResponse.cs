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
    /// 快速注册企业小程序
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/register-management/fast-registration-ent/registerMiniprogram.html"/>
    /// </summary>
    public class RegisterMiniprogramResponse : WeChatResponse
    {

        /// <summary>
        /// 获取响应明细信息
        /// </summary>
        /// <returns></returns>
        public override WeChatResponseMessage GetResponseMessage()
        {
             
            ResponseMessages.Add(new WeChatResponseMessage(100001, "", "已下发的模板消息法人并未确认且已超时（24h），未进行身份证校验"));
            ResponseMessages.Add(new WeChatResponseMessage(100002, "", "已下发的模板消息法人并未确认且已超时（24h），未进行人脸识别校验"));
            ResponseMessages.Add(new WeChatResponseMessage(100003, "", "已下发的模板消息法人并未确认且已超时（24h）"));
            ResponseMessages.Add(new WeChatResponseMessage(101, "", "工商数据返回：“企业已注销”"));
            ResponseMessages.Add(new WeChatResponseMessage(102, "", "工商数据返回：“企业不存在或企业信息未更新”"));
            ResponseMessages.Add(new WeChatResponseMessage(103, "", "工商数据返回：“企业法定代表人姓名不一致”"));
            ResponseMessages.Add(new WeChatResponseMessage(104, "", "工商数据返回：“企业法定代表人身份证号码不一致”"));
            ResponseMessages.Add(new WeChatResponseMessage(105, "", "法定代表人身份证号码，工商数据未更新，请 5-15 个工作日之后尝试"));
            ResponseMessages.Add(new WeChatResponseMessage(1000, "", "工商数据返回：“企业信息或法定代表人信息不一致”"));
            ResponseMessages.Add(new WeChatResponseMessage(1001, "", "主体创建小程序数量达到上限"));
            ResponseMessages.Add(new WeChatResponseMessage(1002, "", "主体违规命中黑名单"));
            ResponseMessages.Add(new WeChatResponseMessage(1003, "", "管理员绑定账号数量达到上限"));
            ResponseMessages.Add(new WeChatResponseMessage(1004, "", "管理员违规命中黑名单"));
            ResponseMessages.Add(new WeChatResponseMessage(1005, "", "管理员手机绑定账号数量达到上限"));
            ResponseMessages.Add(new WeChatResponseMessage(1006, "", "管理员手机号违规命中黑名单"));
            ResponseMessages.Add(new WeChatResponseMessage(1007, "", "管理员身份证创建账号数量达到上限"));
            ResponseMessages.Add(new WeChatResponseMessage(1008, "", "管理员身份证违规命中黑名单"));
            ResponseMessages.Add(new WeChatResponseMessage(-1, "", "企业与法人姓名不一致"));

            ResponseMessages.Add(new WeChatResponseMessage(89249, "task running", "该 appid 已有转正任务执行中，距上次任务 24h 后再试"));
            ResponseMessages.Add(new WeChatResponseMessage(89247, "inner error  retry after some while", "系统内部错误"));
            ResponseMessages.Add(new WeChatResponseMessage(86004, "invalid wechat", "无效微信号"));
            ResponseMessages.Add(new WeChatResponseMessage(61070, "name  idcard  wechat name not in accordance", "法人姓名与微信号不一致"));
            ResponseMessages.Add(new WeChatResponseMessage(89248, "invalid code type", "企业代码类型无效，请选择正确类型填写"));
            ResponseMessages.Add(new WeChatResponseMessage(89250, "task not found", "未找到该任务"));
            ResponseMessages.Add(new WeChatResponseMessage(89251, "legal persona checking", "模板消息已下发，待法人人脸核身校验"));
            ResponseMessages.Add(new WeChatResponseMessage(89252, "front checking", "法人&企业信息一致性校验中"));
            ResponseMessages.Add(new WeChatResponseMessage(89253, "lack of some params", "缺少参数"));
            ResponseMessages.Add(new WeChatResponseMessage(89254, "lack of some component rights", "第三方权限集不全，请补充权限集后重试"));
            ResponseMessages.Add(new WeChatResponseMessage(89255, "enterprise code invalid", "code参数无效，请检查 code 长度以及内容是否正确；注意code_type的值不同需要传的 code 长度不一样"));
           

            return ResponseMessages.LastOrDefault(c=>c.Code==Code);
        }
    }
}
