using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace WebAPISelfHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new MyConfig("http://localhost:58674/");
            var server = new HttpSelfHostServer(config, new MyHttpMessageHandler());
            var task = server.OpenAsync();
            task.Wait();
            Console.WriteLine("Server is up and running");
            Console.ReadLine();

        }

        private void Backup()
        {
            var config = new HttpSelfHostConfiguration("http://localhost:58674/");
            config.Routes.MapHttpRoute("defualtroute", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            var server = new HttpSelfHostServer(config);//, new MyHttpMessageHandler());
            var task = server.OpenAsync();
            task.Wait();
            Console.WriteLine("Server is up and running");
            Console.WriteLine("hit enter to call server with client");
            Console.ReadLine();
            var client = new HttpClient(server);
            client.GetAsync("http://localhost:58674/api/my").ContinueWith((t) =>
            {
                var result = t.Result;
                result.Content.ReadAsStringAsync().ContinueWith((res) =>
                {
                    Console.WriteLine("client got response :: " + res.Result);
                });
            });
        }
    }
}
