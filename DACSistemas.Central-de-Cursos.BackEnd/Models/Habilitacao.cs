using DACSistemas.Central_de_Cursos.BackEnd.Models.Enums;
using System;
using System.Collections.Generic;

namespace DACSistemas.Central_de_Cursos.BackEnd.Models
{
    public class Habilitacao
    {
        public Habilitacao()
        {
            Usuarios = new List<Usuario>();
        }

        // Primary Key
        public int? HabilitacaoID { get; set; }

        // Foreign keys

        // Fields
        public Associacao Associacao { get; set; }
        public string Nivel { get; set; }
        public DateTime DataDeFiliacao { get; set; }
        public bool? Apagado { get; set; }

        // Virtual Properties
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}