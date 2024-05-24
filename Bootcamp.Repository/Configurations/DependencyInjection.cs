using Bootcamp.Repository.Categories;
using Bootcamp.Repository.Products;
using Bootcamp.Service;
using Bootcamp.Service.Categories;
using Bootcamp.Service.Products;
using Microsoft.Extensions.DependencyInjection;

namespace Bootcamp.Repository.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
