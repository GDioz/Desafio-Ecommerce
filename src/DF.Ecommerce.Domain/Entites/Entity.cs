using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Domain.Entites
{
    public abstract class  Entity
    {
        protected Entity()
        {
            if(Id == Guid.Empty)
                Id = Guid.NewGuid();

        }
        public Guid Id { get; set; }
    }
}
