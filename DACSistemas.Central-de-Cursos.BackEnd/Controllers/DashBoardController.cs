using DACSistemas.Central_de_Cursos.BackEnd.Context;
using DACSistemas.Central_de_Cursos.BackEnd.Repositories;
using DACSistemas.Central_de_Cursos.BackEnd.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

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

        //[Route("")]
        //[HttpGet]
        //public IHttpActionResult Get()
        //{
        //    var result = _context.Usuarios


        //       .Select(vm => new ListDashBoardViewModel

        //       {
        //           UsuarioID = vm.UsuarioID,
        //           FraseBoasVindas = "Seja Bem Vindo ao Painel do Aluno",


        //       }).Where(a => a.UsuarioID == 1);

        //    return Ok(result);
        //}
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = _context.Usuarios
                .Include(uc => uc.UsuarioCurso)

               .Select(vm => new ListDashBoardViewModel

               {
                   UsuarioID = vm.UsuarioID,
                   FraseBoasVindas = "Seja Bem Vindo ao Painel do Aluno",
                   Curso = vm.UsuarioCurso.ToList().Select(c => c.Curso).Select(vmCurso => new ListCursoViewModel
                   {
                       CursoID = vmCurso.CursoID,
                       Nome = vmCurso.Titulo,
                       Descricao = vmCurso.Descricao,
                       DataInclusao = vmCurso.DataCadastro,
                       CargaHoraria = vmCurso.CargaHoraria,
                       FinalDeSemana = vmCurso.FinalDeSemana,

                       Agendas = vmCurso.Agendas.Select(vmAgenda => new ListAgendaViewModel
                       {
                           AgendaID = vmAgenda.AgendaID,
                           Descricao = vmAgenda.Descricao,
                           CEP = vmAgenda.Endereco.CEP,
                           Endereco = vmAgenda.Endereco.Logradouro,
                           Cargo = "Instrutor",
                           InstrutorFotoUrl = vmAgenda.Usuario.Foto,
                           Inicio = vmAgenda.Inicio,
                           Termino = vmAgenda.Termino,
                           Instrutor = vmAgenda.Usuario.Nome,
                           Aulas = vmAgenda.Aulas.Select(vmAulas => new ListAulaViewModel { AulaID = vmAulas.AulaID, Entrada = vmAulas.Entrada, Saida = vmAulas.Saida, Observacao = vmAulas.Observacao }).ToList()
                       }).ToList(),




                   }).ToList()

               }).Where(w => w.UsuarioID == 1);

            return Ok(result);
        }
    }
}