using DF.Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace DF.Ecommerce.Api.Config
{
    public class BasicAuthenticationHandler: AuthenticationHandler <AuthenticationSchemeOptions>
    {
        private readonly IUserAplication _userAplication;
        public BasicAuthenticationHandler(
            IUserAplication userAplication,
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock) 
        {
            _userAplication = userAplication;
        }
        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.Headers["WWW-Authenticate"] = "Basic";
            return base.HandleChallengeAsync(properties);
        }



        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string username;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                username = credentials.FirstOrDefault();
                var password = credentials.LastOrDefault();
                if (!_userAplication.CheckUser(username,password))
                {
                    throw new ArgumentException("Usuário ou Senha Inválida!");
                }
            }
            catch(Exception ex)
            {
                return AuthenticateResult.Fail(ex.Message);
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,username)
            };
            var identity = new ClaimsIdentity(claims,Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal,Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }

    }
}
