using DF.Ecommerce.Domain.Entites;
using DF.Ecommerce.Domain.Interfaces.Repository;
using DF.Ecommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Infrastructure.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(CarrinhoContext context) : base(context)
        {

        }

        public async Task<Produto> AtualizarInformacoesDoProduto(Produto produto)
        {
            var produtoRef = await ObterPorId(produto.Id);
            produtoRef.Preco = produto.Preco;
            produtoRef.Nome= produto.Nome;
            produtoRef.Descricao= produto.Descricao;
            produtoRef.Peso = produto.Peso;
            await Atualizar(produto);
            return produtoRef;
        }
    }
}
