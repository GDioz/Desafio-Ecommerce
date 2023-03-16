using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DF.Ecommerce.Application.Models
{
    public class MsgModel
    {
        public string Message { get; set; }
        public MsgModel(string message)
        {
            Message = message;
        }
    }
}
