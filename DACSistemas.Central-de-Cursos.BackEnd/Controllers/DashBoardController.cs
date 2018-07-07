using DACSistemas.Central_de_Cursos.BackEnd.Context;
using DACSistemas.Central_de_Cursos.BackEnd.Repositories;
using DACSistemas.Central_de_Cursos.BackEnd.ViewModels;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Linq;

namespace DACSistemas.Central_de_Cursos.BackEnd.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/usuario/dashboard")]
    public class DashBoardController : ApiController
    {
        private readonly CentralDeCursosContext _context;
        private readonly UsuarioRepository _repository;

        public DashBoardController()
        {
            _context = new CentralDeCursosContext();
            _repository = new UsuarioRepository();
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = _context.Usuarios
               .Include(e => e.Enderecos)        
               .Include(uc => uc.UsuarioCurso.Select(c => c.Curso)).Select(vm => new ListDashBoardViewModel
               {
                   Curso = vm.UsuarioCurso.Select(c => c.Curso).FirstOrDefault(t => t.CursoID == vm.UsuarioID).Nome,
                   DescricaoDoCurso = vm.UsuarioCurso.Select(c => c.Curso).FirstOrDefault(t => t.CursoID == vm.UsuarioID).Descricao
               });
              
               


            return Ok(result);
        }
    }
}