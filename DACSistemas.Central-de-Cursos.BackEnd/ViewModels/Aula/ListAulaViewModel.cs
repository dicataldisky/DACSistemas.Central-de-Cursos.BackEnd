using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System;

namespace DACSistemas.Central_de_Cursos.BackEnd.ViewModels
{
    public class ListAulaViewModel
    {
        private int _Total;

        public int? AulaID { get; set; }
        //public string Aluno { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? Saida { get; set; }      
        public string Observacao { get; set; }
        public Usuario Usuario { get; set; }
       
        public int TotalDeMinutosTreinados
        {
            get {
                try
                {
                    TimeSpan diff = Saida.Value - Entrada.Value;
                    _Total = (int)diff.TotalMinutes;
                     return _Total;
                }
                catch (Exception)
                {

                    return 0;
                }
               
            }
            set { _Total = value; }
        }
    }
}