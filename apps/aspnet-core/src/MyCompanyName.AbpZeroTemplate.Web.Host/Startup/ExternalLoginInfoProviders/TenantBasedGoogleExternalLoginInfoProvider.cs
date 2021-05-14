﻿using System.Collections.Generic;
using Abp.AspNetZeroCore.Web.Authentication.External;
using Abp.AspNetZeroCore.Web.Authentication.External.Google;
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
    public class TenantBasedGoogleExternalLoginInfoProvider : TenantBasedExternalLoginInfoProviderBase,
        ISingletonDependency
    {
        private readonly IAbpSession _abpSession;
        private readonly ISettingManager _settingManager;

        public TenantBasedGoogleExternalLoginInfoProvider(
            ISettingManager settingManager,
            IAbpSession abpSession,
            ICacheManager cacheManager) : base(abpSession, cacheManager)
        {
            _settingManager = settingManager;
            _abpSession = abpSession;
        }

        public override string Name { get; } = GoogleAuthProviderApi.Name;

        private ExternalLoginProviderInfo CreateExternalLoginInfo(GoogleExternalLoginProviderSettings settings)
        {
            return new(
                GoogleAuthProviderApi.Name,
                settings.ClientId,
                settings.ClientSecret,
                typeof(GoogleAuthProviderApi),
                new Dictionary<string, string>
                {
                    {"UserInfoEndpoint", settings.UserInfoEndpoint}
                }
            );
        }

        protected override bool TenantHasSettings()
        {
            var settingValue = _settingManager.GetSettingValueForTenant(AppSettings.ExternalLoginProvider.Tenant.Google,
                _abpSession.TenantId.Value);
            return !settingValue.IsNullOrWhiteSpace();
        }

        protected override ExternalLoginProviderInfo GetTenantInformation()
        {
            var settingValue = _settingManager.GetSettingValueForTenant(AppSettings.ExternalLoginProvider.Tenant.Google,
                _abpSession.TenantId.Value);
            var settings = settingValue.FromJsonString<GoogleExternalLoginProviderSettings>();
            return CreateExternalLoginInfo(settings);
        }

        protected override ExternalLoginProviderInfo GetHostInformation()
        {
            var settingValue =
                _settingManager.GetSettingValueForApplication(AppSettings.ExternalLoginProvider.Host.Google);
            var settings = settingValue.FromJsonString<GoogleExternalLoginProviderSettings>();
            return CreateExternalLoginInfo(settings);
        }
    }
}