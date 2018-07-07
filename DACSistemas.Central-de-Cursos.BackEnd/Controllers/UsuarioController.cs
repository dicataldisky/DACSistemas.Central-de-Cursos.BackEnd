using DACSistemas.Central_de_Cursos.BackEnd.Context;
using DACSistemas.Central_de_Cursos.BackEnd.Models;
using DACSistemas.Central_de_Cursos.BackEnd.Repositories;
using DACSistemas.Central_de_Cursos.BackEnd.Utils;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DACSistemas.Central_de_Cursos.BackEnd.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private readonly CentralDeCursosContext _context;
        private readonly UsuarioRepository _repository;

        protected UsuarioController()
        {
            _context = new CentralDeCursosContext();
            _repository = new UsuarioRepository();
        }

        [Route("")]
        [HttpGet]
        [Authorize]
        // GET api/usuario
        public IHttpActionResult Get()
        {
            var dados = _repository.Get(Convert.ToInt32(User.Identity.Name));
            return Ok(dados);
        }

        [Route("")]
        [HttpPost]
        // POST api/usuario/
        public IHttpActionResult Post(Usuario vm)
        {
            vm.Token = GenerateToken.GetNewToken();
            vm.Foto = "profileblank.jpg";
           

            // Regra 1 - Verificar se o objeto enviado é valido
            if (!ModelState.IsValid)
                return StatusCode(System.Net.HttpStatusCode.NotAcceptable); //retorna 406

            // Regra 2 - Aplicar trim nos campos de string
            vm.Nome = vm.Nome.LimpaString();
            vm.Email = vm.Email.LimpaString();
            vm.Senha = vm.Senha.LimpaString();
            vm.Foto = vm.Foto.LimpaString();
            vm.CPF = vm.CPF.LimpaString();
            vm.RG = vm.RG.LimpaString();

            // Regra 3 - verificar se ja nao existe um usuario com o mesmo email cadastrado
            if (_context.Usuarios.Any(p => p.Email == vm.Email))
                return StatusCode(System.Net.HttpStatusCode.Conflict); //retorna 409

            try
            {
                // Regra 4 - Cria novo Usuario somente as propriedades permitidas
                var novoUsuario = new Usuario
                {
                    Token = GenerateToken.GetNewToken(),
                    Nome = vm.Nome,
                    Email = vm.Email,
                    Senha = vm.Senha,
                    Foto = vm.Foto,
                    CPF = vm.CPF,
                    RG = vm.RG,
                    Telefone = vm.Telefone,
                    TelefoneEmergencia = vm.TelefoneEmergencia,
                    Celular = vm.Celular,
                    EstadoCivil = vm.EstadoCivil,
                    Sexo = vm.Sexo,
                    DataNascimento = vm.DataNascimento
                };

                if (vm.Enderecos.Any())
                {
                    foreach (var item in vm.Enderecos)
                    {
                        novoUsuario.Enderecos.Add(new Endereco
                        {
                            CEP = item.CEP,
                            Logradouro = item.Logradouro,
                            Numero = item.Numero,
                            Complemento = item.Complemento,
                            Bairro = item.Bairro,
                            Localidade = item.Localidade,
                            UF = item.UF,
                            CodIBGE = item.CodIBGE,
                            CodGIA = item.CodGIA,
                            Apagado = false
                        });
                    }
                }

                // Regra 5 - Adiciona Usuario na Base de dados
                _repository.Insert(novoUsuario);

                var urlRegistro = string.Format("/api/usuarios/{0}", novoUsuario.UsuarioID);
                return Created(urlRegistro, novoUsuario);
            }
            catch (System.Exception e)
            {
                return StatusCode(System.Net.HttpStatusCode.ExpectationFailed);
            }
        }

        [Route("")]
        [HttpPut]
        // PUT api/usuario
        public IHttpActionResult Put(Usuario vm)
        {
            // Regra 1 - Verificar se o objeto enviado é valido
            if (!ModelState.IsValid)
                return StatusCode(System.Net.HttpStatusCode.NotAcceptable); //retorna 406

            // Regra 2 - Aplicar trim nos campos de string
            vm.Nome = vm.Nome.LimpaString();
            vm.Email = vm.Email.LimpaString();
            vm.Senha = vm.Senha.LimpaString();
            vm.Foto = vm.Foto.LimpaString();
            vm.CPF = vm.CPF.LimpaString();
            vm.RG = vm.RG.LimpaString();

            try
            {
                // Regra 3 - Existe o usuario no banco de dados?
                var registro = _context.Usuarios.Find(User.Identity.Name); //PEGAR O ID DO USUARIO LOGADO 

                if (registro == null)
                    return NotFound();

                // Regra 4 - Já existe um usuário com o mesmo email
                if (registro.Email != vm.Email && _context.Usuarios.Any(p => p.Email == vm.Email))
                    return StatusCode(System.Net.HttpStatusCode.Conflict);

                // Regra 5 - Alterar somente as propriedades permitidasr
                registro.Nome = vm.Nome;
                registro.Email = vm.Email;
                registro.Senha = vm.Senha;
                registro.Foto = vm.Foto;
                registro.CPF = vm.CPF;
                registro.RG = vm.RG;
                registro.Telefone = vm.Telefone;
                registro.TelefoneEmergencia = vm.TelefoneEmergencia;
                registro.Celular = vm.Celular;
                registro.EstadoCivil = vm.EstadoCivil;
                registro.Sexo = vm.Sexo;
                registro.DataNascimento = vm.DataNascimento;

                _repository.Update(registro);

                return Ok(registro);
            }
            catch (System.Exception)
            {
                return StatusCode(System.Net.HttpStatusCode.ExpectationFailed);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        // DELETE api/usuario/{id}
        public IHttpActionResult Delete(int id)
        {
            try
            {
                // Regra 1 - Existe o usuario no banco de dados?
                var registro = _context.Usuarios.Find(id);

                if (registro == null)
                    return NotFound();

                // Regra 2 - Alterar somente as propriedades permitidasr
                _repository.Delete(registro);

                return Ok(registro);
            }
            catch (System.Exception)
            {
                return StatusCode(System.Net.HttpStatusCode.ExpectationFailed);
            }
        }

        [Route("teste")]
        [HttpGet]
        public IHttpActionResult Teste()
        {
            //var dados = _context.Agendas
            //    .Include(x => x.Endereco)
            //    .Include(b => b.Curso)
            //    .Include(c => c.Usuario)
            //    .ToList();
            return Ok();
        }
    }
}