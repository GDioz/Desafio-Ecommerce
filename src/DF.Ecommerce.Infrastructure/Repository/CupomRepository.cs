using DF.Ecommerce.Domain.Entites;
using DF.Ecommerce.Domain.Interfaces.Repository;
using DF.Ecommerce.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Infrastructure.Repository
{
    public class CupomRepository : BaseRepository<Cupom>, ICupomAplication
    {
        public CupomRepository(CarrinhoContext context) : base(context)
        {

        }

        public async Task<Cupom> AtualizarInformacoesDoCumpom(Cupom cupom)
        {
            var cupomRef = await ObterPorId(cupom.Id);
            cupomRef.Descricao = cupom.Descricao;
            cupomRef.VlCupom = cupom.VlCupom;
            await Atualizar(cupom);
            return cupomRef;
        }
    }
}
