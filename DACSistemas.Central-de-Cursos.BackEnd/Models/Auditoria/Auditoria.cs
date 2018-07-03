using System;
using System.Collections.Generic;

namespace DACSistemas.Central_de_Cursos.BackEnd.Models
{
    public class Auditoria
    {
        public Auditoria()
        {
            DataCadastro = DateTime.Now;
            Alteracoes = new List<AuditoriaAlteracao>();
        }

        //ID
        public int AuditoriaID { get; set; }

        //Foreign keys
        public int UsuarioID { get; set; }

        //Fields
        public string Tela { get; set; }
        public string IP { get; set; }
        public DateTime DataCadastro { get; set; }

        //Virtual Properties
        public virtual ICollection<AuditoriaAlteracao> Alteracoes { get; set; }
    }
}