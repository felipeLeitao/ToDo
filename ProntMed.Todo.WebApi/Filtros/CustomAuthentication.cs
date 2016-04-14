using ProntMed.Todo.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ProntMed.Todo.WebApi.Filtros
{
    public class CustomAuthentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            else
            {
                var token = actionContext.Request.Headers.Authorization.Parameter;
                var tokenDecodificado = Encoding.UTF8.GetString(Convert.FromBase64String(token));

                var login = tokenDecodificado.Substring(0, tokenDecodificado.IndexOf(":", StringComparison.Ordinal));
                var senha = tokenDecodificado.Substring(tokenDecodificado.IndexOf(":", StringComparison.Ordinal) + 1);


                if (ValidarUsuario(login, senha) != null)
                {
                    base.OnActionExecuting(actionContext);
                }
                else
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
            }
        }

        private Usuario ValidarUsuario(string login, string senha)
        {
            var permissoes = new string[] { "Administrador" };

            if (login == "felipe" && senha == "123")
            return new Usuario() { Email = "cleytonferrari@gmail.com", Permissoes = permissoes };

            return null;
        }

    }
}