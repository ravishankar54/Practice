using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;


namespace OwinAndKartanaDemo
{
  public partial  class Startup
    {
        public void ConfigurationAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
               
            });
            
        }
    }
}
