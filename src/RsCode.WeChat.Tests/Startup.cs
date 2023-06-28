using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RsCode.WeChat.Tests
{
    public class Startup
    {
        public void ConfigureHost(IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddWeChat(options =>
                {
                   context.Configuration.GetSection("Tencent.WeChat").Bind(options);
                });
            });
        }
    }
}
