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

namespace RsCode.WeChat.MP
{
    /// <summary>
    /// <see cref="https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/subscribe-message/subscribeMessage.send.html"/>
    /// </summary>
    public class MessageSendInfo
    {
        /// <summary>
        /// 事物 可汉字、数字、字母或符号组合
        /// </summary>
        [JsonPropertyName("thing.DATA")]
        public string Thing { get; set; }

        /// <summary>
        /// 数字
        /// </summary>
        [JsonPropertyName("number.DATA")]
        public string Number { get; set; }

        /// <summary>
        /// 字母
        /// </summary>
        [JsonPropertyName("letter.DATA")]
        public string Letter { get; set; }

        /// <summary>
        /// 符号
        /// </summary>
        [JsonPropertyName("symbol.DATA")]
        public string Symbol { get; set; }



        /// <summary>
        /// 字符串
        /// 可数字、字母或符号组合
        /// </summary>
        [JsonPropertyName("character_string.DATA")]
        public string CharacterString { get; set; }

        /// <summary>
        /// 时间
        /// 24小时制时间格式（支持+年月日），支持填时间段，两个时间点之间用“~”符号连接
        /// </summary>
        [JsonPropertyName("time.DATA")]
        public string Time { get; set; }

        /// <summary>
        /// 年月日格式（支持+24小时制时间），支持填时间段，两个时间点之间用“~”符号连接
        /// </summary>
        [JsonPropertyName("date.DATA")]
        public string Date { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [JsonPropertyName("amount.DATA")]
        public string Amount { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        [JsonPropertyName("phone_number.DATA")]
        public string Phone { get; set; }

        /// <summary>
        /// 车牌号码
        /// </summary>
        [JsonPropertyName("car_number.DATA")]
        public string CarNumber { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [JsonPropertyName("name.DATA")]
        public string Name { get; set; }

        /// <summary>
        /// 汉字
        /// </summary>
        [JsonPropertyName("phrase.DATA")]
        public string Phrase { get; set; }

        
        public MessageValue Value { get; set; }
    }

    public class MessageValue
    {
        public MessageValue()
        {

        }
        public MessageValue(string value)
        {
            Value = value;
        }
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
        
}
