using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACSistemas.Central_de_Cursos.BackEnd.ViewModels
{
    public class ListDashBoardViewModel
    {
        public string FraseBoasVindas { get; set; }
        public string Curso { get; set; }
        public string DescricaoDoCurso { get; set; }
        public int HorasRestantes { get; set; }
        public int TotalDeAulasRealizadas { get; set; }
        public double PercentualDeAproveitamento { get; set; }
        public decimal RestanteAReceber { get; set; }

        //public List<Aula> AulasDisponiveis { get; set; }
    }
}