using System.Collections.Generic;
using Abp.Dependency;
using MyCompanyName.AbpZeroTemplate.Authorization.Users.Importing.Dto;

namespace MyCompanyName.AbpZeroTemplate.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader : ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}