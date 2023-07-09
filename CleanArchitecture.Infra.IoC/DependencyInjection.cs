using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Validations;
using CleanArchitecture.Infra.Data.Context;
using CleanArchitecture.Infra.Data.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace CleanArchitecture.Infra.IoC
{
    public static class IoC
    {

        public static IServiceCollection AddInversionOfController(
                                    this IServiceCollection services,
                                    IConfiguration configuration)
        {
            DatabaseConfigurations(services, configuration);

            DependencyInjection(services);

            Mappers(services);

            return services;
        }

        /// <summary>
        /// Define AutoMappers
        /// </summary>
        /// <param name="services"></param>
        private static void Mappers(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));
        }

        /// <summary>
        /// Define Dependency Injections
        /// </summary>
        /// <param name="services"></param>
        private static void DependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IValidator<Product>, ProductValidator>();

            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IValidator<Supplier>, SupplierValidator>();
        }

        /// <summary>
        /// Configure Database an Run Initial Migration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        private static void DatabaseConfigurations(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                        );

            /// Run Migration on project start
            var serviceProvider = services.BuildServiceProvider();
            using (var dataContext = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext)))
            {
                if (dataContext.Database.GetPendingMigrations().Any())
                {
                    dataContext.Database.Migrate();
                }
            }
        }
    }
}
