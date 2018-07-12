using System.Collections.Generic;
using System.Net.Mail;

namespace DACSistemas.Central_de_Cursos.BackEnd.Models
{
    public class Email
    {
        public List<string> Destinatarios { get; set; }
        public string NomeDeApresentacao { get; set; }
        public string Assunto { get; set; }
        public string CorpoDaMensagem { get; set; }
        public MailPriority PrioridadeDaMensagem { get; set; }
        public Configuracoes configuracoes { get; set; }
    }

    public class Configuracoes
    {
        //Propriedades:
        public string Servidor { get; set; }
        public int Porta { get; set; }
        public string Remetente { get; set; }
        public string Senha { get; set; }
        public bool SSL { get; set; }
        public int TimeOut { get; set; }
    }
}