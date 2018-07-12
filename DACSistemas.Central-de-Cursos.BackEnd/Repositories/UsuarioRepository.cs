using DACSistemas.Central_de_Cursos.BackEnd.Context;
using DACSistemas.Central_de_Cursos.BackEnd.Models;
using DACSistemas.Central_de_Cursos.BackEnd.Utils;
using DACSistemas.Central_de_Cursos.BackEnd.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DACSistemas.Central_de_Cursos.BackEnd.Repositories
{
    public class UsuarioRepository
    {
        private CentralDeCursosContext _context;

        public UsuarioRepository()
        {
            _context = new CentralDeCursosContext();
        }

        public IList<ListUsuarioViewModel> Get(int usuarioid)
        {
            var data = _context.Usuarios
                .Include(e => e.Enderecos)
                .Include(e => e.UsuarioCurso.Select(s => s.Curso))
                .Select(x => new ListUsuarioViewModel
                {
                    UsuarioID = x.UsuarioID,
                    NomeCompleto = x.Nome,
                    Email = x.Email,
                    Foto = x.Foto,
                    Sexo = x.Sexo,
                    EstadoCivil = x.EstadoCivil,
                    DataDeNascimento = x.DataNascimento,
                    Telefone = x.Telefone,
                    TelefonDeEmergencia = x.TelefoneEmergencia,
                    Celular = x.Celular,
                    Enderecos = x.Enderecos.Select(e => new ListEnderecoViewModel
                    {
                        EnderecoID = e.EnderecoID,
                        CEP = e.CEP,
                        Logradouro = e.Logradouro,
                        Numero = e.Numero,
                        Complemento = e.Complemento,
                        Bairro = e.Bairro,
                        Cidade = e.Localidade,
                        UF = e.UF
                    }).ToList(),
                    Grupos = x.Grupos.Select(g => new ListGrupoViewModel {
                        GrupoID = g.GrupoID,
                        Descricao = g.Descricao,
                        Instrutor = g.Instrutor
                    }).ToList(),
                    Cursos = x.UsuarioCurso.Select(a => a.Curso).Select(c => new ListCursoViewModel
                    { 
                        DataInclusao = x.UsuarioCurso.FirstOrDefault(a => a.CursoID == c.CursoID && a.UsuarioID == usuarioid).DataInclusao,
                        CursoID = c.CursoID,
                        Nome = c.Titulo,
                        Descricao = c.Descricao,
                        CargaHoraria = c.CargaHoraria,
                        FinalDeSemana = c.FinalDeSemana
                    }).ToList(),
                    Habilitacoes = x.Habilitacoes.Select(h => new ListHabilitacaoViewModel
                    {
                        HabilitacaoID = h.HabilitacaoID,
                        Associacao = h.Associacao,
                        Nivel = h.Nivel,
                        DataDeFiliacao = h.DataDeFiliacao
                    }).ToList()
                })
                .Where(u => u.UsuarioID == usuarioid)
                .AsNoTracking()
                .ToList();
            
            return data;
        }

        public Usuario GetPorEmailESenha(string email, string senha)
        {
            senha = MD5PasswordEncryptor.MD5Hash(senha);
            var result = _context.Usuarios
                .Include(e => e.Enderecos)
                .Include(uc => uc.UsuarioCurso.Select(c => c.Curso))
                .FirstOrDefault(u => u.Email == email && u.Senha == senha);
            return result;
        }

        public Usuario GetPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public Usuario GetPorToken(string token)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Token == token);
        }

        public Usuario Get(int? id)
        {
            return _context.Usuarios
                .AsNoTracking()
                .FirstOrDefault(u => u.UsuarioID == id);
        }

        public Usuario Insert(Usuario usuario)
        {
            usuario.Token = GenerateToken.GetNewToken();
            usuario.Foto = "profileblank.jpg";
            usuario.Senha = MD5PasswordEncryptor.MD5Hash(usuario.Senha);

            //UsuarioCurso uc = new UsuarioCurso();
            //uc.CursoID = 1;
            //uc.DataInclusao = DateTime.Now;
            //usuario.UsuarioCurso.Add(uc);

            Grupo g = _context.Grupos.Find(3);
            usuario.Grupos.Add(g);
            

            _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            //_repository.SaveChanges(AuditoriaFactory.Create("Usuario.Cadastro"));

            return usuario;
        }

        public Usuario Update(Usuario usuario)
        { 
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();

            return usuario;
        }

        public Usuario Delete (Usuario usuario)
        {
            usuario.Apagado = true;
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();

            return usuario;

        }
    }
}