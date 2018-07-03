using DACSistemas.Central_de_Cursos.BackEnd.Context;
using DACSistemas.Central_de_Cursos.BackEnd.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DACSistemas.Central_de_Cursos.BackEnd.Repositories
{
    public class EnderecoRepository
    {
        private CentralDeCursosContext _context;

        public EnderecoRepository()
        {
            _context = new CentralDeCursosContext();
        }

        public IList<ListEnderecoPorUsuarioViewModel> Get(int usuarioid)
        {
            var data = _context.Usuarios
                .Include(c => c.Enderecos)
                .Select(x => new ListEnderecoPorUsuarioViewModel
                {
                    UsuarioID = x.UsuarioID,
                    Enderecos = x.Enderecos.Select(i => new ListEnderecoViewModel
                    {
                        EnderecoID = i.EnderecoID,
                        CEP = i.CEP,
                        Logradouro = i.Logradouro,
                        Numero = i.Numero,
                        Complemento = i.Complemento,
                        Bairro = i.Bairro,
                        Cidade = i.Localidade,
                        UF = i.UF 
                    }).ToList()
                }).ToList()
                .Where(w => w.UsuarioID == usuarioid)
                .ToList();
            return data;
        }
    }
}