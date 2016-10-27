using System.Web.Http;
using GloboMartDataAccessService.Models;

namespace GloboMartDataAccessService.Controllers
{
    public class ProductPriceController : ApiController
    {
        public ProductPriceController()
        {

        }

        public IHttpActionResult GetProduct(long id)
        {
            using (GloboMartContext db = new GloboMartContext())
            {
                Product product = db.Products.Find(id);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }

        }
    }
}
