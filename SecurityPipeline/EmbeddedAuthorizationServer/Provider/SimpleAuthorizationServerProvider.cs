using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Security.Claims;
using Microsoft.Owin.Security;
namespace EmbeddedAuthorizationServer.Provider
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string id, secret;
            if (context.TryGetBasicCredentials(out id, out secret))
            {
                if (secret == "secret")
                {
                    context.Validated();
                }
            }
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //validate user credentails
            if (context.UserName != context.Password)
            {
                context.Rejected();
                return;
            }

            //create cliams
            var id = new ClaimsIdentity(context.Options.AuthenticationType);
            id.AddClaim(new Claim("sub", context.UserName));
            id.AddClaim(new Claim("role", "user"));

            //create metadata to pass a refresh token provider
            var props = new AuthenticationProperties(
                new Dictionary<string, string>()
                {
                    {"as:client_id",context.ClientId}
                });
            var ticket = new AuthenticationTicket(id, props);
            context.Validated(ticket);
        }

        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var orginalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.ClientId;

            //enforce client binding of refresh token
            if (orginalClient != currentClient)
            {
                context.Rejected();
                return;
            }

            //chance to change authentication ticket for refresh token requests
            var newId = new ClaimsIdentity(context.Ticket.Identity);
            newId.AddClaim(new Claim("newClaim", "refreshToken"));

            var newTicket = new AuthenticationTicket(newId, context.Ticket.Properties);
            context.Validated(newTicket);
        }
    }
}