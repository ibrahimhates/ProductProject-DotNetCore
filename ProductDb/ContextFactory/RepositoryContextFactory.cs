using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using RepositoriesLayer.EFCore;

namespace Api.ContextFactory
{
    public class RepositoryContextFactory
    : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            // configurationBuilder
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // DbContextOptionsBuilder
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                prj => prj.MigrationsAssembly("Api"));

            return new RepositoryContext(builder.Options);
        }
    }
}
