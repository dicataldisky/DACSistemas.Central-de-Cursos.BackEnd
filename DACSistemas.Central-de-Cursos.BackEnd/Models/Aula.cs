using System;

namespace DACSistemas.Central_de_Cursos.BackEnd.Models
{
    public class Aula
    {
        public Aula()
        {
        }

        //Primary Key
        public int AulaID { get; set; }

        //Fields
        public int UsuarioID { get; set; }
        public int AgendaID { get; set; }
        public int CursoID { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? Saida { get; set; }
        public string Observacao { get; set; }

        //Virtual Properties
        public virtual Usuario Usuario { get; set; }
        public virtual Agenda Agenda { get; set; }
        public virtual Curso Curso { get; set; }
    }
}