using Microsoft.AspNetCore.Mvc.Filters;

namespace ContactManager.UI1.Filters.ResultFilters
{
 public class TokenResultFilter : IResultFilter
 {
  public void OnResultExecuted(ResultExecutedContext context)
  {
  }

  public void OnResultExecuting(ResultExecutingContext context)
  {
   context.HttpContext.Response.Cookies.Append("Auth-Key", "A100");
  }
 }
}
