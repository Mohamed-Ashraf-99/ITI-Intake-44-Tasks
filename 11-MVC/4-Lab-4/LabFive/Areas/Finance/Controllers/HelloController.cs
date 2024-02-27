using Microsoft.AspNetCore.Mvc;

namespace LabFivePL.Areas.Hello.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
