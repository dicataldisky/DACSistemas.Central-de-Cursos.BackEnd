using System.Collections.Generic;

namespace DACSistemas.Central_de_Cursos.BackEnd.ViewModels
{
    public class ListEnderecoPorUsuarioViewModel
    {
        public int? UsuarioID { get; set; }
        public ICollection<ListEnderecoViewModel> Enderecos { get; set; }
    }
}