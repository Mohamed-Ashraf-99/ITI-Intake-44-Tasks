using Microsoft.AspNetCore.Mvc;

namespace LabFivePL.Areas.Welcom.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
