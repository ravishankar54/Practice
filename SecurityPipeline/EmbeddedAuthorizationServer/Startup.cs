using EmbeddedAuthorizationServer.Provider;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
[assembly: OwinStartup(typeof(EmbeddedAuthorizationServer.Startup))]
namespace EmbeddedAuthorizationServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //token generation
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions()
            {
                // for demo
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(8),
                Provider = new SimpleAuthorizationServerProvider(),
                RefreshTokenProvider = null
            });

            //token cosumption
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            app.UseWebApi(WebApiConfig.Register());
        }
    }
}