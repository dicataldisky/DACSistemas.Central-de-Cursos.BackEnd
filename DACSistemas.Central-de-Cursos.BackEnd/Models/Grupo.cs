using System.Collections.Generic;

namespace DACSistemas.Central_de_Cursos.BackEnd.Models
{
    public class Grupo : DataLog
    {
        public Grupo()
        {
            Usuarios = new List<Usuario>();
        }

        // Primary Key
        public int? GrupoID { get; set; }

        // Foreign keys

        // Fields
        public string Descricao { get; set; }
        public bool Instrutor { get; set; }
        public bool? Apagado { get; set; }

        // Virtual Properties
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}