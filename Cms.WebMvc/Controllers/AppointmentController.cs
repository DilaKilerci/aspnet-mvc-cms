using Microsoft.AspNetCore.Mvc;

namespace Cms.WebMvc.Controllers
{
  public class AppointmentController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
