using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web.Http.SelfHost;
using System.Web.Http.SelfHost.Channels;

namespace WebAPISelfHost
{
    internal class MyConfig : HttpSelfHostConfiguration
    {
        private string v;

        public MyConfig(string url) : base(url)
        {
            this.v = url;
        }

        protected override BindingParameterCollection OnConfigureBinding(HttpBinding httpBinding)
        {
            httpBinding.Security.Mode = HttpBindingSecurityMode.TransportCredentialOnly;
            httpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
            return base.OnConfigureBinding(httpBinding);
        }
    }
}