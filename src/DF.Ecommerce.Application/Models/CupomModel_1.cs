using DF.Ecommerce.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Application.Models
{
    public class CupomModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Peso { get; set; }
        public decimal Preco { get; set; }
        public Guid Codigo { get; set; }
    }
}
