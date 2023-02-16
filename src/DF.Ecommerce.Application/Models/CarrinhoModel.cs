using DF.Ecommerce.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Application.Models
{
    public class CarrinhoModel
    {
        public decimal VlTotal { get; set; }
        public List<ItemCarrinhoModel> ItensCarrinhos { get; set; }
        public Guid IdCliente { get; set; }
    }
}
