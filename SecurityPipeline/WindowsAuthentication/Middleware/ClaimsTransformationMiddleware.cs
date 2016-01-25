
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace WindowsAuthentication
{
    public class ClaimsTransformationMiddleware
    {
        private readonly ClaimsTransformationOptions options;
        private readonly Func<IDictionary<string, object>, Task> next;
        public ClaimsTransformationMiddleware(Func<IDictionary<string, object>, Task> next, ClaimsTransformationOptions options)
        {
            this.next = next;
            this.options = options;
        }
        public async Task Invoke(IDictionary<string, object> env)
        {
            var context = new OwinContext(env);
            if (context.Authentication != null &&
                context.Authentication.User != null)
            {
                var transformedPrincipal = await options.ClaimsTransformation(context.Authentication.User);
                context.Authentication.User = new ClaimsPrincipal(transformedPrincipal);
            }
            await next(env);
        }
    }
}