using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACSistemas.Central_de_Cursos.BackEnd.ViewModels
{
    public class ListDashBoardViewModel
    {
        public int? UsuarioID { get; set; }
        public string FraseBoasVindas { get; set; }
        public ICollection<ListCursoViewModel> Curso { get; set; }

    }
}