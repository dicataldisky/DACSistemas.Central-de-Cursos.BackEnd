using DACSistemas.Central_de_Cursos.BackEnd.Models.Enums;
using System;
using System.Collections.Generic;

namespace DACSistemas.Central_de_Cursos.BackEnd.ViewModels
{
    public class ListUsuarioViewModel
    {
        public Int32? UsuarioID { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public DateTime? DataDeNascimento { get; set; }
        public Int64 Telefone { get; set; }
        public Int64 TelefonDeEmergencia { get; set; }
        public Int64 Celular { get; set; }

        public List<ListEnderecoViewModel> Enderecos { get; set; }
        public List<ListGrupoViewModel> Grupos { get; set; }
        public List<ListCursoViewModel> Cursos { get; set; }
        public List<ListHabilitacaoViewModel> Habilitacoes { get; set; }
    }
}