using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XMethodOverride.Controllers;

namespace XMethodOverride
{
    internal class MyMethodOverrideHandler : DelegatingHandler
    {
        private const string Header = "X-Http-Method-Override";
        public MyMethodOverrideHandler()
        {
        }
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
                CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Post && request.Headers.Contains(Header))
            {
                var realverb = request.Headers.GetValues(Header).FirstOrDefault();
                if (realverb != null)
                {
                    request.Method = new MyHttpMethod(realverb);
                }
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}