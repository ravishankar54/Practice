using System;
using System.Net.Http;
using Thinktecture.IdentityModel.Client;

namespace Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var response = GetToken();
            CallService(response.AccessToken);
        }


        private static TokenResponse GetToken()
        {
            var client = new OAuth2Client(new Uri("http://localhost:12345/token"));
            return client.RequestResourceOwnerPasswordAsync("ravi", "ravi").Result;
        }

        private static void CallService(string token)
        {
            var client = new HttpClient();
            client.SetBearerToken(token);
            var response = client.GetStringAsync(new Uri("http://localhost:12345/api/identity/"));
            Console.WriteLine(response);
            Console.ReadLine();
        }



        private static void OldOwintestMethod()
        {
            var handler = new HttpClientHandler
            {
                UseDefaultCredentials = true
            };
            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:44300/api/")
            };
            var response = client.GetAsync("identity").Result;
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }
    }
}
