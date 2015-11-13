using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrainingCompany.Controllers
{
    public class CoursesController : ApiController
    {
        public IEnumerable<course> Get()
        {
            return courses;
        }

        static List<course> courses = InitCourses();
        private static List<course> InitCourses()
        {
            var list = new List<course>();
            list.Add(new course { id = 0, title = "MVC" });
            list.Add(new course { id = 1, title = "Web API" });
            return list;
        }

        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage msg = null;
            var ret = (from c in courses where c.id == id select c).FirstOrDefault();
            if (ret == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Course not found");
            }
            return Request.CreateResponse<course>(HttpStatusCode.OK, ret);
        }

        public HttpResponseMessage Post([FromBody] course c)
        {
            c.id = courses.Count;
            courses.Add(c);
            var msg = Request.CreateResponse();
            msg.Headers.Location = new Uri(Request.RequestUri + c.id.ToString());
            return msg;
        }

        public void Put(int id, [FromBody] course c1)
        {
            var ret = (from c in courses where c.id == id select c).FirstOrDefault();
            ret.title = c1.title;
        }

        public void Delete(int id)
        {
            var ret = (from c in courses where c.id == id select c).FirstOrDefault();
            courses.Remove(ret);
        }
    }
    public class course
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}
