using DF.Ecommerce.Domain.Entites;
using DF.Ecommerce.Domain.Interfaces.Repository;
using DF.Ecommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Infrastructure.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly CarrinhoContext _context;
        protected readonly DbSet<TEntity> _dbset;
        public BaseRepository(CarrinhoContext context)
        {

        }
        public virtual async Task<TEntity> Adicionar(TEntity entity)
        {
            var entidade = _dbset.Add(entity);
            await SaveChanges();
            return entidade.Entity;
        }

        public virtual async Task<TEntity> Atualizar(TEntity entity)
        {
            var atualizado = _dbset.Update(entity);
            await SaveChanges();
            return atualizado.Entity;
        }

        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> expression)
        {
            //return await _context.Find(expression);
            return await _dbset.AsNoTracking().Where(expression).ToListAsync();
        }

        public void Dispose()
        {
           _context?.Dispose();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await _dbset.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await _dbset.ToListAsync();
        }

        public virtual async Task Remover(Guid id)
        {
            var removido = _dbset.Find(id);
            _dbset.Remove(removido);
            //_dbset.Remove(new TEntity{Id = id});
            await SaveChanges();
        }

        public virtual async Task<int> SaveChanges()
        {
           return await _context.SaveChangesAsync();
        }

    }
}
