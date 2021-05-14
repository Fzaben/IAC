using Abp.Dependency;
using Abp.Reflection.Extensions;
using Microsoft.Extensions.Configuration;
using MyCompanyName.AbpZeroTemplate.Configuration;

namespace MyCompanyName.AbpZeroTemplate.Test.Base
{
    public class TestAppConfigurationAccessor : IAppConfigurationAccessor, ISingletonDependency
    {
        public TestAppConfigurationAccessor()
        {
            Configuration = AppConfigurations.Get(
                typeof(AbpZeroTemplateTestBaseModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public IConfigurationRoot Configuration { get; }
    }
}