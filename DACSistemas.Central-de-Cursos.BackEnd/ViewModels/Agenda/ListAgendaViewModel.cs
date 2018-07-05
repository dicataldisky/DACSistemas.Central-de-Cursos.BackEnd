using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACSistemas.Central_de_Cursos.BackEnd.ViewModels
{
    public class ListAgendaViewModel
    {
        public int? AgendaID { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public Usuario Usuario { get; set; }
        public Curso Curso { get; set; }
        public Endereco Endereco { get; set; }
    }
}