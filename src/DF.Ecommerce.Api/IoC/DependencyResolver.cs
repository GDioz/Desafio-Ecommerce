using DF.Ecommerce.Application;
using DF.Ecommerce.Application.Interfaces;
using DF.Ecommerce.Domain.Entites;
using DF.Ecommerce.Domain.Interfaces.Repository;
using DF.Ecommerce.Domain.Interfaces.UnitOfWork;
using DF.Ecommerce.Infrastructure.Repository;
using DF.Ecommerce.Infrastructure.UnitOfWork;
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
            services.AddScoped<IUnitOfWorkCarrinho, UnitOfWorkCarrinho>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<Domain.Interfaces.Repository.IClienteAplication, ClienteRepository>();
            services.AddScoped<Domain.Interfaces.Repository.ICupomAplication, CupomRepository>();
            services.AddScoped<Domain.Interfaces.Repository.ICarrinhoAplication, CarrinhoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<Domain.Interfaces.Repository.IItemCarrinhoAplication, ItemCarrinhoRepository>();
        }

        private static void RegisterAplications(IServiceCollection services)
        {
            services.AddScoped<Application.Interfaces.IClienteAplication, ClienteAplication>();
            services.AddScoped<Application.Interfaces.ICarrinhoAplication, CarrinhoAplication>();
            services.AddScoped<Application.Interfaces.ICupomAplication, CupomAplication>();
            services.AddScoped<Application.Interfaces.IProdutoAplication, ProdutoAplication>();
            services.AddScoped<Application.Interfaces.IItemCarrinhoAplication, ItemCarrinhoAplication>();
        }
    }
}

