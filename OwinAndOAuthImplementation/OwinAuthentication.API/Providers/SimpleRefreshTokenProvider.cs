﻿using Owin.OAuth.API.Entities;
using System;
using System.Threading.Tasks;

namespace Owin.OAuth.API.Providers
{
    public class SimpleRefreshTokenProvider : Microsoft.Owin.Security.Infrastructure.IAuthenticationTokenProvider
    {
        public async Task CreateAsync(Microsoft.Owin.Security.Infrastructure.AuthenticationTokenCreateContext context)
        {
            var clientid = context.Ticket.Properties.Dictionary["as:client_id"];
            if (string.IsNullOrWhiteSpace(clientid))
            {
                return;
            }
            var refreshTokenId = Guid.NewGuid().ToString("n");
            using (AuthRepository repo = new AuthRepository())
            {
                var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime");

                var token = new RefreshToken()
                {
                    Id = Helper.GetHash(refreshTokenId),
                    ClientId = clientid,
                    Subject = context.Ticket.Identity.Name,
                    IssuedUtc = DateTime.UtcNow,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime))
                };

                context.Ticket.Properties.IssuedUtc = token.IssuedUtc;
                context.Ticket.Properties.ExpiresUtc = token.ExpiresUtc;

                token.ProtectedTicket = context.SerializeTicket();

                var result = await repo.AddRefreshToken(token);

                if (result)
                {
                    context.SetToken(refreshTokenId);
                }
            }
        }

        public void Create(Microsoft.Owin.Security.Infrastructure.AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public void Receive(Microsoft.Owin.Security.Infrastructure.AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public async Task ReceiveAsync(Microsoft.Owin.Security.Infrastructure.AuthenticationTokenReceiveContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            string hashedTokenId = Helper.GetHash(context.Token);

            using (AuthRepository repo = new AuthRepository())
            {
                var refreshToken = await repo.FindRefreshToken(hashedTokenId);

                if (refreshToken != null)
                {
                    //Get protectedTicket from refreshToken class
                    context.DeserializeTicket(refreshToken.ProtectedTicket);
                    var result = await repo.RemoveRefreshToken(hashedTokenId);
                }
            }
        }
    }
}
