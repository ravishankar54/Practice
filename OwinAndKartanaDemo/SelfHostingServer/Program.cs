using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(SelfHostingServer.Startup))]
namespace SelfHostingServer
{
    using System.Web.Http;
    using AppFunc = Func<IDictionary<string, object>, Task>;
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var uri = "http://localhost:58674/";
    //        using (WebApp.Start<Startup>(uri))
    //        {
    //            Console.WriteLine("Started!");
    //            Console.ReadKey();
    //            Console.WriteLine("Stopped");
    //        }
    //    }
    //}

    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.Use(async (environment, next) =>
            //{
            //    foreach (var pair in environment.Environment)
            //    {
            //        Console.WriteLine("{0} : {1}", pair.Key, pair.Value);
            //    }
            //    await next();
            //});

            //app.Use(async (environment, next) =>
            //{
            //    Console.WriteLine("Requesting : {0}", environment.Request.Path);
            //    await next();
            //    Console.WriteLine("Response : {0}", environment.Response.StatusCode);
            //});

            ConfigureWebApi(app);

            app.UseHelloWorld();

            //app.Run(ctx =>
            //{
            //    return ctx.Response.WriteAsync("Test");
            //});
            //app.Use<HelloWorldComponent>();
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            app.UseWebApi(config);
        }
    }

    public static class AppBuilderExtensions
    {
        public static void UseHelloWorld(this IAppBuilder app)
        {
            app.Use<HelloWorldComponent>();
        }
    }
    class HelloWorldComponent
    {
        AppFunc next;
        public HelloWorldComponent(AppFunc next)
        {
            this.next = next;
        }
        public Task Invoke(IDictionary<string, object> envoirnment)
        {
            //await next(envoirnment);

            var resposne = envoirnment["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(resposne))
            {
                return writer.WriteAsync("Hello!!");
            }
        }
    }
    //Development\Practice\OwinAndKartanaDemo\SelfHostingServer\bin>"C:\Program Files\IIS Express\iisexpress.exe" /path:C:\Development\Practice\OwinAndKartanaDemo\SelfHostingServer
}
