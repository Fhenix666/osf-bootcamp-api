using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BootCamp.Adm.Security
{
    /// <summary>
    /// AutorizationFilter
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute" />
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter" />
    public class AuthorizationFilter : ActionFilterAttribute, IAsyncActionFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationFilter"/> class.
        /// </summary>
        public AuthorizationFilter()
        {

        }
        /// <summary>
        /// Decodes the specified token.
        /// </summary>
        /// <param name="Token">The token.</param>
        /// <returns></returns>
        public static JwtSecurityToken Decode(string Token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.ReadJwtToken(Token);
        }
        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <inheritdoc />
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionDescriptor.EndpointMetadata.Where(f => f.GetType() == typeof(AllowAnonymousAttribute)).FirstOrDefault() != null)
            {
                await next();
                return;
            }

            string token = TokenHelper.GetToken(context.HttpContext.Request);         

            string systemName = TokenHelper.GetValueClaim(token, ClaimTypes.System);
            if (string.IsNullOrEmpty(systemName))
            {
                string response = JsonConvert.SerializeObject(new
                {
                    code = "Unauthorized",
                    message = "Token invalido.",
                });
                await context.HttpContext.Response.WriteAsync(response.ToLower());
            }
            else
            {
                DateTimeOffset tokenTo = System.DateTimeOffset.FromUnixTimeSeconds((long.Parse(TokenHelper.GetValueClaim(token, "exp"))));
                DateTimeOffset toDay = new DateTimeOffset(DateTime.Today);

                if (toDay.CompareTo(tokenTo) < 0)
                    await next();
                else
                {
                    context.HttpContext.Response.StatusCode = 401;
                    context.HttpContext.Response.ContentType = $"{System.Net.Mime.MediaTypeNames.Application.Json};charset=UTF-8";//"application/json;charset=UTF-8";

                    string response = JsonConvert.SerializeObject(new
                    {
                        code = "Unauthorized",
                        message = "Las sesión caducó, es necesario que ingreses de nuevo a la aplicación.",
                    });
                    await context.HttpContext.Response.WriteAsync(response.ToLower());
                }
            }

            return;
        }
    }
}
