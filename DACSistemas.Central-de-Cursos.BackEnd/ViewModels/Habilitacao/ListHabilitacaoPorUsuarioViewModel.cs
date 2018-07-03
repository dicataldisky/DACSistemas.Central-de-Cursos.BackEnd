using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACSistemas.Central_de_Cursos.BackEnd.ViewModels
{
    public class ListHabilitacaoPorUsuarioViewModel
    {
        public int? UsuarioID { get; set; }
        public ICollection<ListHabilitacaoViewModel> Habilitacoes { get; set; }
    }
}