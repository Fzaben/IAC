using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.Editions.Dto
{
    public class MoveTenantsToAnotherEditionDto
    {
        [Range(1, int.MaxValue)] public int SourceEditionId { get; set; }

        [Range(1, int.MaxValue)] public int TargetEditionId { get; set; }
    }
}