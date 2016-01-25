using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin.OAuth.API.Entities;
using Owin.OAuth.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owin.OAuth.API
{
    class AuthRepository : IDisposable
    {
        private AuthContext ctx;
        private UserManager<IdentityUser> userManager;
        public AuthRepository()
        {
            ctx = new AuthContext();
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };

            var result = await userManager.CreateAsync(user, userModel.Password);
            return result;
        }
        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            var result = await userManager.FindAsync(userName, password);
            return result;
        }

        public Client FindClient(string clientId)
        {
            var client = ctx.Clients.Find(clientId);

            return client;
        }

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {

            var existingToken = ctx.RefreshTokens.Where(r => r.Subject == token.Subject && r.ClientId == token.ClientId).SingleOrDefault();

            if (existingToken != null)
            {
                var result = await RemoveRefreshToken(existingToken);
            }

            ctx.RefreshTokens.Add(token);
            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

                return await ctx.SaveChangesAsync() > 0;
            }
            catch (DbEntityValidationException e)
            {
                StringBuilder errorMessage = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {

                    errorMessage.Append(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        errorMessage.Append(string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }
                throw new Exception(errorMessage.ToString());
            }
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = await ctx.RefreshTokens.FindAsync(refreshTokenId);

            if (refreshToken != null)
            {
                ctx.RefreshTokens.Remove(refreshToken);
                return await ctx.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
        {
            ctx.RefreshTokens.Remove(refreshToken);
            return await ctx.SaveChangesAsync() > 0;
        }

        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await ctx.RefreshTokens.FindAsync(refreshTokenId);

            return refreshToken;
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            return ctx.RefreshTokens.ToList();
        }

        public void Dispose()
        {
            ctx.Dispose();
            userManager.Dispose();
        }
    }
}
