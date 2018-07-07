using DACSistemas.Central_de_Cursos.BackEnd.Context;
using DACSistemas.Central_de_Cursos.BackEnd.Models;
using DACSistemas.Central_de_Cursos.BackEnd.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DACSistemas.Central_de_Cursos.BackEnd.Repositories
{
    public class CursoRepository
    {
        private CentralDeCursosContext _context;

        public CursoRepository()
        {
            _context = new CentralDeCursosContext();
        }

        public IList<ListCursoPorUsuarioViewModel> Get(int usuarioid)
        {
            var data = _context.Usuarios
                .Include(c => c.UsuarioCurso.Select(s => s.Curso))
                .Select(x => new ListCursoPorUsuarioViewModel
                {
                    UsuarioID = x.UsuarioID,
                     Cursos = x.UsuarioCurso.Select(a => a.Curso).Select(i => new ListCursoViewModel
                    {
                         DataInclusao = x.UsuarioCurso.FirstOrDefault(a => a.CursoID == i.CursoID && a.UsuarioID == usuarioid).DataInclusao,
                         CursoID = i.CursoID,
                         Nome = i.Nome,
                         Descricao = i.Descricao,
                         CargaHoraria = i.CargaHoraria,
                         FinalDeSemana = i.FinalDeSemana,
                        }).ToList()
                }).ToList()
                .Where(w => w.UsuarioID == usuarioid)
                .ToList();
            return data;
        }

        public Curso GetCurso(int cursoID)
        {
            return _context.Cursos.Find(cursoID);
        }
    }
}