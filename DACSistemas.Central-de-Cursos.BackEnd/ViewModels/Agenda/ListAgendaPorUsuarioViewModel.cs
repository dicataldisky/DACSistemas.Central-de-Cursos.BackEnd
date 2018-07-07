using System.Collections.Generic;

namespace DACSistemas.Central_de_Cursos.BackEnd.ViewModels
{
    public class ListAgendaPorUsuarioViewModel
    {
        public int? UsuarioID { get; set; }
        public ICollection<ListAgendaViewModel> Agendas { get; set; }
    }
}