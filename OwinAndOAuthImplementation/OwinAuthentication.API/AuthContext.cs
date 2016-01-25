using Microsoft.AspNet.Identity.EntityFramework;
using Owin.OAuth.API.Entities;
using System.Data.Entity;

namespace Owin.OAuth.API
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext() : base("AuthContext")
        {
            
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
