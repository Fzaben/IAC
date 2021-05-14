using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using DevOps.Authorization.Roles;
using DevOps.Authorization.Users;
using DevOps.MultiTenancy;

namespace DevOps.EntityFrameworkCore
{
    public class DevOpsDbContext : AbpZeroDbContext<Tenant, Role, User, DevOpsDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public DevOpsDbContext(DbContextOptions<DevOpsDbContext> options)
            : base(options)
        {
        }
    }
}
