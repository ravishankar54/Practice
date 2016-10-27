using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcAndWebApiTemplateWithAuthentication.Startup))]
namespace MvcAndWebApiTemplateWithAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
