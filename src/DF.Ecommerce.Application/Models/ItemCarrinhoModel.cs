using DF.Ecommerce.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Application.Models
{
    public class ItemCarrinhoModel
    {
        public Guid IdProduto { get; set; }
        public Guid IdCarrinho { get; set; }
        public int Quantidade { get; set; }
        public CupomModel Produto { get; set; }
        public CarrinhoModel Carrinho { get; set; }
    }
}
