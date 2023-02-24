using DF.Ecommerce.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Domain.Interfaces.Repository
{
    public interface ICupomAplication : IBaseRepository<Cupom>
    {
        Task<Cupom> AtualizarInformacoesDoCumpom(Cupom cupom);
    }
}
