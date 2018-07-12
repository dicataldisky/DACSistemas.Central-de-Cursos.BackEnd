using DACSistemas.Central_de_Cursos.BackEnd.Context;
using DACSistemas.Central_de_Cursos.BackEnd.Models;
using DACSistemas.Central_de_Cursos.BackEnd.Repositories;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DACSistemas.Central_de_Cursos.BackEnd.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/usuario/agenda")]
    public class AgendaController : ApiController
    {
        private readonly AgendaRepository _repository;
        private readonly CentralDeCursosContext _context;

        protected AgendaController()
        {
            _repository = new AgendaRepository();
            _context = new CentralDeCursosContext();
        }

        [Route("")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult Get()
        {
            int id = Convert.ToInt32(User.Identity.Name);

            UsuarioCurso uc = new UsuarioCurso();
            uc = _context.UsuarioCursos
                .FirstOrDefault(x => x.UsuarioID == id);

            var dados = _repository.Get(Convert.ToInt32(User.Identity.Name), uc.CursoID);
            return Ok(dados);
        }

    }
}