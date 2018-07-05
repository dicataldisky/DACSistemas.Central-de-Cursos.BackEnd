using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACSistemas.Central_de_Cursos.BackEnd.Models
{
    public class UsuarioCurso
    {
        public int UsuarioID { get; set; }
        public int CursoID { get; set; }
        public DateTime DataInclusao { get; set; }
        public Curso Curso { get; set; }
        public Usuario Usuario { get; set; }
    }
}