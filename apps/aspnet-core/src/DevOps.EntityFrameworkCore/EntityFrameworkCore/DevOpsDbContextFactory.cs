using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using DevOps.Configuration;
using DevOps.Web;

namespace DevOps.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class DevOpsDbContextFactory : IDesignTimeDbContextFactory<DevOpsDbContext>
    {
        public DevOpsDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DevOpsDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DevOpsDbContextConfigurer.Configure(builder, configuration.GetConnectionString(DevOpsConsts.ConnectionStringName));

            return new DevOpsDbContext(builder.Options);
        }
    }
}
