using System.Collections.Generic;

namespace DACSistemas.Central_de_Cursos.BackEnd.Models
{
    public class Endereco : DataLog
    {
        public Endereco()
        {
            Usuarios = new List<Usuario>();
        }

        // Primary Key
        public int? EnderecoID { get; set; }

        // Foreign keys

        // Fields
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string CodIBGE { get; set; }
        public string CodGIA { get; set; }
        public bool? Apagado { get; set; }

        // Virtual Properties
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Agenda> Agendas { get; set; }
    }
}