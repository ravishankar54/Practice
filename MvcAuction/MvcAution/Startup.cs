using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcAuction.Startup))]
namespace MvcAuction
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
