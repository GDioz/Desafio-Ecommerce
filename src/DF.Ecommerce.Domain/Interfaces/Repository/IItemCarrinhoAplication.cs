using DF.Ecommerce.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Domain.Interfaces.Repository
{
    public interface IItemCarrinhoAplication
    {
        Task<int> AtualizarQuantidade(Guid idProduto, Guid idCarrinho, int quantidade);
        Task<int> RemoverItemCarrinho(Guid idProduto, Guid idCarrinho);
        Task<int> LimparCarrinho(Guid idCarrinho);
    }
}
