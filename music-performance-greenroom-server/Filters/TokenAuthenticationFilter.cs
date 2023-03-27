using GreenroomServer.TokenAuthentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GreenroomServer.Filters
{
    public class TokenAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenManager = (ITokenManager)context.HttpContext.RequestServices.GetService(typeof(ITokenManager));

            var result = true;
            
            
            if(!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                result = false;

                var token = string.Empty;

                if (result)
                {
                    token = context.HttpContext.Request.Headers.First(x => x.Key == "Authorization").Value;
                    if (tokenManager.VerifyToken(token))
                        result = false;                   
                }
                if (!result)
                {
                    context.ModelState.AddModelError("Unauthorized", "Access Denied");
                    context.Result = new UnauthorizedObjectResult(context.ModelState);
                }
            }

        }
    }
}
