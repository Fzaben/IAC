using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace DevOps.Controllers
{
    public abstract class DevOpsControllerBase: AbpController
    {
        protected DevOpsControllerBase()
        {
            LocalizationSourceName = DevOpsConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
