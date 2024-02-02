using DemoCICD.Infrastructure.Dapper.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using DemoCICD.Domain.Abstractions.Dappers.Repositories.Product;


namespace DemoCICD.Infrastructure.Dapper.DependencyInjections.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureDapper(this IServiceCollection services)
        => services.AddTransient<IProductRepository, ProductRepository>()
            .AddTransient<DemoCICD.Domain.Abstractions.Dappers.IUnitOfWork, UnitOfWork>();
    }
}
