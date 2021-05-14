using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DevOps.EntityFrameworkCore;
using DevOps.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace DevOps.Web.Tests
{
    [DependsOn(
        typeof(DevOpsWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class DevOpsWebTestModule : AbpModule
    {
        public DevOpsWebTestModule(DevOpsEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DevOpsWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(DevOpsWebMvcModule).Assembly);
        }
    }
}