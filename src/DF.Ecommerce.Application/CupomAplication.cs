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
    public class CupomAplication : Interfaces.ICupomAplication
    {

        private readonly IMapper _mapper;
        private readonly Domain.Interfaces.Repository.ICupomAplication _cupomRepository;


        public CupomAplication(IMapper mapper, Domain.Interfaces.Repository.ICupomAplication cupomRepository)
        {
            _mapper = mapper;
            _cupomRepository = cupomRepository;
        }

        public async Task<Result<CupomModel>> ObterCupomPeloId(Guid id)
        {
            var cupom = await _cupomRepository.ObterPorId(id);
            return Result<CupomModel>.Ok(_mapper.Map<CupomModel>(cupom));
        }

        public async Task<Result<List<CupomModel>>> ObterCupons()
        {
            var cupons = await _cupomRepository.ObterTodos();
            return Result<List<CupomModel>>.Ok(_mapper.Map<List<CupomModel>>(cupons));
        }

        public async Task<Result<CupomModel>> AtualizarInformacoes(CupomModel cupomModel)
        {
            var atualizado = _mapper.Map<Cupom>(cupomModel);
            var cupomAtualizado = await _cupomRepository.Atualizar(atualizado);
            return Result<CupomModel>.Ok(_mapper.Map<CupomModel>(cupomAtualizado));
        }

        public async Task<Result<CupomModel>> InserirCupom(CupomModel cupomModel)
        {
            var addCupom = _mapper.Map<Cupom>(cupomModel);
            var clienteAdicionado = await _cupomRepository.Adicionar(addCupom);
            return Result<CupomModel>.Ok(_mapper.Map<CupomModel>(clienteAdicionado));
        }

        public async Task<Result<string>> RemoverCupom(Guid id)
        {
            await _cupomRepository.Remover(id);
            return Result<String>.Ok("Cupom Removido com Sucesso!");
        }
    }
}
