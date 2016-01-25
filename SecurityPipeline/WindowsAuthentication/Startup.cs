using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
[assembly: OwinStartup(typeof(WindowsAuthentication.Startup))]

namespace WindowsAuthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWindowsAuthentication();
            app.UseClaimsTransformation(Transformation);
            app.UseWebApi(WebApiConfig.Register());
        }

        private async Task<ClaimsPrincipal> Transformation(ClaimsPrincipal incoming)
        {
            if (!incoming.Identity.IsAuthenticated)
            {
                return incoming;
            }
            var name = incoming.Identity.Name;
            // got to datastore and check adn valdiate
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier,name),
                new Claim(ClaimTypes.Role,"test"),
                new Claim(ClaimTypes.Email,"test@test.com")
            };
            var id = new ClaimsIdentity("Windows");
            id.AddClaims(claims);
            return new ClaimsPrincipal(id);

        }
    }
}