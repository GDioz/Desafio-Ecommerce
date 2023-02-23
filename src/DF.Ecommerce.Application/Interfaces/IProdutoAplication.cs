using DF.Ecommerce.Application.Models;
using DF.Ecommerce.Application.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Application.Interfaces
{
    public interface IProdutoAplication
    {
        Task<Result<List<ProdutoModel>>> ObterProdutos();
        Task<Result<ProdutoModel>> ObterProdutoPeloId(Guid id);
        Task<Result<ProdutoModel>> InserirProduto(ProdutoModel produtoModel);
        Task<Result<string>> RemoverProduto(Guid id);
        Task<Result<ProdutoModel>> AtualizarInformacoes(ProdutoModel produtoModel);

    }
}
