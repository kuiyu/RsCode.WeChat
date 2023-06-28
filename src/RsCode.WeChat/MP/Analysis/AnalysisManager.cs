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

namespace RsCode.WeChat.MP.Analysis
{
    /// <summary>
    /// 分析
    /// </summary>
    public class AnalysisManager
    {
        WxMpClient mpClient;
        public AnalysisManager(WxMpClient _mpClient)
        {
            mpClient = _mpClient;
        }

        #region 留存数据
        /// <summary>
        /// 获取用户访问小程序日留存
        /// </summary>
        /// <returns></returns>
        public async Task<RetainInfo> GetDailyRetain(string accessToken,DateTime startDate,DateTime endDate)
        {
            string url = $"https://api.weixin.qq.com/datacube/getweanalysisappiddailyretaininfo?access_token={accessToken}";
            string start_date = startDate.ToString("yyyyMMdd");
            string end_Date = endDate.ToString("yyyyMMdd");
            var param = new {
                access_token = accessToken,
                begin_date= start_date,
                end_date= end_Date
            };
            HttpContent content = new StringContent(JsonSerializer.Serialize(param));
            return await  mpClient.PostAsync<RetainInfo>(url, content);
        }

        /// <summary>
        /// 获取用户访问小程序月留存
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<RetainInfo> GetMonthlyRetain(string accessToken, DateTime startDate, DateTime endDate)
        {
            string url = $"https://api.weixin.qq.com/datacube/getweanalysisappidmonthlyretaininfo?access_token={accessToken}";
            string start_date = startDate.ToString("yyyyMMdd");
            string end_Date = endDate.ToString("yyyyMMdd");
            var param = new
            {
                access_token = accessToken,
                begin_date = start_date,
                end_date = end_Date
            };
            HttpContent content = new StringContent(JsonSerializer.Serialize(param));
            return await mpClient.PostAsync<RetainInfo>(url, content);
        }
        /// <summary>
        /// 获取用户访问小程序周留存
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<RetainInfo> GetWeeklyRetain(string accessToken, DateTime startDate, DateTime endDate)
        {
            string url = $"https://api.weixin.qq.com/datacube/getweanalysisappidweeklyretaininfo?access_token={accessToken}";
            string start_date = startDate.ToString("yyyyMMdd");
            string end_Date = endDate.ToString("yyyyMMdd");
            var param = new
            {
                access_token = accessToken,
                begin_date = start_date,
                end_date = end_Date
            };
            HttpContent content = new StringContent(JsonSerializer.Serialize(param));
            return await mpClient.PostAsync<RetainInfo>(url, content);
        }
        #endregion
    }
}
