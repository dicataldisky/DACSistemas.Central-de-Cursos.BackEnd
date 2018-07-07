using System;

namespace DACSistemas.Central_de_Cursos.BackEnd.Models
{
    public class UsuarioCurso
    {
        // Foreign Key
        public int UsuarioID { get; set; }
        public int CursoID { get; set; }

        //Fields
        public DateTime DataInclusao { get; set; }

        // Virtual Properties
        public virtual Curso Curso { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}