using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

//[assembly: OwinStartup(typeof(OwinStartupClassDetectionDemo.ProductionStartup))]
[assembly: OwinStartup("ProductionConfiguration", typeof(OwinStartupClassDetectionDemo.ProductionStartup))]

namespace OwinStartupClassDetectionDemo
{
    public class ProductionStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(context =>
            {
                string t = DateTime.Now.Millisecond.ToString();
                return context.Response.WriteAsync(t + " Production OWIN App");
            });
        }
    }
}
