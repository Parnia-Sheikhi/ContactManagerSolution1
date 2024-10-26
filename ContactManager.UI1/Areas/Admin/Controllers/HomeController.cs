using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.UI1.Areas.Admin.Controllers
{
 [Area("Admin")]
 [Authorize(Roles = "Admin")]
 public class HomeController : Controller
 {
  public IActionResult Index()
  {
   return View();
  }
 }
}
