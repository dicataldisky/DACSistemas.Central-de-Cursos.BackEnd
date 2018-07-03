using DACSistemas.Central_de_Cursos.BackEnd.Models;
using DACSistemas.Central_de_Cursos.BackEnd.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DACSistemas.Central_de_Cursos.BackEnd.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/email")]
    public class EmailController : ApiController
    {
        private readonly UsuarioRepository _repository;

        protected EmailController()
        {
            _repository = new UsuarioRepository();
        }

        [HttpPost]
        [Route("exist")]
        public IHttpActionResult Post([FromBody] Usuario usuario)
        {
            var usu = _repository.GetPorEmail(usuario.Email);
            if (usu != null)
                return StatusCode(System.Net.HttpStatusCode.Conflict);
            else
                return Ok();
        }

        [HttpGet]
        [Route("confirmation/send/token={token}")]
        public IHttpActionResult EnviaEmailDeConfirmacao(string token)
        {
            var usuario = _repository.GetPorToken(token);

            Configuracoes conf = new Configuracoes()
            {
                Remetente = "cadastro@dacsistemas.com.br",
                Senha = "Dacsistemas@@2018",
                Servidor = "smtp.dacsistemas.com.br",
                Porta = 587,
                SSL = false,
                TimeOut = 60000
            };

            Email email = new Email();

            email.configuracoes = conf;
            email.Assunto = "Email de Confirmação";
            email.CorpoDaMensagem = String.Format(@"Olá, <b>{0}</b>!<Br><Br> Bem-vindo a Central de Cursos. <Br><Br>Você precisa confirmar seu endereço de e-mail para concluir o seu cadastro.<Br><Br><font color=red> Para concluir o seu cadatro, acesse o link abaixo:</font><br><a href='http://localhost:9000/#!/confirmation/received?token={1}'>http://localhost:9000/#!/confirmation/received?token={1}</a><br><br> Atenciosamente,<br>Central de Cursos<Br><Br><Br><b>Não responda este email, pois não estamos monitorando esta caixa de entrada. Qualquer duvida entre em contato diretamente com seu instrutor.</b>", usuario.Nome, token);

            email.Destinatarios = new List<string>();
            email.Destinatarios.Add(usuario.Email);
            email.NomeDeApresentacao = "Central de Cursos";
            email.PrioridadeDaMensagem = System.Net.Mail.MailPriority.Normal;

            Enviador env = new Enviador();

            try
            {
                env.EnviarEmail(email);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(System.Net.HttpStatusCode.ExpectationFailed);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("confirmation/received/token={token}")]
        public IHttpActionResult ConfirmarUsuario(string token)
        {
             var usuario = _repository.GetPorToken(token);
            if (usuario == null) { return StatusCode(System.Net.HttpStatusCode.NotFound); }
            if(usuario.Ativo == true) { return StatusCode(System.Net.HttpStatusCode.Conflict); }

            try
            {
                usuario.Ativo = true;
                _repository.Update(usuario);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(System.Net.HttpStatusCode.InternalServerError);

            }
        }
    }
}