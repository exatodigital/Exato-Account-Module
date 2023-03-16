using ExatoDigital.OpenSource.AccountModule.Domain;
using ExatoDigital.OpenSource.AccountModule.Repository.PostgreSql.Repositories;
using ExatoDigital.OpenSource.AccountModule.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Core
{
    public static class ServiceCollectionExtensions
    {
        public static void ExatoAccountModule(this IServiceCollection services)
        {
            services.AddScoped<IAccountModuleFacade, AccountModuleFacade>();
            services.AddScoped<IAccountModuleRepository, AccountModuleRepository>();
            services.AddScoped<IAccountModuleRepositoryFactory, AccountModuleRepositoryFactory>();
        }
    }
}
