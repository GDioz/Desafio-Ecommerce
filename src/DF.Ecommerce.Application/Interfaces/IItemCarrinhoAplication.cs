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
        Task<Result<CarrinhoModel>> AtualizarQuantidade(Guid idProduto, string documento, int quantidade);
        Task<Result<string>> RemoverItemCarrinho(Guid idProduto, string documento);
        Task<Result<string>> LimparCarrinho(string documento);
    }
}
