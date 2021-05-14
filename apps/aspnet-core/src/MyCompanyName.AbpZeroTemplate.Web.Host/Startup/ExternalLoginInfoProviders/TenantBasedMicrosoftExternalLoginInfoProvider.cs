﻿using Abp.AspNetZeroCore.Web.Authentication.External;
using Abp.AspNetZeroCore.Web.Authentication.External.Microsoft;
using Abp.Configuration;
using Abp.Dependency;
using Abp.Extensions;
using Abp.Json;
using Abp.Runtime.Caching;
using Abp.Runtime.Session;
using MyCompanyName.AbpZeroTemplate.Authentication;
using MyCompanyName.AbpZeroTemplate.Configuration;

namespace MyCompanyName.AbpZeroTemplate.Web.Startup.ExternalLoginInfoProviders
{
    public class TenantBasedMicrosoftExternalLoginInfoProvider : TenantBasedExternalLoginInfoProviderBase,
        ISingletonDependency
    {
        private readonly IAbpSession _abpSession;
        private readonly ISettingManager _settingManager;

        public TenantBasedMicrosoftExternalLoginInfoProvider(
            ISettingManager settingManager,
            IAbpSession abpSession,
            ICacheManager cacheManager) : base(abpSession, cacheManager)
        {
            _settingManager = settingManager;
            _abpSession = abpSession;
        }

        public override string Name { get; } = MicrosoftAuthProviderApi.Name;

        private ExternalLoginProviderInfo CreateExternalLoginInfo(MicrosoftExternalLoginProviderSettings settings)
        {
            return new(
                MicrosoftAuthProviderApi.Name,
                settings.ClientId,
                settings.ClientSecret,
                typeof(MicrosoftAuthProviderApi)
            );
        }

        protected override bool TenantHasSettings()
        {
            var settingValue =
                _settingManager.GetSettingValueForTenant(AppSettings.ExternalLoginProvider.Tenant.Microsoft,
                    _abpSession.TenantId.Value);
            return !settingValue.IsNullOrWhiteSpace();
        }

        protected override ExternalLoginProviderInfo GetTenantInformation()
        {
            var settingValue =
                _settingManager.GetSettingValueForTenant(AppSettings.ExternalLoginProvider.Tenant.Microsoft,
                    _abpSession.TenantId.Value);
            var settings = settingValue.FromJsonString<MicrosoftExternalLoginProviderSettings>();
            return CreateExternalLoginInfo(settings);
        }

        protected override ExternalLoginProviderInfo GetHostInformation()
        {
            var settingValue =
                _settingManager.GetSettingValueForApplication(AppSettings.ExternalLoginProvider.Host.Microsoft);
            var settings = settingValue.FromJsonString<MicrosoftExternalLoginProviderSettings>();
            return CreateExternalLoginInfo(settings);
        }
    }
}