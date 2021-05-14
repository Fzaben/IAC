using System.Threading.Tasks;
using Abp.Application.Services;
using DevOps.Authorization.Accounts.Dto;

namespace DevOps.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
