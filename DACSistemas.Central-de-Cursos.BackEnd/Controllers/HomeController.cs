using System.Diagnostics;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DACSistemas.Central_de_Cursos.BackEnd.Controllers
{
    [EnableCors("*", "*", "*")]
    public class HomeController : ApiController
    {
        [Route("")]
        [HttpGet]
        public object Get()
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;

            return new { Version = version };
        }
        
    }
}