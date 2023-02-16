using AutoMapper;
using DF.Ecommerce.Application.Models;
using DF.Ecommerce.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Application.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ClienteModel, Cliente>().ReverseMap();
            CreateMap<CarrinhoModel, Carrinho>().ReverseMap();
            CreateMap<ItemCarrinhoModel, ItemCarrinho>().ReverseMap();
            CreateMap<CupomModel, Cupom>()
                .ForMember(dest => dest.Id,opt => opt.MapFrom(src => src.Codigo))
                .ReverseMap();
            CreateMap<ProdutoModel, Produto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Codigo))
                .ReverseMap();
        }
    }
}
