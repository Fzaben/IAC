using System.Threading.Tasks;
using Abp.Application.Services;
using DevOps.Sessions.Dto;

namespace DevOps.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
