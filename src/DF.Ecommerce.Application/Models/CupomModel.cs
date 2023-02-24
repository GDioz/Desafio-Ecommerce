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
        public string Descricao { get; set; }
        public decimal VlCupom { get; set; }
        public Guid Codigo { get; set; }

    }
}
