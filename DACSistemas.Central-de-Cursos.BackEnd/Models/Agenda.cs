using DACSistemas.Central_de_Cursos.BackEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DACSistemas.Central_de_Cursos.BackEnd.Models
{
    public class Agenda : DataLog
    {
        // Primary Key
        public int AgendaID { get; set; }



        // Fields
        public int CursoID { get; set; }
        public int UsuarioID { get; set; }
        public int EnderecoID { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Termino { get; set; }
        
        public Curso Curso { get; set; }
        public Usuario Usuario { get; set; }
        public Endereco Endereco { get; set; }





    
    }
}