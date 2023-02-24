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

        private ICarrinhoAplication _carrinhoRepository;
        private IProdutoRepository _produtoRepository;
        private IItemCarrinhoAplication _itemCarrinhoRepository;
        private ICupomAplication _cupomRepository;
        private IClienteAplication _clienteRepository;

        public UnitOfWorkCarrinho(CarrinhoContext context) : base(context) => _carrinhoContext = context;
        public IClienteAplication ClienteRepository => _clienteRepository ??= new ClienteRepository(_carrinhoContext);

        public ICarrinhoAplication CarrinhoRepository => _carrinhoRepository ??= new CarrinhoRepository(_carrinhoContext);

        public IProdutoRepository ProdutoRepository => _produtoRepository ??= new ProdutoRepository(_carrinhoContext);

        public IItemCarrinhoAplication ItemCarrinhoRepository => _itemCarrinhoRepository ??= new ItemCarrinhoRepository(_carrinhoContext);

        public ICupomAplication CupomRepository => _cupomRepository ??= new CupomRepository(_carrinhoContext);
    }
}
