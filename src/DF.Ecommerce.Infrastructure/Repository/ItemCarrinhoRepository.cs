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
    public class ItemCarrinhoRepository : IItemCarrinhoRepository
    {
        private readonly CarrinhoContext _context;
        private readonly DbSet<ItemCarrinho> _dbSet;
   
        public ItemCarrinhoRepository(CarrinhoContext context)
        {
            _context = context;
            _dbSet = context.Set<ItemCarrinho>();
        }
        public async Task<int> AtualizarQuantidade(Guid idProduto, Guid idCarrinho, int quantidade)
        {
            var itemCarrinho = await _dbSet.FindAsync(idCarrinho,idProduto);
            itemCarrinho.Quantidade += quantidade;
            _dbSet.Update(itemCarrinho);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> LimparCarrinho(Guid idCarrinho)
        {
            var itensCarrinho = _dbSet.Where(x => x.IdCarrinho == idCarrinho);
            _dbSet.RemoveRange(itensCarrinho);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoverItemCarrinho(Guid idProduto, Guid idCarrinho)
        {
            var itemCarrinho = await _dbSet.FindAsync(idCarrinho, idProduto);
            _dbSet.Remove(itemCarrinho);
            return await _context.SaveChangesAsync();
        }
    }
}
