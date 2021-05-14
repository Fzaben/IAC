using Abp.Application.Services.Dto;

namespace MyCompanyName.AbpZeroTemplate.Dto
{
    public class PagedAndSortedInputDto : PagedInputDto, ISortedResultRequest
    {
        public PagedAndSortedInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }

        public string Sorting { get; set; }
    }
}