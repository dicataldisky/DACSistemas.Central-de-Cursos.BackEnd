using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DACSistemas.Central_de_Cursos.BackEnd.ViewModels
{
    public class ListCursoViewModel
    {
        public int? CursoID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Int16 CargaHoraria  { get; set; }
        public bool FinalDeSemana { get; set; }
        public DateTime? DataInclusao { get; set; }
        public ICollection<ListAgendaViewModel> Agendas { get; set; }
    }
}