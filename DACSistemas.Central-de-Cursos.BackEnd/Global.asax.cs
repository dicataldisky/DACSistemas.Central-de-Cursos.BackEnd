using Microsoft.Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(DACSistemas.Central_de_Cursos.BackEnd.Startup))]
namespace DACSistemas.Central_de_Cursos.BackEnd
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //vai ignorar referencia de loops
            GlobalConfiguration.Configuration.Formatters.JsonFormatter
                .SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
