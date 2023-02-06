using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Domain.Entites
{
    public class Carrinho : Entity 
    {
        public int VlTotal { get; set; }
        public ICollection<ItemCarrinho> ItensCarrinhos { get; set; }
        public Guid IdCliente { get; set; }
        public Guid IdCupom { get; set; }

        public Cliente Cliente { get; set; }
        public Cupom Cupom { get; set; }

        public Carrinho()
        {
            if(ItensCarrinhos == null || !ItensCarrinhos.Any()) 
                ItensCarrinhos = new List<ItemCarrinho>();
        }
    }
}
