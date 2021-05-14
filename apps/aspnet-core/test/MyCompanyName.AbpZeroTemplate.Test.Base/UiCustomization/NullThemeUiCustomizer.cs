using System;
using System.Threading.Tasks;
using Abp;
using MyCompanyName.AbpZeroTemplate.Configuration.Dto;
using MyCompanyName.AbpZeroTemplate.UiCustomization;
using MyCompanyName.AbpZeroTemplate.UiCustomization.Dto;

namespace MyCompanyName.AbpZeroTemplate.Test.Base.UiCustomization
{
    public class NullThemeUiCustomizer : IUiCustomizer
    {
        public Task<UiCustomizationSettingsDto> GetUiSettings()
        {
            return Task.FromResult(new UiCustomizationSettingsDto());
        }

        public Task UpdateUserUiManagementSettingsAsync(UserIdentifier user, ThemeSettingsDto settings)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTenantUiManagementSettingsAsync(int tenantId, ThemeSettingsDto settings)
        {
            throw new NotImplementedException();
        }

        public Task UpdateApplicationUiManagementSettingsAsync(ThemeSettingsDto settings)
        {
            throw new NotImplementedException();
        }

        public Task<ThemeSettingsDto> GetHostUiManagementSettings()
        {
            throw new NotImplementedException();
        }

        public Task<ThemeSettingsDto> GetTenantUiCustomizationSettings(int tenantId)
        {
            throw new NotImplementedException();
        }
    }
}