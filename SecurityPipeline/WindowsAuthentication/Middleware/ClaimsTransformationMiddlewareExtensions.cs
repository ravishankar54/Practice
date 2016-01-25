using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace WindowsAuthentication
{
    public static class ClaimsTransformationMiddlewareExtensions
    {
        public static IAppBuilder UseClaimsTransformation(this IAppBuilder app, Func<ClaimsPrincipal, Task<ClaimsPrincipal>> transformation)
        {
            return app.UseClaimsTransformation(new ClaimsTransformationOptions
            {
                ClaimsTransformation = transformation
            });
        }

        public static IAppBuilder UseClaimsTransformation(this IAppBuilder app, ClaimsTransformationOptions options)
        {
            if (options == null)
            {
                throw new ArgumentException("options");
            }
            app.Use(typeof(ClaimsTransformationMiddleware), options);
            return app;
        }

    }
}