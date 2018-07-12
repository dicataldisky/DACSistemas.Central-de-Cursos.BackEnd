using DACSistemas.Central_de_Cursos.BackEnd.Context;
using DACSistemas.Central_de_Cursos.BackEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DACSistemas.Central_de_Cursos.BackEnd.Repositories
{
    public class AgendaRepository
    {
        private CentralDeCursosContext _context;

        public AgendaRepository()
        {
            _context = new CentralDeCursosContext();
        }
         //.Include(c => c.UsuarioCurso.Select(s => s.Curso))
        public IList<ListAgendaPorUsuarioViewModel> Get(int usuarioid, int cursoid)
        {
            var data = _context.Usuarios
                .Include(a => a.Agendas)
                .Include(e => e.Enderecos)

                .Select(x => new ListAgendaPorUsuarioViewModel
                {
                    UsuarioID = x.UsuarioID,
                    Agendas = x.Agendas.Where(w => w.CursoID == cursoid)
                    .Select(lavm => new ListAgendaViewModel
                    {
                        AgendaID = lavm.AgendaID,
                        //Curso = lavm.Curso.Titulo,
                        Descricao = lavm.Descricao,
                        CEP = lavm.Endereco.CEP,
                        Endereco = lavm.Endereco.Logradouro + ", " + lavm.Endereco.Numero + " - " + lavm.Endereco.Bairro + " - " + lavm.Endereco.Localidade,
                        Inicio = lavm.Inicio,
                        Termino = lavm.Termino,
                        Instrutor = lavm.Usuario.Nome,
                        //   AulaConfirmada = lavm.Confirmacoes.Count > 0
                        Aulas = lavm.Aulas.Select(vm => new ListAulaViewModel {
                            AulaID = vm.AulaID,
                           // UsuarioID = vm.UsuarioID,
                          //  Aluno = vm.Usuario.Nome,
                            Entrada = vm.Entrada,
                            Saida = vm.Saida,
                            Observacao = vm.Observacao
                        }).ToList()
                       
                   }).ToList(),
                    
                }).ToList();



            //.Select(x => new ListAgendaPorUsuarioViewModel
            //{
            //    UsuarioID = x.UsuarioID,
            //    Agendas = x.Agendas.Select(a => a.Endereco).Select(i => new ListAgendaViewModel
            //    {
            //        Endereco = x.Enderecos.FirstOrDefault(a => a.EnderecoID == i.EnderecoID),
            //    }).ToList()

            //}).ToList()
            //.Where(w => w.UsuarioID == usuarioid)
            //.ToList();
            return data;
        }
    }
}