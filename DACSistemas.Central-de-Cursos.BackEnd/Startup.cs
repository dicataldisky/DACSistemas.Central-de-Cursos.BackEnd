using DACSistemas.Central_de_Cursos.BackEnd.Models.OAuth;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Net.Http.Formatting;
using System.Web.Cors;
using System.Web.Http;

namespace DACSistemas.Central_de_Cursos.BackEnd
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();


            // Web API configuration and services
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            config.Formatters.JsonFormatter
            .SerializerSettings
            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;


            config.MapHttpAttributeRoutes();

            //Ativando Cors
            ConfigureCors(app);

            //Ativando tokens de acesso
            AtivandoAccessTokens(app);

            //Ativando configuração WebAPI
            app.UseWebApi(config);

        }

        private void AtivandoAccessTokens(IAppBuilder app)
        {
            //Configurando fornecimento de tokens
            var opcoesConfiguracaoToken = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/security/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                Provider = new AuthorizationServerProvider(),
            };


            // Ativando o uso de tokens
            app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private void ConfigureCors(IAppBuilder app)
        {
            var politica = new CorsPolicy();

            politica.AllowAnyHeader = true;

            politica.Origins.Add("http://localhost:15699");
            politica.Origins.Add("http://localhost:15699");

            politica.Methods.Add("GET");
            politica.Methods.Add("POST");

            //var corsOptions = new CorsOptions
            //{
            //    PolicyProvider = new CorsPolicyProvider
            //    {
            //        PolicyResolver = context => Task.FromResult(politica)
            //    }
            //};

            app.UseCors(CorsOptions.AllowAll);
        }
    }
}