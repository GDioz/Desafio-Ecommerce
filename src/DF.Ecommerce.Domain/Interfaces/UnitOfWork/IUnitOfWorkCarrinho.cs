using DF.Ecommerce.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWorkCarrinho : IUnitOfWorkBase
    {
        ICarrinhoRepository CarrinhoRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        IItemCarrinhoRepository ItemCarrinhoRepository { get; }
        ICupomRepository CupomRepository { get; }  
        IClienteRepository  ClienteRepository { get; }
    }
}
