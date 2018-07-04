using DACSistemas.Central_de_Cursos.BackEnd.Models.Enums;
using System;
using System.Collections.Generic;

namespace DACSistemas.Central_de_Cursos.BackEnd.Models
{
    public class Usuario : DataLog
    {
        public Usuario()
        {
            Enderecos = new List<Endereco>();
            Grupos = new List<Grupo>();
            Habilitacoes = new List<Habilitacao>();
            Agendas = new List<Agenda>();
        }

        // Primary key
        public int? UsuarioID { get; set; }

        // Foreing keys

        // Fields
        public string Token { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Foto { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public Int64 Telefone { get; set; }
        public Int64 TelefoneEmergencia { get; set; }
        public Int64 Celular { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public bool Apagado { get; set; }

        // Virtual Properties
        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Grupo> Grupos { get; set; }
        
        public virtual ICollection<Habilitacao> Habilitacoes { get; set; }
        public virtual ICollection<Agenda> Agendas { get; set; }
        public virtual ICollection<UsuarioCurso> UsuarioCurso { get; set; }
    }
}