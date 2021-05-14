using Abp.Application.Services.Dto;

namespace MyCompanyName.AbpZeroTemplate.Editions.Dto
{
    public class SubscribableEditionComboboxItemDto : ComboboxItemDto
    {
        public SubscribableEditionComboboxItemDto(string value, string displayText, bool? isFree) : base(value,
            displayText)
        {
            IsFree = isFree;
        }

        public bool? IsFree { get; set; }
    }
}