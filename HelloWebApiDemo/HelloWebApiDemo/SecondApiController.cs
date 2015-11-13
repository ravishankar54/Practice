using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HelloWebApiDemo
{
    public class SecondApiController : ApiController
    {
        public string Get()
        {
            return "From Second Web API Controller" + DateTime.Now.ToString();
        }
    }
}