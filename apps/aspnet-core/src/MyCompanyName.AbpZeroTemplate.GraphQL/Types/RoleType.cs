using GraphQL.Types;
using MyCompanyName.AbpZeroTemplate.Dto;

namespace MyCompanyName.AbpZeroTemplate.Types
{
    public class RoleType : ObjectGraphType<RoleDto>
    {
        public RoleType()
        {
            Name = "RoleType";

            Field(x => x.Id);
            Field(x => x.IsDefault);
            Field(x => x.IsStatic);
            Field(x => x.Name);
            Field(x => x.DisplayName);
            Field(x => x.CreationTime);
            Field(x => x.CreatorUserId, true);
            Field(x => x.LastModificationTime, true);
            Field(x => x.LastModifierUserId, true);
            Field(x => x.TenantId, true);
        }
    }
}