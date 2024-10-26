using Microsoft.AspNetCore.Mvc.Filters;

namespace ContactManager.UI1.Filters.ResultFilters
{
 public class PersonAlwaysRunResultFilter : IAlwaysRunResultFilter
 {
  public void OnResultExecuted(ResultExecutedContext context)
  {
   //before logic here
  }

  public void OnResultExecuting(ResultExecutingContext context)
  {
   if (context.Filters.OfType<SkipFilter>().Any())
   {
    return;
   }
  }
 }
}
