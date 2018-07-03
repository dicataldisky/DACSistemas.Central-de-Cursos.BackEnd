using DACSistemas.Central_de_Cursos.BackEnd.Repositories;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace DACSistemas.Central_de_Cursos.BackEnd.Models.OAuth
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public Usuario Usuario { get; private set; }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                var user = context.UserName;
                var password = context.Password;

                UsuarioRepository repository = new UsuarioRepository();
                Usuario = repository.GetPorEmailESenha(user, password);


                if (Usuario == null) { context.SetError("invalid_grant", "Usuário ou senha inválidos"); return; }
               if (Usuario.Ativo == false) { context.SetError("not_activated", Usuario.Token); return; }


                var identify = new ClaimsIdentity(context.Options.AuthenticationType);
                identify.AddClaim(new Claim(ClaimTypes.Name, Convert.ToString(Usuario.UsuarioID.Value)));

                var roles = new List<string>();
                //roles.Add("Admin");
                roles.Add("Aluno");

                foreach (var role in roles)
                {
                    identify.AddClaim(new Claim(ClaimTypes.Role, role));
                }

                GenericPrincipal principal = new GenericPrincipal(identify, roles.ToArray());
                Thread.CurrentPrincipal = principal;

                context.Validated(identify);
            }
            
            catch (Exception ex)
            {
                context.SetError("invalid_grant", "Falha ao autenticar");
            }
        }
        
    }
}