using Microsoft.EntityFrameworkCore;
using RepositoriesLayer.Contracts;
using RepositoriesLayer.EFCore;
using ServicesLayer;
using ServicesLayer.Contracts;

namespace Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
                options
                .UseSqlServer(configuration.GetConnectionString("sqlConnection"))
            );
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager,RepositoryManager>();

        public static void ConfigureServicesManager(this IServiceCollection services) =>
            services.AddScoped<IServicesManager, ServiceManager>();

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IProductServices, ProductManager>();
            services.AddScoped<ICategoryServices, CategoryManager>();
        }
    }
}
