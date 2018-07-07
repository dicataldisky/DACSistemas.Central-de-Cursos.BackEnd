using System.Collections.Generic;

namespace DACSistemas.Central_de_Cursos.BackEnd.ViewModels
{
    public class ListCursoPorUsuarioViewModel
    {
        public int? UsuarioID { get; set; }
        public ICollection<ListCursoViewModel> Cursos { get; set; }
    }
}