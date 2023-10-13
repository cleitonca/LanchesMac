using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    [Authorize]
    //[Authorize(Roles ="Admin")]
    //[AllowAnonymous]
    public class ContatoController : Controller
    {
        //[Authorize]
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login","Account");

            
        }
    }
}
