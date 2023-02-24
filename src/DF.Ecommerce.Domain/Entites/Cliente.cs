using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Domain.Entites
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set;}
        public Carrinho Carrinho { get; set; }
        public Cliente()
        {
            if(Carrinho == null)
                Carrinho = new Carrinho();
        }
    }
}
