using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;

namespace Owin.OAuth.API.Console
{
    public class Program
    {
        public static void Main()
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host     
            using (Microsoft.Owin.Hosting.WebApp.Start<Startup>(url: baseAddress))
            {
                var client = new System.Net.Http.HttpClient();
                var response = client.GetAsync(baseAddress + "test").Result;
                System.Console.WriteLine(response);

                System.Console.WriteLine();

                var authorizationHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes("ravi:secretKey"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authorizationHeader);

                var form = new Dictionary<string, string>
               {
                   {"grant_type", "password"},
                   {"username", "rboyina"},
                   {"password", "welcome@123"},
               };

                var tokenResponse = client.PostAsync(baseAddress + "accesstoken", new System.Net.Http.FormUrlEncodedContent(form)).Result;
                var token = tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;

                System.Console.WriteLine("Token issued is: {0}", token.AccessToken);

                System.Console.WriteLine();

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);
                var authorizedResponse = client.GetAsync(baseAddress + "test").Result;
                System.Console.WriteLine(authorizedResponse);
                System.Console.WriteLine(authorizedResponse.Content.ReadAsStringAsync().Result);
            }

            System.Console.ReadLine();
        }
    }
}
