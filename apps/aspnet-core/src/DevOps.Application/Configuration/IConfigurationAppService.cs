using System.Threading.Tasks;
using DevOps.Configuration.Dto;

namespace DevOps.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
