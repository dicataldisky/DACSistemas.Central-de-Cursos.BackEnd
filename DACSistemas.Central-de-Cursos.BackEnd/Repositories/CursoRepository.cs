using DACSistemas.Central_de_Cursos.BackEnd.Context;
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
                .Include(c => c.Cursos)
                .Select(x => new ListCursoPorUsuarioViewModel
                {
                    UsuarioID = x.UsuarioID,
                     Cursos = x.Cursos.Select(i => new ListCursoViewModel
                    {
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
    }
}