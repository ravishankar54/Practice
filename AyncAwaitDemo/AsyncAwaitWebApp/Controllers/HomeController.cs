using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AsyncAwaitWebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                var httpMessage = await client.GetAsync("http://www.filipekberg.se/rss");
                var content = await httpMessage.Content.ReadAsStringAsync();
                return Content(content);
            }
        }
    }
}