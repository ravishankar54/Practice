using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SelfHostingServer
{
    public class CustomerController : ApiController
    {
        public Customer Get()
        {
            return new Customer() { Name = "Test ravi" };
        }
    }
}
