using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Domain.Entites
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Peso { get; set; }
        public decimal Preco { get; set; }
        public ICollection<ItemCarrinho> ItensCarrinhos { get; set; }
    }
}
