using DACSistemas.Central_de_Cursos.BackEnd.Context;
using DACSistemas.Central_de_Cursos.BackEnd.Models;
using DACSistemas.Central_de_Cursos.BackEnd.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DACSistemas.Central_de_Cursos.BackEnd.Repositories
{
    public class GrupoRepository
    {
        private CentralDeCursosContext _context;

        public GrupoRepository()
        {
            _context = new CentralDeCursosContext();
        }

        public IList<ListGrupoPorUsuarioViewModel> Get(int usuarioid)
        {
            var data = _context.Usuarios
                .Include(g => g.Grupos)
                .Select(x => new ListGrupoPorUsuarioViewModel
                {
                    UsuarioID = x.UsuarioID,
                    Nome = x.Nome,
                    FotoUrl = x.Foto,
                    Grupos = x.Grupos.Select(i => new ListGrupoViewModel
                    {
                        GrupoID = i.GrupoID,
                        Descricao = i.Descricao,
                        Instrutor = i.Instrutor
                    }).ToList()
                }).ToList()
                .Where(w => w.UsuarioID == usuarioid)
                .ToList();
              return data;
        }

        public Grupo GetGrupo(int grupoid)
        {
            return _context.Grupos.Find(grupoid);
        }
    }
}