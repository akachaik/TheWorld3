using Microsoft.AspNet.Mvc;
using System;

namespace TheWorld3.Controllers
{
    public class  AuthController : Controller
    {
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Trips", "App");
            }

            return View();
        }
    }
}
