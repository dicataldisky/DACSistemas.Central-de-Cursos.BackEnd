using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DACSistemas.Central_de_Cursos.BackEnd.Models
{
    public class Enviador : Email
    {
        public bool EnviarEmail(Email email)
        {
            MailMessage mailMessage = new MailMessage();

            //Adiciona Header para tentativa de Anti-SPAM
            mailMessage.Headers.Add("Message-Id",
                                String.Format("<{0}@{1}>",
                                Guid.NewGuid().ToString(),
                                email.configuracoes.Remetente.Split(new[] { '@' })[1]));

            // Adiciona REMETENTE
            mailMessage.From = new MailAddress(email.configuracoes.Remetente, email.NomeDeApresentacao, Encoding.UTF8);

            // Adiciona Lista de DESTINATÁRIOS
            foreach (var item in email.Destinatarios.ToList())
            {
                mailMessage.To.Add(new MailAddress(item));
            }

            // Adiciona Assunto
            mailMessage.Subject = email.Assunto;

            // Define Corpo da Mensagem
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = email.CorpoDaMensagem;

            //Define Prioridade da Mensagem
            mailMessage.Priority = email.PrioridadeDaMensagem;

            SmtpClient mSmtpClient = new SmtpClient(email.configuracoes.Servidor, email.configuracoes.Porta);
            mSmtpClient.Timeout = email.configuracoes.TimeOut;
            mSmtpClient.UseDefaultCredentials = false;
            mSmtpClient.EnableSsl = email.configuracoes.SSL;
            mSmtpClient.Port = email.configuracoes.Porta;
            mSmtpClient.Credentials = new NetworkCredential(email.configuracoes.Remetente, email.configuracoes.Senha);

            //Dispara Email
            try
            {
                mSmtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                throw new SmtpException(String.Format("O Envio do email falhou -> Error: {0}", ex.ToString()));
            }
        }
    }
}