using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DevOps.Authorization;

namespace DevOps
{
    [DependsOn(
        typeof(DevOpsCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class DevOpsApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<DevOpsAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(DevOpsApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
