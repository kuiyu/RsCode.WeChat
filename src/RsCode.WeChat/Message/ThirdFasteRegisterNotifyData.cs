/*
 * 项目：微信API sdk
 * 描述：微信API 开发工具包
 * 作者：河南软商网络科技有限公司
 * github:https://github.com/kuiyu/RsCode.WeChat.git
 * gitee: https://gitee.com/kuiyu/RsCode.WeChat.git
 * 
 */
using RsCode.WeChat.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace RsCode.WeChat.Message
{
    /// <summary>
    /// 注册审核事件推送数据
    /// <see cref="https://developers.weixin.qq.com/doc/oplatform/openApi/OpenApiDoc/register-management/fast-registration-ent/registerMiniprogram.html#"/>
    /// </summary>
    public class ThirdFasteRegisterNotifyData:WeChatMessage
    {
        /// <summary>
        /// 第三方平台 appid
        /// </summary>
        [XmlElement("AppId")]
        public string AppId { get; set; } = "";
        /// <summary>
        /// 时间戳，单位：s
        /// </summary>
        [XmlElement("CreateTime")]
        public long CreateTime { get; set; }
        /// <summary>
        /// 固定为："notify_third_fasteregister"
        /// </summary>
        [XmlElement("InfoType")]public string InfoType { get; set; } = "";
        /// <summary>
        ///创建小程序appid
        /// </summary>
        [XmlElement("appid")]
        public string appid { get; set; }
        [XmlElement("status")]
        public int status { get; set; }
        [XmlElement("auth_code")]
        public string auth_code { get; set; }
        [XmlElement("msg")]
        public string msg { get; set; }
        [XmlElement("info")]
        public MpRegisterInfo RegisterInfo { get; set; }


        protected SortedDictionary<string, object> m_values = new SortedDictionary<string, object>();
        public SortedDictionary<string, object> FromXml(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                //Log.Error(this.GetType().ToString(), "将空的xml串转换为WxPayData不合法!");
                throw new Exception("将空的xml串转换为WxPayData不合法!");
            }


            SafeXmlDocument xmlDoc = new SafeXmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNode xmlNode = xmlDoc.FirstChild;//获取到根节点<xml>
            XmlNodeList nodes = xmlNode.ChildNodes;
            foreach (XmlNode xn in nodes)
            {
                XmlElement xe = (XmlElement)xn;
                m_values[xe.Name] = xe.InnerText;//获取xml的键值对到WxPayData内部的数据中 
            }


            return m_values;
        }

        public void LoadData(string data, DataTransferFormatter dataTransferFormatter)
        {
            if (dataTransferFormatter == DataTransferFormatter.XML)
            {
                this.FromXml(data);
                AppId = GetValue("AppId")?.ToString();
                CreateTime = GetValue("CreateTime") == null ? 0 : Convert.ToInt64(GetValue("CreateTime"));
                InfoType = GetValue("InfoType")?.ToString();

                string info = GetValue("info")?.ToString();
                this.RegisterInfo = new MpRegisterInfo();
                this.RegisterInfo.Name = GetValue("name")?.ToString();
                this.RegisterInfo.Code = GetValue("code")?.ToString();
                this.RegisterInfo.CodeType = GetValue("code_type")?.ToString();
                this.RegisterInfo.LegalPersonalWechat = GetValue("legal_persona_wechat")?.ToString();
                this.RegisterInfo.LegalPersonalName = GetValue("legal_persona_name")?.ToString();
                this.RegisterInfo.ComponentPhone = GetValue("component_phone")?.ToString();
            }
            else
            {
                JsonSerializer.Deserialize<ThirdPlatformMessage>(data);
            }
        }

        internal List<WeChatResponseMessage> ResponseMessages { get; set; } = new List<WeChatResponseMessage>();
        public WeChatResponseMessage GetResponseMessage()
        {
            ResponseMessages.Add(new WeChatResponseMessage(0, "审核通过", "审核通过"));
            ResponseMessages.Add(new WeChatResponseMessage(-1, "企业与法人姓名不一致", "企业与法人姓名不一致"));


            ResponseMessages.Add(new WeChatResponseMessage(100001, "已下发的模板消息法人并未确认且已超时（24h），未进行身份证校验", "已下发的模板消息法人并未确认且已超时（24h），未进行身份证校验"));
            ResponseMessages.Add(new WeChatResponseMessage(100002, "已下发的模板消息法人并未确认且已超时（24h），未进行人脸识别校验", "已下发的模板消息法人并未确认且已超时（24h），未进行人脸识别校验"));
            ResponseMessages.Add(new WeChatResponseMessage(100003, "已下发的模板消息法人并未确认且已超时（24h）", "已下发的模板消息法人并未确认且已超时（24h）"));

            ResponseMessages.Add(new WeChatResponseMessage(101, "工商数据返回：“企业已注销”", "工商数据返回：“企业已注销”"));
            ResponseMessages.Add(new WeChatResponseMessage(102, "工商数据返回：“企业不存在或企业信息未更新”", "工商数据返回：“企业不存在或企业信息未更新”"));
            ResponseMessages.Add(new WeChatResponseMessage(103, "工商数据返回：“企业法定代表人姓名不一致”", "工商数据返回：“企业法定代表人姓名不一致”"));
            ResponseMessages.Add(new WeChatResponseMessage(104, "工商数据返回：“企业法定代表人身份证号码不一致”", "工商数据返回：“企业法定代表人身份证号码不一致”"));
            ResponseMessages.Add(new WeChatResponseMessage(105, "法定代表人身份证号码，工商数据未更新，请 5-15 个工作日之后尝试", "法定代表人身份证号码，工商数据未更新，请 5-15 个工作日之后尝试"));

            ResponseMessages.Add(new WeChatResponseMessage(1000, "工商数据返回：“企业信息或法定代表人信息不一致”", "工商数据返回：“企业信息或法定代表人信息不一致”"));
            ResponseMessages.Add(new WeChatResponseMessage(1001, "主体创建小程序数量达到上限", "主体创建小程序数量达到上限”"));
            ResponseMessages.Add(new WeChatResponseMessage(1002, "主体违规命中黑名单", "主体违规命中黑名单"));
            ResponseMessages.Add(new WeChatResponseMessage(1003, "管理员绑定账号数量达到上限", "管理员绑定账号数量达到上限"));
            ResponseMessages.Add(new WeChatResponseMessage(1004, "管理员违规命中黑名单", "管理员违规命中黑名单"));
            ResponseMessages.Add(new WeChatResponseMessage(1005, "管理员手机绑定账号数量达到上限", "管理员手机绑定账号数量达到上限"));
            ResponseMessages.Add(new WeChatResponseMessage(1006, "管理员手机号违规命中黑名单", "管理员手机号违规命中黑名单"));
            ResponseMessages.Add(new WeChatResponseMessage(1007, "管理员身份证创建账号数量达到上限", "管理员身份证创建账号数量达到上限"));
            ResponseMessages.Add(new WeChatResponseMessage(1008, "管理员身份证违规命中黑名单", "管理员身份证违规命中黑名单"));

            int code = status;
            var resMessage = ResponseMessages.LastOrDefault(c => c.Code == code);
            if (resMessage == null)
            {
                resMessage = new WeChatResponseMessage(code, "未定义的错误", "未定义的错误");
            }
            return resMessage;
        }
    }

    public class MpRegisterInfo
    {
        /// <summary>
        /// 企业名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
        /// <summary>
        /// 企业代码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }
        [XmlElement("code_type")]
        public string CodeType { get; set; }
        [XmlElement("legal_persona_wechat")]
        public string LegalPersonalWechat { get; set; }
        [XmlElement("legal_persona_name")]
        public string LegalPersonalName { get; set; }
        [XmlElement("component_phone")]
        public string ComponentPhone { get; set; }
    }
}
