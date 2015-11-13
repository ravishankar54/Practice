using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace XMethodOverride.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        [HttpPut]
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            Request.CreateResponse(HttpStatusCode.OK, value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [MyCustomHttpMethod]
        public void MyMethod(int id, [FromBody]string value)
        {
            Request.CreateResponse(HttpStatusCode.OK, value);
        }
    }

    public class MyCustomHttpMethodAttribute : Attribute, IActionHttpMethodProvider
    {
        public Collection<HttpMethod> HttpMethods
        {
            get
            {
                var result = new Collection<HttpMethod>();
                result.Add(new MyHttpMethod("MyCustomHttpMethod"));
                return result;
            }
        }
    }

    public class MyHttpMethod : HttpMethod
    {
        public MyHttpMethod(string method) : base(method)
        {

        }
    }
}

//Host: localhost:51126
//X-Http-Method-Override: PUT
//Content-Type: application/json; charset=utf-8
//Content-Length: 39
