using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Domain.Entites
{
    public class Cupom : Entity
    {
        public string Descricao { get; set; }
        public decimal VlCupom { get; set; }
        public ICollection<Carrinho> Carrinhos { get; set; }
    }
}
