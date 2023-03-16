using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Domain.Entites
{
    public class ItemCarrinho
    {
        public Guid IdProduto { get; set; }
        public Guid IdCarrinho { get; set; }
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }
        public Carrinho Carrinho { get; set; }
    }
}
