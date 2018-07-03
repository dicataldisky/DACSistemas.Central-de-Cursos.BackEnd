using DACSistemas.Central_de_Cursos.BackEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DACSistemas.Central_de_Cursos.BackEnd.Models
{
    public class Agenda
    {
        // Primary Key
        public int AgendaID { get; set; }


        public int CursoID { get; set; }
        public virtual Curso Curso { get; set; }

        public int InstrutorID { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int EnderecoID { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }

        // Fields
        public DateTime? Inicio { get; set; }
        public DateTime? Termino { get; set; }



    
    }
}