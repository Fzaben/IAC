using Abp.Authorization;
using DevOps.Authorization.Roles;
using DevOps.Authorization.Users;

namespace DevOps.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
