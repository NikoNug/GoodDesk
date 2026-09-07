using Microsoft.AspNetCore.Mvc;

namespace GoodDesk.API.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
