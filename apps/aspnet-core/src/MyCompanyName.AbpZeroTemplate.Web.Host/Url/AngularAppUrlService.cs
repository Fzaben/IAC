using Abp.MultiTenancy;
using MyCompanyName.AbpZeroTemplate.Url;

namespace MyCompanyName.AbpZeroTemplate.Web.Url
{
    public class AngularAppUrlService : AppUrlServiceBase
    {
        public AngularAppUrlService(
            IWebUrlService webUrlService,
            ITenantCache tenantCache
        ) : base(
            webUrlService,
            tenantCache
        )
        {
        }

        public override string EmailActivationRoute => "account/confirm-email";

        public override string PasswordResetRoute => "account/reset-password";
    }
}