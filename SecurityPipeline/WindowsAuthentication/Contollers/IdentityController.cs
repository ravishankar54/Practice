using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;
using WindowsAuthentication.Models;
namespace WindowsAuthentication.Contollers
{
    [Authorize]
    public class IdentityController : ApiController
    {
        public IEnumerable<ViewClaim> Get()
        {
            var principal = User as ClaimsPrincipal;
            return from c in principal.Claims
                   select new ViewClaim
                   {
                       Type = c.Type,
                       Value = c.Value
                   };
        }
    }
}
