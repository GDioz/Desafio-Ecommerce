using DF.Ecommerce.Application.Models;
using DF.Ecommerce.Application.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Application.Interfaces
{
    public interface IItemCarrinhoAplication
    {
        Task<Result<string>> AtualizarQuantidade(Guid idProduto, Guid idCarrinho, int quantidade);
        Task<Result<string>> RemoverItemCarrinho(Guid idProduto, Guid idCarrinho);
        Task<Result<string>> LimparCarrinho(Guid idCarrinho);
    }
}
