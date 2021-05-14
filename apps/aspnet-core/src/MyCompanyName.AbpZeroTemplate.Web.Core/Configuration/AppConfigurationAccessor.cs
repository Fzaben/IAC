using Abp.Dependency;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MyCompanyName.AbpZeroTemplate.Configuration;

namespace MyCompanyName.AbpZeroTemplate.Web.Configuration
{
    public class AppConfigurationAccessor : IAppConfigurationAccessor, ISingletonDependency
    {
        public AppConfigurationAccessor(IWebHostEnvironment env)
        {
            Configuration = env.GetAppConfiguration();
        }

        public IConfigurationRoot Configuration { get; }
    }
}