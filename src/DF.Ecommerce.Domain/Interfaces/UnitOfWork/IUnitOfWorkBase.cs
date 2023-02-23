﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWorkBase : IDisposable 
    {
        int Save();
    }
}