using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using DevOps.Configuration.Dto;

namespace DevOps.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : DevOpsAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
