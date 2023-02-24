using DF.Ecommerce.Application.Models;
using DF.Ecommerce.Application.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Application.Interfaces
{
    public interface IClienteAplication
    {
        Task<Result<List<ClienteModel>>> ObterClientes();
        Task<Result<ClienteModel>> ObterClientePeloId(Guid id);
        Task<Result<ClienteModel>> ObterClientePeloDocumento(string documento);
        Task<Result<ClienteModel>> InserirCliente(ClienteModel clienteModel);
        Task<Result<string>> RemoverCliente(Guid id);
        Task<Result<ClienteModel>> AtualizarInformacoes(ClienteModel clienteModel);
    }
}
