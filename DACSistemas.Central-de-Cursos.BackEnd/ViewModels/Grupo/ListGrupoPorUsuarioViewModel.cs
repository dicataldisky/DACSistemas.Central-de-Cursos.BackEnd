using System.Collections.Generic;

namespace DACSistemas.Central_de_Cursos.BackEnd.ViewModels
{
    public class ListGrupoPorUsuarioViewModel
    {
        public int? UsuarioID { get; set; }
        public string Nome { get; set; }
        public string FotoUrl { get; set; }
        public ICollection<ListGrupoViewModel> Grupos { get; set; }
    }
}