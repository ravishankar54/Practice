using Owin.OAuth.API.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace Owin.OAuth.API.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private AuthRepository repo = null;

        public AccountController()
        {
            repo = new AuthRepository();
        }
        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult>  Register(UserModel usermodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Microsoft.AspNet.Identity.IdentityResult result = await repo.RegisterUser(usermodel);
            IHttpActionResult errorResult = GetErrorResult(result);
            return errorResult ?? Ok();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }

            base.Dispose(disposing);
        }
        private IHttpActionResult GetErrorResult(Microsoft.AspNet.Identity.IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
