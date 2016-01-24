using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(OwinAndKartanaDemo.Startup))]
namespace OwinAndKartanaDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigurationAuth(app);
        }
    }
}
