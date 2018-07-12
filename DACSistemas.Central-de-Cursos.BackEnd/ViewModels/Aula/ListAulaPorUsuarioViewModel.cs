using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACSistemas.Central_de_Cursos.BackEnd.ViewModels
{
    public class ListAulaPorUsuarioViewModel
    {
        public int? UsuarioID { get; set; }
        public ICollection<ListAulaViewModel> Aulas { get; set; }
    }
}