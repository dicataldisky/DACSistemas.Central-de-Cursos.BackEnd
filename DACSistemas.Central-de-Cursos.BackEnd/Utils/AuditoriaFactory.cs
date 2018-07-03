using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System;
using System.Web;

namespace DACSistemas.Central_de_Cursos.BackEnd.Utils
{
    public class AuditoriaFactory
    {
        public static Auditoria Create(string Tela)
        {
            var UserIP = HttpContext.Current.Request.UserHostAddress;
            //var UserID = HttpContext.Current.User.Identity.GetUserId<int>();
            var UserID = 1; //Pegar do usuario logado

            return new Auditoria { IP = UserIP, UsuarioID = UserID, Tela = Tela };
        }
    }
}