using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System;
using System.Collections.Generic;

namespace DACSistemas.Central_de_Cursos.BackEnd.ViewModels
{
    public class ListAgendaViewModel
    {
        public int? AgendaID { get; set; }
        public string Curso { get; set; }
        public string Descricao { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Termino { get; set; }
        public string Instrutor { get; set; }
        public bool AulaConfirmada { get; set; }
    }
}