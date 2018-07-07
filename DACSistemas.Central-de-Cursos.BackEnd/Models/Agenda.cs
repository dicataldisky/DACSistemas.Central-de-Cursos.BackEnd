using System;
using System.Collections;
using System.Collections.Generic;

namespace DACSistemas.Central_de_Cursos.BackEnd.Models
{
    public class Agenda : DataLog
    {
        public Agenda()
        {
            Aulas = new List<Aula>();
        }
        // Primary Key
        public int? AgendaID { get; set; }


        // Fields
        public int CursoID { get; set; }
        public int UsuarioID { get; set; }
        public int EnderecoID { get; set; }
        public string Descricao { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Termino { get; set; }
        
        public Curso Curso { get; set; }
        public Usuario Usuario { get; set; }
        public Endereco Endereco { get; set; }
        public virtual ICollection<Aula> Aulas { get; set; }
    }
}