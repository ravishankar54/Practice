using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPISelfHost
{
    public class MyController : ApiController
    {
        public string Get()
        {
            return "hello from my controller using self hosting";
        }
    }
}
