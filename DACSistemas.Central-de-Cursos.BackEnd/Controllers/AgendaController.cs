using DACSistemas.Central_de_Cursos.BackEnd.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DACSistemas.Central_de_Cursos.BackEnd.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/usuario/agenda")]
    public class AgendaController : ApiController
    {
        private readonly AgendaRepository _repository;

        protected AgendaController()
        {
            _repository = new AgendaRepository();
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