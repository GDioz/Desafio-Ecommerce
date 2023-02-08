using DF.Ecommerce.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<Cliente> ObterClientePorDocumento(string documento);
        Task<Cliente> AtualizarInformacoes(Cliente cliente);
    }
}
