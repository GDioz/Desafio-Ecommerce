using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Application.Interfaces
{
    public interface IUserAplication
    {
        bool CheckUser(string username, string password);

    }
}
