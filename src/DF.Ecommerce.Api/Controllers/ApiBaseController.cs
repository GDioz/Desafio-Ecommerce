﻿using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;

namespace DF.Ecommerce.Api.Controllers
{
    [ApiController]
    public abstract class ApiBaseController : ControllerBase
    {
        protected string MensagemErro(IReadOnlyCollection<Notification> notifications)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in notifications)
            {
                builder.Append(item.Message);
            }

            return builder.ToString();
        }
    }
}
