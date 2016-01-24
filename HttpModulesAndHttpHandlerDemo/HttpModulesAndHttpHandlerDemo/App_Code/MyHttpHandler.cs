using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HttpModulesAndHttpHandlerDemo.App_Code
{
   public class MyHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            MyHttpModule.objArrayList.Add("HttpHandler:ProcessRequest");
            context.Response.Redirect("Default.aspx");
        }
    }

}
