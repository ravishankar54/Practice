using System.Net.Http;

namespace Owin.OAuth.API.Console
{
    [System.Web.Http.Authorize]
    public class TestController : System.Web.Http.ApiController
    {
        [System.Web.Http.Route("test")]
        public System.Net.Http.HttpResponseMessage Get()
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, "hello from a secured resource!");
        }
    }
}