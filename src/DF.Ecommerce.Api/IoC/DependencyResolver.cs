using DF.Ecommerce.Domain.Interfaces.Repository;
using DF.Ecommerce.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DF.Ecommerce.Api.IoC
{
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            RegisterAplications(services);
            RegisterRepositories(services);
            RegisterUnitOfWork(services);
            RegisterClasses(services);
        }

        private static void RegisterClasses(IServiceCollection services)
        {
            //throw new NotImplementedException();
        }

        private static void RegisterUnitOfWork(IServiceCollection services)
        {
            //throw new NotImplementedException();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICupomRepository, CupomRepository>();
            services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IItemCarrinhoRepository, ItemCarrinhoRepository>();
        }

        private static void RegisterAplications(IServiceCollection services)
        {
            //throw new NotImplementedException();
        }
    }
}
