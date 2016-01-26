using System;
using System.Web.Http;

//[assembly: Microsoft.Owin.OwinStartup(typeof(Owin.OAuth.API.Console.Startup))]

namespace Owin.OAuth.API.Console
{ 
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var oauthProvider = new Microsoft.Owin.Security.OAuth.OAuthAuthorizationServerProvider
            {
                OnGrantResourceOwnerCredentials = async context =>
                {
                    if (context.UserName == "rboyina" && context.Password == "welcome@123")
                    {
                        var claimsIdentity = new System.Security.Claims.ClaimsIdentity(context.Options.AuthenticationType);
                        claimsIdentity.AddClaim(new System.Security.Claims.Claim("user", context.UserName));
                        context.Validated(claimsIdentity);
                        return;
                    }
                    context.Rejected();
                },
                OnValidateClientAuthentication = async context =>
                {
                    string clientId;
                    string clientSecret;
                    if (context.TryGetBasicCredentials(out clientId, out clientSecret))
                    {
                        if (clientId == "ravi" && clientSecret == "secretKey")
                        {
                            context.Validated();
                        }
                    }
                }
            };
            var oauthOptions = new Microsoft.Owin.Security.OAuth.OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new Microsoft.Owin.PathString("/accesstoken"),
                Provider = oauthProvider,
                AuthorizationCodeExpireTimeSpan = TimeSpan.FromMinutes(1),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(3),
                SystemClock = new Microsoft.Owin.Infrastructure.SystemClock()

            };
            app.UseOAuthAuthorizationServer(oauthOptions);
            app.UseOAuthBearerAuthentication(new Microsoft.Owin.Security.OAuth.OAuthBearerAuthenticationOptions());

            var config = new System.Web.Http.HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
        }
    }
}
