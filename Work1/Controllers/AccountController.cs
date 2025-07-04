using Microsoft.AspNetCore.Mvc;

namespace Work1.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

    }
}
