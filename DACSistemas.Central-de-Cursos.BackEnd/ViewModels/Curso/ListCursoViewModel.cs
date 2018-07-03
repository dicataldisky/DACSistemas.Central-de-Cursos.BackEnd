using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System;

namespace DACSistemas.Central_de_Cursos.BackEnd.ViewModels
{
    public class ListCursoViewModel
    {
        public int? CursoID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Int16 CargaHoraria  { get; set; }
        public bool FinalDeSemana { get; set; }

    }
}