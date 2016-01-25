using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;
using System.Threading.Tasks;

namespace EmbeddedAuthorizationServer.Provider
{
    public class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
    {

        private static ConcurrentDictionary<string, AuthenticationTicket> refreshTokens;
        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var guid = Guid.NewGuid().ToString();

            var refreshTokenProperties = new AuthenticationProperties(context.Ticket.Properties.Dictionary)
            { 
                IssuedUtc = context.Ticket.Properties.IssuedUtc,
                ExpiresUtc = DateTime.UtcNow.AddYears(1)

            };
            var refreshTokenTicket = new AuthenticationTicket(context.Ticket.Identity, refreshTokenProperties);

            refreshTokens.TryAdd(guid, refreshTokenTicket);
            context.SetToken(guid);
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            AuthenticationTicket ticket;
            if (refreshTokens.TryRemove(context.Token,out ticket))
            {
                context.SetTicket(ticket);
            }
        }
    }
}