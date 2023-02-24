using DF.Ecommerce.Domain.Entites;
using DF.Ecommerce.Domain.Interfaces.Repository;
using DF.Ecommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Infrastructure.Repository
{
    public class CarrinhoRepository : BaseRepository<Carrinho>, ICarrinhoAplication
    {
        public CarrinhoRepository(CarrinhoContext context) : base(context)
        {

        }

        public async Task<Carrinho> ObterCarrinho(string documento)
        {
            return await Task.FromResult(_context.Carrinhos
                .Include(x => x.Cliente)
                .Include(x => x.ItensCarrinhos)
                .ThenInclude(x => x.Produto)
                .FirstOrDefault(c => c.Cliente.Cpf.Equals(documento)));
        }
    }
}
