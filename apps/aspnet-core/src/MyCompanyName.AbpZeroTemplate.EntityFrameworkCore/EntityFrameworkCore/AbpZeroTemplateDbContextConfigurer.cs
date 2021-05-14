using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyCompanyName.AbpZeroTemplate.EntityFrameworkCore
{
    public static class AbpZeroTemplateDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AbpZeroTemplateDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AbpZeroTemplateDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}