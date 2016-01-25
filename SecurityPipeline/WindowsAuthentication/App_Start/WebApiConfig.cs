using Newtonsoft.Json;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
namespace WindowsAuthentication
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            var config = new HttpConfiguration();
            // allowing Cross Orgin Requests to access our api by 
            // enabling Cross Origin Resource Sharing(CORS) globally
            //var corsAttribute = new EnableCorsAttribute(origins: "*", headers: "*", methods: "*");
            //config.EnableCors(corsAttribute);
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Define Formatters
            var formatters = config.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            var appXmlType = formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            return config;
        }
    }
}
