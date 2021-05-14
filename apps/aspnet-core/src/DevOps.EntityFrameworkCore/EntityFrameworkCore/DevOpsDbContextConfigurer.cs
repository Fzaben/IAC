using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace DevOps.EntityFrameworkCore
{
    public static class DevOpsDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<DevOpsDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<DevOpsDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
