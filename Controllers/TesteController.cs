using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
