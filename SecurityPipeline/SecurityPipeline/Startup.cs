using Owin;
using SecurityPipeline.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SecurityPipeline
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            configuration.Routes.MapHttpRoute(
                "default",
                "api/{controller}");
            //configuration.Filters.Add(new TestAuthenticationFilterAttribute());
            app.Use(typeof(TestMiddleware));
            app.UseWebApi(configuration);
        }
    }
}