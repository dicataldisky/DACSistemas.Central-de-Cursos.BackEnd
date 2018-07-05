using DACSistemas.Central_de_Cursos.BackEnd.Context;
using DACSistemas.Central_de_Cursos.BackEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DACSistemas.Central_de_Cursos.BackEnd.Repositories
{
    public class AgendaRepository
    {
        private CentralDeCursosContext _context;

        public AgendaRepository()
        {
            _context = new CentralDeCursosContext();
        }

        public IList<ListAgendaPorUsuarioViewModel> Get(int usuarioid)
        {
            var data = _context.Usuarios
                .Include(c => c.Agendas.Select(s => s.Endereco))
                .Select(x => new ListAgendaPorUsuarioViewModel
                {
                    UsuarioID = x.UsuarioID,
                    Agendas = x.Agendas.Select(a => a.Endereco).Select(i => new ListAgendaViewModel
                    {
                        Endereco = x.Enderecos.FirstOrDefault(a => a.EnderecoID == i.EnderecoID),
                    }).ToList()
                    
                }).ToList()
                .Where(w => w.UsuarioID == usuarioid)
                .ToList();
            return data;
        }
    }
}