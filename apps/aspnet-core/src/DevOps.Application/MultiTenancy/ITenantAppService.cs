using Abp.Application.Services;
using DevOps.MultiTenancy.Dto;

namespace DevOps.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

