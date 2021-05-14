using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DevOps.Configuration;

namespace DevOps.Web.Host.Startup
{
    [DependsOn(
       typeof(DevOpsWebCoreModule))]
    public class DevOpsWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public DevOpsWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DevOpsWebHostModule).GetAssembly());
        }
    }
}
