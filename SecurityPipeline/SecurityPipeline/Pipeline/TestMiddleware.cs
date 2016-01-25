using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace SecurityPipeline.Pipeline
{
    public class TestMiddleware
    {
        private Func<IDictionary<string, object>, Task> next;
        public TestMiddleware(Func<IDictionary<string, object>, Task> next)
        {
            this.next = next;
        }

        public async Task Invoke(IDictionary<string, object> enviornment)
        {
            var context = new OwinContext(enviornment);
            //authentication

            context.Request.User =
                new GenericPrincipal(new GenericIdentity("dom"), new string[] { });
            Helper.Write("Middlerware", context.Request.User);
            await this.next(enviornment);
        }
    }
}