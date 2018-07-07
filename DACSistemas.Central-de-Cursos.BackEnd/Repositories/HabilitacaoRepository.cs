using DACSistemas.Central_de_Cursos.BackEnd.Context;
using DACSistemas.Central_de_Cursos.BackEnd.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DACSistemas.Central_de_Cursos.BackEnd.Repositories
{
    public class HabilitacaoRepository
    {
        private CentralDeCursosContext _context;

        public HabilitacaoRepository()
        {
            _context = new CentralDeCursosContext();
        }

        public IList<ListHabilitacaoPorUsuarioViewModel> Get(int usuarioid)
        {
            var data = _context.Usuarios
                .Include(h => h.Habilitacoes)
                .Select(x => new ListHabilitacaoPorUsuarioViewModel
                {
                    UsuarioID = x.UsuarioID,
                    Habilitacoes = x.Habilitacoes.Select(i => new ListHabilitacaoViewModel
                    {
                        HabilitacaoID = i.HabilitacaoID,
                        Associacao = i.Associacao,
                        Nivel = i.Nivel,
                        DataDeFiliacao = i.DataDeFiliacao
                    }).ToList()
                }).ToList()
                .Where(w => w.UsuarioID == usuarioid)
                .ToList();
            return data;
        }
    }
}