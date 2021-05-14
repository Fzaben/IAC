using System;

namespace MyCompanyName.AbpZeroTemplate.Url
{
    public class NullAppUrlService : IAppUrlService
    {
        private NullAppUrlService()
        {
        }

        public static IAppUrlService Instance { get; } = new NullAppUrlService();

        public string CreateEmailActivationUrlFormat(int? tenantId)
        {
            throw new NotImplementedException();
        }

        public string CreatePasswordResetUrlFormat(int? tenantId)
        {
            throw new NotImplementedException();
        }

        public string CreateEmailActivationUrlFormat(string tenancyName)
        {
            throw new NotImplementedException();
        }

        public string CreatePasswordResetUrlFormat(string tenancyName)
        {
            throw new NotImplementedException();
        }
    }
}