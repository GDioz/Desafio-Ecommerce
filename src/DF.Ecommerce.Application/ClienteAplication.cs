using AutoMapper;
using DF.Ecommerce.Application.Interfaces;
using DF.Ecommerce.Application.Models;
using DF.Ecommerce.Application.Results;
using DF.Ecommerce.Domain.Entites;
using DF.Ecommerce.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Application
{
    public class ClienteAplication : Interfaces.IClienteAplication
    {
        private readonly IMapper _mapper;
        private readonly Domain.Interfaces.Repository.IClienteAplication _clienteRepository;


        public ClienteAplication(IMapper mapper, Domain.Interfaces.Repository.IClienteAplication clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }
        public async Task<Result<ClienteModel>> ObterClientePeloDocumento(string documento)
        {
            var cliente = await _clienteRepository.ObterClientePorDocumento(documento);
            return Result<ClienteModel>.Ok(_mapper.Map<ClienteModel>(cliente));
        }

        public async Task<Result<ClienteModel>> ObterClientePeloId(Guid id)
        {
            var cliente = await _clienteRepository.ObterClientePorIdComInclude(id);
            return Result<ClienteModel>.Ok(_mapper.Map<ClienteModel>(cliente));
        }

        public async Task<Result<List<ClienteModel>>> ObterClientes()
        {
            var clientes = await _clienteRepository.ObterTodos();
            return Result<List<ClienteModel>>.Ok(_mapper.Map<List<ClienteModel>>(clientes));
        }

        public async Task<Result<ClienteModel>> AtualizarInformacoes(ClienteModel clienteModel)
        {
            var atualizado = _mapper.Map<Cliente>(clienteModel);
            var clienteAtualizado = await _clienteRepository.Atualizar(atualizado);
            return Result<ClienteModel>.Ok(_mapper.Map<ClienteModel>(clienteAtualizado));
        }

        public async Task<Result<ClienteModel>> InserirCliente(ClienteModel clienteModel)
        {
            var addCliente = _mapper.Map<Cliente>(clienteModel);
            var clienteAdicionado = await _clienteRepository.Adicionar(addCliente);
            return Result<ClienteModel>.Ok(_mapper.Map<ClienteModel>(clienteAdicionado));
        }

 

        public async Task<Result<string>> RemoverCliente(Guid id)
        {
            await _clienteRepository.Remover(id);
            return Result<String>.Ok("Cliente Removido com Sucesso!");
        }
    }
}
