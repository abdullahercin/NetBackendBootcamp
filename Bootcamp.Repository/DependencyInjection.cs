using Bootcamp.Repository.Categories;
using Bootcamp.Repository.Products;
using Bootcamp.Service;
using Bootcamp.Service.Categories;
using Bootcamp.Service.Products;
using Microsoft.Extensions.DependencyInjection;

namespace Bootcamp.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
