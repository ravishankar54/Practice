using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPISelfHost
{
    internal class MyHttpMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Received an http message");
            var task = new Task<HttpResponseMessage>(() =>
           {
               var un = Thread.CurrentPrincipal.Identity.Name;
               var msg = new HttpResponseMessage();
               msg.Content = new StringContent("Hello self hosting  by ::" + un);
               Console.WriteLine("Response sent by ");
               return msg;
           });
            task.Start();
            return task;
        }
    }
}