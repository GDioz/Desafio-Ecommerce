using DF.Ecommerce.Domain.Interfaces.UnitOfWork;
using DF.Ecommerce.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Infrastructure.UnitOfWork
{
    public class UnitOfWorkBase : IUnitOfWorkBase
    {
        private readonly CarrinhoContext context;
        private bool disposed = false;
        public UnitOfWorkBase(CarrinhoContext context)
        {
            this.context = context;

        }

        public int Save() => context != null ? context.SaveChanges() : 0;
        

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!disposed && disposing && context != null)   
                context.Dispose();
            disposed = true;
        }
    }
}
