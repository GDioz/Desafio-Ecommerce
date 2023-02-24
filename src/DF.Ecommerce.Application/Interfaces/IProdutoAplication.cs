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
        Task<Result<List<CupomModel>>> ObterProdutos();
        Task<Result<CupomModel>> ObterProdutoPeloId(Guid id);
        Task<Result<CupomModel>> InserirProduto(CupomModel produtoModel);
        Task<Result<string>> RemoverProduto(Guid id);
        Task<Result<CupomModel>> AtualizarInformacoes(CupomModel produtoModel);

    }
}
