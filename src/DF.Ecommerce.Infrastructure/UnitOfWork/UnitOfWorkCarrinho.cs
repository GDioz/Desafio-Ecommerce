using DF.Ecommerce.Domain.Interfaces.Repository;
using DF.Ecommerce.Domain.Interfaces.UnitOfWork;
using DF.Ecommerce.Infrastructure.Context;
using DF.Ecommerce.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Infrastructure.UnitOfWork
{
    public class UnitOfWorkCarrinho : UnitOfWorkBase , IUnitOfWorkCarrinho
    {
        private readonly CarrinhoContext _carrinhoContext;

        private ICarrinhoRepository _carrinhoRepository;
        private IProdutoRepository _produtoRepository;
        private IItemCarrinhoRepository _itemCarrinhoRepository;
        private ICupomRepository _cupomRepository;
        private IClienteRepository _clienteRepository;

        public UnitOfWorkCarrinho(CarrinhoContext context) : base(context) => _carrinhoContext = context;
        public IClienteRepository ClienteRepository => _clienteRepository ??= new ClienteRepository(_carrinhoContext);

        public ICarrinhoRepository CarrinhoRepository => _carrinhoRepository ??= new CarrinhoRepository(_carrinhoContext);

        public IProdutoRepository ProdutoRepository => _produtoRepository ??= new ProdutoRepository(_carrinhoContext);

        public IItemCarrinhoRepository ItemCarrinhoRepository => _itemCarrinhoRepository ??= new ItemCarrinhoRepository(_carrinhoContext);

        public ICupomRepository CupomRepository => _cupomRepository ??= new CupomRepository(_carrinhoContext);
    }
}
