using DF.Ecommerce.Application.Models;
using DF.Ecommerce.Application.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Application.Interfaces
{
    public interface ICarrinhoAplication
    {
        Task<Result<CarrinhoModel>> AdicionarItem(Guid idProduto, string documento);
        Task<Result<string>> RemoverItem(Guid idProduto, string documento);
        Task<Result<CarrinhoModel>> AtualizarQuantidade(Guid idProduto, string documento, int quantidade);
        Task<Result<CarrinhoModel>> AdicionarCupomDesconto(Guid idCupom, string documento);
        Task<Result<string>> LimparCarrinho(string documento);
        Task<Result<CarrinhoModel>> ObterCarrinho(string documento);
    }
}
