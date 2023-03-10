using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Domain.Entites
{
    public class Carrinho : Entity 
    {
        public decimal VlTotal { get; set; }
        public List<ItemCarrinho> ItemCarrinhos { get; set; }
        public Guid IdCliente { get; set; }
        public Guid? IdCupom { get; set; }
        public Cliente Cliente { get; set; }
        public Cupom Cupom { get; set; }

        public Carrinho()
        {
            if(ItemCarrinhos == null || !ItemCarrinhos.Any()) 
                ItemCarrinhos = new List<ItemCarrinho>();
        }
    }
}
