using DF.Ecommerce.Application.Models;
using DF.Ecommerce.Application.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Application.Interfaces
{
    public interface ICupomAplication
    {
        Task<Result<List<CupomModel>>> ObterCupons();
        Task<Result<CupomModel>> ObterCupomPeloId(Guid id);
        Task<Result<CupomModel>> InserirCupom(CupomModel cupomModel);
        Task<Result<string>> RemoverCupom(Guid id);
        Task<Result<CupomModel>> AtualizarInformacoes(CupomModel cupomModel);
    }
}
