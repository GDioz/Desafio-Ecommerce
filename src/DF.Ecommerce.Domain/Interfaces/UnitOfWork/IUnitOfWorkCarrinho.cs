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
        ICarrinhoAplication CarrinhoRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        IItemCarrinhoAplication ItemCarrinhoRepository { get; }
        ICupomAplication CupomRepository { get; }  
        IClienteAplication  ClienteRepository { get; }
    }
}
