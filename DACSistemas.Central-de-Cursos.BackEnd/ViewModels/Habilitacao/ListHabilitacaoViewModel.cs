using DACSistemas.Central_de_Cursos.BackEnd.Models.Enums;
using System;

namespace DACSistemas.Central_de_Cursos.BackEnd.ViewModels
{
    public class ListHabilitacaoViewModel
    {
        public int? HabilitacaoID { get; set; }
        public Associacao Associacao { get; set; }
        public string Nivel { get; set; }
        public DateTime DataDeFiliacao { get; set; }
    }
}