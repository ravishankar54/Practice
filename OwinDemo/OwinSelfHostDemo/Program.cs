using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;

namespace OwinSelfHostDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                //Console.WriteLine("Press [enter] to quit...");
                //Console.ReadLine();

                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/values").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }

            Console.ReadLine();
        }

        //string baseUrl = "http://localhost:12345/";

        //    using (WebApp.Start<Startup>(new StartOptions(baseUrl) { ServerFactory = "Microsoft.Owin.Host.HttpListener" }))
        //    {
        //        // Launch the browser
        //        Process.Start(baseUrl);

        //        // Keep the server going until we're done
        //        Console.WriteLine("Press Any Key To Exit");
        //        Console.ReadKey();
        //    }
    }
}

//Open Web Interface for .NET(OWIN) defines an abstraction between.NET web servers and web applications.
//By decoupling the web server from the application, OWIN makes it easier to create middleware for .NET web development.
//Also, OWIN makes it easier to port web applications to other hosts—for example, self-hosting in a Windows service or other process.

//Open Web Interface for .NET(OWIN) defines an abstraction between.NET web servers and web applications.
//OWIN decouples the web application from the server, which makes OWIN ideal for self-hosting a web application in your own process,
//outside of IIS.