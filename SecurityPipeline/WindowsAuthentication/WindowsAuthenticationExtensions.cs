using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WindowsAuthentication
{
    public static class WindowsAuthenticationExtensions
    {
        public static IAppBuilder UseWindowsAuthentication(this IAppBuilder app)
        {
            object value;
            if (app.Properties.TryGetValue("System.Net.HttpListener", out value))
            {
                var listner = value as HttpListener;
                if (listner!=null)
                {
                    listner.AuthenticationSchemes = AuthenticationSchemes.IntegratedWindowsAuthentication;
                }
            }
            return app;
        }
    }
}