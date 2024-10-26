using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Mime;

namespace ContactManager.UI1.Filters.AuthorizationFilter
{
 public class TokenAuthorizationFilter : IAuthorizationFilter
 {
  public void OnAuthorization(AuthorizationFilterContext context)
  {
   if (context.HttpContext.Request.Cookies.ContainsKey("Auth-Key") == false)
   {
    context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
    return;
   }

   if (context.HttpContext.Request.Cookies["Auth-Key"] != "A100")
   {
    context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
   }
  }
 }
}
