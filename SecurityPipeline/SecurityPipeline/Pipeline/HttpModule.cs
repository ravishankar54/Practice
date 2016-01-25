using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityPipeline.Pipeline
{
    public class HttpModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            Helper.Write("HttpModule", HttpContext.Current.User);
        }
    }
}