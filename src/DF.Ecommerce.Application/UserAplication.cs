using DF.Ecommerce.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Application
{
    public class UserAplication : IUserAplication
    {
        public bool CheckUser(string username, string password)
        {
            return username.Equals("Gustavo")&&password.Equals("456123");
        }
    }
}
