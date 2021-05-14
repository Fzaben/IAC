using Abp.Dependency;
using Microsoft.Extensions.Configuration;
using MyCompanyName.AbpZeroTemplate.Configuration;

namespace MyCompanyName.AbpZeroTemplate.Net.Sms
{
    public class TwilioSmsSenderConfiguration : ITransientDependency
    {
        private readonly IConfigurationRoot _appConfiguration;

        public TwilioSmsSenderConfiguration(IAppConfigurationAccessor configurationAccessor)
        {
            _appConfiguration = configurationAccessor.Configuration;
        }

        public string AccountSid => _appConfiguration["Twilio:AccountSid"];

        public string AuthToken => _appConfiguration["Twilio:AuthToken"];

        public string SenderNumber => _appConfiguration["Twilio:SenderNumber"];
    }
}