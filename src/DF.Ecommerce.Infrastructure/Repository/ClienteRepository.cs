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
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CarrinhoContext context) : base(context)
        {
            
        }
        public async Task<Cliente> AtualizarInformacoes(Cliente cliente)
        {
            var clientRef = await ObterClientePorIdComInclude(cliente.Id);
            clientRef.Nome = cliente.Nome;
            clientRef.DataNascimento = cliente.DataNascimento;
            clientRef.Email = cliente.Email;
            clientRef.Cpf= cliente.Cpf;
            await Atualizar(cliente);
            return clientRef;
        }

        public async Task<Cliente> ObterClientePorDocumento(string documento)
        {
            return await Task.FromResult(_context.Clientes
                //.Include(x => x.Carrinho)
                //.ThenInclude(x => x.ItensCarrinhos)
                //.ThenInclude(x => x.Produto)
                .FirstOrDefault(c => c.Cpf.Equals(documento)));
        }

        public async Task<Cliente> ObterClientePorIdComInclude(Guid id)
        {
            return await Task.FromResult(_context.Clientes
                .Include(x => x.Carrinho)
                .ThenInclude(x => x.ItensCarrinhos)
                .ThenInclude(x => x.Produto)
                .FirstOrDefault(c => c.Id.Equals(id)));
        }
    }
}
