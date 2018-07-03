using System;
using System.Collections.Generic;

namespace DACSistemas.Central_de_Cursos.BackEnd.Models
{
    public class Curso : DataLog
    {
        public Curso()
        {
            Usuarios = new List<Usuario>();
            Agendas = new List<Agenda>();
        }

        // Primary Key
        public int? CursoID { get; set; }

        // Foreign keys

        // Fields
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Int16 CargaHoraria { get; set; }
        public bool FinalDeSemana { get; set; }
        public bool? Apagado { get; set; }

        // Virtual Properties
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Agenda> Agendas { get; set; }


    }
}