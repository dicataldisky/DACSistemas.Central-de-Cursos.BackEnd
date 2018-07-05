using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACSistemas.Central_de_Cursos.BackEnd.ViewModels
{
    public class ListAgendaPorUsuarioViewModel
    {
        public int? UsuarioID { get; set; }
        public ICollection<ListAgendaViewModel> Agendas { get; set; }
    }
}