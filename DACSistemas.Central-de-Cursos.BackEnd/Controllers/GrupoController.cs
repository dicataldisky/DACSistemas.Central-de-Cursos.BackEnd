using DACSistemas.Central_de_Cursos.BackEnd.Repositories;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DACSistemas.Central_de_Cursos.BackEnd.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/usuario/grupo")]
    public class GrupoController : ApiController
    {
        private readonly GrupoRepository _repository;

        protected GrupoController()
        {
            _repository = new GrupoRepository();
        }

        [Route("")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult Get()
        {
            var dados = _repository.Get(Convert.ToInt32(User.Identity.Name));
            return Ok(dados);
        }
    }
}